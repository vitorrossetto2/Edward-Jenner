import './welcome.scss';
import { Component } from '../../@core';
import { header } from '../../components';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Welcome
 * @classdesc component/class Welcome
 */
export default class Welcome extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__welcome',
    });
  }

  dataCharger(data) {
    // data recebida da api ou de algum processamento
    // esse valor vem do router.
    console.log(data); // eslint-disable-line
    header.setNavigation(true);
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.welcome(_defaultSelector));
    return this.el;
  }
}
