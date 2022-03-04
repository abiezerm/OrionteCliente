import logo from './logo.svg';
import './App.css';
import Login from "./pages/Login";
import SideBar from "./Components/SideBar/Index";
import Clients from "./pages/Clients";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import ClientProfileCard from "./Components/Clients/ClientProfileCard";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<SideBar />}>
          <Route path="/clients" element={<Clients />}></Route>
          <Route path="/Clients/detail" element={<ClientProfileCard />}></Route>
          <Route path="/clients" element={<Clients />}></Route>
        </Route>
        <Route path="Login" element={<Login />}></Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
