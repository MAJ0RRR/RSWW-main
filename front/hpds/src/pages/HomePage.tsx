import NavBarNotLoggedIn from "../components/NavBarNotLoggedIn";
import Search from "../components/Search";

function HomePage() {
  return (
    <>
      <NavBarNotLoggedIn />
      <Search />
      <h1>Home Page</h1>
    </>
  );
}

export default HomePage;
