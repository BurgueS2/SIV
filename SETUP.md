# Configuração do Ambiente de Desenvolvimento para o Sistema SIV

Este guia fornece instruções passo a passo para configurar o ambiente de desenvolvimento necessário para contribuir com o projeto Sistema Inteligente de Vendas (SIV).

## Pré-requisitos

Antes de começar, certifique de ter instalado em sua máquina:

- **Git**: Para clonar o repositório do projeto.
- **MySQL Server**: Para o armazenamento e gerenciamento dos dados.
- **.NET SDK**: Necessário para desenvolvimento em C#.
- **Visual Studio**: IDE recomendada para o desenvolvimento do projeto ou outro IDE da sua escolha.

## Configuração do Ambiente

### 1. Clonar o Repositório

Primeiro, clone o repositório do projeto para sua máquina local usando o Git:

```bash
git clone https://github.com/BurgueS2/SIV
```

### 2. Instalar o MySQL Server
- Baixe e instale o MySQL Server da página oficial.
- Durante a instalação, defina a senha do usuário root ou crie um novo usuário e anote as credenciais.

### 3. Configurar o Banco de Dados
- Crie um banco de dados chamado `pdv` ou outro nome que você achar melhor no MySQL.
- Importe o [script SQL](script.sql) fornecido no repositório para criar as tabelas necessárias.

### 4. Configurar a string de Conexão
- Abra o arquivo `SIV/Core/ConnectionManager.cs` no projeto clonado.
- Atualize a string de conexão com as credenciais do seu MySQL Server:

- ```csharp
  private static string _connectionString = "SERVER=localhost; DATABASE=pdv; UID=seu_usuario; PWD=sua_senha; PORT=3306;";
  ```
  
### 5. Restaurar Pacotes NuGet
- Abra o projeto no seu IDE.
- O IDE deve restaurar automaticamente os pacotes NuGet necessários. Caso isso não aconteça, execute o comando:
- ```terminal
  dotnet restore
  ```

### 6. Compilar o Projeto
- Compile o projeto para verificar se não há erros. Isso pode ser feito através do IDE ou usando o comando:
- ```terminal
  dotnet build
  ```
### 7. Executar o Projeto
- Execute o projeto para verificar se a aplicação está funcionando corretamente. 
- Isso pode ser feito através do IDE executando o projeto pressionando F5 ou utilizando o botão de execução no IDE. Isso iniciará a aplicação e abrirá a interface principal do sistema.

## Conclusão
Após seguir estes passos, o Sistema SIV deverá estar rodando em sua máquina. Explore as funcionalidades e contribua com o projeto!