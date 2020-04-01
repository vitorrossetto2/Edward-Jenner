export default class TAlert {
  constructor(alert = {}) {
    this.message = alert.message || '';
    this.type = alert.type;
    this.icon = alert.type;
  }

  get icon() {
    return this._icon;
  }

  set icon(type) {
    this._icon = alertIcon(type);
    return;
  }

  get type() {
    return this._type;
  }

  set type(value) {
    this._type = alertType(value);
    return;
  }
}

const alertType = (type) => {
  const types = {
    0: 'success',
    1: 'error',
    2: 'info',
    3: 'warning',
    default: 'info',
  };

  return types[type] || types['default'];
};

const alertIcon = (type) => {
  const types = {
    0: 'icon-ok-circled2-1',
    1: 'icon-cancel-circled-outline',
    2: 'icon-info-circled-alt',
    3: 'icon-warning-empty',
    default: 'info',
  };

  return types[type] || types['default'];
};
