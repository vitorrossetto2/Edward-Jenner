import { get, post } from './service';
import { URLS } from '.';

const headers = {
  'Content-Type': 'application/json',
};

const checkLogin = async (user) => {
  try {
    // alterar método para post
    const url = `${URLS.API_PATH}/users?email=${user.email}&password=${user.password}`;
    return await get(url, headers, true);
  } catch (err) {
    console.log(err); // eslint-disable-line
    return false;
  }
};

const registerUser = async (user) => {
  try {
    const url = `${URLS.API_PATH}/register`;
    return await post(url, JSON.stringify(user), headers, true);
  } catch (err) {
    console.log(err); // eslint-disable-line
    return false;
  }
};

export { checkLogin, registerUser };
