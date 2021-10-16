
IF (DB_ID(N'BookStore') IS NULL)
	CREATE DATABASE BookStore
GO

USE BookStore
GO

IF OBJECT_ID ('Roles') IS NULL
	CREATE TABLE Roles
	(
	Id INT NOT NULL CONSTRAINT PK_Role PRIMARY KEY,
	RoleName NVARCHAR(255) NOT NULL,	
	)
GO

IF OBJECT_ID ('Users') IS NULL
	CREATE TABLE Users
	(
	Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_UserId DEFAULT NEWID(),
	UserName NVARCHAR(256) NOT NULL CONSTRAINT UK_UserName UNIQUE,
	[Password] NVARCHAR(256) NOT NULL,
	LastLogin DATETIME NULL,
	IsActiv BIT NOT NULL CONSTRAINT DF_IsActiv DEFAULT 1,
	RoleId INT NOT NULL,
	SurName NVARCHAR(256) NOT NULL,
	[Name] NVARCHAR(256) NOT NULL,
	Email NVARCHAR(500) NOT NULL,
	PhoneNumber NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_User PRIMARY KEY (Id)
	)
GO

IF OBJECT_ID ('BookTypes') IS NULL
	CREATE TABLE BookTypes
	(
	Id INT NOT NULL IDENTITY (1, 1) CONSTRAINT PK_BookType PRIMARY KEY,
	[Name] NVARCHAR(255) NOT NULL
	)
GO

IF OBJECT_ID ('SpecialTags') IS NULL
	CREATE TABLE SpecialTags
	(
	Id INT NOT NULL IDENTITY (1, 1) CONSTRAINT PK_SpecialTag PRIMARY KEY,
	[Name] NVARCHAR(255) NOT NULL
	)
GO

IF OBJECT_ID ('Book') IS NULL
	CREATE TABLE Books
	(
	Id INT NOT NULL IDENTITY(1, 1) CONSTRAINT PK_Book PRIMARY KEY,
	[Name] NVARCHAR(256) NOT NULL,
	[Description] NVARCHAR(2000) NOT NULL, 
	[Author] NVARCHAR(256) NOT NULL,
	[Publisher] NVARCHAR(256) NOT NULL,
	PagesNo NUMERIC(20, 2) NOT NULL,
	Price NUMERIC(20, 2) NOT NULL,
	IsAvailable BIT NOT NULL,
	ImagePath NVARCHAR(1000) NULL,
	BookTypeId INT NOT NULL
	)
GO

IF OBJECT_ID ('BooksSpecialTags') IS NULL
	CREATE TABLE BooksSpecialTags
	(
	SpecialTagId INT NOT NULL,
	BookId INT NOT NULL,
	CONSTRAINT PK_BookSpecialTag PRIMARY KEY (SpecialTagId, BookId)
	)
GO

IF OBJECT_ID ('Feedback') IS NULL 
	CREATE TABLE Feedback
	(
	Id INT NOT NULL IDENTITY(1, 1) CONSTRAINT PK_Feedback PRIMARY KEY,
	CommentTitle NVARCHAR(256) NOT NULL,
	Comment NVARCHAR(2000) NOT NULL,
	Rating INT NOT NULL,
	BookId INT NOT NULL,
	UserId UNIQUEIDENTIFIER NULL
	)
GO

IF OBJECT_ID('Orders') IS NULL
	CREATE TABLE Orders
	(
	Id INT NOT NULL IDENTITY(1, 1) CONSTRAINT PK_Orders PRIMARY KEY,
	CustomerName NVARCHAR(256) NOT NULL,
	CustomerPhoneNumber NVARCHAR(256) NOT NULL,
	CustomerEmail NVARCHAR(256) NOT NULL,
	CustomerAddress NVARCHAR(500) NOT NULL,
	OrderDate DATETIME NOT NULL
	)
GO

IF OBJECT_ID('OrdersBooks') IS NULL
	CREATE TABLE OrdersBooks
	(
	BookId INT NOT NULL,
	OrderId INT NOT NULL,
	CONSTRAINT PK_OrdersBooks PRIMARY KEY (BookId, OrderId)
	)
GO

IF OBJECT_ID('USP_CreateFK') IS NOT NULL
	DROP PROCEDURE USP_CreateFK
GO

CREATE PROCEDURE USP_CreateFK
@FKName NVARCHAR(512),
@ChildTableName NVARCHAR(256),
@ChildColumnName NVARCHAR(256),
@ParentTableName NVARCHAR(256),
@ParentColumnName NVARCHAR(256),
@CascadeDelete BIT = 0
AS
BEGIN
	DECLARE @sql NVARCHAR(4000)
	SET @sql =  'IF (OBJECT_ID(''' + @FKName +''', ''F'') IS NULL)' +
				'ALTER TABLE ' + @ChildTableName + ' ' +
				'ADD CONSTRAINT ' + @FKName + ' ' +
				'FOREIGN KEY (' + @ChildColumnName + ')' +
				'REFERENCES ' + @ParentTableName + '(' + @ParentColumnName + ')'
	IF (@CascadeDelete = 1)
		SET @sql = @sql + 'ON DELETE CASCADE '
    EXEC sp_executesql @sql
END
GO

EXEC USP_CreateFK 'FK_Users_Roles', 'Users', 'RoleId', 'Roles', 'Id'
GO

EXEC USP_CreateFK 'FK_Books_BookTypes', 'Books', 'BookTypeId', 'BookTypes', 'Id'
GO

EXEC USP_CreateFK 'FK_BooksSpecialTags_SpecialTags', 'BooksSpecialTags', 'SpecialTagId', 'SpecialTags', 'Id'
GO

EXEC USP_CreateFK 'FK_BooksSpecialTags_Books', 'BooksSpecialTags', 'BookId', 'Books', 'Id', 1
GO

EXEC USP_CreateFK 'FK_Feedback_Books', 'Feedback', 'BookId', 'Books', 'Id'
GO

EXEC USP_CreateFK 'FK_Feedback_Users', 'Feedback', 'UserId', 'Users', 'Id'
GO

EXEC USP_CreateFK 'FK_OrdersBooks_Orders', 'OrdersBooks', 'OrderId', 'Orders', 'Id', 1
GO

EXEC USP_CreateFK 'FK_OrdersBooks_Books', 'OrdersBooks', 'BookId', 'Books', 'Id'
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = 1)
INSERT INTO Roles (Id, RoleName)
SELECT 1, 'SuperAdmin'
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = 2)
INSERT INTO Roles (Id, RoleName)
SELECT 2, 'Admin'
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = 3)
INSERT INTO Roles (Id, RoleName)
SELECT 3, 'Director'
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = 4)
INSERT INTO Roles (Id, RoleName)
SELECT 4, 'SalesManager'
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = 5)
INSERT INTO Roles (Id, RoleName)
SELECT 5, 'SalesAgent'
GO

DECLARE @UserId UNIQUEIDENTIFIER = '414D6C6F-4E20-46F7-848F-D3FCF0AF2A05'
IF NOT EXISTS (SELECT 1 FROM Users WHERE Id = @UserId)
INSERT INTO Users(Id, UserName, [Password], RoleId, SurName, [Name], Email, PhoneNumber)
SELECT @UserId, 'Admin', 'YWRtaW4=', 1, 'Admin', 'Admin', 'admin@app.com', '0723045984'
GO

