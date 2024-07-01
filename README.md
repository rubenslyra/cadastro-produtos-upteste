# Cadastro de Produtos - UP Brasil
[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7-blue)](https://docs.microsoft.com/en-us/dotnet/framework/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019-orange)](https://docs.microsoft.com/en-us/sql/sql-server/)
[![WebForms](https://img.shields.io/badge/WebForms-ASP.NET-red)](https://docs.microsoft.com/en-us/aspnet/web-forms/)
[![Swagger](https://img.shields.io/badge/Swagger-API%20Documentation-brightgreen)](https://swagger.io/docs/)
[![JWT](https://img.shields.io/badge/JWT-Authentication-yellow)](https://jwt.io/introduction/)
[![NUnit](https://img.shields.io/badge/NUnit-Testing-green)](https://nunit.org/)

Este projeto implementa um sistema de cadastro de produtos utilizando .NET Framework 4.7, WebForms, SQL Server e JWT para autenticação. A API é documentada utilizando Swagger e inclui testes unitários com NUnit.

## Estrutura do Projeto

- **Business**: Contém a lógica de negócios.
- **Data**: Contém os repositórios para acesso ao banco de dados.
- **Models**: Contém as classes de modelos de dados.
- **Web**: Contém a aplicação WebForms.
- **Tests**: Contém os testes unitários e de integração.

## Pré-requisitos

- Visual Studio 2019 ou superior
- SQL Server 2019 ou superior
- .NET Framework 4.7
- NuGet

## Configuração do Ambiente

1. **Clone o Repositório**

   ```sh
   git clone https://github.com/rubenslyra/product-catalog.git
   cd product-catalog
   ```

2. **Configuração do Banco de Dados**

   - Crie um banco de dados no SQL Server.
   - Execute os scripts SQL fornecidos em `scripts/` para criar as tabelas e stored procedures.

   ```sh
   cd scripts
   sqlcmd -S YOUR_SERVER -U YOUR_USER -P YOUR_PASSWORD -d master -i create_tables.sql
   sqlcmd -S YOUR_SERVER -U YOUR_USER -P YOUR_PASSWORD -d master -i create_procedures.sql
   ```

3. **Configuração do Projeto**

   - Abra o projeto no Visual Studio.
   - Configure a string de conexão no `Web.config`.

     ```xml
     <connectionStrings>
         <add name="ProductDB" connectionString="Server=YOUR_SERVER;Database=ProductDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;" providerName="System.Data.SqlClient"/>
     </connectionStrings>
     ```

   - Configure as chaves JWT no `Web.config`.

     ```xml
     <appSettings>
         <add key="JwtIssuer" value="YOUR_ISSUER"/>
         <add key="JwtSecretKey" value="YOUR_SECRET_KEY"/>
     </appSettings>
     ```

4. **Restaurar Pacotes NuGet**

   ```sh
   nuget restore
   ```

## Executar o Projeto

1. **Compilar e Executar**

   - Compile o projeto no Visual Studio.
   - Execute o projeto utilizando IIS Express ou configure um site no IIS.

2. **Acessar a Aplicação**

   - Acesse a aplicação em `http://localhost:PORT/`.
   - A documentação da API estará disponível em `http://localhost:PORT/swagger`.

## Executar Testes

1. **Configuração do Ambiente de Testes**

   - Configure uma string de conexão de teste no `App.config` do projeto de testes.

     ```xml
     <connectionStrings>
         <add name="ProductDB" connectionString="Server=YOUR_SERVER;Database=ProductDBTest;User Id=YOUR_USER;Password=YOUR_PASSWORD;" providerName="System.Data.SqlClient"/>
     </connectionStrings>
     ```

2. **Executar Testes**

   - Execute os testes utilizando o Test Explorer do Visual Studio ou via linha de comando.

     ```sh
     dotnet test
     ```

## Estrutura de Arquivos

```plaintext
product-catalog/
├── scripts/
│   ├── create_tables.sql
│   ├── create_procedures.sql
├── src/
│   ├── CPU.Business/
│   ├── CPU.Data/
│   ├── CPU.Models/
│   ├── CPU.Web/
│   ├── CPU.Tests/
├── README.md
```

## Referências

- [Documentação do .NET Framework](https://docs.microsoft.com/en-us/dotnet/framework/)
- [Documentação do SQL Server](https://docs.microsoft.com/en-us/sql/sql-server/)
- [Documentação do WebForms](https://docs.microsoft.com/en-us/aspnet/web-forms/)
- [Documentação do Swagger](https://swagger.io/docs/)
- [Documentação do JWT](https://jwt.io/introduction/)
- [Documentação do NUnit](https://nunit.org/)

### Scripts de Banco de Dados

#### `create_tables.sql`

```sql
-- Criação da tabela de Produtos
CREATE TABLE Produtos (
    ProdutoId INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(255) NULL,
    Preco DECIMAL(18,2) NOT NULL,
    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
    DataAtualizacao DATETIME NULL
);

-- Criação da tabela de Categorias
CREATE TABLE Categorias (
    CategoriaId INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(255) NULL,
    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
    DataAtualizacao DATETIME NULL
);

-- Tabela de relacionamento entre Produtos e Categorias (muitos-para-muitos)
CREATE TABLE ProdutoCategorias (
    ProdutoId INT NOT NULL,
    CategoriaId INT NOT NULL,
    CONSTRAINT PK_ProdutoCategorias PRIMARY KEY (ProdutoId, CategoriaId),
    CONSTRAINT FK_ProdutoCategorias_Produtos FOREIGN KEY (ProdutoId) REFERENCES Produtos(ProdutoId),
    CONSTRAINT FK_ProdutoCategorias_Categorias FOREIGN KEY (CategoriaId) REFERENCES Categorias(CategoriaId)
);
```

#### `create_procedures.sql`

```sql
-- Stored Procedure para Inserir Produto
CREATE PROCEDURE sp_InserirProduto
    @Nome NVARCHAR(100),
    @Descricao NVARCHAR(255),
    @Preco DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Produtos (Nome, Descricao, Preco, DataCriacao)
    VALUES (@Nome, @Descricao, @Preco, GETDATE());
END

-- Stored Procedure para Atualizar Produto
CREATE PROCEDURE sp_AtualizarProduto
    @ProdutoId INT,
    @Nome NVARCHAR(100),
    @Descricao NVARCHAR(255),
    @Preco DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Produtos
    SET Nome = @Nome,
        Descricao = @Descricao,
        Preco = @Preco,
        DataAtualizacao = GETDATE()
    WHERE ProdutoId = @ProdutoId;
END

-- Stored Procedure para Deletar Produto
CREATE PROCEDURE sp_DeletarProduto
    @ProdutoId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM ProdutoCategorias WHERE ProdutoId = @ProdutoId;
    DELETE FROM Produtos WHERE ProdutoId = @ProdutoId;
END

-- Stored Procedure para Selecionar Produto por ID
CREATE PROCEDURE sp_SelecionarProdutoPorId
    @ProdutoId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ProdutoId, Nome, Descricao, Preco, DataCriacao, DataAtualizacao
    FROM Produtos
    WHERE ProdutoId = @ProdutoId;
END

-- Stored Procedure para Inserir Produto com Transação
CREATE PROCEDURE sp_InserirProdutoComTransacao
    @Nome NVARCHAR(100),
    @Descricao NVARCHAR(255),
    @Preco DECIMAL(18,2),
    @CategoriaIds INT[]
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @ProdutoId INT;

        INSERT INTO Produtos (Nome, Descricao, Preco, DataCriacao)
        VALUES (@Nome, @Descricao, @Preco, GETDATE());

        SET @ProdutoId = SCOPE_IDENTITY();

        IF @CategoriaIds IS NOT NULL
        BEGIN
            DECLARE @CategoriaId INT;
            DECLARE @Counter INT = 0;

            WHILE @Counter < (SELECT COUNT(*) FROM STRING_SPLIT(@CategoriaIds, ','))
            BEGIN
                SET @CategoriaId = (SELECT value FROM STRING_SPLIT(@CategoriaIds, ',') ORDER BY value OFFSET @Counter ROWS FETCH NEXT 1 ROWS ONLY);
                INSERT INTO ProdutoCategorias (ProdutoId, CategoriaId) VALUES (@ProdutoId, @CategoriaId);
                SET @Counter = @Counter + 1;
            END
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

-- Stored Procedure para Atualizar Produto com Transação
CREATE PROCEDURE sp_AtualizarProdutoComTransacao
    @ProdutoId INT,
    @Nome NVARCHAR(100),
    @Descricao NVARCHAR(255),
    @Preco DECIMAL(18,2),


    @CategoriaIds INT[]
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Produtos
        SET Nome = @Nome,
            Descricao = @Descricao,
            Preco = @Preco,
            DataAtualizacao = GETDATE()
        WHERE ProdutoId = @ProdutoId;

        DELETE FROM ProdutoCategorias WHERE ProdutoId = @ProdutoId;

        IF @CategoriaIds IS NOT NULL
        BEGIN
            DECLARE @CategoriaId INT;
            DECLARE @Counter INT = 0;

            WHILE @Counter < (SELECT COUNT(*) FROM STRING_SPLIT(@CategoriaIds, ','))
            BEGIN
                SET @CategoriaId = (SELECT value FROM STRING_SPLIT(@CategoriaIds, ',') ORDER BY value OFFSET @Counter ROWS FETCH NEXT 1 ROWS ONLY);
                INSERT INTO ProdutoCategorias (ProdutoId, CategoriaId) VALUES (@ProdutoId, @CategoriaId);
                SET @Counter = @Counter + 1;
            END
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
```
