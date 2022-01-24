CREATE DATABASE FurnitureShop
GO

USE FurnitureShop
GO

CREATE TABLE [User] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [RoleId] int,
  [Username] nvarchar(255),
  [Password] varchar(64),
  [CreateAt] timestamp,
  [Image] nvarchar(255)
)
GO

CREATE TABLE [Role] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255),
  [Description] nvarchar(255)
)
GO

CREATE TABLE [Brand] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255),
  [Description] nvarchar(255)
)
GO

CREATE TABLE [Category] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ParentId] int,
  [Name] nvarchar(255),
  [Description] nvarchar(255)
)
GO

CREATE TABLE [Product] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ProductBasetId] nvarchar(255),
  [CategoryId] int,
  [BrandId] int,
  [MaterialId] int,
  [Name] nvarchar(255),
  [Size] nvarchar(255),
  [Description] nvarchar(255),
  [Quantity] int,
  [Price] money,
  [Image] nvarchar(255)
)
GO

CREATE TABLE [Import] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Description] nvarchar(255),
  [CreateAt] timestamp,
  [TotalCost] money
)
GO

CREATE TABLE [ImportDetail] (
  [ImportId] int,
  [ProductId] int,
  [Quantity] int,
  [Cost] int,
  PRIMARY KEY ([ImportId], [ProductId])
)
GO

CREATE TABLE [Invoice] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserId] int,
  [CreateAt] timestamp,
  [VoucherId] int,
  [PaymentStatus] nvarchar(255),
  [DeliveryStatus] nvarchar(255)
)
GO

CREATE TABLE [Voucher] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Description] nvarchar(255),
  [StartAt] datetime,
  [EndAt] datetime,
  [Value] money,
  [MinPurchase] money
)
GO

CREATE TABLE [InvoiceDetail] (
  [InvoiceId] int,
  [ProductId] int,
  [Quantity] int,
  [UnitPrice] int,
  PRIMARY KEY ([InvoiceId], [ProductId])
)
GO

CREATE TABLE [Rating] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserId] int,
  [Score] int,
  [Description] nvarchar(255),
  [ProductId] int
)
GO

CREATE TABLE [Material] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255),
  [Description] nvarchar(255)
)
GO

CREATE TABLE [ProductImage] (
  [Url] nvarchar(255),
  [ProductId] int,
  [ProductBasetId] nvarchar(255),
  [Priority] int
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

