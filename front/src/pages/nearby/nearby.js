import './nearby.scss';
import { Button } from '../../components';
import { Component } from '../../@core';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Nearby
 * @classdesc component/class Nearby
 */
export default class Nearby extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__nearby',
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    const btnGetRequest = new Button({ label: 'Pegar Pedido' });

    const nearbyMock = {
      client: {
        name: 'Claudio Alves',
        distance: 2,
        image: 'https://imagens.publico.pt/imagens.aspx/1406209?tp=UH&db=IMAGENS&type=JPG',
        description:
          'Eu sou um senhor amável e possuo uma senhora maravilhosa, gostaria de uma alma querida para ir ao mercado para mim, pois estou no grupo de risco.',
      },
      request: {
        items: ['Item A', 'Item B', 'Item C', 'Item D', 'Item E', 'Item F', 'Item G', 'Item H'],
      },
    };

    this.el = this.template(
      'div',
      { class: _defaultSelector },
      template.nearby(_defaultSelector, nearbyMock, btnGetRequest)
    );
    return this.el;
  }
}
