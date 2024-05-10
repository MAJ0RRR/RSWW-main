import "../styles/SearchStyles.css";
import Dropdown from "react-bootstrap/Dropdown";
import Button from "react-bootstrap/Button";
import { useState } from "react";

function SearchBar() {
  // variables
  const [country, setCountry] = useState("");
  const [city, setCity] = useState("");
  const [whenFrom, setWhenFrom] = useState("");
  const [whenTo, setWhenTo] = useState("");
  const [howLongFrom, setHowLongFrom] = useState(0);
  const [howLongTo, setHowLongTo] = useState(7);
  const [from, setFrom] = useState("");
  const [typeOfTransport, setTypeOfTransport] = useState("");
  const [adults, setAdults] = useState(2);
  const [upTo3, setUpTo3] = useState(0);
  const [upTo10, setUpTo10] = useState(0);
  const [upTo18, setUpTo18] = useState(0);

  const possibleTypesOfTransport = ["Plane", "Bus", "Own"];

  // mock data
  const mocked_countries = ["Country1", "Country2", "Country3", "Country4"];
  const mocked_cities = ["City1", "City2", "City3", "City4"];
  const mocked_from = ["City1", "City2", "City3", "City4"];

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
                    {country ? country : "country"}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    {mocked_countries.map((item) => (
                      <Dropdown.Item
                        className="list-item"
                        onClick={() => setCountry(item)}
                      >
                        {item}
                      </Dropdown.Item>
                    ))}
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
                    {city ? city : "city"}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    {mocked_cities.map((item) => (
                      <Dropdown.Item
                        className="list-item"
                        onClick={() => setCity(item)}
                      >
                        {item}
                      </Dropdown.Item>
                    ))}
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
                    {whenFrom.length > 0 && whenTo.length > 0
                      ? whenFrom + " - " + whenTo
                      : "when"}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item">
                      <label>From:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="DD.MM.RRRR"
                        onChange={(event) => setWhenFrom(event.target.value)}
                      ></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item">
                      <label>To:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="DD.MM.RRRR"
                        onChange={(event) => setWhenTo(event.target.value)}
                      ></input>
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
                    {howLongFrom} - {howLongTo}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item">
                      <label>From:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="number of days"
                        onChange={(event) =>
                          setHowLongFrom(parseInt(event.target.value))
                        }
                      ></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item">
                      <label>To:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="number of days"
                        onChange={(event) =>
                          setHowLongTo(parseInt(event.target.value))
                        }
                      ></input>
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
                    {from ? from : "from"}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    {mocked_from.map((item) => (
                      <Dropdown.Item
                        className="list-item"
                        onClick={() => setFrom(item)}
                      >
                        {item}
                      </Dropdown.Item>
                    ))}
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
                    {typeOfTransport ? typeOfTransport : "type of transport"}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    {possibleTypesOfTransport.map((item) => (
                      <Dropdown.Item
                        className="list-item"
                        onClick={() => setTypeOfTransport(item)}
                      >
                        {item}
                      </Dropdown.Item>
                    ))}
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
                    {adults} + {upTo3} + {upTo10} + {upTo18}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item">
                      <label>Adults:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="number"
                        onChange={(event) =>
                          setAdults(parseInt(event.target.value))
                        }
                      ></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item">
                      <label>Up to 3 years old:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="number"
                        onChange={(event) =>
                          setUpTo3(parseInt(event.target.value))
                        }
                      ></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item">
                      <label>Up to 10 years old:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="number"
                        onChange={(event) =>
                          setUpTo10(parseInt(event.target.value))
                        }
                      ></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item">
                      <label>Up to 18 years old:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="number"
                        onChange={(event) =>
                          setUpTo18(parseInt(event.target.value))
                        }
                      ></input>
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

export default SearchBar;
