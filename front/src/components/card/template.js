export default {
  card(_defaultSelector, state) {
    return `
        <h4 class="${_defaultSelector}__title" data-prop-title>${state.title}</h4>
        <p class="${_defaultSelector}__body" data-prop-body>${state.body}</p>
      `;
  },
};
