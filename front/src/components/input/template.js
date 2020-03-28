export default {
  input(_defaultSelector, label, pattern, type, required) {
    const attrPattern = pattern ? `pattern="${pattern}"` : '';
    const attrRequired = required ? 'required' : '';
    return `        
        <input class="${_defaultSelector}__field" type="${type}" ${attrPattern} ${attrRequired} />
        <label class="${_defaultSelector}__label">${label}</label>
      `;
  },
};
