import { useAuth } from "oidc-react";
import { BottomTeaser } from "./BottomTeaser";
import styles from "./Layout.module.scss";
import { TopBrand } from "./TopBrand";
import { TopMenu } from "./TopMenu";
import { TopUserActions } from "./TopUserActions";
import { ProgressIndicator } from "../Progress/progressIndicator";

interface Props {
  children: JSX.Element;
}

export const Layout = (props: Props) => {
  const auth = useAuth();

  const getLayout = () => {
    return (
      <div className={styles.layout}>
        <div className={styles.layout__top}>
          <div>
            <TopBrand showNavbar={true} />
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

  return (
    <ProgressIndicator size="5rem" isLoading={auth.isLoading}>
      {getLayout()}
    </ProgressIndicator>
  );
};
