export default {
  map(_defaultSelector, infos, btnReadRequest) {
    return {
      html: `
        <div id="client_details" class="${_defaultSelector}__details hidden">
          <div class="${_defaultSelector}__details__profile">
            <div class="${_defaultSelector}__details__profile__image">
              <img src="${infos.client.image}" alt="${infos.client.name}">
            </div>
            <div class="${_defaultSelector}__details__profile__content">
              <p class="${_defaultSelector}__details__profile__content__name">${infos.client.name}</p>
              <p class="${_defaultSelector}__details__profile__content__distance">📍 ${infos.client.distance} km</p>
            </div>
          </div>
          <div class="${_defaultSelector}__details__description">
            <p>${infos.client.description}</p>
          </div>
          <div id="btn_noDetails" class="btnReadRequest"></div>
        </div>
        <div class="${_defaultSelector}__google_maps" id="map"></div>
    `,
      reference: ['.btnReadRequest'],
      components: [btnReadRequest.render()],
    };
  },
};
