import NavBarNotLoggedIn from "../components/NavBarNotLoggedIn";
import Search from "../components/Search";

function SearchResultPage() {
  return (
    <>
      <NavBarNotLoggedIn />
      <Search />
      <div className="page-content">
        <div className="page-title">Holidays Poland</div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-50 font-size-36">Marion</div>
            <div className="right-50 font-size-36">32321 PLN</div>
          </div>
          <div className="elements">
            <div className="left-50">
              Address: <br />
              Transport: <br />
              Date: <br />
              Duration: <br />
            </div>
            <div className="right-50-relative">
              <div className="bottom-right">
                <button
                  type="button"
                  className="btn btn-light custom button-style"
                >
                  Check offer
                </button>
              </div>
            </div>
          </div>
        </div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-50 font-size-36">Marion</div>
            <div className="right-50 font-size-36">32321 PLN</div>
          </div>
          <div className="elements">
            <div className="left-50">
              Address: <br />
              Transport: <br />
              Date: <br />
              Duration: <br />
            </div>
            <div className="right-50-relative">
              <div className="bottom-right">
                <button
                  type="button"
                  className="btn btn-light custom button-style"
                >
                  Check offer
                </button>
              </div>
            </div>
          </div>
        </div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-50 font-size-36">Marion</div>
            <div className="right-50 font-size-36">32321 PLN</div>
          </div>
          <div className="elements">
            <div className="left-50">
              Address: <br />
              Transport: <br />
              Date: <br />
              Duration: <br />
            </div>
            <div className="right-50-relative">
              <div className="bottom-right">
                <button
                  type="button"
                  className="btn btn-light custom button-style"
                >
                  Check offer
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default SearchResultPage;
