import './register.scss';
import { Button, Input } from '../../components';
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

    const btnRegister = new Button({ label: 'Cadastrar', cssClass: '--reverse' });
    const inputName = new Input({ label: 'Nome' });
    const inputEmail = new Input({ label: 'Email' });
    const inputEmailConfirmation = new Input({ label: 'Confirmar e-mail' });
    const inputPassword = new Input({ label: 'Senha', type: 'password' });
    const inputPasswordConfirmation = new Input({ label: 'Confirmar senha', type: 'password' });
    this.el = this.template(
      'div',
      { class: _defaultSelector },
      template.register(
        _defaultSelector,
        inputName.render(),
        inputEmail.render(),
        inputEmailConfirmation.render(),
        inputPassword.render(),
        inputPasswordConfirmation.render(),
        btnRegister.render()
      )
    );
    return this.el;
  }
}
