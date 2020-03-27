import './card.scss';
import { Component, setPrivateProperties } from '../../@core';
import { TCard } from '../../models';
import template from './template.js';

const privateProperties = new WeakMap();

/**
 * @class Card
 * @classdesc component/class Card
 */
export default class Card extends Component {
  constructor(card = {}) {
    super(new TCard(card));
    setPrivateProperties(privateProperties, this, {
      _defaultSelector: 'c__card',
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);
    const { state } = this;

    this.el = this.template('div', { class: _defaultSelector }, template.card(_defaultSelector, state));
    window.card = this;
    return this.el;
  }
}
