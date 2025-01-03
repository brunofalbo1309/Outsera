# Outsera - BackEnd

Projeto API RESTful para possibilitar a leitura da lista de indicados e vencedores da categoria Pior Filme do Golden Raspberry Awards. 


## Configuração do arquivo movielist

Para rodar esse projeto, você vai precisar ajustar no arquivo `appsettings.json` a chave com as informações da localização do arquivo movielist. 

Segue exemplo com as Configurações atuais do projeto:
```file option
"FileOption": {
                "Folder": "C:\\File",
                "Name": "movielist.csv"
}
```
## Documentação da API

Retorna uma lista com maior intervalo entre dois prêmios consecutivos, e o que obteve dois prêmios mais rápido, seguindo a especificação de formato definida na
 
```http
  GET /Movie
```

## Rodando os testes

Para rodar diretamente na API `via CLI` use os seguintes comandos:

#### GET 
```curl
  curl -X GET http://localhost:5279/Movie
```

Para rodar o projeto de teste acesse do diretório `[diretório raiz do repositório]\Outsera.Backend\GoldenRaspberryAwards.Test`. Nele, `via CLI` use o seguinte comando:
```
dotnet test
```