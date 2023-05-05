import { IUser } from "./user";

export interface IAnnouncement {
  id: string;
  createdAt: Date;
  validTo: Date;

  author: IUser;
  title: string;
  content: string;
}
