import { IAnnouncement } from '../../models/announcements';
import { useState } from 'react';
import { create } from 'zustand';
import { IUser } from '../../models';

export const useAnnouncementService = () => {
  const [isLoading, setIsLoading] = useState(false);
  const getAnnouncements = (): IAnnouncement[] => {
    setIsLoading(true);

    const res: IAnnouncement[] = [
      {
        id: "111-111-111",
        author: { email: "mock1@email.com" } as IUser,
        content: "mock content",
        title: "title 1",
        validTo: new Date(),
        createdAt: new Date()
      },
      {
        id: "222-222-222",
        author: { email: "mock2@email.com" } as IUser,
        content: "mock content",
        title: "title 2",
        validTo: new Date(),
        createdAt: new Date()
      },
      {
        id: "333-333-333",
        author: { email: "mock3@email.com" } as IUser,
        content: "mock content",
        title: "title 3",
        validTo: new Date(),
        createdAt: new Date()
      }
    ];

    setIsLoading(false);

    return res;
  }

  return ({
    isLoading, getAnnouncements
  })
}

interface IAnnouncementStore {
  announcements: IAnnouncement[];
  setAnnouncements: (data: IAnnouncement[]) => void;
}

export const useAnnouncementStore = create<IAnnouncementStore>((set) => ({
  announcements: [],
  setAnnouncements: (data: IAnnouncement[]) => set(() => ({ announcements: data }))
}))
