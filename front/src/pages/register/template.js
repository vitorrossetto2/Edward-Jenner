export default {
  register(
    _defaultSelector,
    inputName,
    inputEmail,
    inputEmailConfirmation,
    inputPassword,
    inputPasswordConfirmation,
    btnRegister
  ) {
    return {
      html: `
        <div class="container">
          <div class="${_defaultSelector}__content">
            <div class="inputName"></div>          
            <div class="inputEmail"></div>
            <div class="inputEmailConfirmation"></div>
            <div class="inputPassword"></div>
            <div class="inputPasswordConfirmation"></div>
            <div class="btnRegister"></div>
          </div>
          <div class="${_defaultSelector}__socials">
            <div></div>
          </div>
        </div>
      `,
      reference: [
        '.inputName',
        '.inputEmail',
        '.inputEmailConfirmation',
        '.inputPassword',
        '.inputPasswordConfirmation',
        '.btnRegister',
      ],
      components: [
        inputName,
        inputEmail,
        inputEmailConfirmation,
        inputPassword,
        inputPasswordConfirmation,
        btnRegister,
      ],
    };
  },
};
