create procedure sp_CustomerUpdate
@CustomerID int,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@CustomerLoyaltyPoints int = null
as
begin
set nocount on

if not exists(select 1 from Customers where CustomerID = @CustomerID)
begin
	raiserror('Customer ID %d does not exist.',16,1,@CustomerID)
	return 1
end

if @CustomerLoyaltyPoints < 0
begin
	raiserror('Customer loyalty points cannot be less than 0.',16,1)
	return 1
end

update Customers
set FirstName = @FirstName,
	LastName = @LastName,
	CustomerLoyaltyPoints = @CustomerLoyaltyPoints,
	UpdatedDate = getdate()		
where CustomerID = @CustomerID and(
	FirstName != @FirstName or
	LastName != @LastName or
	isnull(CustomerLoyaltyPoints, -1) != isnull(@CustomerLoyaltyPoints, -1)
)

return 0
end