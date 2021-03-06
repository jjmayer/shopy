/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Id] 
      ,[Username]
      ,[PasswordHash] COLLATE SQL_Latin1_General_CP1_CI_AS
      ,[ShopingListId]
      ,[CreatedAt]
      ,[UpdatedAt]
  FROM [Shopy].[dbo].[User]

update [Shopy].[dbo].[User]
set PasswordHash = 'd033e22ae348aeb5660fc2140aec35850c4da997'

alter table [User]
	add constraint uq_user_username UNIQUE (username)

GO
CREATE TRIGGER trg_ShoppingItemUserCheck
ON [Shopy].[dbo].[ShopingItem]
FOR INSERT,UPDATE
AS
DECLARE
	@userId nvarchar(max)
BEGIN
	SET NOCOUNT ON;

	SELECT @userId = UserId
	FROM inserted;

	SELECT 1
	FROM ShopingList sl
	JOIN Shopingitem item ON sl.Id = item.ShopingListId
	JOIN [User] u ON sl.Id = u.ShopingListId
	WHERE u.Id = @userId;
	
	IF @@ROWCOUNT = 0
		ROLLBACK;
	ELSE
		COMMIT;
END;
GO