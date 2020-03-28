export default {
  register(
    _defaultSelector,
    inputName,
    inputEmail,
    //inputEmailConfirmation,
    inputPassword,
    //inputPasswordConfirmation,
    btnRegister
  ) {
    return {
      html: `
        <div class="container">
          <div class="${_defaultSelector}__content">
            <form id="formRegister">
              <div>
              <div class="inputName"></div>          
              </div>
              <div><div class="inputEmail"></div></div>
              <!--<div class="inputEmailConfirmation"></div>-->
              <div><div class="inputPassword"></div></div>
              <!--<div class="inputPasswordConfirmation"></div>-->
              <div>
                <input type="radio" name="typeUser" value="0" id="type1"/><label for="type1">Preciso de ajuda</label>
                <input type="radio" name="typeUser" value="1" id="type1"/><label for="type2">Quero ajudar</label>
                <input type="radio" name="typeUser" value="2" id="type1"/><label for="type3">Empresa</label>
              </div>
              <div><div class="btnRegister"></div></div>              
            </form>
          </div>
          <div class="${_defaultSelector}__socials">
            <div></div>
          </div>
        </div>
      `,
      reference: [
        '.inputName',
        '.inputEmail',
        //'.inputEmailConfirmation',
        '.inputPassword',
        //'.inputPasswordConfirmation',
        '.btnRegister',
      ],
      components: [
        inputName,
        inputEmail,
        //inputEmailConfirmation,
        inputPassword,
        //inputPasswordConfirmation,
        btnRegister,
      ],
    };
  },
};
