API REST desenvolvida em ASP.NET Core para cadastro, listagem, edição e remoção de brinquedos. Projeto criado com Entity Framework Core, SQL Server e Swagger para documentação e testes.

COMO EXECUTAR O PROJETO:

Clone o repositório:

git clone https://github.com/seu-usuario/BrinquedoAPIv2.git

Abra o projeto no Visual Studio:

Configure a connection string (arquivo appsettings.json): 

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=BrinquedoDBv2;Trusted_Connection=True;" }
  
Abra o Package Manager Console e execute: 

Update-Database

Execute o projeto 

Acesse o Swagger em: https://localhost:7047/swagger

Os prints estão na pasta docs!
