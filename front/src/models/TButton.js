export default class TButton {
  constructor(options = {}) {
    this.type = options.type || 'button';
    this.label = options.label || 'Label';
    this.cssClass = options.cssClass || '';
    this.disabled = options.disabled || false;
  }
}
