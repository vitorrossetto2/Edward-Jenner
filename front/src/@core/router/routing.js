import { Education, Home, Login, Map, Nearby, Register } from '../../pages';
import { resolveUser } from './resolvers';

const routes = [
  {
    path: '/',
    component: new Home(),
  },
  {
    path: 'education',
    component: new Education(),
  },
  {
    path: 'home',
    component: new Home(),
  },
  {
    path: 'login',
    component: new Login(),
    resolve: resolveUser,
  },
  {
    path: 'register',
    component: new Register(),
  },
  {
    path: 'welcome',
    component: {},
    resolve: resolveUser,
  },
  {
    path: 'nearby',
    component: new Nearby(),
  },
  {
    path: 'map',
    component: new Map(),
  },
];

export { routes };
