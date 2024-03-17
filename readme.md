# FIAP ORDERS

Projeto criado para o Tech Challenge da fase 3 do curso de pós graduação em **Arquitetura de Sistemas .NET com Azure**.
##### Turma  **2023/2 GRUPO 12**

## Sobre o projeto
Fiap Orders é um serviço de processamento de pedidos.
A arquitetura utilizada é a de microserviços onde todos os serviços foram implementados em .Net 8.0.
A Comunicação entre os serviços é feita através de mensageria com o RabbitMQ e MassTransit.

## Como executar o projeto

 1. Na raiz do projeto execute o seguinte comando: `docker compose up -d --build`.
 2. Após a inicialização dos containers, é possível acessar o swagger pela seguinte URL [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)


## Documentação da API

### Inserir novo Pedido

Para inserir um novo pedido devem ser informados o nome, e-mail do cliente e os itens do pedido.
O Retorno do método contém os dados do pedido.

**URL:**  `http://localhost:5000/Order`
**Método:** `POST`

#### Parâmetros

```json
{
	"name":  "Cliente Teste",
	"email":  "teste@email.com",
	"items":  [
		{
			"description":  "Caneta",
			"quantity":  1,
			"price":  1.90
		},
		{
			"description":  "Carne",
			"quantity":  0.590,
			"price":  53.00
		}
	]
}
```

#### Response
```json
{
	"Name":  "Cliente Teste",
	"Email":  "teste@email.com",
	"Total":  33.170,
	"Items":  [
		{
			"Description":  "Caneta",
			"Quantity":  1,
			"Price":  1.90,
			"Total":  1.90
		},
		{
			"Description":  "Carne",
			"Quantity":  0.590,
			"Price":  53,
			"Total":  31.270
		}
	]
}
```

## Uso do Seq via Docker

O Seq é uma plataforma de gerenciamento de logs moderna, projetada para facilitar a coleta, análise e visualização de registros de aplicativos e sistemas. Com o Seq, você pode centralizar todos os logs do seu aplicativo em um único local, facilitando a detecção de problemas, depuração de código e análise de tendências.

### Por que usar o Seq?

- **Centralização de Logs:** O Seq permite centralizar logs de vários aplicativos e sistemas em um único local, simplificando o processo de monitoramento e análise.
- **Pesquisa Avançada:** Com recursos de pesquisa avançados, você pode filtrar e pesquisar logs com facilidade para encontrar informações específicas ou identificar problemas rapidamente.
- **Visualizações Personalizadas:** O Seq oferece recursos poderosos de visualização para ajudar a transformar dados de log em gráficos e métricas úteis, permitindo uma compreensão mais profunda do desempenho do sistema.
- **Integração com Docker:** O Seq pode ser facilmente integrado a ambientes Docker, permitindo que você colete e analise logs de contêineres Docker de forma eficiente.

### Como usar o Seq via Docker

**Acesse o Seq:** Após executar o contêiner, você pode acessar o Seq através do navegador da web. Basta abrir seu navegador e navegar para `http://localhost:5341` para acessar a interface do Seq.

Com o Seq configurado e em execução, você poderá começar a enviar logs dos seus aplicativos para análise e visualização na plataforma Seq.

