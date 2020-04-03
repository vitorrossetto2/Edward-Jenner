import { STRINGS, URLS } from './constants';
import { checkLogin, registerUser } from './requests';
import { isMobileDevice, setDelay, storageUser } from './helpers';
import { loadPolyfills } from './polyfills';

export { STRINGS, URLS, loadPolyfills, isMobileDevice, setDelay, storageUser, checkLogin, registerUser };
