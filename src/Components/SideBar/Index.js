import MenuItem from "./MenuItem";
import "../../logos.png";
import {
  AiFillBank,
  AiOutlineBank,
  AiOutlineHome,
  AiOutlineSetting,
  AiOutlineUser,
} from "react-icons/ai";
import { useEffect } from "react";
import { Outlet, useNavigate } from "react-router-dom";

const UserChip = () => {
  let user;
  user = localStorage.getItem("userMail");
  return (
    <div className="flex items-center w-full text-white mt-auto hover:rounded-full mb-6 hover:bg-neutral-900 cursor-pointer p-5">
      <img
        className=" w-10 h-10 rounded-full"
        src="https://randomuser.me/api/portraits/women/60.jpg"
      />
      <div className="flex flex-col">
        <span className="ml-3 text-white text-sm">
          {user.split("@gmail.com")}
        </span>
        <span className="ml-3 text-neutral-300 text-xs">Developer</span>
      </div>
    </div>
  );
};

export default function () {
  const navigate = useNavigate();
  return (
    <>
      <div className="flex bg-neutral-100">
        <div className="h-screen w-56 rounded-r-md text-white bg-black">
          <div className="p-2 flex flex-col h-screen">
            <img
              onClick={() => {
                navigate("/clients");
              }}
              src="https://o.remove.bg/downloads/c7b79efe-0873-4e92-88d1-2981a19f55b3/looka_blue-removebg-preview.png"
            ></img>
            <MenuItem Title="Home" Icon={AiOutlineHome} />
            <MenuItem Title="Clients" Icon={AiOutlineUser} />
            <MenuItem Title="Companies" Icon={AiOutlineBank} />
            <UserChip />
          </div>
        </div>
        <div className="ml-8">
          <Outlet />
        </div>
      </div>
    </>
  );
}
