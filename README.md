# crudC

Projeto ASP.NET MVC em C# para CRUD de funcionarios e dependentes, com persistencia em SQL Server LocalDB.

## Visao geral

O sistema possui dois dominios principais:

- `Funcionario`
- `Dependente`

Cada funcionario pode possuir dependentes associados. A aplicacao usa interface web com Razor Views, controllers MVC e uma camada simples de repositorio para acesso ao banco.

## Tecnologias

- ASP.NET MVC 5
- C#
- SQL Server LocalDB
- Razor Views
- Bootstrap
- jQuery

## Estrutura do projeto

- `CrudFuncionario.sln`
  solucao principal do Visual Studio.
- `CrudFuncionario/Controllers`
  endpoints MVC e fluxo de navegacao.
- `CrudFuncionario/Models`
  modelos de dominio usados pela aplicacao.
- `CrudFuncionario/Repositorio`
  camada de acesso a dados com SQL direto via `SqlConnection` e `SqlCommand`.
- `CrudFuncionario/Views`
  telas Razor para listagem, cadastro, edicao e exclusao.
- `CrudFuncionario/App_Start/RouteConfig.cs`
  configuracao de rotas MVC.
- `SQLQuery1.sql` e `tabelas.txt`
  scripts e referencia das tabelas do banco.

## Arquitetura

A arquitetura atual segue uma separacao simples por camadas:

- camada web MVC
  controllers recebem a requisicao HTTP e escolhem a view ou redirect.
- camada de dominio
  models como `Funcionario` e `Dependente` representam os dados da aplicacao.
- camada de persistencia
  repositórios executam SQL diretamente no banco.

Nao ha Entity Framework nem uma camada de servicos separada. O fluxo real hoje e:

1. a rota chega no controller
2. o controller chama um repositorio
3. o repositorio acessa o banco via `SqlConnection`
4. o resultado volta para o controller
5. o controller renderiza uma Razor View

## Controllers principais

- `FuncionarioController`
  lista, cria, edita e exclui funcionarios.
- `DependenteController`
  lista, cria, edita e exclui dependentes vinculados a um funcionario.

Um ponto importante do fluxo e a relacao entre entidades:

- `VisualizarDependentes(int id)` em `FuncionarioController`
  redireciona para a listagem de dependentes do funcionario selecionado.
- `DependenteController`
  usa `idFuncionario` na query string para manter o contexto da associacao.

## Persistencia

Os repositórios usam SQL manual com `System.Data.SqlClient`.

Exemplo de repositorios:

- `FuncionarioRepositorio`
- `DependenteRepositorio`

A string de conexao atual esta embutida no codigo:

- `Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ado;`

Isso significa que o projeto depende de um banco local chamado `Ado`.

## Modelo de dados

Pelos scripts versionados, as tabelas principais sao:

- `Funcionario`
  - `FuncionarioId`
  - `Nome`
  - `Idade`
- `Dependente`
  - `DependenteId`
  - `FuncionarioId`
  - `Nome`

Ao excluir um funcionario, o repositorio remove antes os dependentes associados.

## Interface

As views ficam em:

- `Views/Funcionario`
- `Views/Dependente`
- `Views/Shared`

Elas implementam o CRUD classico:

- listar
- incluir
- editar
- excluir

## Observacoes

Este projeto esta mais alinhado com um CRUD tradicional de estudo ou demonstracao do que com uma arquitetura enterprise. A organizacao e clara para o tamanho do sistema, mas algumas melhorias naturais seriam:

- mover a string de conexao para configuracao externa
- adicionar uma camada de servicos
- separar melhor regras de negocio dos controllers
- adicionar testes automatizados
