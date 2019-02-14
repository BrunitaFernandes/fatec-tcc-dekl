USE [DEKLCP]
GO
/****** Object:  UserDefinedFunction [dbo].[FN_PAYMENT_TYPE_ACCOUNT_TO_PAY]    Script Date: 14/02/2019 16:57:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[FN_PAYMENT_TYPE_ACCOUNT_TO_PAY](@PaymentType INT)
RETURNS VARCHAR(30)
AS
BEGIN
	RETURN CASE @PaymentType 
		   WHEN 1 THEN 'Dinheiro'
	       WHEN 2 THEN 'Transferência Bancária'
		   WHEN 3 THEN 'Depósito Bancário'
	END
END