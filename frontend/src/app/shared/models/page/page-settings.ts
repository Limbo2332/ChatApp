import { IPageFiltering } from './page-filtering';
import { IPagePagination } from './page-pagination';

export interface IPageSettings {
  filter?: IPageFiltering;
  pagination?: IPagePagination;
}
