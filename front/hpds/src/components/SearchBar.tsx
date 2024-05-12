import "../styles/SearchStyles.css";
import Dropdown from "react-bootstrap/Dropdown";
import Button from "react-bootstrap/Button";
import { useState } from "react";

function SearchBar() {
  // variables
  const [seachBarData, setSearchBarData] = useState({
    country: "",
    city: "",
    whenFrom: "",
    whenTo: "",
    howLongFrom: 0,
    howLongTo: 7,
    from: "",
    typeOfTransport: "",
    adults: 2,
    upTo3: 0,
    upTo10: 0,
    upTo18: 0,
  });
  const possibleTypesOfTransport = ["Plane", "Bus", "Own"];

  const handleChange = (e) => {
    const { name, value } = e.target;
    setSearchBarData({ ...seachBarData, [name]: value });
  };

  const handleClick = (e, name: string) => {
    setSearchBarData({ ...seachBarData, [name]: e.target.innerText });
  };

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
                    {seachBarData.country ? seachBarData.country : "country"}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    {mocked_countries.map((item) => (
                      <Dropdown.Item
                        className="list-item"
                        onClick={(event) => handleClick(event, "country")}
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
                    {seachBarData.city ? seachBarData.city : "city"}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    {mocked_cities.map((item) => (
                      <Dropdown.Item
                        className="list-item"
                        onClick={(event) => handleClick(event, "city")}
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
                    {seachBarData.whenFrom.length > 0 &&
                    seachBarData.whenTo.length > 0
                      ? seachBarData.whenFrom + " - " + seachBarData.whenTo
                      : "when"}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item">
                      <label>From:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="DD.MM.RRRR"
                        name="whenFrom"
                        onChange={handleChange}
                      ></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item">
                      <label>To:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="DD.MM.RRRR"
                        name="whenTo"
                        onChange={handleChange}
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
                    {seachBarData.howLongFrom} - {seachBarData.howLongTo}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item">
                      <label>From:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="number of days"
                        name="howLongFrom"
                        onChange={handleChange}
                      ></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item">
                      <label>To:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="number of days"
                        name="howLongTo"
                        onChange={handleChange}
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
                    {seachBarData.from ? seachBarData.from : "from"}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    {mocked_from.map((item) => (
                      <Dropdown.Item
                        className="list-item"
                        onClick={(event) => handleClick(event, "from")}
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
                    {seachBarData.typeOfTransport
                      ? seachBarData.typeOfTransport
                      : "type of transport"}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    {possibleTypesOfTransport.map((item) => (
                      <Dropdown.Item
                        className="list-item"
                        onClick={(event) =>
                          handleClick(event, "typeOfTransport")
                        }
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
                    {seachBarData.adults} + {seachBarData.upTo3} +{" "}
                    {seachBarData.upTo10} + {seachBarData.upTo18}
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item className="list-item">
                      <label>Adults:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="number"
                        name="adults"
                        onChange={handleChange}
                      />
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item">
                      <label>Up to 3 years old:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="number"
                        name="upTo3"
                        onChange={handleChange}
                      ></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item">
                      <label>Up to 10 years old:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="number"
                        name="upTo10"
                        onChange={handleChange}
                      ></input>
                    </Dropdown.Item>
                    <Dropdown.Item className="list-item">
                      <label>Up to 18 years old:</label>
                      <br />
                      <input
                        type="text"
                        placeholder="number"
                        name="upTo18"
                        onChange={handleChange}
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
