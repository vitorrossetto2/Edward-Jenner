import './profile.scss';
import { Address, Phones, UserProfile } from '../index';
import { Component, setPrivateProperties } from '../../@core';
import { isMobileDevice, storageUser } from '../../utils';
import { spinner } from '../../components';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Profile
 * @classdesc component/class Profile
 */
export default class Profile extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__profile',
      _user: storageUser(),
    });
  }

  navigationEventHandlers() {
    const { el } = this;
    Array.from(el.querySelectorAll('a'))?.forEach((item) => {
      item.addEventListener('click', function (evt) {
        evt.preventDefault();
        if (isMobileDevice()) {
          const route = this.getAttribute('href')?.replace('#', '');
          if (route) window.router?.routeChange(route);
        }
      });
    });
  }

  preparePages() {
    const { _defaultSelector } = privateProperties.get(this);
    const { el } = this;
    const contentPages = el.querySelector(`.${_defaultSelector}__content__pages`);
    const pages = [
      {
        route: 'user-profile',
        page: UserProfile,
      },
      {
        route: 'address',
        page: Address,
      },
      {
        route: 'phones',
        page: Phones,
      },
    ];

    contentPages.appendChild(new pages[2].page().render());
    setPrivateProperties(privateProperties, this, { contentPages, pages });
  }

  render() {
    const { _defaultSelector, _user } = privateProperties.get(this);
    spinner.show(false);
    this.el = this.template('div', { class: _defaultSelector }, template.profile(_defaultSelector, _user));
    this.navigationEventHandlers();
    if (!isMobileDevice()) this.preparePages();
    return this.el;
  }
}
