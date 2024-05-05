import NavBarNotLoggedIn from "../components/NavBarNotLoggedIn";
import "../styles/LogInStyles.css";

function LogInPage() {
  return (
    <div>
      <NavBarNotLoggedIn />
      <div className="container">
        <div className="header">Log in</div>
        <div className="inputs">
          <div className="input">
            <input
              type="text"
              placeholder="Enter login"
              name="login"
              required
            />
          </div>
          <div className="input">
            <input
              type="password"
              placeholder="Enter password"
              name="password"
              required
            />
          </div>
        </div>
        <div className="submit-container">
          <button type="button" className="btn btn-light">
            Log in
          </button>
        </div>
      </div>
    </div>
  );
}

export default LogInPage;
