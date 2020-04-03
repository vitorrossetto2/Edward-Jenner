import './address.scss';
import { isMobileDevice, storageUser } from '../../utils';
import { Component } from '../../@core';
import { breadcrumb } from '../../components';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Address
 * @classdesc component/class Address
 */
export default class Address extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__address',
      _defaultName: 'Endereços',
      _defaultIcon: 'icon-location-circled',
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

    this.el = this.template('div', { class: _defaultSelector }, template.address(_defaultSelector, _user));
    if (isMobileDevice()) this.buildBreadcrumb();
    return this.el;
  }
}
