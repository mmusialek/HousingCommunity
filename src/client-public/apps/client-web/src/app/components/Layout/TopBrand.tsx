import { Button } from "@mui/material";
import { useNavigate } from "react-router";
import { LeftNavbar } from "../LeftNavbar/LeftNavbar";

interface ITopBrand {
  showNavbar: boolean;
}

export const TopBrand = (props: ITopBrand) => {
  const navigate = useNavigate();

  const onHomeClick = () => {
    navigate("/");
  };

  return (
    <>
      {props.showNavbar && <LeftNavbar />}
      <Button onClick={onHomeClick}>H comm</Button>
    </>
  );
};
