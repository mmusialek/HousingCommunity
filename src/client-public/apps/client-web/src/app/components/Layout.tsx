import { useAuth } from "oidc-react";
import { BottomTeaser } from "./BottomTeaser";
import styles from "./Layout.module.scss";
import { TopBrand } from "./TopBrand";
import { TopMenu } from "./TopMenu";
import { TopUserActions } from "./TopUserActions";
import { CircularProgress } from "@mui/material";

interface Props {
  children: JSX.Element;
}

export const Layout = (props: Props) => {
  const auth = useAuth();

  const getLoader = () => {
    return (
      <div className={styles.loader}>
        <CircularProgress size="5rem" />
      </div>
    );
  };

  const getLayout = () => {
    return (
      <div className={styles.layout}>
        <div className={styles.layout__top}>
          <div>
            <TopBrand />
          </div>
          <div>
            <TopMenu />
          </div>
          <div>
            <TopUserActions />
          </div>
        </div>
        <div className={styles.layout__content}>{props.children}</div>
        <div className={styles.layout__bottom}>
          <BottomTeaser />
        </div>
      </div>
    );
  };

  return auth.isLoading ? getLoader() : getLayout();
};
