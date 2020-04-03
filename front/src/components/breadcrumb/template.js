export default {
  breadcrumb(_defaultSelector, config) {
    return `
        <div class="container">
          <div class="${_defaultSelector}__content">
            <button alt="button" title="Voltar">
              <i class="icon-left-open"></i>
            </button>
            <div class="${_defaultSelector}__content__actual">
              <span>
                <i class="${config.icon}"></i>                
              </span>
              ${config.name}
            </div>
          </div>
        </div>
      `;
  },
};
