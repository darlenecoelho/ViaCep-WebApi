# ViaCep-WebApi

Este é um projeto ASP.NET Core Web API criado com o objetivo de estudar e demonstrar o uso da biblioteca Polly para implementar políticas de resiliência. A API ViaCep permite consultar informações de endereços a partir de códigos CEP utilizando a API ViaCep.

## Descrição

O ViaCep-WebApi é uma API simples e leve que utiliza o serviço da API ViaCep (https://viacep.com.br/) para obter informações de endereço a partir de códigos CEP. O projeto foi desenvolvido com foco em estudar e aplicar conceitos de resiliência, utilizando a biblioteca Polly para implementar políticas de retry e circuit breaker.

## Recursos

- Consulta de endereço a partir de código CEP.
- Integração com a API ViaCep.
- Utilização de políticas de resiliência com Polly para lidar com falhas de conexão.
- Documentação da API com Swagger.

## Tecnologias Utilizadas

- ASP.NET Core 7.0
- C#
- Newtonsoft.Json
- Polly

## Como Usar

1. Clone o repositório para a sua máquina local.
2. Abra o projeto em um ambiente de desenvolvimento compatível com ASP.NET Core 7.0.
3. Execute o projeto.
4. Utilize uma ferramenta de teste de API, como o Postman, para enviar requisições para a API.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues relatando problemas, sugerir melhorias ou enviar pull requests para adicionar novos recursos.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
