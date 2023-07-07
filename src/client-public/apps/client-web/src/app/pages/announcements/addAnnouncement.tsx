import { TextField } from "@mui/material";
import { Controller, useForm } from "react-hook-form";

export const AddAnnouncement = () => {
  const { control, handleSubmit } = useForm();

  const onSubmit = () => {
    //
  };

  const renderAddForm = () => {
    return (
      <form onSubmit={handleSubmit(onSubmit)}>
        <Controller
          name="checkbox"
          control={control}
          rules={{ required: true }}
          render={() => <TextField id="outlined-basic" label="Outlined" variant="outlined" />}
        />
        <input type="submit" />
      </form>
    );
  };

  return <div>{renderAddForm()}</div>;
};
