USE [Ado]
GO

/****** Object: Table [dbo].[Funcionario] Script Date: 10/12/2019 20:14:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Funcionario] (
    [FuncionarioId] INT           IDENTITY (1, 1) NOT NULL,
    [Nome]          VARCHAR (500) NOT NULL,
    [Idade]         INT           NOT NULL
);




/******/

USE [Ado]
GO

/****** Object: Table [dbo].[Dependente] Script Date: 10/12/2019 20:15:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dependente] (
    [DependenteId]  INT           IDENTITY (1, 1) NOT NULL,
    [FuncionarioId] INT           NULL,
    [Nome]          VARCHAR (500) NOT NULL
);


