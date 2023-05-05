import { RouteObject, createBrowserRouter } from "react-router-dom";
import { Announcements, Logout, MainPage, PageError, Profile } from "../pages";

export interface IRouting {
  routes: RouteObject[];
}

const routes: RouteObject[] = [
  {
    path: "/",
    element: <MainPage />,
    errorElement: <PageError />,
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
