import NavBarLoggedIn from "../components/NavBarLoggedIn";
import "../styles/MyTripPageStyles.css";
import Button from "react-bootstrap/Button";

function MyTripsPage() {
  return (
    <>
      <NavBarLoggedIn />
      <div className="page-content">
        <div className="page-title">My trips</div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-20 font-size-36">Marion</div>
            <div className="middle-60 font-size-36 color-orange">
              No reservation
            </div>
            <div className="right-20 font-size-36">32321 PLN</div>
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
                <span style={{ fontSize: "24px" }}>Time left: 00:02</span>
                <Button variant="secondary" className="button-style">
                  Details
                </Button>
              </div>
            </div>
          </div>
        </div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-20 font-size-36">Marion</div>
            <div className="middle-60 font-size-36 color-red">
              No payment in given time
            </div>
            <div className="right-20 font-size-36">32321 PLN</div>
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
                  Details
                </Button>
              </div>
            </div>
          </div>
        </div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-20 font-size-36">Marion</div>
            <div className="middle-60 font-size-36 color-green">
              Payment done
            </div>
            <div className="right-20 font-size-36">32321 PLN</div>
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
                  Details
                </Button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default MyTripsPage;
