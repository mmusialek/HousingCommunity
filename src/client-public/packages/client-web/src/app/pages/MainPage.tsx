import { Outlet } from "react-router";
import { Layout } from "../components/Layout";
import { ThemeProvider } from "@emotion/react";
import { CssBaseline, createTheme, responsiveFontSizes } from "@mui/material";
import { AuthProvider } from "oidc-react";
import { oidcConfig } from "./auth/authHandling";

let theme = createTheme({
  palette: {
    mode: "dark",
  },
});
theme = responsiveFontSizes(theme);

export const MainPage = () => {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <AuthProvider {...oidcConfig}>
        <Layout>
          <Outlet />
        </Layout>
      </AuthProvider>
    </ThemeProvider>
  );
};
