import './phones.scss';
import { breadcrumb, spinner } from '../../components';
import { Component } from '../../@core';
import { TPhone } from '../../models';
import { isMobileDevice } from '../../utils';
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
      _phone: new TPhone(),
    });
  }

  buildBreadcrumb() {
    const { el } = this;
    const { _defaultName, _defaultIcon } = privateProperties.get(this);
    el.appendChild(breadcrumb.render({ name: _defaultName, icon: _defaultIcon }));
  }

  getChilds() {
    const { _phone } = privateProperties.get(this);
    const { el } = this;
    const button = el.querySelector('button');

    Array.from(el.querySelectorAll('.c__input__field'))?.forEach((item) => {
      item.addEventListener('change', (evt) => {
        const property = evt.target.getAttribute('name');
        _phone[property] = evt.target.value;
        if (_phone.ddd && _phone.number) {
          button.removeAttribute('disabled');
        } else {
          button.setAttribute('disabled', true);
        }
      });
    });
  }

  render() {
    const { _defaultSelector, _phone } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.phones(_defaultSelector, _phone));
    if (isMobileDevice()) this.buildBreadcrumb();
    this.getChilds();
    spinner.show(false);
    return this.el;
  }
}
