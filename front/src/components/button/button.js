import './button.scss';
import { Component } from '../../@core';
import { TButton } from '../../models';

const privateProperties = new WeakMap();
/**
 * @class Button
 * @classdesc component/class Button
 */
export default class Button extends Component {
  constructor(options = {}) {
    super(new TButton(options));
    privateProperties.set(this, {
      _defaultSelector: 'c__button',
    });
  }

  set disabled(val) {
    this.state = { ...this.state, disabled: val };
    !val ? this.el.removeAttribute('disabled') : this.el.setAttribute('disabled', true);
  }

  set label(val) {
    this.state = { ...this.state, label: val };
    this.el.innerText = val;
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);
    const { label, cssClass, disabled } = this.state;
    this.el = this.template(
      'button',
      {
        class: `${_defaultSelector} ${_defaultSelector}${cssClass}`,
        'data-label': label,
      },
      label
    );

    if (disabled) {
      this.el.setAttribute('disabled', true);
    }
    window[`button${label}`] = this;
    return this.el;
  }
}
