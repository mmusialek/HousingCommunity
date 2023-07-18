import { useEffect } from "react";
import { IAnnouncement } from "../../models";
import { ProgressIndicator } from "../../components";
import { useAnnouncementService, useAnnouncementStore } from "./announcementStore";
import { IWebTableColumn, WebTable } from "../../components/webTable/webTable";

export const Announcements = () => {
  const { getAnnouncements, isLoading } = useAnnouncementService();
  const store = useAnnouncementStore();

  useEffect(() => {
    const data = getAnnouncements();
    store.setAnnouncements(data);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const renderList = () => {
    if (store.announcements.length) {
      const items: IAnnouncement[] = store.announcements;
      const columns: IWebTableColumn<IAnnouncement>[] = [
        {
          name: "author",
          label: "Author",
          render: (item) => {
            return <span>{item.author.email}</span>;
          },
        },
        {
          name: "title",
          label: "Title",
        },
        {
          name: "content",
          label: "Content",
        },
      ];
      const table = <WebTable columns={columns} items={items}></WebTable>;
      return table;
    }

    return <div>no data</div>;
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
