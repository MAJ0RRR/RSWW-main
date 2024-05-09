import NavBarLoggedIn from "../components/NavBarLoggedIn";
import "../styles/MyTripPageStyles.css";

function MyTripsPage() {
  return (
    <>
      <NavBarLoggedIn />
      <div className="page-content">
        <div className="page-title">My trips</div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-20 font-size-36">Marion</div>
            <div className="middle-60 font-size-36">No reservation</div>
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
                Time left: 00:02
                <button
                  type="button"
                  className="btn btn-light custom button-style"
                >
                  Details
                </button>
              </div>
            </div>
          </div>
        </div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-20 font-size-36">Marion</div>
            <div className="middle-60 font-size-36">
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
                <button type="button" className="btn btn-light custom">
                  Details
                </button>
              </div>
            </div>
          </div>
        </div>
        <div className="page-section-content">
          <div className="elements">
            <div className="left-20 font-size-36">Marion</div>
            <div className="middle-60 font-size-36">Payment done</div>
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
                <button
                  type="button"
                  className="btn btn-light custom button-custom-styles"
                >
                  Details
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default MyTripsPage;
