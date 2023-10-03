api : dotnet new webapi
testes: dotnet new xunit
mvc : dotnet new mvc

# Criando o projeto principal
Criar api
Criar testes
Criar solução
Adicionar projetos à solução
Adicionar a referência do projeto api.csproj no projeto testes.csproj


# Criando api
Criar pasta api
> mkdir api
Apontar para a pasta criada
> cd api
Criar projeto BASE da api
> dotnet new webapi
Adicionar pacote EntityFramework
> dotnet add package Microsoft.EntityFrameworkCore.Design
Adicionar pacote Sqlite database
> dotnet add package Microsoft.EntityFrameworkCore.Sqlite
Adicionar ConnectionStrings em testes/appsettings.Development.json
> notepad appsettings.Development.json

Exemplo ConnectionStrings abaixo 

json
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=escola.db"
  }
}

```

Criar pasta Controllers
> mkdir Controllers

Apontar para a pasta Controllers
> cd Controllers

Crie CursoController
> echo > CursoController.cs

```
Codigo CursoController
```
Crie UsuarioController
> echo "Codigo UsuarioController" > UsuarioController.cs && notepad UsuarioController.cs

```
Codigo CursoController
```

Retornar para a pasta api
> cd ..
Criar pasta Data
> mkdir Data
Apontar para pasta Data
> cd Data
Criar EscolaContext
> echo "EscolaContext" > EscolaContext.cs 
```
Codigo EscolaContext
```

Criar pasta
> mkdir Entities
Apontar para Entities
> cd Entities

Criar classe Curso
> echo "Codigo da Clase Curso"> Curso.cs && notepad Curso.cs
```
Codigo da Classe Curso
```
Criar classe Usuario
> echo "Codigo da Classe Usuario"> Usuario.cs && notepad Curso.cs
```
Codigo da Classe Curso
```

Retornar para a pasta api
> cd .. && cd ..

Adicionar configuração ao Program.css
> notepad Program.cs

```
using IntroEntityFramework.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EscolaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
    );


```

Criar migrations
> dotnet-ef migrations add CriandoMigrations

Aplicar migrations para criar banco de dados escola.db e tabelas
> dotnet-ef database update

# Configurando Projeto de testes (testes)
> cd testes
Adicionar pacote Microsoft.AspNetCore.Mvc.Testing ao projeto de testes
> dotnet add package Microsoft.AspNetCore.Mvc.Testing
Adicionar pacote AutoBogus 2.12
> dotnet add package AutoBogus --version 2.12.0


# Informações sobre comandos no Windows
mkdir : O comando abaixo cria a pasta exemplo
> mkdir exemplo
cd : O comando cd abaixo entra na pasta
> cd exemplo
echo : O comando echo abaixo cria o arquivo nome.cs com a linha "Meu nome"
> echo "Meu nome" > nome.cs
notepad : O comando notepad abaixo abre o arquivo nome.cs
> notepad nome.cs

Os comandos podem ser combinados com &&. Abaixo cria a pasta notas com o arquivo nota.txt contendo a linha "Nota de Exemplo"
> mkdir notas && echo "Nota de exemplo" && notepad nota.txt
Abaixo retorna 2 pastas usando cd
>> cd .. && cd ..


# Criar um Cliente
flutter
android
angular
mvc : dotnet new mvc
webmvc console : dotnet new console
webmvc angular: dotnet new angular