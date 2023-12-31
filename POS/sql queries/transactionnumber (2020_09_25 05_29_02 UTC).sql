USE [NC.db] /* database mo */
GO
/****** Object:  StoredProcedure [dbo].[USP_EC_AutoNo]    Script Date: 08/04/2019 16:59:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[USP_EC_AutoNo] /*name ng transaction number na stored procdedure */

AS

BEGIN



DECLARE @CURRENT_CODE VARCHAR(20)

DECLARE @CURRENT_DATE VARCHAR(8)

DECLARE @CURRENT_NO VARCHAR(5)

DECLARE @NEXT_CODE VARCHAR(20)

DECLARE @NEXT_NO CHAR(5)



SELECT TOP 1 @CURRENT_CODE = TransactionNo

FROM [EventTransaction] /*name ng table ng transaction */

ORDER BY TransactionNo DESC /*column name ng TRansaction number */


PRINT @CURRENT_CODE

SET @CURRENT_DATE = SUBSTRING(@CURRENT_CODE,3,8)

SET @CURRENT_NO = SUBSTRING(@CURRENT_CODE, 11,5)

PRINT @CURRENT_DATE
PRINT @CURRENT_NO

  IF @CURRENT_DATE = CONVERT(VARCHAR(10),GETDATE(),112)

   BEGIN

    DECLARE @CURRENT_NO_INT INT

	SET @CURRENT_NO_INT = CONVERT(INT,@CURRENT_NO) + 1

	SET @NEXT_NO = RIGHT('00000' + CONVERT(VARCHAR(10),@CURRENT_NO_INT),5)

	SET @NEXT_CODE = 'ET' + @CURRENT_DATE + @NEXT_NO /*prefix name ng transaction sakin kasi event transaction */

   END

  ELSE

   BEGIN
 
    SET @NEXT_CODE = 'ET' + CONVERT(VARCHAR(10),GETDATE(),112) + '00001' /*prefix name ng transaction sakin kasi event transaction */


		
   END

 SELECT @NEXT_CODE as CODE

END
