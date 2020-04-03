import './phones.scss';
import { isMobileDevice, storageUser } from '../../utils';
import { Component } from '../../@core';
import { breadcrumb } from '../../components';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Phones
 * @classdesc component/class Phones
 */
export default class Phones extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__phones',
      _defaultName: 'Telefones',
      _defaultIcon: 'icon-phone-circled',
      _user: storageUser(),
    });
  }

  buildBreadcrumb() {
    const { el } = this;
    const { _defaultName, _defaultIcon } = privateProperties.get(this);
    el.appendChild(breadcrumb.render({ name: _defaultName, icon: _defaultIcon }));
  }

  render() {
    const { _defaultSelector, _user } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.phones(_defaultSelector, _user));
    if (isMobileDevice()) this.buildBreadcrumb();
    return this.el;
  }
}
