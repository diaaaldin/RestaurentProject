USE [RestaurantDb]
GO

/****** Object:  Table [dbo].[CustomerMenus]    Script Date: 9/23/2022 3:55:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomerMenus](
	[CustomerId] [int] NOT NULL,
	[RestaurentMenuId] [int] NOT NULL,
 CONSTRAINT [PK_CustomerMenus] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[RestaurentMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CustomerMenus]  WITH CHECK ADD  CONSTRAINT [FK_CustomerMenus_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CustomerMenus] CHECK CONSTRAINT [FK_CustomerMenus_Customers_CustomerId]
GO

ALTER TABLE [dbo].[CustomerMenus]  WITH CHECK ADD  CONSTRAINT [FK_CustomerMenus_RestaurentMenus_RestaurentMenuId] FOREIGN KEY([RestaurentMenuId])
REFERENCES [dbo].[RestaurentMenus] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CustomerMenus] CHECK CONSTRAINT [FK_CustomerMenus_RestaurentMenus_RestaurentMenuId]
GO

