export default {
  alert(_defaultSelector, icon, message) {
    return `
        <div class="${_defaultSelector}__icon">
          <i class="${icon}"></i>
        </div>        
        <p>${message}</p>
      `;
  },
};
