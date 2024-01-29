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