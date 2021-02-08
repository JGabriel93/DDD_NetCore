# NetCore_DDD
 
## Índice

Esse projeto tem como objetivo criar um sistema de conta corrente, como cada conta é vinculada a um usuário, também temos o CRUD completo de usuário.
Quando o usuário é criado, é criada também uma conta corrente, porém com valor inicial = R$ 0.

A partir de uma conta corrente, o usuário pode realizar:
* Depósito (assim inserindo saldo na sua conta);
* Realizar pagamento (preenchendo o código de barras do boleto e o valor, o valor é deduzido do saldo);
* Transferência entre contas (preenchendo o CPF do destinatário e o valor desejado, assim o valor enviado reduzido do seu saldo e acrescentado no saldo do destinatário);
* Retirada (assim é simulado um saque, o valor é deduzido do saldo)

**Além disso, é possível visualizar todo o histórico das transações.**

Foi criado um botão, onde ao clicar é como se o sistema tivesse adiantado 1 dia, assim todas as contas são acrescidas no saldo o rendimento diário baseado no 100% do CDI, hoje sendo um rendimento de 0.005% por dia.

**O projeto em .Net Core, já contém toda a implementação de autenticação via token JWT, porém ainda não foi implementado no Angular a parte de "login" e passagem do token via "headers" das requisições, por isso, a parte de autenticação na API está comentada.**

Para executar o projeto, será necessário instalar os seguintes programas:

- [.Net Core 5.0.102]: Necessário para executar o projeto (https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.102-windows-x64-installer)
- [Node v14.15.4]: Necessário para executar o projeto feito em Angular (https://nodejs.org/en/blog/release/v14.15.4/)
- [Visual Studio Code]: Para desenvolvimento do projeto (https://code.visualstudio.com/download)
- [MySQL Community Server]: Ferramenta de banco de dados (https://dev.mysql.com/downloads/mysql/)
- [Git]: Para realizar o controle de versão do projeto (https://git-scm.com/downloads)

## Construção

**OBS:** *A API está configurada para criar o banco de dados automaticamente (migrations), caso ele já não exista. Antes de realizar a primeira execução garanta que o **MySQL** esteja instalado.*

Para executar o projeto com o .Net Core, navegar até o diretório do projeto e executar o comando abaixo:

```bash
$ code . (com esse comando, abre o visual code)
```

Após abrir o visual studio code, clicar em "Terminal", depois em "New Terminal" e executar os comandos abaixo:

```bash
$ dotnet restore
$ dotnet build
```

Após esses comandos executados pode apertar "F5" ou ir em "Run" e dar start.

Para executar o projeto Angular, navegar até o diretório do projeto ("DDD_NetCore\App") e executar o comando abaixo:

```bash
$ code . (com esse comando, abre o visual code)
```

Após abrir o visual studio code, seguir com os comandos abaixo:

```bash
$ cd App
$ ng serve
```

O comandos irão compilar os projetos e realizar a execução de ambos.
* Projeto em .Net Core: http://localhost:5000/index.html (aqui é possível ver a doumentação da API via Swagger, também é possível realizar as requisições)
* Projeto em Angular: http://localhost:4200/users

Com a criação do banco de dados, para facilitar o uso, são incluídos automaticamente esses dados de usuários:
* Nome: João
* Email: admin@mail.com
*(para esse usuário, foi inserido um depósito de R$ 1000)*

* Nome: José
* Email: jose@mail.com
*(para esse usuário, foi apenas criada a conta com R$ 0)*

## Funcionalidades

### Login

Via API (ainda não disponível pelo projeto Angular), é possível fazer o login a partir do "email" e "senha", onde é gerado o token JWT.

*As validações de autenticações estão feitas, porém estão comentadas pois está faltando a implementação no projeto Angular.*

### Usuário

Criação, atualização, visualização e deleção.
Para criar um usuário, no menu tem o acesso "Novo usuário"
Para editar e excluir um usuário, na lista de usuários, é só clicar no "detalhe" do usuário desejado e abrirá a tela com as informações dele, assim disponibilizando os botões de "editar" e "excluir"

* Nome (até 60 caracteres), Email (até 100 caracteres)
* Os campos de "nome" e "cpf" são constraints únicas no banco de dados (não pode ter 2 registros iguais), ainda não tem validação de CPF, porém de email tem.
*Automaticamente, ao inserir um usuário, a conta corrente é criada com um saldo inicial de R$ 0.*

### Conta Corrente

Criada a partir da criação do usuário, saldo inicial R$ 0.
* Valor máximo das transações: 10000000

### Depósitos

É permitido realizar depósitos nas contas correntes, no menu de usuários, ao clicar na conta do usuário é aberta a página da conta onde aparece a opção para depositar.

### Pagamentos

É permitido realizar pagamentos a partir da conta corrente, no menu de usuários, ao clicar na conta do usuário é aberta a página da conta onde aparece a opção para pagar.
* Código de barras (de 44 a 47 caracteres), exemplo de código de barras válido: 00193373700000001000500940144816060680935031
* Para efetuar o pagamento, o valor a ser pago não pode ser maior do que o saldo disponível (validação feita na API, porém não exibida no projeto angular, mas pode utilizar via postman ou swagger e exibirá a validação)

### Transferência

É permitido realizar transferências para outro usuário (passando o CPF) a partir da conta corrente, no menu de usuários, ao clicar na conta do usuário é aberta a página da conta onde aparece a opção para transferir.
* Para efetuar a transferência, o valor a ser transferido não pode ser maior do que o saldo disponível (validação feita na API, porém não exibida no projeto angular, mas pode utilizar via postman ou swagger e exibirá a validação)
* Para efetuar a transferência, o cpf do destinatário deve contar na base de dados (validação feita na API, porém não exibida no projeto angular, mas pode utilizar via postman ou swagger e exibirá a validação)

### Retiradas

É permitido realizar retiradas a partir da conta corrente, no menu de usuários, ao clicar na conta do usuário é aberta a página da conta onde aparece a opção para retirar.
* Para efetuar a retirada, o valor a ser retirado não pode ser maior do que o saldo disponível (validação feita na API, porém não exibida no projeto angular, mas pode utilizar via postman ou swagger e exibirá a validação)

### Rendimento diário

É permitido realizar aplicações de rendimento diário, no menu de usuários, ao clicar no botão "Aplicar rendimento diário", todas as contas são atualizadas somando o rendimento diário, baseado em 100% do CDI, ou seja, hoje o equivalente a 0.005% do saldo (por dia).
Como essa rota já está feita na API, a ideia é que ao implantar a aplicação, seja criada uma rotina (via schedule, por exemplo), onde 1x por dia essa rota seja acessada, assim todas as contas renderão automaticamente todos os dias.
A configuração do valor de rendimento é configurada no "appsettings.json" do projeto.

*O rendimento é arredondado para 2 casas decimais, ao realizar o cálculo.*


## Testes
A aplicação contém esses testes unitários:
* Api.Application.Test
* Api.Data.Test
* Api.Integration.Test
* Api.Service.Test


## Observações
* As datas estão sendo atribuídas pela data do servidor. (UtcNow)
* As configurações do projeto estão em: **"appsettings.json"**.
* O projeto em Angular não consta com mensagens de validação e exbição das mensagens de retorno, futuramente serão implementadas.
* O projeto em Angular não consta autenticação via login, futuramente será implementada.