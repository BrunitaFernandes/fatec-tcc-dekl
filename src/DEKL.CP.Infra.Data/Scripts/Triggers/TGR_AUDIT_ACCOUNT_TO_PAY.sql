USE [DEKLCP]
GO
/****** Object:  Trigger [dbo].[TGR_AUDIT_ACCOUNT_TO_PAY]    Script Date: 15/02/2019 10:09:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER TRIGGER [dbo].[TGR_AUDIT_ACCOUNT_TO_PAY]
ON [dbo].[AccountToPay]
FOR UPDATE
AS
BEGIN
	DECLARE @ApplicationUserId INT;
	DECLARE @ModuleId INT;
    DECLARE @Event VARCHAR(MAX);
	
	SET @Event = '';

	IF UPDATE(Value)
	BEGIN
		SELECT @Event = @Event + 'Valor de: ' + FORMAT(D.Value, 'C2', 'pt-br') + 
		                            ' Para: ' + FORMAT(I.Value, 'C2', 'pt-br') + '\n' 
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE 
			D.Value != I.Value
	END

	IF UPDATE(PaidValue)
	BEGIN
		SELECT @Event = @Event + 'Valor Pago de: ' + FORMAT(ISNULL(D.PaidValue, 0), 'C2', 'pt-br') + 
		                                 ' Para: ' + FORMAT(ISNULL(I.PaidValue, 0), 'C2', 'pt-br') + '\n' 
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE 
			ISNULL(D.PaidValue, 0) != ISNULL(I.PaidValue, 0)
	END

	IF UPDATE(PaymentDate)
	BEGIN
		SELECT @Event = @Event + 'Data de pagamento de: ' + IIF(D.PaymentDate IS NULL, '', FORMAT(D.PaymentDate, 'dd/MM/yyyy HH:mm:ss', 'pt-br')) + 
		                                        ' Para: ' + IIF(I.PaymentType IS NULL, '', FORMAT(I.PaymentDate, 'dd/MM/yyyy HH:mm:ss', 'pt-br')) + '\n'
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE 
			ISNULL(D.PaymentDate, GETDATE()) != ISNULL(I.PaymentDate, GETDATE())
	END

	IF UPDATE(Description)
	BEGIN
		SELECT @Event = @Event + 'Descrição de: ' + ISNULL(D.Description, '') + 
		                                ' Para: ' + ISNULL(I.Description, '') + '\n'
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE 
			ISNULL(D.Description, '') != ISNULL(I.Description, '')
	END

	IF UPDATE(MaturityDate)
	BEGIN
		SELECT @Event = @Event + 'Data de vencimento de: ' + FORMAT(D.MaturityDate, 'dd/MM/yyyy HH:mm:ss', 'pt-br') + 
		                                         ' Para: ' + FORMAT(I.MaturityDate, 'dd/MM/yyyy HH:mm:ss', 'pt-br') + '\n'
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE 
			D.MaturityDate != I.MaturityDate
	END

	IF UPDATE(DailyInterest)
	BEGIN
		SELECT @Event = @Event + 'Mora diária de: ' + FORMAT(D.DailyInterest, 'P2') + 
		                                  ' Para: ' + FORMAT(I.DailyInterest, 'P2') + '\n'
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE 
			D.DailyInterest != I.DailyInterest
	END

	IF UPDATE(Penalty)
	BEGIN
		SELECT @Event = @Event + 'Multa de: ' + FORMAT(D.Penalty, 'P2') + 
		                            ' Para: ' + FORMAT(I.Penalty, 'P2') + '\n'
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE
			D.Penalty != I.Penalty
	END

	IF UPDATE(MonthlyAccount)
	BEGIN
		SELECT @Event = @Event + 'Conta mensal de: ' + IIF(D.MonthlyAccount = 1, 'Sim', 'Não') +
		                                   ' Para: ' + IIF(I.MonthlyAccount = 1, 'Sim', 'Não') + '\n'
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE 
			D.MonthlyAccount != I.MonthlyAccount
	END

	IF UPDATE(Priority)
	BEGIN
		SELECT @Event = @Event + 'Prioridade de: ' + dbo.FN_PRIORITY_ACCOUNT_TO_PAY(D.Priority) +
		                                 ' Para: ' + dbo.FN_PRIORITY_ACCOUNT_TO_PAY(I.Priority) + '\n'
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE 
			D.Priority != I.Priority
	END

	IF UPDATE(PaymentType)
	BEGIN
		SELECT @Event = @Event + 'Prioridade de: ' + dbo.FN_PAYMENT_TYPE_ACCOUNT_TO_PAY(D.PaymentType) +
		                                 ' Para: ' + dbo.FN_PAYMENT_TYPE_ACCOUNT_TO_PAY(I.PaymentType) + '\n'
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE 
			D.PaymentType != I.PaymentType
	END

	IF UPDATE(DocumentNumber)
	BEGIN
		SELECT @Event = @Event + 'Número do Documento de: ' + D.DocumentNumber + 
		                                          ' Para: ' + I.DocumentNumber + '\n'
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE 
			D.DocumentNumber != I.DocumentNumber
	END

	IF UPDATE(NumberOfInstallments)
	BEGIN
		SELECT @Event = @Event + 'Número de parcelas de: ' + FORMAT(D.NumberOfInstallments, 'D') + 
		                                         ' Para: ' + FORMAT(I.NumberOfInstallments, 'D') + '\n'
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE 
			D.NumberOfInstallments != I.NumberOfInstallments
	END

	IF UPDATE(ProviderId)
	BEGIN
		SELECT @Event = @Event + 'Fornecedor de: ' + (
														SELECT ISNULL(PPP.Name, PLP.CorporateName) FROM Provider P
														LEFT JOIN ProviderPhysicalPerson PPP ON P.Id = PPP.Id
														LEFT JOIN ProviderLegalPerson PLP ON P.Id = PLP.Id
														WHERE 
															P.Id = D.ProviderId
													  ) +
		                                  ' Para: ' + (
														SELECT ISNULL(PPP.Name, PLP.CorporateName) FROM Provider P
														LEFT JOIN ProviderPhysicalPerson PPP ON P.Id = PPP.Id
														LEFT JOIN ProviderLegalPerson PLP ON P.Id = PLP.Id
														WHERE 
															P.Id = I.ProviderId
													  )
		FROM DELETED D
		JOIN INSERTED I ON D.Id = I.Id
		WHERE 
			D.ProviderId != I.ProviderId
	END

	IF(@Event IS NOT NULL AND @Event != '')
	BEGIN
		SELECT @ApplicationUserId = ApplicationUserId, @ModuleId = ModuleId FROM INSERTED

		INSERT INTO Audit (ApplicationUserId, ModuleId, Event, DateTime, AddedDate, ModifiedDate, Active)
		VALUES (@ApplicationUserId, @ModuleId, @Event, GETDATE(), GETDATE(), NULL, 1)
	END
END