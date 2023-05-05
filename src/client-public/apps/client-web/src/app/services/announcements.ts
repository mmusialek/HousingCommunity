import { IAnnouncement } from './../models/announcements';
import { useState } from 'react';
import { create } from 'zustand';

export const useAnnouncementService = () => {
  const [isLoading, setIsLoading] = useState(false);
  const getAnnouncements = (): IAnnouncement[] => {
    setIsLoading(true);
    //get data
    setIsLoading(false);
    return [];
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
