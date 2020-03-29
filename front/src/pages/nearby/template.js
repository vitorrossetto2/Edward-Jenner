export default {
  nearby(_defaultSelector, infos, btnGetRequest) {
    return {
      html: `
        <section class="${_defaultSelector}__overlay">
          <div class="${_defaultSelector}__perfil">
            <div class="${_defaultSelector}__perfil__avatar">
              <img src="${infos.client.image}" alt="${infos.client.name}">
            </div>
            <article class="${_defaultSelector}__perfil__about">
              <h2>${infos.client.name}</h2>
              <h3>📍 ${infos.client.distance} km</h3>
            </article>
          </div>
        
          <div class="${_defaultSelector}__description">
            <p>${infos.client.description}</p>
          </div>

          <div class="${_defaultSelector}__request">
            ${
              infos.request.items.map((item) =>
                `<dl>
                    <dt>
                      <h3>${item.nome}</h3>
                    </dt>
                    <dd>
                      <p>Quantidade: ${item.quantidade} | Preço maximo: ${item.precoMaximo}</p>
                    </dd>
                  </dl>
                `
              ).join('')
            }
          </div>
        </section>
        <div class="btnGetRequest"></div>
    `,
      reference: ['.btnGetRequest'],
      components: [btnGetRequest.render()],
    };
  },
};
