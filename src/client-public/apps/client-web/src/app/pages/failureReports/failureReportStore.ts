import { useState } from "react";
import { IFailureReport } from "../../models";
import { create } from "zustand";

export const useFailureReportService = () => {
  const [isLoading, setIsLoading] = useState(false);
  const getData = () => {
    setIsLoading(true);
    // TODO get data
    setIsLoading(false);
    return [];
  }

  return ({
    isLoading, getData
  })
}

interface IFailureRepostStore {
  items: IFailureReport[];
  setItems: (items: IFailureReport[]) => void;
}

export const useFailureReportStore = create<IFailureRepostStore>((set) => ({
  items: [],
  setItems: (data: IFailureReport[]) => set(() => ({ items: data }))
}))

