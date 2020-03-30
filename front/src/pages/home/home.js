import './home.scss';
import { Button, Card } from '../../components';
import { Component } from '../../@core';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Home
 * @classdesc component/class Home
 */
export default class Home extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__home',
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);
    const btnCadastro = new Button({
      label: 'Cadastro',
      callback: () => {
        window.router?.routeChange('register');
      },
    });
    const btnLogin = new Button({
      label: 'Login',
      cssClass: '--secondary',
      callback: () => {
        window.router?.routeChange('login');
      },
    });
    const card = new Card({
      title: 'Título do card',
      body: 'Corpo do card',
    });

    /* exemplo de alteração de state card */
    setTimeout(() => {
      card.state = { title: 'New title' }; // alterando apenas uma propriedade
    }, 3000);

    setTimeout(() => {
      card.state = { title: 'Other title', body: 'New body' }; // alterando várias propriedades
    }, 5000);

    this.el = this.template(
      'div',
      { class: _defaultSelector },
      template.home(_defaultSelector, btnCadastro, btnLogin, card)
    );
    return this.el;
  }
}
