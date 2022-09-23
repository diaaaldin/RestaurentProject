USE [RestaurantDb]
GO

/****** Object:  Table [dbo].[RestaurentMenus]    Script Date: 9/23/2022 3:57:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RestaurentMenus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MealName] [nvarchar](max) NULL,
	[PriceInNIS] [real] NOT NULL,
	[PriceInUSD] [real] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[Archived] [bit] NOT NULL,
	[RestaurantId] [int] NOT NULL,
 CONSTRAINT [PK_RestaurentMenus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[RestaurentMenus] ADD  DEFAULT ((0)) FOR [RestaurantId]
GO

ALTER TABLE [dbo].[RestaurentMenus]  WITH CHECK ADD  CONSTRAINT [FK_RestaurentMenus_Restaurants_RestaurantId] FOREIGN KEY([RestaurantId])
REFERENCES [dbo].[Restaurants] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[RestaurentMenus] CHECK CONSTRAINT [FK_RestaurentMenus_Restaurants_RestaurantId]
GO

