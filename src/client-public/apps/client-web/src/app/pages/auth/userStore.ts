import { create } from "zustand";
import { IUser } from "../../models";

interface IUserStore {
  currentUser?: IUser | null;
  isLogged: boolean;
  loginUser: (data: IUser) => void;
  logoutUser: () => void;
}


export const useUserStore = create<IUserStore>((set, get) => ({
  currentUser: null,
  isLogged: false,
  loginUser: (data: IUser) => {
    set(() => ({ isLogged: true }))
    set(() => ({ currentUser: data }))
  },
  logoutUser: () => {
    set(() => ({ isLogged: false }))
    set(() => ({ currentUser: null }))
  }
}))
