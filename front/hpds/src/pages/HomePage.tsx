import NavBarNotLoggedIn from "../components/NavBarNotLoggedIn";
import Search from "../components/Search";
import Button from "react-bootstrap/Button";

function HomePage() {
  return (
    <>
      <NavBarNotLoggedIn />
      <Search />
      <div className="page-content">
        <div className="page-title">Popular directions</div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-50 font-size-36">Greece</div>
            <div className="right-50 font-size-36">
              <Button variant="secondary" className="font-size-36">
                Check offers
              </Button>
            </div>
          </div>
        </div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-50 font-size-36">Greece</div>
            <div className="right-50 font-size-36">
              <Button variant="secondary" className="font-size-36">
                Check offers
              </Button>
            </div>
          </div>
        </div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-50 font-size-36">Greece</div>
            <div className="right-50 font-size-36">
              <Button variant="secondary" className="font-size-36">
                Check offers
              </Button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default HomePage;
