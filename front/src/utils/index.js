import { STRINGS, URLS } from './constants';
import { checkLogin, registerUser } from './requests';
import { setDelay, storageUser } from './helpers';
import { loadPolyfills } from './polyfills';

export { STRINGS, URLS, loadPolyfills, setDelay, storageUser, checkLogin, registerUser };
