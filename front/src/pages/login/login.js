import './login.scss';
import { Component } from '../../@core';
import { TUser } from '../../models';
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
      _model: new TUser(),
    });
  }

  dataCharger(data) {
    // data recebida da api ou de algum processamento
    // esse valor vem do router.
    console.log(data); // eslint-disable-line
  }

  getChilds() {
    const { el } = this;
    const { _model } = privateProperties.get(this);

    const button = el.querySelector('button');
    button?.addEventListener('click', () => {
      console.log(_model); // eslint-disable-line
      window.router.routeChange('map');
    });

    Array.from(el.querySelectorAll('input'))?.forEach((input) => {
      input.addEventListener('change', (evt) => {
        const property = evt.target.name;
        _model[property] = evt.target.value;
        if (_model.email && _model.password) button?.removeAttribute('disabled');
        else button?.setAttribute('disabled', true);
      });
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.login(_defaultSelector));
    this.getChilds();
    return this.el;
  }
}
