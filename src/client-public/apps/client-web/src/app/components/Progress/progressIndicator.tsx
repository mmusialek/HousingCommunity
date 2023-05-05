import { CircularProgress } from "@mui/material";

interface IProgressIndicator {
  children: JSX.Element;
  size: string;
  isLoading: boolean;
}

export const ProgressIndicator = (props: IProgressIndicator) => {
  return props.isLoading ? <CircularProgress size="5" /> : props.children;
};
