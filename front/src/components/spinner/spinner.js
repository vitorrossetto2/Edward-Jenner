import './spinner.scss';
import { Component } from '../../@core';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Spinner
 * @classdesc component/class Spinner
 */
export default class Spinner extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__spinner',
    });
  }

  show(show) {
    const { el } = this;
    const { _defaultSelector } = privateProperties.get(this);
    const open = `${_defaultSelector}--open`;
    show ? el.classList.add(open) : el.classList.remove(open);
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.spinner(_defaultSelector));
    return this.el;
  }
}
