import { BottomTeaser } from "./BottomTeaser";
import styles from "./Layout.module.scss";
import { TopBrand } from "./TopBrand";
import { TopMenu } from "./TopMenu";

interface Props {
  children: JSX.Element;
}

export const EmptyLayout = (props: Props) => {
  const getLayout = () => {
    return (
      <div className={styles.layout}>
        <div className={styles.layout__top}>
          <div>
            <TopBrand showNavbar={false} />
          </div>
          <div>
            <TopMenu />
          </div>
          <div></div>
        </div>
        <div className={styles.layout__content}>{props.children}</div>
        <div className={styles.layout__bottom}>
          <BottomTeaser />
        </div>
      </div>
    );
  };

  return getLayout();
};
