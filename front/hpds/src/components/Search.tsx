import "../styles/SearchStyles.css";
import Dropdown from "react-bootstrap/Dropdown";
import Button from "react-bootstrap/Button";

function Search() {
  return (
    <div className="page-content">
      <div className="elements">
        <div className="left-80">
          <div className="search-container">
            <div className="search-input-group">
              <div className="search-input-field">
                <label htmlFor="inputField1">Country:</label>
                <br />
                <Dropdown>
                  <Dropdown.Toggle
                    variant="not"
                    id="dropdown-basic"
                    className="dropdown-button"
                  >
                    country
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item" href="#/action-1">
                      Cuba
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-2">
                      Peru
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-3">
                      Thailand
                    </Dropdown.Item>
                  </Dropdown.Menu>
                </Dropdown>
              </div>
              <div className="search-input-field">
                <label htmlFor="inputField1">City:</label>
                <br />
                <Dropdown style={{ background: "#F6F6F6" }}>
                  <Dropdown.Toggle
                    variant="not"
                    id="dropdown-basic"
                    className="dropdown-button"
                  >
                    city
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item" href="#/action-1">
                      Havana
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-2">
                      Havana
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-3">
                      Havana
                    </Dropdown.Item>
                  </Dropdown.Menu>
                </Dropdown>
              </div>
              <div className="search-input-field">
                <label htmlFor="inputField1">When:</label>
                <br />
                <Dropdown style={{ background: "#F6F6F6" }} autoClose="outside">
                  <Dropdown.Toggle
                    variant="not"
                    id="dropdown-basic"
                    className="dropdown-button"
                  >
                    when
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item" href="#/action-1">
                      <label>From:</label>
                      <br />
                      <input type="text" placeholder="DD-MM-RRRR"></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-2">
                      <label>To:</label>
                      <br />
                      <input type="text" placeholder="DD-MM-RRRR"></input>
                    </Dropdown.Item>
                  </Dropdown.Menu>
                </Dropdown>
              </div>
              <div className="search-input-field">
                <label htmlFor="inputField1">How long:</label>
                <br />
                <Dropdown style={{ background: "#F6F6F6" }} autoClose="outside">
                  <Dropdown.Toggle
                    variant="not"
                    id="dropdown-basic"
                    className="dropdown-button"
                  >
                    how long
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item" href="#/action-1">
                      <label>From:</label>
                      <br />
                      <input type="text" placeholder="number of days"></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-2">
                      <label>To:</label>
                      <br />
                      <input type="text" placeholder="number of days"></input>
                    </Dropdown.Item>
                  </Dropdown.Menu>
                </Dropdown>
              </div>
            </div>
            <div className="search-input-group">
              <div className="search-input-field">
                <label htmlFor="inputField1">From:</label>
                <br />
                <Dropdown style={{ background: "#F6F6F6" }}>
                  <Dropdown.Toggle
                    variant="not"
                    id="dropdown-basic"
                    className="dropdown-button"
                  >
                    from
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item" href="#/action-1">
                      Havana
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-2">
                      Havana
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-3">
                      Havana
                    </Dropdown.Item>
                  </Dropdown.Menu>
                </Dropdown>
              </div>
              <div className="search-input-field">
                <label htmlFor="inputField1">Type of transport:</label>
                <br />
                <Dropdown style={{ background: "#F6F6F6" }}>
                  <Dropdown.Toggle
                    variant="not"
                    id="dropdown-basic"
                    className="dropdown-button"
                  >
                    type of transport
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item" href="#/action-1">
                      Havana
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-2">
                      Havana
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-3">
                      Havana
                    </Dropdown.Item>
                  </Dropdown.Menu>
                </Dropdown>
              </div>
              <div className="search-input-field">
                <label htmlFor="inputField1">People:</label>
                <br />
                <Dropdown style={{ background: "#F6F6F6" }} autoClose="outside">
                  <Dropdown.Toggle
                    variant="not"
                    id="dropdown-basic"
                    className="dropdown-button"
                  >
                    people
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item" href="#/action-1">
                      <label>Adults:</label>
                      <br />
                      <input type="text" placeholder="number"></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-2">
                      <label>Up to 3 years old:</label>
                      <br />
                      <input type="text" placeholder="number"></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-2">
                      <label>Up to 10 years old:</label>
                      <br />
                      <input type="text" placeholder="number"></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item" href="#/action-2">
                      <label>Up to 18 years old:</label>
                      <br />
                      <input type="text" placeholder="number"></input>
                    </Dropdown.Item>
                  </Dropdown.Menu>
                </Dropdown>
              </div>
            </div>
          </div>
        </div>
        <div className="right-20-relative">
          <div className="bottom-right">
            <Button variant="secondary" className="font-size-36">
              Search
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Search;
