# Tools

1. O projeto foi criado a partir do [VJSCLI](https://www.npmjs.com/package/vjscli)

- Se for utilizar o vjscli faça a instalação de modo global `npm i -g vjscli`
- Facilita para criar a estrutura de projeto
- No desenvolvimento ajuda na hora de criar os componentes com o comando `vjs -g <nome_do_component>` na pasta onde seu
  componente vai ficar.

# Getting Started

1. Clone o repositório
2. Abra o prompt de comando e navegue até a pasta onde clonou o projeto
3. Faça a instalação com `npm install`
4. Se não ocorrer nenhum erro na instalação das dependências o projeto esta pronto para trabalho.

# Build and Docs

1. `npm run local` para dar start no projeto em modo de desenvolvimento

- O [webpack-dev-server](https://webpack.js.org/configuration/dev-server/) abrirá uma página para você, caso isso não
  ocorra, abra o seu navegador e digite: [http://localhost:8080](http://localhost:8080)

2. `npm run build` para preparar o projeto para modo produção

- Ao finalizar o processo, uma pasta dist será criada na raiz do projeto, contendo os arquivos finais.
- O projeto esta com diversas ferramentas para optimização, incluindo brotli com fallback para gzip.

3. `npm run docs` para criar a documentação do projeto.

- Ao finalizar o processo, uma pasta docs será criada na raiz do projeto.
- A documentação é criada a partir de comentários estruturados feito no decorrer do código, se atente ao padrão

# Infos

1. Se atente a estrutura do projeto, a arquitetura foi pensada em componentes pequenos, onde um componente pode ser
   parte de outro componente.
2. Atente-se aos contratos(models) dos componentes, que podem ser encontrados no seguinte caminho (levando em
   consideração a raiz do projeto): src/models
3. Todo componente deve extender a classe Component encontrada na pasta @core.
4. Para novas rotas atente-se em cadastrá-las no arquivo `routing.js` encontrado no caminho (levando em consideração a
   raiz do projeto): src/@core/router/routing.js.

- Se você precisar fazer alguma requisição ou mesmo alguma função que precisa ser resolvida (pense em Promises) antes da
  navegação ocorrer, cadastre a mesma no arquivo `resolvers.js` que pode ser encontrado no mesmo caminho especificado
  acima.

5. Após criar a sua rota, lembre-se também de criar a sua página na pasta page que pode ser encontrada no caminho
   (levando em consideração a raiz do projeto): src/pages

- Se atente em seguir o padrão das demais páginas.
