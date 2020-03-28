export default class TUser {
  constructor(user = {}) {
    this.name = user.name;
    this.email = user.email;
    this.password = user.password;
    this.avatar = user.avatar;
    this.address = user.address;
    this.typeUser = typeUser(user.type);
    this.lat = user.lat;
    this.lon = user.lon;
    this.age = user.age;
    this.description = user.description;
  }
}

const typeUser = (type) => {
  const types = {
    risc: 0,
    help: 1,
    business: 2,
    default: 0,
  };

  return types[type] || types['default'];
};
