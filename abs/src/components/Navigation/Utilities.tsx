import AdminNavigation from "./AdminNavigation";
import UserNavigation from "./UserNavigation";
import WelcomeNavigation from "./WelcomeNavigation";

export const NavigationBar = () => {
  return false ? (
    true ? (
      <UserNavigation />
    ) : (
      <AdminNavigation />
    )
  ) : (
    <WelcomeNavigation />
  );
};
