export default {
  home(_defaultSelector, btnCadastro, btnLogin) {
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
            <div class="${_defaultSelector}__what__text">
              <h1>O que é?</h1>
              <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
            </div>
            <div class="${_defaultSelector}__what__phone">
              <div class="phone"></div>  
            </div>                            
          </div>
        </div>
        <div class="${_defaultSelector}__who">
          <div class="container">            
            <div class="${_defaultSelector}__who__phone">
              <div class="phone"></div>  
            </div>               
            <div class="${_defaultSelector}__who__text">
              <h1>Como funciona?</h1>
              <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
            </div>             
          </div>
        </div>        
      `,
      reference: ['.btnCadastro', '.btnLogin'],
      components: [btnCadastro.render(), btnLogin.render()],
    };
  },
};
