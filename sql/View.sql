USE [RestaurantDb]
GO

/****** Object:  View [dbo].[Export Data]    Script Date: 9/23/2022 3:57:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Export Data] AS
select R.Name AS [Restaurent Name] , CM.CustomerId ,RM.PriceInUSD ,RM.PriceInNIS,RM.MealName ,C.Name AS FirstName , C.LastName from Restaurants R 
JOIN RestaurentMenus RM ON R.Id = RM.RestaurantId
JOIN CustomerMenus CM ON RM.Id = CM.RestaurentMenuId
JOIN Customers C ON CM.CustomerId = C.Id
GO

