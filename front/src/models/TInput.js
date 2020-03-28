export default class TInput {
  constructor(options = {}) {
    this.required = options.required || false;
    this.type = options.type || 'text';
    this.pattern = options.pattern || '';
    this.label = options.label || 'Label';
    this.value = options.value || '';
    this.disabled = options.disabled || false;
  }
}
