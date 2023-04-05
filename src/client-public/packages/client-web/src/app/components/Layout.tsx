import { useRouter } from "../routing";
import { BottomTeaser } from "./BottomTeaser";

interface Props {
  children: JSX.Element;
}

export const Layout = (props: Props) => {
  const router = useRouter();
  return (
    <div>
      <div>
        <button onClick={() => {router.routing.push("/go1")}}>go 1</button>
      </div>
      <div>{props.children}</div>
      <div>
        <BottomTeaser />
      </div>
    </div>
  );
};
