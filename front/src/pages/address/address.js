import './address.scss';
import { Component, setPrivateProperties } from '../../@core';
import { breadcrumb, spinner } from '../../components';
import { getAddressWithCEP, isMobileDevice } from '../../utils';
import { TAddress } from '../../models';
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
      _address: new TAddress(),
    });
  }

  buildBreadcrumb() {
    const { el } = this;
    const { _defaultName, _defaultIcon } = privateProperties.get(this);
    el.appendChild(breadcrumb.render({ name: _defaultName, icon: _defaultIcon }));
  }

  getChilds() {
    const { el } = this;
    const { _address } = privateProperties.get(this);
    const fieldCEP = el.querySelector('[name="cep"]');
    const _button = el.querySelector('button');
    setPrivateProperties(privateProperties, this, { _button });

    Array.from(el.querySelectorAll('.c__input__field')).forEach((item) => {
      item.addEventListener('change', (evt) => {
        _address[evt.target.getAttribute('name')] = evt.target.value;
        setPrivateProperties(privateProperties, this, { _address });
        this.checkModelToSend();
      });
    });
    fieldCEP.addEventListener('change', async (evt) => {
      evt.preventDefault();
      this.getCEP(evt.target);
    });
  }

  checkModelToSend() {
    const { _button } = privateProperties.get(this);
    const { street, number, neighborhood, state, country, type } = privateProperties.get(this)['_address'];

    if (street && number && neighborhood && state && country && type) {
      _button.removeAttribute('disabled');
    } else {
      _button.setAttribute('disabled', true);
    }
  }

  async getCEP(element) {
    const { el } = this;
    const { _address } = privateProperties.get(this);
    const cep = element.value.replace(/\D/g, '');
    if (cep && /^[0-9]{8}$/.test(cep)) {
      const response = await getAddressWithCEP(cep);
      if (response) {
        const address = {
          cep,
          street: response.logradouro,
          neighborhood: response.bairro,
          city: response.localidade,
          state: response.uf,
        };
        Object.assign(_address, address);
        setPrivateProperties(privateProperties, this, { _address });
        for (const [k, v] of Object.entries(_address)) {
          const input = el.querySelector(`input[name="${k}"]`);
          if (input) input.value = v;
        }
      }
    }
  }

  render() {
    const { _defaultSelector, _address } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.address(_defaultSelector, _address));
    if (isMobileDevice()) this.buildBreadcrumb();
    spinner.show(false);
    this.getChilds();
    return this.el;
  }
}
