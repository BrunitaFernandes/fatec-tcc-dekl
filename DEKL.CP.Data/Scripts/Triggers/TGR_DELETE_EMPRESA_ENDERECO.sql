CREATE TRIGGER [dbo].[TGR_DELETE_EMPRESA_ENDERECO]
   ON [dbo].[Empresa]
   AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON

    DELETE FROM Endereco WHERE Id = DELETED.EnderecoId;
	
END;