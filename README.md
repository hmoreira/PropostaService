- O serviço foi criado utilizando **Visual Studio 2022** e **SQL Server LocalDB** (disponivel na instalacao do VS);
- O BD **PropostaSeguro** deve ser criado antes da execução do script proposta_db_script.sql, que deve ser executado utilizando o BD PropostaSeguro;
- O SDK do **.NET 8** deve ser instalado antes da execução do serviço (https://dotnet.microsoft.com/pt-br/download);
- Para execução do serviço abrir o terminal na raiz da pasta PropostaService.Api e executar o comando **dotnet run**
- Para execução dos testes unitários abrir o terminal na raiz do repositório e executar o comando **dotnet test**
- Para testes locais, se for preciso alterar a string de conexão do BD, isso deve ser feito no arquivo **launchSettings.json**, localizado na pasta **PropostaService.Api/Properties**. A string de conexão é o valor da chave **ConnectionStrings:DefaultConnection** conforme exemplo abaixo :

  "ConnectionStrings:DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PropostaSeguro;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
