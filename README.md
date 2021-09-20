# Cartola FC - Pesquisa
> Pesquisa de ligas do _Cartola FC_ e com fácil visualização das pontuações. Para quem quer iniciar um projeto sobre o _Cartola FC_ acredito ser um bom guia.

## Pré-requisitos

Você vai precisar do [Docker](https://hub.docker.com) para rodar o Redis:
```bash
# Configurar na porta port:6379 é a porta de conexão que está configurada no appsettings.json
$ docker pull redis
```

Não realizei nenhuma criação de login para pegar o token de acesso do _Cartola FC_ com isso é necessário fazer o login manual no _Cartola FC_ ir nos cookies e pegar o GLBID, após isso, copiar e colar no appsettings.json do projeto Cartola.Api
```bash
"GlbId": "12af9de170ba1c9d1fad06e38c2c44b53644151487763483756355132..."
```

## Visão Simples
<h1 align="center">
  <img alt="LigaSimples" title="Liga Simples" src="./assets/images/screenshot-localhost_44368-2021.09.20-00_40_34.png" />
</h1>

<h1 align="center">
  <img alt="DetalheTime" title="Detalhe Time" src="./assets/images/screenshot-localhost_44368-2021.09.20-00_40_56.png" />
</h1>

## Visão Detalhada
<h1 align="center">
  <img alt="LigaDethada" title="Liga Detalhada" src="./assets/images/screenshot-localhost_44368-2021.09.20-00_42_16.png" />
</h1>

<h1 align="center">
  <img alt="DetalheTime" title="Detalhe Time" src="./assets/images/screenshot-localhost_44368-2021.09.20-00_45_15.png" />
</h1>

## Observações
Esse projeto utiliza das apis do [Cartola FC](https://cartolafc.globo.com/) para funcionar, podendo parar de funcionar a qualquer momento.

## License
This project is under the MIT license. See the [LICENSE](https://github.com/lukemorales/rocketshoes-react-native/blob/master/LICENSE) for more information.

## Autor
:bust_in_silhouette: __Julio C Silva__:
* [Github](https://github.com/JULIOCSILVA)
* [Linkedin](https://www.linkedin.com/in/julio-cesar-da-silva-a097b16a/)
