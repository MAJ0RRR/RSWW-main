import "../styles/SearchStyles.css";

function Search() {
  return (
    <>
      <div className="page-content">
        <div className="page-section-content">
          <div className="elements">
            <div className="left-80">
              <div
                style={{
                  display: "flex",
                  flexDirection: "row",
                  alignItems: "center",
                }}
              >
                <div style={{ marginRight: "20px" }}>
                  <label htmlFor="inputField1">Where:</label>
                  <br />
                  <input type="text" id="inputField1" />
                </div>
                <div style={{ marginRight: "20px" }}>
                  <label htmlFor="inputField2">When:</label>
                  <br />
                  <input type="text" id="inputField2" />
                </div>
                <div style={{ marginRight: "20px" }}>
                  <label htmlFor="inputField2">How long:</label>
                  <br />
                  <input type="text" id="inputField2" />
                </div>
                <div>
                  <label htmlFor="inputField2">From:</label>
                  <br />
                  <input type="text" id="inputField2" />
                </div>
              </div>
              <div
                style={{
                  display: "flex",
                  flexDirection: "row",
                  alignItems: "center",
                }}
              >
                <div style={{ marginRight: "20px" }}>
                  <label htmlFor="inputField1">Type of transport:</label>
                  <br />
                  <input type="text" id="inputField1" />
                </div>
                <div style={{ marginRight: "20px" }}>
                  <label htmlFor="inputField2">Pepole:</label>
                  <br />
                  <input type="text" id="inputField2" />
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
