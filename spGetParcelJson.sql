USE [Kane_IL_Test_Import]
GO
/****** Object:  StoredProcedure [dbo].[spGetParcelJson]    Script Date: 1/06/2023 11:23:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Author:		<saulrodriguez>
-- Create date: <05/30/2023>
-- Description:	<Get Parcel info with JSON details>
-- ================================================
CREATE OR ALTER PROCEDURE [dbo].[spGetParcelJson]
	-- Add the parameters for the stored procedure here
	@parcelNumber varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *, 
		(SELECT * 
		 FROM [dbo].[parcel] 
		 WHERE parcel_number = @parcelNumber 
		 FOR JSON AUTO, INCLUDE_NULL_VALUES
		 ) AS [details]
	FROM [dbo].[parcel] 
	WHERE parcel_number = @parcelNumber

END
