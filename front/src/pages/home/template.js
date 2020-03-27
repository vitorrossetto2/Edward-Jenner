export default {
  home(_defaultSelector, btnCadastro, btnLogin, card) {
    return {
      html: `
        <div class="${_defaultSelector}__banner">
          <div class="container">
            <div class="${_defaultSelector}__banner__description">
              <h1>Feito para conectar quem precisa de ajuda nesse momento de pandemia com quem pode ajudar.</h1>
              <div class="btnCadastro"></div>
              <div class="btnLogin"></div>              
            </div>
          </div>
        </div>          
        <div class="${_defaultSelector}__what">
          <div class="container">
            <h1>Como funciona?</h1>
            <div class="phone"></div>
            <div class="card"></div>
          </div>
        <div>
      `,
      reference: ['.btnCadastro', '.btnLogin', '.card'],
      components: [btnCadastro.render(), btnLogin.render(), card.render()],
    };
  },
};
