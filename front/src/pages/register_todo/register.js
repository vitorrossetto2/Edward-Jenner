/* eslint-disable */
import './register.scss';
import { Button, Input } from '../../components';
import { Component, setPrivateProperties } from '../../@core';
import { TUser } from '../../models';
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
      _model: new TUser(),
    });
  }

  checkModel(evt) {
    const { _model, _btnRegister } = privateProperties.get(this);
    const property = evt.target.name;
    _model[property] = evt.target.value;
    setPrivateProperties(privateProperties, this, { _model });
    if (_model.name && _model.email && _model.password) {
      _btnRegister.disabled = false;
    }
  }

  sendForm(data) {
    const { el } = this;
    console.log(data); //eslint-disable-line
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    const handleEventInput = (evt) => {
      this.checkModel(evt);
    };

    const handleClickButton = (evt) => {
      this.sendForm(evt);
    };

    const inputName = new Input({
      label: 'Nome completo:',
      required: true,
      pattern: '.*\\S.*',
      name: 'name',
      callback: handleEventInput,
    });

    const inputEmail = new Input({
      label: 'Email:',
      type: 'mail',
      required: true,
      pattern: '.*\\S.*',
      name: 'email',
      callback: handleEventInput,
    });
    //const inputEmailConfirmation = new Input({ label: 'Confirmar e-mail' });
    const inputPassword = new Input({
      label: 'Senha:',
      type: 'password',
      name: 'password',
      required: true,
      callback: handleEventInput,
    });
    //const inputPasswordConfirmation = new Input({ label: 'Confirmar senha', type: 'password' });
    const btnRegister = new Button({
      label: 'Cadastrar',
      cssClass: '--reverse',
      type: 'submit',
      disabled: true,
      callback: handleClickButton,
    });

    this.el = this.template(
      'div',
      { class: _defaultSelector },
      template.register(
        _defaultSelector,
        inputName.render(),
        inputEmail.render(),
        //inputEmailConfirmation.render(),
        inputPassword.render(),
        //inputPasswordConfirmation.render(),
        btnRegister.render()
      )
    );

    setPrivateProperties(privateProperties, this, { _btnRegister: btnRegister });
    return this.el;
  }
}
