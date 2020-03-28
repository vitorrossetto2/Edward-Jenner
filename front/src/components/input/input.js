import './input.scss';
import { Component } from '../../@core';
import { TInput } from '../../models';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Input
 * @classdesc component/class Input
 */
export default class Input extends Component {
  constructor(options = {}) {
    super(new TInput(options));
    privateProperties.set(this, {
      _defaultSelector: 'c__input',
      _callback: options.callback || false,
    });
  }

  handleEvent() {
    const { _callback } = privateProperties.get(this);
    const { input } = this;
    if (!_callback) return;

    input.addEventListener('blur', (evt) => {
      _callback(evt);
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);
    const { label, name, pattern, type, required } = this.state;

    this.el = this.template(
      'div',
      {
        class: _defaultSelector,
      },
      template.input(_defaultSelector, label, name, pattern, type, required)
    );
    this.input = this.el.querySelector('input');
    this.handleEvent();
    return this.el;
  }
}
