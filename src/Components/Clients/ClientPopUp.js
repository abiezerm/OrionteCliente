import { useState } from "react";

export default function () {
  const [popUpIsActive, setPopUpIsActive] = useState(true);
  const [formData, setFormData] = useState(true);
  const [page, setPage] = useState(1);
  const handlePage = (page) => {
    setPage(page);
  };
  const postClient = () => {};
  if (page === 1) {
    return (
      <div
        className={`${
          popUpIsActive ? "inline" : "hidden"
        } flex h-screen fixed right-0 left-0top-0 z-50 justify-center items-center md:inset-0 h-modal sm:h-full"
        id="popup-modal`}
      >
        <div className="flex flex-col w-screen h-screen  pl-5 pr-5 bg-black bg-opacity-60">
          <div className="rounded-lg p-10 m-auto shadow-lg bg-white">
            <div className="flex flex-row justify-between">
              <div className="flex-1">
                <h1 className="text-lg tracking-widest font-extrabold">
                  New Client
                </h1>
              </div>
              <div className="flex flex-between ">
                <button>{/* <FontAwesomeIcon icon={faTimes} /> */}</button>
              </div>
            </div>
            <div className="flex flex-col mt-4">
              <h1 className="labels border-red-800 focus:outline-red-600 ">
                Name
              </h1>
              <input
                className="inputText text-sm border-red-800 focus:border-red-800 border-2"
                name="name"
                autoComplete="Off"
                onChange={setFormData}
                placeholder="Name"
              ></input>
            </div>
            <div className="flex flex-wrap mt-4">
              <div className="flex flex-col flex-1 m-1">
                <h3 className="labels">Phone Number</h3>
                <input
                  name="PhoneNumber"
                  className="inputText"
                  onChange={setFormData}
                  placeholder="Phone Number"
                ></input>
              </div>
              <div className="m-1 flex-1">
                <div className="flex flex-col">
                  <h3 className="labels">Location</h3>
                  <input
                    className="inputText"
                    name="location"
                    onChange={setFormData}
                    placeholder="Location"
                  ></input>
                </div>
              </div>
            </div>
            <div className="flex flex-col mt-4 mb-5 ">
              <h3 className="labels">No. Identification</h3>
              <input
                className="inputText"
                name="noIdentification"
                onChange={setFormData}
                placeholder="No. Identification"
              ></input>
            </div>

            <footer className="flex justify-center">
              <div className="flex flex-col">
                <div className="flex justify-center my-4">
                  <div
                    onClick={() => {
                      setPage(1);
                    }}
                    className={`w-2 h-2 mx-1 bg-black rounded-full ${
                      page == 2 && "border-2 border-slate-900 bg-white"
                    }`}
                  >
                    {" "}
                  </div>
                  <div
                    onClick={() => {
                      setPage(2);
                    }}
                    className={`w-2 h-2 mx-1 bg-black rounded-full ${
                      page == 1 && "border-2 border-slate-900 bg-white"
                    }`}
                  >
                    {" "}
                  </div>
                </div>

                <button
                  className="btn btn--primary  bg-black text-white flex w-48"
                  onClick={postClient}
                >
                  Accept
                </button>
              </div>
            </footer>
            {/* Inputs */}
          </div>
        </div>
      </div>
    );
  } else {
    return (
      <div
        className={`${
          popUpIsActive ? "inline" : "hidden"
        } flex h-screen fixed right-0 left-0top-0 z-50 justify-center items-center md:inset-0 h-modal sm:h-full"
        id="popup-modal`}
      >
        <div className="flex flex-col w-screen h-screen  pl-5 pr-5 bg-black bg-opacity-60">
          <div className="rounded-lg p-10 m-auto shadow-lg bg-white">
            <div className="flex flex-row justify-between">
              <div className="flex-1">
                <h1 className="text-lg tracking-widest font-extrabold">
                  Client Addresess
                </h1>
              </div>
              <div className="flex flex-between ">
                <button>{/* <FontAwesomeIcon icon={faTimes} /> */}</button>
              </div>
            </div>
            <div className="flex flex-col mt-4">
              <h1 className="labels border-red-800 focus:outline-red-600 ">
                Address
              </h1>
              <input
                className="inputText text-sm border-red-800 focus:border-red-800 border-2"
                name="name"
                autoComplete="Off"
                onChange={setFormData}
                placeholder="Name"
              ></input>
            </div>
            <div className="flex flex-wrap mt-4">
              <div className="flex flex-col flex-1 m-1">
                <h3 className="labels">AddressComplement</h3>
                <input
                  name="PhoneNumber"
                  className="inputText"
                  onChange={setFormData}
                  placeholder="Phone Number"
                ></input>
              </div>
              <div className="m-1 flex-1">
                <div className="flex flex-col">
                  <h3 className="labels">Postal Code</h3>
                  <input
                    className="inputText"
                    name="location"
                    onChange={setFormData}
                    placeholder="Location"
                  ></input>
                </div>
              </div>
            </div>
            <div className="flex flex-col mt-4 mb-5 ">
              <h3 className="labels">City</h3>
              <input
                className="inputText"
                name="noIdentification"
                onChange={setFormData}
                placeholder="No. Identification"
              ></input>
            </div>

            <footer className="flex justify-center">
              <div className="flex flex-col">
                <div className="flex justify-center my-4">
                  <div
                    onClick={() => {
                      setPage(1);
                    }}
                    className={`w-2 h-2 mx-1 bg-black rounded-full ${
                      page == 2 && "border-2 border-slate-900 bg-white"
                    }`}
                  >
                    {" "}
                  </div>
                  <div
                    onClick={() => {
                      setPage(2);
                    }}
                    className={`w-2 h-2 mx-1 bg-black rounded-full ${
                      page == 1 && "border-2 border-slate-900 bg-white"
                    }`}
                  >
                    {" "}
                  </div>
                </div>

                <button
                  className="btn btn--primary  bg-black text-white flex w-48"
                  onClick={postClient}
                >
                  Accept
                </button>
              </div>
            </footer>
            {/* Inputs */}
          </div>
        </div>
      </div>
    );
  }
}
