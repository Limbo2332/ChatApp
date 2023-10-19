import { IAccessToken } from '../token/access-token';
import { IUser } from './user';

export interface IAuthUser {
  user: IUser;
  token: IAccessToken;
}
