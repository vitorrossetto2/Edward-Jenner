import './register.scss';
import { Component } from '../../@core';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Register
 * @classdesc component/class Register
 */

export default class Register extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__register',
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.register());
    return this.el;
  }
}
