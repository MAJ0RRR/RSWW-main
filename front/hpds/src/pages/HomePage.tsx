import NavBarNotLoggedIn from "../components/NavBarNotLoggedIn";
import Search from "../components/Search";

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
              <button
                type="button"
                className="btn btn-light custom button-style"
              >
                Check offers
              </button>
            </div>
          </div>
        </div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-50 font-size-36">Greece</div>
            <div className="right-50 font-size-36">
              <button
                type="button"
                className="btn btn-light custom button-style"
              >
                Check offers
              </button>
            </div>
          </div>
        </div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-50 font-size-36">Greece</div>
            <div className="right-50 font-size-36">
              <button
                type="button"
                className="btn btn-light custom button-style"
              >
                Check offers
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default HomePage;
