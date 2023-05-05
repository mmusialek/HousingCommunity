import { useEffect } from "react";
import { IAnnouncement } from "../../models";
import { useAnnouncementService, useAnnouncementStore } from "../../services";
import { StringUtils } from "../../utils";
import { ProgressIndicator } from "../../components";

export const Announcements = () => {
  const { getAnnouncements, isLoading } = useAnnouncementService();
  const store = useAnnouncementStore();

  useEffect(() => {
    const data = getAnnouncements();
    store.setAnnouncements(data);
  }, []);

  const renderAnnouncement = (ann: IAnnouncement) => {
    return (
      <div key={ann.id}>
        <div>{ann.title}</div>
        <div>{StringUtils.formatDate(ann.createdAt)}</div>
        <div>{ann.title}</div>
        <div>{ann.content}</div>
      </div>
    );
  };

  const renderList = () => {
    if(store.announcements.length){

      return <div>{store.announcements.map((q) => renderAnnouncement(q))}</div>;
    }

    return <div>no data</div>
  };

  return (
    <ProgressIndicator size="5rem" isLoading={isLoading}>
      <>
        <div>announcements</div>
        <div>{renderList()}</div>
      </>
    </ProgressIndicator>
  );
};
