USE [POS] /* name ng database niyo */
GO
/****** Object:  StoredProcedure [dbo].[SP_AutoNo_EPM]    Script Date: 08/04/2019 16:44:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




Create PROCEDURE [dbo].[SP_AutoNo]/* name ng autonumber ichange niyo na lang */
	@pfx		char(3)		=	'',
	@NewNumber	char(13)	=	'',
	@UserName	varchar(50)	=	'',
	@DT_Stamp	smalldatetime = '' 
AS
Declare @maxCode			As char(12)
Declare @CreateNumber		As int
Declare @RecNo				As int
BEGIN
	select	@MaxCode =	case when max(NewNumber) is null then '000000000000'
							 else max(NewNumber) end 
						from Autonumber  
	where left(NewNumber,3) =@pfx 
	set @CreateNumber = right(@maxCode,9)+1
	Select @Pfx+Replicate('0',12-Len(@CreateNumber)-3)+Cast(@CreateNumber as Char)
	insert into	Autonumber (PFX, NewNumber , UserName) Values
				(@Pfx,
				@Pfx+Replicate('0',12-Len(@CreateNumber)-3)+Cast(@CreateNumber as Char),
				@UserName)
	Select @RecNo = @@Identity 
	Select NewNumber from Autonumber  where RecNo = @RecNo 
END
