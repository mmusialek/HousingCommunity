import { AuthProviderProps } from "oidc-react";

export const oidcConfig: AuthProviderProps = {
  authority: "https://localhost:7200",
  clientId: "webapp",
  redirectUri: "http://localhost:4200/profile",
};

// const Routes = () => (
//   <AuthProvider {...oidcConfig}>

//   </AuthProvider>
// );
