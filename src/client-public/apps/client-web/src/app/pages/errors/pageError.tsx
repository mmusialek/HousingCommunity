import { EmptyLayout } from "../../components";
import { GenericError as ErrorTeaser } from "../../components/error/genericError";

export const PageError = () => {
  return (
    <EmptyLayout>
      <ErrorTeaser message="error occured :(" />
    </EmptyLayout>
  );
};
