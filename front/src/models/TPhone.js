export default class TPhone {
  constructor(phone = {}) {
    this.ddd = phone.ddd || '';
    this.number = phone.number || '';
    this.type = phone.type;
  }

  get type() {
    return phoneTypes(this._type);
  }

  set type(type) {
    this._type = type;
    return;
  }
}

const phoneTypes = (type) => {
  const types = {
    0: 'Casa',
    1: 'Celular',
    default: 'Casa',
  };

  return types[type] || types['default'];
};
