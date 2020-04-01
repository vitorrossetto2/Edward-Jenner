export default class TUser {
  constructor(user = {}) {
    this.logged = user.logged || false;
    this.id = user.id || null;
    this.name = user.name || null;
    this.email = user.email || null;
    this.password = user.password || null;
    this.avatar = user.avatar || null;
    this.address = user.address || null;
    this.typeUser = typeUser(user.type);
    this.lat = user.lat || null;
    this.lon = user.lon || null;
    this.age = user.age || null;
    this.description = user.description || null;
    this.keepConnected = false || null;
  }
}

const typeUser = (type) => {
  const types = {
    risc: 0,
    help: 1,
    business: 2,
  };

  return types[type];
};
