CREATE DATABASE FurnitureShop
GO

USE FurnitureShop
GO

CREATE TABLE [user] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [full_name] nvarchar(255),
  [email] nvarchar(255),
  [password] nvarchar(255),
  [created_at] timestamp,
  [image] nvarchar(255)
)
GO

CREATE TABLE [role] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [discription] nvarchar(255)
)
GO

CREATE TABLE [brand] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(255),
  [description] nvarchar(255)
)
GO

CREATE TABLE [category] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [displayname] nvarchar(255),
  [discription] nvarchar(255)
)
GO

CREATE TABLE [topic] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [category_id] int,
  [displayname] nvarchar(255),
  [discription] nvarchar(255)
)
GO

CREATE TABLE [product] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [category_id] int,
  [brand_id] int,
  [material] nvarchar(255),
  [size] nvarchar(255),
  [discription] nvarchar(255),
  [quantity] int,
  [cost] int,
  [image] nvarchar(255)
)
GO

CREATE TABLE [import] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [description] nvarchar(255),
  [created_at] timestamp,
  [cost] money
)
GO

CREATE TABLE [import_detail] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [import_id] int,
  [product_id] int,
  [quantity] int,
  [cost] int
)
GO

CREATE TABLE [invoice] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [user_id] int,
  [create_at] timestamp,
  [discount_id] int,
  [payment_status] nvarchar(255),
  [delivery_status] nvarchar(255)
)
GO

CREATE TABLE [discount] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [percentage] int,
  [description] nvarchar(255),
  [startAt] datetime,
  [endAt] datetime,
  [maxValue] money,
  [minPurchase] money,
  [isMoney] bit
)
GO

CREATE TABLE [invoice_detail] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [invoice_id] int,
  [product_id] int,
  [quantity] int,
  [unit_price] int
)
GO

CREATE TABLE [rating] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [user_id] int,
  [score] int,
  [description] nvarchar(255),
  [product_id] int
)
GO

ALTER TABLE [rating] ADD FOREIGN KEY ([user_id]) REFERENCES [user] ([id])
GO

ALTER TABLE [rating] ADD FOREIGN KEY ([product_id]) REFERENCES [product] ([id])
GO

ALTER TABLE [product] ADD FOREIGN KEY ([brand_id]) REFERENCES [brand] ([id])
GO

ALTER TABLE [product] ADD FOREIGN KEY ([category_id]) REFERENCES [category] ([id])
GO

ALTER TABLE [invoice] ADD FOREIGN KEY ([user_id]) REFERENCES [user] ([id])
GO

ALTER TABLE [invoice] ADD FOREIGN KEY ([discount_id]) REFERENCES [discount] ([id])
GO

ALTER TABLE [topic] ADD FOREIGN KEY ([category_id]) REFERENCES [category] ([id])
GO

ALTER TABLE [import_detail] ADD FOREIGN KEY ([import_id]) REFERENCES [import] ([id])
GO

ALTER TABLE [import_detail] ADD FOREIGN KEY ([product_id]) REFERENCES [product] ([id])
GO

ALTER TABLE [invoice_detail] ADD FOREIGN KEY ([invoice_id]) REFERENCES [invoice] ([id])
GO

ALTER TABLE [invoice_detail] ADD FOREIGN KEY ([product_id]) REFERENCES [product] ([id])
GO
