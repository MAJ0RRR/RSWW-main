import NavBarNotLoggedIn from "../components/NavBarNotLoggedIn";
import "../styles/FormStyles.css";

function LogInPage() {
  return (
    <>
      <NavBarNotLoggedIn />
      <div className="container">
        <div className="header">Log in</div>
        <div className="inputs">
          <div className="input">
            <input type="text" placeholder="Login" name="login" required />
          </div>
          <div className="input">
            <input
              type="password"
              placeholder="Password"
              name="password"
              required
            />
          </div>
        </div>
        <div className="submit-container">
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

export default LogInPage;
