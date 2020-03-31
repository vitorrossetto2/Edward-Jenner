import './login.scss';
import { alert, header } from '../../components';
import { Component } from '../../@core';
import { TUser } from '../../models';
import { checkLogin } from '../../utils';
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

  getChilds() {
    const { el } = this;
    const { _model } = privateProperties.get(this);

    const button = el.querySelector('button');
    button?.addEventListener('click', async (evt) => {
      evt.preventDefault();
      const response = await checkLogin(_model);
      if (response) {
        console.log(header); //eslint-disable-line
        window.location.href = 'portal.html#welcome';
      } else alert.showMessage(1, 'Erro ao efetuar o login');
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
