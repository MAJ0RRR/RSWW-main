import NavBarNotLoggedIn from "../components/NavBarNotLoggedIn";
import Search from "../components/Search";

function HomePage() {
  return (
    <div>
      <NavBarNotLoggedIn />
      <Search />
      <h1>Home Page</h1>
    </div>
  );
}

export default HomePage;
