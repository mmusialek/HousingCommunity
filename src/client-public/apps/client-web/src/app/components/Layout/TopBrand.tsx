import { Button } from "@mui/material";
import { useNavigate } from "react-router";
import { LeftNavbar } from "../LeftNavbar/LeftNavbar";

export const TopBrand = () => {
  const navigate = useNavigate();

  const onHomeClick = () => {
    navigate("/");
  };

  return (
    <>
      <LeftNavbar />
      <Button onClick={onHomeClick}>H comm</Button>
    </>
  );
};
