import { BottomTeaser } from "./BottomTeaser";
import styles from "./Layout.module.scss";
import { TopBrand } from "./TopBrand";
import { TopMenu } from "./TopMenu";
import { TopUserActions } from "./TopUserActions";

interface Props {
  children: JSX.Element;
}

export const Layout = (props: Props) => {
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
