import "../styles/globals.css";
import Login from "./Login";
import SideBar from "../Components/SideBar/Index";
import { Provider } from "react-redux";
import store from "../Store/Index";
import { useEffect } from "react";
function MyApp({ Component, pageProps }) {
  return (
    <>
      <Provider tokestore={store}>
        <div className="flex bg-neutral-100">
          <div className={`flex`}>
            <SideBar />
          </div>
          <div className={`w-full ml-8`}>
            <Component {...pageProps} />
          </div>
        </div>
      </Provider>
    </>
  );
}

export default MyApp;
