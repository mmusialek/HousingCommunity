import { RouteObject, createBrowserRouter } from "react-router-dom";
import { MainPage } from "./pages/MainPage";
import { Logout } from "./pages/auth/logout";
import { Profile } from "./pages/profile/profile";
import { Announcements } from "./pages/announcements/announcements";

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
      {
        path: "announcements",
        element: <Announcements />,
      },
    ],
  },
];

export const router = createBrowserRouter(routes);
