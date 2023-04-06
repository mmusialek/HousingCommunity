import { Controller, useForm } from "react-hook-form";
import styles from "./register.module.scss";
import { TextField, Button } from "@mui/material";

export const Register = () => {
  const { handleSubmit, control } = useForm({ mode: "onBlur", reValidateMode: "onBlur", criteriaMode: "all" });

  const onSubmit = (data: unknown) => {
    alert(`submitted: ${JSON.stringify(data)}`);
  };

  return (
    <div className={styles.register}>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className={styles.register__item}>
          <Controller
            name="username"
            control={control}
            render={() => {
              return <TextField label="Username" type="text" />;
            }}
          />
        </div>
        <div className={styles.register__item}>
          <Controller
            name="email"
            control={control}
            render={() => {
              return <TextField label="Email" type="text" />;
            }}
          />
        </div>
        <div className={styles.register__actions}>
          <Button type="button">przypomnij hasło</Button>
          <Button type="submit" variant="outlined">
            submit
          </Button>
        </div>
      </form>
    </div>
  );
};
