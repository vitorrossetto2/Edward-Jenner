export default {
  input(_defaultSelector, label, name, pattern, type, required) {
    const attrPattern = pattern ? `pattern="${pattern}"` : '';
    const attrRequired = required ? 'required' : '';
    return `        
        <input class="${_defaultSelector}__field" name="${name}" type="${type}" ${attrPattern} ${attrRequired} />
        <label class="${_defaultSelector}__label">${label}</label>
      `;
  },
};
