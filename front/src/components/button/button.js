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
      _callback: options.callback,
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

  setCallback() {
    const { el } = this;
    const { _callback } = privateProperties.get(this);

    el.onclick = (evt) => {
      evt.preventDefault();
      _callback(evt.target);
    };
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);
    const { label, type, cssClass, disabled } = this.state;
    const otherClass = cssClass ? `${_defaultSelector}${cssClass}` : '';
    this.el = this.template(
      'button',
      {
        class: `${_defaultSelector} ${otherClass}`,
        'data-label': label,
        type,
      },
      label
    );

    if (disabled) {
      this.el.setAttribute('disabled', true);
    }

    this.setCallback();
    return this.el;
  }
}
