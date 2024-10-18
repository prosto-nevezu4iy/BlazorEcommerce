USE [EShop]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
	CREATE TABLE [dbo].[Product](
		[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
		[Description] NVARCHAR(max) NULL,
		[Genre] NVARCHAR(max) NOT NULL,
		[Price] DECIMAL(10, 2) NOT NULL,
		[Unit] NVARCHAR(max) NULL
	);