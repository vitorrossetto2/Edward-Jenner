import { Address, List, Map, Phones, Profile, UserProfile } from '../../../pages';
import { resolveUser } from './resolvers';
import { userIsLogged } from './guards';

const routes = [
  {
    path: '',
    page: List,
    resolve: resolveUser,
    guard: userIsLogged,
  },
  {
    path: 'list',
    page: List,
    resolve: resolveUser,
    guard: userIsLogged,
  },
  {
    path: 'profile',
    page: Profile,
    guard: userIsLogged,
  },
  {
    path: 'map',
    page: Map,
    guard: userIsLogged,
  },
  {
    path: 'user-profile',
    page: UserProfile,
    guard: userIsLogged,
  },
  {
    path: 'phones',
    page: Phones,
    guard: userIsLogged,
  },
  {
    path: 'address',
    page: Address,
    guard: userIsLogged,
  },
  {
    path: '**',
    page: 'index.html#login',
  },
];

export { routes };
