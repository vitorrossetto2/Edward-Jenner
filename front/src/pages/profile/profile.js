import './profile.scss';
import { Component } from '../../@core';
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
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.profile(_defaultSelector));
    return this.el;
  }
}
