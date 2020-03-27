export default {
  nearby(_defaultSelector, infos, btnGetRequest) {
    return {
      html: `
        <div class="${_defaultSelector}__header">
          <p class="${_defaultSelector}__header__name">${infos.client.name}</p>
          <p class="${_defaultSelector}__header__distance">📍 ${infos.client.distance} km</p>
        </div>
        <div class="${_defaultSelector}__overlay">
          <div class="${_defaultSelector}__description">
            <div class="${_defaultSelector}__description__image">
              <img src="${infos.client.image}" alt="${infos.client.name}">
            </div>
            <p>${infos.client.description}</p>
          </div>
          <div class="${_defaultSelector}__request">
            <ul>
              ${infos.request.items.map((item) => `<li>${item}</li>`).join('')}
            </ul>
          </div>
        </div>
        <div class="btnGetRequest"></div>
    `,
      reference: ['.btnGetRequest'],
      components: [btnGetRequest.render()],
    };
  },
};
