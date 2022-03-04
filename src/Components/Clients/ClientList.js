import { useEffect, useState } from "react";
import api from "../../API/AxiosInstance";
import {
  AiFillDelete,
  AiFillSchedule,
  AiOutlineCodepen,
  AiOutlineDelete,
  AiOutlineSearch,
} from "react-icons/ai";
import ClientPopUp from "./ClientPopUp";
import { useNavigate } from "react-router-dom";

export default function () {
  const [clientList, setClientList] = useState([]);

  useEffect(() => {
    api
      .get("/clients")
      .then((response) => {
        setClientList(response.data);
        console.log(response.data);
      })
      .catch((error) => {});
  }, []);
  const navigate = useNavigate();
  const handleNavigate = () => {
    navigate("detail");
  };
  return (
    <>
      <div className=" overflow-x-auto ">
        <div className="flex flex-row  mt-8 sm:justify-between justify-between">
          <div className="flex w-full">
            <h1 className="text-bold text-xl">List Of Clients</h1>
          </div>

          <div className="w-full ml-auto">
            <div className="absolute pt-3 px-2 text-neutral-200 outline-hidden">
              {" "}
              <AiOutlineSearch />
            </div>
            <input
              type="text"
              className="block text-xs p-2 border-none text-neutral-400  pl-7 px-4 w-full sm:max-w-lg rounded-lg sm:text-sm border-2 bg-white focus:outline-none"
              placeholder="Search..."
              autoComplete="off"
            />
          </div>
        </div>
        <table className="min-w-full mt-6 bg-white rounded-lg">
          <thead>
            <tr className="border-b-2 whitespace-nowrap border-neutral-100">
              <th className="text-left p-4 text-sm">Id</th>
              <th className="text-left px-2 w-40 text-sm">Client</th>
              <th className="text-left text-sm w-36 px-4">PhoneNumber</th>
              <th className="text-left text-sm w-36 px-4">NoIdentification</th>
              <th className="text-left text-sm w-36 px-8">Since</th>
              <th className="text-left px-4 text-sm">Status</th>
              <th className="text-left px-4 text-sm">Actions</th>
            </tr>
          </thead>
          <tbody className={`${clientList.length < 1 && "hidden"} `}>
            {clientList.map((item, index) => {
              return (
                <tr
                  onClick={() => {
                    navigate("detail");
                    localStorage.setItem("id", item.id);
                  }}
                  key={index}
                  className="hover:bg-neutral-200 hover:rounded-full  hover:cursor-pointer transition-all duration-200 ease-in-out"
                >
                  <td className="p-5">{item.id}</td>
                  <td className="whitespace-nowrap">
                    <div className="flex p-4 w-52">
                      <img
                        className="w-8"
                        src="https://avataaars.io/?avatarStyle=Circle&topType=LongHairBigHair&accessoriesType=Round&hairColor=Auburn&facialHairType=Blank&clotheType=ShirtVNeck&clotheColor=Red&eyeType=Default&eyebrowType=Default&mouthType=Default&skinColor=Pale"
                      ></img>
                      <div className="flex flex-col mx-2">
                        <span className="text-sm font-semibold">
                          {item.name}
                        </span>
                        <span className="text-xs text-slate-300">
                          Developer
                        </span>
                      </div>
                    </div>
                  </td>
                  <td className="text-left text-sm w-40 px-2 whitespace-nowrap">
                    {item.phoneNumber}
                  </td>
                  <td className="text-left text-sm w-40 px-4 whitespace-nowrap">
                    {item.noIdentification}
                  </td>

                  <td className="text-left pr-10 text-xs whitespace-nowrap">
                    {item.createdAt}
                  </td>

                  <td>
                    <span className="text-xs font-semibold rounded-full bg-purple-300  p-2">
                      {item.status ? "Active" : "Disable"}
                    </span>
                  </td>
                  <td className="px-5 whitespace-nowrap text-red-700">
                    {/* <FontAwesomeIcon className="mx-2" icon={faPen} /> */}
                    <AiFillDelete size={18} />
                  </td>
                  <td>{item.status}</td>
                </tr>
              );
            })}
          </tbody>
        </table>
        <div className="w-full flex justify-center my-5">
          <span
            className={`${
              clientList.length > 1 && "hidden"
            } text-center text-neutral-400`}
          >
            {/* The list is empty!. */}
          </span>
        </div>
      </div>
    </>
  );
}
