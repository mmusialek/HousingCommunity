import { useNavigate } from "react-router";
import { BottomTeaser } from "./BottomTeaser";

interface Props {
  children: JSX.Element;
}

export const Layout = (props: Props) => {
  const navigate = useNavigate();

  return (
    <div>
      <div>
        <button onClick={() => {navigate("/login")}}>login</button>
        <button onClick={() => {navigate("/logout")}}>logout</button>
        <button onClick={() => {navigate("/register")}}>register</button>
      </div>
      <div>{props.children}</div>
      <div>
        <BottomTeaser />
      </div>
    </div>
  );
};
