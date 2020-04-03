export default {
  profile(_defaultSelector, _user) {
    const content = `${_defaultSelector}__content`;
    const profile = `${content}__profile`;
    return `
      <div class="container">
        <div class="${content}">
          <div class="${profile}">
            <div class="${profile}__avatar">
              <img src="${_user.avatar}"/>
              <button class="${profile}__avatar__btn">
                <i class="icon-plus-circle-1"></i>
              </button>
            </div>
          </div>
          <div class="${content}__control">
            <div class="${content}__links">
              <ul>
                <li>
                  <a href="user-profile">
                    <span>
                      <i class="icon-user-circle"></i>
                    </span>
                    Dados pessoais
                  </a>
                </li>
                <li>
                  <a href="address">
                    <span>
                      <i class="icon-location-circled"></i>
                    </span>
                    Endereços
                  </a>
                </li>
                <li>
                  <a href="phones">
                    <span>
                      <i class="icon-phone-circled"></i>
                    </span>
                    Telefones
                  </a>
                </li>
              </ul>
            </div>  
            <div class="${content}__pages"></div>        
          </div>
        </div>
      </div>
      `;
  },
};
