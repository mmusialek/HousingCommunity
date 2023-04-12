import { useNavigate } from "react-router";

export const TopMenu = () => {
  const navigate = useNavigate();

  return (
    <>
      <button onClick={() => { navigate("/login") }}>login</button>
      <button onClick={() => { navigate("/logout") }}>logout</button>
      <button onClick={() => { navigate("/register") }}>register</button>
    </>)
}