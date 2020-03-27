import './login.scss';
import { Component } from '../../@core';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Login
 * @classdesc component/class Login
 */
export default class Login extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__login',
    });
  }

  dataCharger(data) {
    // data recebida da api ou de algum processamento
    // esse valor vem do router.
    console.log(data); // eslint-disable-line
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.login());
    return this.el;
  }
}
