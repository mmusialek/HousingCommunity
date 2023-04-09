
export const oidcConfig = {
  onSignIn: () => {
    // Redirect?
    console.log("sign in redirection!");
  },
  authority: "https://localhost:7200",
  clientId: "webapp",
  redirectUri: "http://localhost:4200/profile",

};

// const Routes = () => (
//   <AuthProvider {...oidcConfig}>

//   </AuthProvider>
// );
