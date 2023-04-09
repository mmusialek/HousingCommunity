import { RouteObject, createBrowserRouter } from "react-router-dom";
import { MainPage } from "./pages/MainPage";
import { Login } from "./pages/auth/login";
import { Logout } from "./pages/auth/logout";
import { Register } from "./pages/auth/register";
import { Profile } from "./pages/profile/profile";

export interface IRouting {
  routes: RouteObject[];
}

const routes: RouteObject[] = [
  {
    path: "/",
    element: <MainPage />,
    errorElement: <div>error occured :(</div>,
    children: [
      {
        path: "login",
        element: <Login />,
      },
      {
        path: "logout",
        element: <Logout />,
      },
      {
        path: "register",
        element: <Register />,
      },
      {
        path: "profile",
        element: <Profile />,
      },
    ],
  },
];

export const router = createBrowserRouter(routes);
