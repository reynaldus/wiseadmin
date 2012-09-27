ALTER PROCEDURE [dbo].[SP_Gerencia_TipoProblema]

	@CODIGO INT,
	@DESCR VARCHAR(500),
	@SLA INT,
	@DEPARTAMENTO INT,
	@ACAO INT
	
AS
/* 
 	*************************************************************************
	* 																		* 	
	* 									                                    *  
	* Sistema 	 	WiseHelp	                                            *  
	* Procedure: 	SP_Gerencia_TipoProblema								*  
	* Descrição: 	Procedure de gerenciamento de Tipos de Problema			*  
	* Versão:		1.0 - 04/2012											*  
	* Desenvolvedor:Natalia M. Alves										*  
	* Parâmetros:  	@CODIGO													*
	*				@DESCR 	                          						*  
	* 			   	@ACAO		                					        *  
	*  Versão:		1.1 - 08/2012				 							*
	*  Desenvolvedor:Francisco S. Pereira 		   	 						*
	*																		*
   	*																		*
	*																		*
	*                          												*  
	*			 @ACAO - Define a ação a ser executada:                     *  
	*					 1 - Cadastrar                                      *  
	*			 		 2 - Consultar                                      *  
	*					 3 - Deletar                                        *  
	*					 4 - Atualizar                                      *  
	*                                                                       *  
	*                                                                       *  
	************************************************************************* 
	*/

BEGIN TRY
		BEGIN TRANSACTION
		--DECLARAÇÃO PADRÃO DA PROCEDURE
		DECLARE @ERROR AS VARCHAR(200)
		DECLARE @NPROC AS VARCHAR(200)
		
		--CADASTRAR
		IF @ACAO = 1
			BEGIN	
				INSERT INTO TBTIPOPROBLEMA
				VALUES(
					   @DESCR,
					   @SLA,
					   @DEPARTAMENTO
					   )
			END
		
		--CONSULTAR
		IF @ACAO = 2
			BEGIN
				SELECT 		CODIGO 
							DESCR		
				FROM TBTIPOPROBLEMA
			END
		
		--DELETAR
		IF @ACAO = 3
			BEGIN
				DELETE FROM TBTIPOPROBLEMA
				WHERE CODIGO = @CODIGO
			END
			
		
		--ATUALIZAR
		IF @ACAO = 4
			BEGIN
				UPDATE TBTIPOPROBLEMA
				SET DESCR = @DESCR
				WHERE CODIGO = @CODIGO
				
			END
			
		
		COMMIT TRANSACTION
		END TRY
	 BEGIN CATCH
	 	ROLLBACK TRANSACTION
	 	SET @ERROR = ERROR_MESSAGE()
	 	SET @NPROC = ERROR_PROCEDURE()
	 	INSERT INTO TBLOGERROR VALUES(@NPROC,@ERROR) 	
	 
	 END CATCH
GO

