import './login.scss';
import { checkLogin, storageUser } from '../../utils';
import { Component } from '../../@core';
import { TUser } from '../../models';
//import { alert } from '../../components';
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
      console.log(response); // eslint-disable-line
      storageUser(
        new TUser({
          logged: false,
          id: 4,
          name: 'Luis Paulo Morais Cardoso',
          username: 'luispmorais',
          email: 'luis.cardoso@xpi.com.br',
          password: '123456',
          avatar:
            'https://avatars2.githubusercontent.com/u/16003741?s=460&u=c236f8e7162185760ebd018a2249486defcef461&v=4',
          birthday: '25/08/1993',
          address: null,
          typeUser: '1',
          description: null,
          keepConnected: null,
        })
      );
      window.location.href = 'portal.html';
      // TODO - descomentar para fazer validação
      // if (response && response.length > 0) {
      //   storageUser(new TUser(response[0]));
      //   window.location.href = 'portal.html';
      // } else alert.showMessage(1, 'Erro ao efetuar o login');
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
