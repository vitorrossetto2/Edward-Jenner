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
          'bla bla bla',
        },
      request: {
        items: [
          {
            id: 1,
            nome: 'Item x',
            quantidade: 12,
            precoMaximo: 30.50
          },
          {
            id: 2,
            nome: 'Item x',
            quantidade: 12,
            precoMaximo: 30.50
          }
        ],
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
