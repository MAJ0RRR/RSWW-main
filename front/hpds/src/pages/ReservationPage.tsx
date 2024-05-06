import NavBarLoggedIn from "../components/NavBarLoggedIn";
import "../styles/ReservationPageStyles.css";

function ReservationPage() {
  return (
    <>
      <NavBarLoggedIn />
      <div className="page-content">
        <div className="page-title">Trip to Hotel Gołebiewski</div>
        <div className="page-section">
          <div className="page-section-title">General info</div>
          <div className="page-section-content">
            <div className="page-section-content-title">Date</div>
            <div className="page-section-content-content">
              Start: 2023-01-01 <br />
              End: 2023-01-01
            </div>
          </div>
          <div className="page-section-content">
            <div className="page-section-content-title">
              People configuration
            </div>
            <div className="page-section-content-content">
              Adult: 12 <br />
              Adult: 12 <br />
              Adult: 12 <br />
              Adult: 12 <br />
            </div>
          </div>
        </div>
        <div className="page-section">
          <div className="page-section-title">Transport</div>
          <div className="page-section-content">
            <div className="page-section-content-title">
              From Berlin to Gdańsk
            </div>
            <div className="page-section-content-content">
              Param: 2023-01-01 <br />
              Param: 2023-01-01 <br />
              Param: 2023-01-01 <br />
              Param: 2023-01-01 <br />
              Param: 2023-01-01
            </div>
          </div>
          <div className="page-section-content">
            <div className="page-section-content-title">
              From Gdańsk to Berlin
            </div>
            <div className="page-section-content-content">
              Param: 2023-01-01 <br />
              Param: 2023-01-01 <br />
              Param: 2023-01-01 <br />
              Param: 2023-01-01 <br />
              Param: 2023-01-01
            </div>
          </div>
        </div>
        <div className="page-section">
          <div className="page-section-title">Hotel</div>
          <div className="page-section-content">
            <div className="page-section-content-title">Details</div>
            <div className="page-section-content-content">
              Param: 2023-01-01 <br />
              Param: 2023-01-01 <br />
              Param: 2023-01-01
            </div>
          </div>
          <div className="page-section-content">
            <div className="page-section-content-title">Configuration</div>
          </div>
        </div>
      </div>
    </>
  );
}

export default ReservationPage;
