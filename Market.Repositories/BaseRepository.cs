using Dapper;
using Market.Extensions.Attributes;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;
using Market.Services.Interfaces.Repositories;

namespace Market.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly DbConnection _connection;
    private readonly string _entityName;

    protected BaseRepository(DbConnection connection)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _entityName = typeof(T).Name;
    }

    public virtual T GetById(object id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        DynamicParameters parameters = new DynamicParameters();
        parameters.Add($"{_entityName}ID", id);

        return _connection.QuerySingle<T>(
            $"sp_{_entityName}GetById",
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<T> GetAll()
    {
        return _connection.Query<T>(
            $"sp_{_entityName}GetAll",
            commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
    {
        return _connection.Query<T>(
            $"sp_{_entityName}GetAll",
            commandType: CommandType.StoredProcedure);
    }

    public virtual object Insert(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        var parameters = new DynamicParameters();
        SetInsertParameters(entity, parameters);
        _connection.Execute($"sp_{_entityName}Insert",
            parameters,
            commandType: CommandType.StoredProcedure);

        return parameters.Get<object>($"{_entityName}ID");
    }

    public void Update(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        var parameters = new DynamicParameters();
        SetUpdateParameters(entity, parameters);
        _connection.Execute(
            $"sp_{_entityName}Update",
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public void Delete(object id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var parameters = new DynamicParameters();
        parameters.Add($"{_entityName}ID", id);

        _connection.Execute(
            $"sp_{_entityName}Delete",
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    private void SetInsertParameters(T value, DynamicParameters parameters)
    {
        parameters.Add($"{_entityName}ID", DbType.Int32, direction: ParameterDirection.Output);

        var insertableProperties = PropertyCache.Get(typeof(T)).Insertable;

        foreach (var property in insertableProperties)
        {
            parameters.Add(property.Name, property.GetValue(value));
        }
    }

    private void SetUpdateParameters(T value, DynamicParameters parameters)
    {
        var updatableProperties = PropertyCache.Get(typeof(T)).Updatable;

        foreach (var property in updatableProperties)
        {
            parameters.Add(property.Name, property.GetValue(value));
        }
    }

    private static class PropertyCache
    {
        private static readonly ConcurrentDictionary<Type, (IReadOnlyList<PropertyInfo> Insertable, IReadOnlyList<PropertyInfo> Updatable)> _cache = new();

        public static (IReadOnlyList<PropertyInfo> Insertable, IReadOnlyList<PropertyInfo> Updatable) Get(Type type)
        {
            return _cache.GetOrAdd(type, t =>
            {
                var properties = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                var insertable = properties
                    .Where(p => !p.IsDefined(typeof(IgnoreForInsertAttribute)))
                    .ToList();

                var updatable = properties
                    .Where(p => !p.IsDefined(typeof(IgnoreForUpdateAttribute)))
                    .ToList();

                return (insertable, updatable);
            });
        }
    }
}