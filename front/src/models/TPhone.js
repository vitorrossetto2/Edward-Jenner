export default class TPhone {
  constructor(phone = {}) {
    this.ddd = phone.ddd || null;
    this.number = phone.number || null;
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

  return types[type] || type['default'];
};
