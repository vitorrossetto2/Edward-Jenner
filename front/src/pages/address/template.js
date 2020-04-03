export default {
  address(_defaultSelector, _user) {
    console.log(_user); //eslint-disable-line
    return `
        <div class="container">
          <div class="${_defaultSelector}__content">
            Endereço
          </div>
        </div>
      `;
  },
};
