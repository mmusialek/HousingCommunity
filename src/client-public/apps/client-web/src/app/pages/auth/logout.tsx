import { useAuth } from "oidc-react";

export const Logout = () => {
  const auth = useAuth();
  return (
    <div className="simple-centered-box">
      <div>Logout</div>
      <div>
        <button
          onClick={async () => {
            await auth.signOutRedirect();
          }}
        >
          logout
        </button>
      </div>
    </div>
  );
};
