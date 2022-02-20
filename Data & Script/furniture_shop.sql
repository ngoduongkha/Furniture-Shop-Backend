CREATE DATABASE FurnitureShop
GO

USE FurnitureShop
GO

CREATE TABLE [User] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [RoleId] INT,
  [Username] NVARCHAR(255),
  [Password] VARCHAR(64),
  [CreateAt] TIMESTAMP,
  [Image] NVARCHAR(255)
)
GO

CREATE TABLE [Role] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(255),
  [Description] NVARCHAR(255)
)
GO

CREATE TABLE [Brand] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(255) NOT NULL,
  [Description] NVARCHAR(255),
  [IsDeleted] BIT DEFAULT(0) NOT NULL
)
GO

CREATE TABLE [Category] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [ParentId] INT DEFAULT 0,
  [Name] NVARCHAR(255) NOT NULL,
  [Description] NVARCHAR(255),
  [IsDeleted] BIT DEFAULT(0) NOT NULL
)
GO

CREATE TABLE [Product] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [ProductBaseId] NVARCHAR(255),
  [CategoryId] INT,
  [BrandId] INT,
  [MaterialId] INT,
  [Name] NVARCHAR(255),
  [Size] NVARCHAR(255),
  [Description] NVARCHAR(255),
  [Quantity] INT,
  [Price] MONEY,
  [Image] NVARCHAR(255)
)
GO

CREATE TABLE [Import] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Description] NVARCHAR(255),
  [CreateAt] TIMESTAMP,
  [TotalCost] MONEY
)
GO

CREATE TABLE [ImportDetail] (
  [ImportId] INT,
  [ProductId] INT,
  [Quantity] INT,
  [Cost] INT,
  PRIMARY KEY ([ImportId], [ProductId])
)
GO

CREATE TABLE [Invoice] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [UserId] INT,
  [CreateAt] TIMESTAMP,
  [VoucherId] INT,
  [PaymentStatus] NVARCHAR(255),
  [DeliveryStatus] NVARCHAR(255)
)
GO

CREATE TABLE [Voucher] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Description] NVARCHAR(255),
  [StartAt] DATETIME,
  [EndAt] DATETIME,
  [Value] MONEY,
  [MinPurchase] MONEY
)
GO

CREATE TABLE [InvoiceDetail] (
  [InvoiceId] INT,
  [ProductId] INT,
  [Quantity] INT,
  [UnitPrice] INT,
  PRIMARY KEY ([InvoiceId], [ProductId])
)
GO

CREATE TABLE [Rating] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [UserId] INT,
  [Score] INT,
  [Description] NVARCHAR(255),
  [ProductId] INT
)
GO

CREATE TABLE [Material] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(255) NOT NULL,
  [Description] NVARCHAR(255),
  [IsDeleted] BIT DEFAULT(0) NOT NULL,
)
GO

CREATE TABLE [ProductImage] (
  [Url] NVARCHAR(255),
  [ProductId] INT,
  [ProductBaseId] NVARCHAR(255),
  [Priority] INT
)
GO

ALTER TABLE [Rating] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [Rating] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
GO

ALTER TABLE [Category] ADD FOREIGN KEY ([ParentId]) REFERENCES [Category] ([Id])
GO

ALTER TABLE [User] ADD FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id])
GO

ALTER TABLE [ImportDetail] ADD FOREIGN KEY ([ImportId]) REFERENCES [Import] ([Id])
GO

ALTER TABLE [ImportDetail] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
GO

ALTER TABLE [InvoiceDetail] ADD FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice] ([Id])
GO

ALTER TABLE [Product] ADD FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id])
GO

ALTER TABLE [Product] ADD FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([Id])
GO

ALTER TABLE [InvoiceDetail] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
GO

ALTER TABLE [Invoice] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [Product] ADD FOREIGN KEY ([MaterialId]) REFERENCES [Material] ([Id])
GO

ALTER TABLE [ProductImage] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
GO
