import './alert.scss';
import { Component } from '../../@core';
import { TAlert } from '../../models';
import { setDelay } from '../../utils';
import template from './template';

const privateProperties = new WeakMap();
/**
 * @class Alert
 * @classdesc component/class Alert
 */
export default class Alert extends Component {
  constructor() {
    super(new TAlert());
    privateProperties.set(this, {
      _defaultSelector: 'c__alert',
    });
  }

  showMessage(type, message) {
    const { _defaultSelector } = privateProperties.get(this);
    const { el } = this;
    this.state = {
      type,
      message,
      icon: type,
    };
    const alert = this.template(
      'div',
      {
        class: `${_defaultSelector}__message ${_defaultSelector}__message--${this.state.type} animated fadeInUp`,
      },
      template.alert(`${_defaultSelector}__message`, this.state.icon, this.state.message)
    );
    el.appendChild(alert);
    setDelay(3000).then(() => {
      alert.innerHTML = '';
      alert.remove();
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector });
    return this.el;
  }
}
