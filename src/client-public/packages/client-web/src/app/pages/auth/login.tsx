import { Button, TextField } from "@mui/material";
import { Controller, useForm } from "react-hook-form";
import styles from "./login.module.scss";
import { AuthProvider } from "oidc-react";
import { oidcConfig } from "./authHandling";

export const Login = () => {
  // const { handleSubmit, control } = useForm({ mode: "onBlur", reValidateMode: "onBlur", criteriaMode: "all" });

  // const onSubmit = (data: unknown) => {
  //   alert(`submitted: ${JSON.stringify(data)}`);
  // };

  // return <AuthProvider {...oidcConfig}></AuthProvider>;
  return <div>nothing here</div>;
  // return (
  //   <div className={styles.login}>
  //     <form onSubmit={handleSubmit(onSubmit)}>
  //       <div className={styles.login__username}>
  //         <Controller
  //           name="username"
  //           control={control}
  //           render={() => {
  //             return <TextField label="Username" type="text" />;
  //           }}
  //         />
  //       </div>
  //       <div className={styles.login__password}>
  //         <TextField label="Password" type="password" />
  //       </div>
  //       <div className={styles.login__actions}>
  //         <Button type="submit" variant="outlined">
  //           submit
  //         </Button>
  //       </div>
  //     </form>
  //   </div>
  // );
};
