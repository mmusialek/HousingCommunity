import { useAuth } from "oidc-react";

export const Logout = () => {
  const auth = useAuth();
  return (
    <div>
      <div>Logout</div>
      <div>
        <button
          onClick={async () => {
            await auth.signOut();
          }}
        >
          logout
        </button>
      </div>
    </div>
  );
};