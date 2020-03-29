export default {
  login(_defaultSelector) {
    return `
      <div class="container">
        <div class="${_defaultSelector}__content">
          <div class="c__input">
            <input class="c__input__field" type="text" name="email" required pattern=".*\\S.*" tabindex="1"/>
            <label class="c__input__label">E-mail:</label>
          </div>
          <div class="c__input">
            <input class="c__input__field" type="password" name="password" required pattern=".*\\S.*" tabindex="2"/>
            <label class="c__input__label">Senha:</label>
          </div>
          <div class="c__checkbox">
            <div class="c__checkbox__content">
              <input class="c__checkbox__field" type="checkbox" name="isConnected" value="true" id="isConnected" tabindex="3"/>
              <label for="isConnected" class="c__checkbox__content__checkmark"></label>
            </div>
            <label for="isConnected">Manter conectado</label>
          </div>
        </div>
      </div>
    `;
  },
};
