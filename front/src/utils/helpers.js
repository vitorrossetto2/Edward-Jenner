import { STRINGS } from '.';

const setDelay = (timer) => {
  return new Promise((resolve) =>
    setTimeout(() => {
      resolve();
    }, timer)
  );
};

const storageUser = (user) => {
  if (!user) {
    return JSON.parse(localStorage.getItem(STRINGS.PROJECT_IDENTIFY)) || false;
  } else {
    localStorage.setItem(STRINGS.PROJECT_IDENTIFY, JSON.stringify(user));
    return user;
  }
};

const isMobileDevice = () => {
  return typeof window.orientation !== 'undefined' || navigator.userAgent.indexOf('IEMobile') !== -1;
};

export { isMobileDevice, setDelay, storageUser };
