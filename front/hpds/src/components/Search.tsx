import "../styles/SearchStyles.css";

function Search() {
  return (
    <>
      <div className="page-content">
        <div className="page-section-content">
          <div className="elements">
            <div className="left-80">
              <div className="search-container">
                <div className="search-input-group">
                  <div className="search-input-field">
                    <label htmlFor="inputField1">Where:</label>
                    <br />
                    <input type="text" id="inputField1" />
                  </div>
                  <div className="search-input-field">
                    <label htmlFor="inputField1">When:</label>
                    <br />
                    <input type="text" id="inputField1" />
                  </div>
                  <div className="search-input-field">
                    <label htmlFor="inputField1">How long:</label>
                    <br />
                    <input type="text" id="inputField1" />
                  </div>
                  <div className="search-input-field">
                    <label htmlFor="inputField1">From:</label>
                    <br />
                    <input type="text" id="inputField1" />
                  </div>
                </div>
                <div className="search-input-group">
                  <div className="search-input-field">
                    <label htmlFor="inputField1">Type of transport:</label>
                    <br />
                    <input type="text" id="inputField1" />
                  </div>
                  <div className="search-input-field">
                    <label htmlFor="inputField1">People:</label>
                    <br />
                    <input type="text" id="inputField1" />
                  </div>
                </div>
              </div>
            </div>
            <div className="right-20-relative">
              <div className="bottom-right">
                <button
                  type="button"
                  className="btn btn-light custom button-style"
                >
                  Search
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default Search;
