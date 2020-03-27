export default {
  spinner(_defaultSelector) {
    return `
      <div class="${_defaultSelector}__content">
        <h1>Carregando...</h1>
        <span>Fazer um spinner descente e animado</span>
      </div>
      `;
  },
};
