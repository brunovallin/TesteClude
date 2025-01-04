# GdP Clude App

O projeto tem como objetivo fazer um **CRUD** ou uma tela de Cadastro de profissionais da saúde com uma base **pré carregada** com dados de especialidade e tipo de documento.

## Tecnologias utilizadas

As tecnologias a seguir foram utilizadas para a composição completa do projeto e serão descritas a seguir. 

### .Net 8.0

Foi utilizado na construção da Rest API e compõe o teste envolvendo a linguagem C# e o framework .Net core. 

---

### Entity Framework

Ferramenta utilizada na construção das persistências do projeto baseado no modelo fornecido para o teste.será utilizado a base de dados SQLite para a integração da base. 

---

### SQLite 3

Base de dados utilizada para o armazenamento dos dados tratados pela API eqé utilizadocna camada de persistência. 

---

### Angular

Utilizado na construção da tela e modals que farão as operações do crud.

---

## Primeiros passos para utilização

Vamos garantir que algumas bibliotecas e ferramentas estejam instaladas corretamente antes de utilizarmos a aplicação. 

### .Net 8 e entity framework

Realize a instalação do .net 8. Link: 

Após a instalação, em um terminal digite o seguintr código:

> `dotnet tools install -- global dotnet-ef`


Isso fará a aplicação reconhecer a utilização de alguns comandos que iremoa realizar. 

Depois de instalado, ainda no terminal, acesse a pasta do projeto de persistencia e utilize o seguinte comando para habilitar a criação da base de dados e das tabelas já populadas.

>`dotnet ef migrations add Initial -o Data/Migrations -p "" `

Execute o comando para cria a base de dados dentro do projeto da API. 

>`dotnet ef database update`

Para finalizarmos, dentro da pasta do projeto API, execute o comando abaixo para inicializar a execução da API:

>`dotnet run`

Uma pagina com um Swagger deve aparecer no seu navegador. 

## Angular

Antes de qualquer comando é necessário que tenhamos o Node.js instalado na máquina.


Após a instalação, em um terminal a parte do terminal rodando a API, entre na pasta do projeto angular e execute o comando abaixo para instalar o angular na maquina e inicializar a tela:

>`npm install -g @angular/cli`

>`npm start`