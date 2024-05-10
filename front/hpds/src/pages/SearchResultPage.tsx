import NavBarNotLoggedIn from "../components/NavBarNotLoggedIn";
import SearchBar from "../components/SearchBar";
import Button from "react-bootstrap/Button";

function SearchResultPage() {
  return (
    <>
      <NavBarNotLoggedIn />
      <SearchBar />
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
                <Button variant="secondary" className="button-style">
                  Check offer
                </Button>
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
                <Button variant="secondary" className="button-style">
                  Check offer
                </Button>
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
                <Button variant="secondary" className="button-style">
                  Check offer
                </Button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default SearchResultPage;