[![Seq](https://github.com/egasparotto/Fiap-TechChallenge3/blob/main/seq.jpg "Seq")](https://github.com/egasparotto/Fiap-TechChallenge3/blob/main/seq.jpg "Seq")


## Autenticação com Auth0

O Auth0 é um serviço de autenticação e autorização escalável e fácil de usar, projetado para simplificar o processo de autenticação em aplicativos da web e APIs.

### Por que usar o Auth0?

- **Segurança Avançada:** O Auth0 oferece recursos avançados de segurança, incluindo autenticação de dois fatores, integração com provedores de identidade social e suporte para padrões de autenticação modernos, como OAuth 2.0 e OpenID Connect.

- **Facilidade de Integração:** Com APIs bem documentadas e bibliotecas cliente para várias plataformas, o Auth0 facilita a integração da autenticação em seus aplicativos e serviços.

- **Gerenciamento de Identidade:** O Auth0 inclui recursos de gerenciamento de identidade, como provisionamento de usuários, gerenciamento de perfil e controle de acesso baseado em funções, para ajudar a controlar o acesso aos recursos da sua aplicação.

- **Escalabilidade e Confiabilidade:** Como um serviço hospedado na nuvem, o Auth0 oferece escalabilidade e confiabilidade, garantindo que seus aplicativos possam lidar com cargas de autenticação de qualquer tamanho.

### Como usar o Auth0
#### Autenticação com Auth0 (Machine to Machine - M2M)

Para autenticar sua API junto ao Auth0 usando o método de credenciais do cliente (Client Credentials Grant), você precisará realizar as seguintes etapas:

1. **Obtenha Credenciais do Cliente (Aplicativo):** No painel de administração do Auth0, vá para "Aplicativos" e selecione seu aplicativo. Anote o "ID do Cliente" e o "Segredo do Cliente", que serão usados para autenticar a solicitação de token JWT.

2. **Solicite um Token de Acesso JWT:** Utilize as credenciais do cliente (ID do Cliente e Segredo do Cliente) para fazer uma solicitação POST para o endpoint de token OAuth do Auth0. Aqui está um exemplo de como fazer isso usando a linha de comando (Usado no nosso projeto):

```bash
curl --request POST \
  --url https://dev-estudo-testes.us.auth0.com/oauth/token \
  --header 'content-type: application/json' \
  --data '{"client_id":"winUSC3FsCWdRQIq5W9vC22x9CQ9Dx5h","client_secret":"wdLl43tisQfQH2r3MtVN6LO4zUw2V4Zp8rclDnqW8m2rJIXfg7CiXd_q_wgPRTJF","audience":"FiapTechChallenge3","grant_type":"client_credentials"}'
```

#### Response
```json
{
    "access_token": "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IkV2WjNnUkJyQVppZTlQblNSLUY3WCJ9.eyJpc3MiOiJodHRwczovL2Rldi1lc3R1ZG8tdGVzdGVzLnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJ3aW5VU0MzRnNDV2RSUUlxNVc5dkMyMng5Q1E5RHg1aEBjbGllbnRzIiwiYXVkIjoiRmlhcFRlY2hDaGFsbGVuZ2UzIiwiaWF0IjoxNzEwNjg1Njg3LCJleHAiOjE3MTA3NzIwODcsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyIsImF6cCI6IndpblVTQzNGc0NXZFJRSXE1Vzl2QzIyeDlDUTlEeDVoIn0.biUlnR-a-xTjLl4KXKBMb5LK4uhpWwKmOAGPWeS1zUYQ4EPu0KC296jMxGMLE4-EDPnc5T19rjRR-_wZCO29rt4koz6IRopJN2OCm1rh1U2tN3IHEmcLXbj5kQWoK1_xX675hnrRqOiEBPkshVxrNa7-zMejn4uBPY8m3jUUd-VDodXVvVUbSGSD5_bFsATgRBzLRlGD7NkkJD_G_5IYXkroXq8HPq6i-RWN-OW-7X1pHsJigd06Qpcyawdib_zaovzN3l3x-0FsLSX28OSpZxQI6rUJoEIH1aWzEKYhhr4yCZdzFWHzxsWRi497xGtA5U1Nv8B3F-KI-ZXahVY80A",
    "expires_in": 86400,
    "token_type": "Bearer"
}
```

[![Uso do Token no projeto](https://github.com/egasparotto/Fiap-TechChallenge3/blob/main/Uso%20Token.png "Uso do Token no projeto")](https://github.com/egasparotto/Fiap-TechChallenge3/blob/main/Uso%20Token.png "Uso do Token no projeto")
