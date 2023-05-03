import { RouteObject, createBrowserRouter } from "react-router-dom";
import { MainPage } from "./pages/MainPage";
import { Logout } from "./pages/auth/logout";
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
        path: "logout",
        element: <Logout />,
      },
      {
        path: "profile",
        element: <Profile />,
      },
    ],
  },
];

export const router = createBrowserRouter(routes);
