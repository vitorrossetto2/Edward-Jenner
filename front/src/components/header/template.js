export default {
  header(_defaultSelector, navigation) {
    return `
      <div class="container">
        <div class="${_defaultSelector}__logotipo">
          
        </div>
        <div class="${_defaultSelector}__control__navigation">
          <button alt="menu" title="menu"><i class="icon-menu-1"></i></button>
        </div>
        <div class="${_defaultSelector}__navigation">
          <div class="${_defaultSelector}__navigation__logotipo"></div>
          ${navigation}
        </div>
      </div>
    `;
  },
  navigation(_defaultSelector, _items) {
    return `      
      <ul>
        ${_items
          .map((item) => {
            return `
            <li>
              <a href="#${item.route}" data-router-link>
                <span>
                  <i class="${item.icon}"></i>
                </span>
                ${item.name}
              </a>
            </li>
          `;
          })
          .join('')}
      </ul>      
    `;
  },
};
