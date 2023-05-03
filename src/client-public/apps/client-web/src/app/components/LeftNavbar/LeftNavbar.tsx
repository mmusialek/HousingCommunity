import * as React from "react";
import { Divider, Drawer, IconButton, List, ListItem, ListItemButton, ListItemIcon, ListItemText } from "@mui/material";
import MailIcon from "@mui/icons-material/Mail";
import { useState } from "react";
import MenuIcon from "@mui/icons-material/Menu";
import ChevronLeftIcon from "@mui/icons-material/ChevronLeft";

export const LeftNavbar = () => {
  const [isOpened, setIsOpened] = useState(false);

  const getMenuItem = (text: string, onMenuClick: (event: React.MouseEvent<HTMLElement> | undefined) => void) => {
    return (
      <ListItem key={text} disablePadding>
        <ListItemButton>
          <ListItemIcon>
            <MailIcon />
          </ListItemIcon>
          <ListItemText primary={text} onClick={onMenuClick} />
        </ListItemButton>
      </ListItem>
    );
  };

  const list = () => {
    const defaultHandler = (event: React.MouseEvent<HTMLElement> | undefined) => {
      alert(event?.target);
    };

    return (
      <List>
        {getMenuItem("Item 1", () => defaultHandler({ target: "Item 1" } as any))}
        {getMenuItem("Item 2", () => defaultHandler({ target: "Item 2" } as any))}
        <Divider />
        {getMenuItem("Item 3", () => defaultHandler({ target: "Item 3" } as any))}
        {getMenuItem("Item 4", () => defaultHandler({ target: "Item 4" } as any))}
      </List>
    );
  };

  const toggleDrawer = (openState: boolean) => (event: React.KeyboardEvent | React.MouseEvent) => {
    if (event.type === "keydown" && ((event as React.KeyboardEvent).key === "Tab" || (event as React.KeyboardEvent).key === "Shift")) {
      return;
    }

    setIsOpened(openState);
  };

  return (
    <>
      {isOpened ? (
        <IconButton onClick={toggleDrawer(false)}>{<ChevronLeftIcon />}</IconButton>
      ) : (
        <IconButton onClick={toggleDrawer(true)}>{<MenuIcon />}</IconButton>
      )}
      <Drawer anchor="left" open={isOpened} onClose={toggleDrawer(false)}>
        {list()}
      </Drawer>
    </>
  );
};
