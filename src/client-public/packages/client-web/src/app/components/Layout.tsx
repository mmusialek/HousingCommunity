import { BottomTeaser } from "./BottomTeaser";
import styles from "./Layout.module.scss";
import { TopMenu } from "./TopMenu";

interface Props {
  children: JSX.Element;
}

export const Layout = (props: Props) => {

  return (
    <div className={styles.layout}>
      <div className={styles.layout__top}>
        <div>brand</div>
        <div>
          <TopMenu />
        </div>
        <div>actions</div>
      </div>
      <div className={styles.layout__content}>{props.children}</div>
      <div className={styles.layout__bottom}>
        <BottomTeaser />
      </div>
    </div>
  );
};
