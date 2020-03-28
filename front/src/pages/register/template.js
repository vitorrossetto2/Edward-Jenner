export default {
  register(_defaultSelector) {
    return `
      <div class="container">
        <div class="${_defaultSelector}__content">
          <form id="formRegister">
            <div class="c__input">
              <input class="c__input__field" type="text" name="name" required pattern=".*\\S.*" tabindex="1"/>
              <label class="c__input__label">Nome completo:</label>
            </div>
            <div class="c__input">
              <input class="c__input__field" type="mail" name="email" required pattern=".*\\S.*" tabindex="2"/>
              <label class="c__input__label">E-mail:</label>
            </div>
            <div class="c__input">
              <input class="c__input__field" type="password" name="password" required pattern=".*\\S.*" tabindex="3"/>
              <label class="c__input__label">Senha:</label>
            </div>
            <div class="${_defaultSelector}__content__radios">
              <div class="c__radio">
                <div class="c__radio__content">
                  <input class="c__radio__field" type="radio" name="typeUser" value="0" id="typeUser0" checked tabindex="4"/>
                  <label for="typeUser0" class="c__radio__content__checkmark"></label>
                </div>
                <label for="typeUser0">Preciso de ajuda</label>
              </div>
              <div class="c__radio">
                <div class="c__radio__content">
                  <input class="c__radio__field" type="radio" name="typeUser" value="1" id="typeUser1" tabindex="5"/>
                  <label for="typeUser1" class="c__radio__content__checkmark"></label>
                </div>
                <label for="typeUser1">Quero ajudar</label>
              </div>
              <div class="c__radio">
                <div class="c__radio__content">
                  <input class="c__radio__field" type="radio" name="typeUser" value="2" id="typeUser2" tabindex="6"/>
                  <label for="typeUser2" class="c__radio__content__checkmark"></label>
                </div>
                <label for="typeUser2">Empresa</label>
              </div>
            </div>
            <button class="c__button c__button--reverse" type="button" disabled tabindex="7">Cadastrar</button>
          </form>
        </div>
        <div class="${_defaultSelector}__socials">
          <div></div>
        </div>
      </div>
      `;
  },
};
