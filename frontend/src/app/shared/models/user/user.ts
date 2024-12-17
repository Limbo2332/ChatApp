import { IBlobImage } from './blob-image';

export interface IUser {
  id: number;
  email: string;
  userName: string;
  imagePath?: string;
  sqlImage?: IBlobImage;
}
