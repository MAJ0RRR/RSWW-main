import NavBarLoggedIn from "../components/NavBarLoggedIn";
import "../styles/FormStyles.css";

function PaymentPage() {
  return (
    <>
      <NavBarLoggedIn />
      <div className="container">
        <div className="header">Payment</div>
        <div className="inputs">
          <div className="input">
            <input
              type="text"
              placeholder="Credit card number"
              name="credit-card-number"
              required
            />
          </div>
          <div className="input">
            <input
              type="text"
              placeholder="Credit card expiration date"
              name="credit-card-expiration-date"
              required
            />
          </div>
          <div className="input">
            <input
              type="text"
              placeholder="Credit card security code"
              name="credit-card-security-code"
              required
            />
          </div>
        </div>
        <div className="submit-container">
          <div className="time-left">Time left: 00:12</div>
          <div className="buttons">
            <button type="button" className="btn btn-light">
              Log in
            </button>
          </div>
        </div>
      </div>
    </>
  );
}

export default PaymentPage;
