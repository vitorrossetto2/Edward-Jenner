export default class TAddress {
  constructor(address = {}) {
    this.cep = address.cep || '';
    this.country = address.country || '';
    this.state = address.state || '';
    this.city = address.city || '';
    this.neighborhood = address.neighborhood || '';
    this.street = address.street || '';
    this.number = address.number || '';
    this.complement = address.complement || '';
    this.type = address.type;
  }

  set type(type) {
    this._type = type;
    return;
  }

  get type() {
    return typeAddress(this._type);
  }
}

const typeAddress = (type) => {
  const types = {
    0: 'Casa',
    1: 'Trabalho',
    2: 'Outro',
    default: 'Casa',
  };
  return types[type] || types['default'];
};
