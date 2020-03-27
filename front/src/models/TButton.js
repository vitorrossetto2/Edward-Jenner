export default class TButton {
  constructor(options = {}) {
    this.label = options.label || 'Label';
    this.cssClass = options.cssClass || '';
    this.disabled = options.disabled || false;
  }
}
