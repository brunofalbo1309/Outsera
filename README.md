# Outsera - BackEnd

Projeto API RESTful para possibilitar a leitura da lista de indicados e vencedores da categoria Pior Filme do Golden Raspberry Awards. 


## Configura��o do arquivo movielist

Para rodar esse projeto, voc� vai precisar ajustar no arquivo `appsettings.json` a chave com as informa��es da localiza��o do arquivo movielist. 

Segue exemplo com as Configura��es atuais do projeto:
```file option
"FileOption": {
                "Folder": "C:\\File",
                "Name": "movielist.csv"
}
```
## Documenta��o da API

Retorna uma lista com maior intervalo entre dois pr�mios consecutivos, e o que obteve dois pr�mios mais r�pido, seguindo a especifica��o de formato definida na
 
```http
  GET /Movie
```

## Rodando os testes

Para rodar diretamente na API `via CLI` use os seguintes comandos:

#### GET 
```curl
  curl -X GET http://localhost:5279/Movie
```

Para rodar o projeto de teste acesse do diret�rio `[diret�rio raiz do reposit�rio]\Outsera.Backend\GoldenRaspberryAwards.Test`. Nele, `via CLI` use o seguinte comando:
```
dotnet test
```