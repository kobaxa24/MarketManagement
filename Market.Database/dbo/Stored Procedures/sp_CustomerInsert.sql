create procedure sp_CustomerInsert
	@CustomerID int output,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@CustomerLoyaltyPoints int = null
as
begin
	set nocount on

	if @CustomerLoyaltyPoints < 0
	begin
		raiserror('Customer loyalty points cannot be less than 0.', 16, 1);
		return 1;
	end

	insert into Customers(FirstName, LastName, CustomerLoyaltyPoints)
	values(@FirstName, @LastName, @CustomerLoyaltyPoints);

	set @CustomerID = scope_identity();

	return 0;
end