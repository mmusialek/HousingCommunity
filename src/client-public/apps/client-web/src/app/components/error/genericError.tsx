interface IGenericError {
  message: string;
}

export const GenericError = (props: IGenericError) => {
  return <div>{props.message}</div>;
};
