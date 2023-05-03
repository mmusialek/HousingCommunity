import { Button, IconButton } from "@mui/material";
import { useNavigate } from "react-router";
import MenuIcon from "@mui/icons-material/Menu";
import { useState } from "react";
import { LeftNavbar } from "./LeftNavbar/LeftNavbar";

export const TopBrand = () => {
  const navigate = useNavigate();
  const [isOpened, setIsOpened] = useState(false);

  const onHomeClick = () => {
    navigate("/");
  };

  const toggleMenu = () => {
    setIsOpened(!isOpened);
  };

  return (
    <>
      {/* <IconButton onClick={() => toggleMenu()}>{<MenuIcon />}</IconButton> */}
      <LeftNavbar />
      <Button onClick={onHomeClick}>H comm</Button>
    </>
  );
};
