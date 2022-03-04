import { useEffect, useState } from "react";
import {
  AiFillFacebook,
  AiFillInstagram,
  AiOutlinePlus,
  AiOutlineTwitter,
} from "react-icons/ai";
import { useLocation, useNavigate } from "react-router-dom";
import api from "../../API/AxiosInstance";
import ClientList from "./ClientList";

export default function () {
  const [formData, setFormData] = useState(true);
  const [page, setPage] = useState(1);
  const [client, setClient] = useState({});
  const location = useLocation();
  const navigate = useNavigate();
  const [currentAddress, setCurrentAddress] = useState({});
  const [addressList, setAddressList] = useState([]);

  const removeAddress = (id) => {
    client.addresses = client.addresses.filter((item) => item.id !== id);
    setClient(client);
    setAddressList(client.addresses);
    console.log(client.addresses);
  };

  const handleForm = (e) => {
    setClient({ ...client, [e.target.name]: e.target.value });
    console.log(client);
  };
  const handleFormAddress = (e) => {
    setCurrentAddress({ ...currentAddress, [e.target.name]: e.target.value });
    console.log(currentAddress);
  };

  const handleCurrentAddress = (id) => {
    setCurrentAddress(client.addresses.find((d) => d.id == id));
  };
  const handleAddAddress = () => {
    console.log(currentAddress);

    if (currentAddress !== {}) {
      const newClient = client.addresses.push(currentAddress);
      setClient(newClient);
      console.log("entradda");
      setAddressList(client.addresses);
    }
  };
  const handleUpdatAndPost = () => {
    if (client.id !== 0) {
      api
        .put("/client", client)
        .then((response) => {
          console.log(response.data);
          navigate("/clients");
        })
        .catch((error) => {
          console.log(error);
        });
    } else {
      api
        .post("/client", client)
        .then((response) => {
          console.log(response.data);
          navigate("/clients");
        })
        .catch((error) => {
          console.log(error);
        });
    }
  };

  const deleteClient = (id) => {
    api
      .delete("/client/")
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.log(error);
      });
  };
  const getClient = () => {
    api
      .get(`client/ ${localStorage.getItem("id")}`)
      .then((response) => {
        setClient(response.data);
        setAddressList(response.data.addresses);
        console.log(client);
      })
      .catch((error) => {
        console.error.log();
      });
  };

  useEffect(() => {
    getClient();
  }, []);

  if (page === 1) {
    return (
      <>
        <div className="grid grid-cols-12">
          <div className="col-span-4">
            <div className="flex mt-8">
              <div className=" w-full h-full bg-white rounded-lg flex flex-col p-8 justify-left">
                <img
                  className="rounded-full w-32 h-32 mx-auto"
                  src="https://avataaars.io/?avatarStyle=Circle&topType=LongHairBigHair&accessoriesType=Round&hairColor=Auburn&facialHairType=Blank&clotheType=ShirtVNeck&clotheColor=Red&eyeType=Default&eyebrowType=Default&mouthType=Default&skinColor=Pale"
                ></img>
                <span className="mx-auto my-1">Alam Mena</span>
                <span className="mx-auto text-xs text-neutral-400 mb-4">
                  Comprador
                </span>

                <div
                  className="mx-2 flex justify-between p-4 border-y-2 border-neutral-100 
          hover:bg-neutral-200 hover:rounded-sm  hover:cursor-pointer transition-all duration-200 ease-in-out"
                >
                  <span className="text-sm ">Twitter</span>
                  <AiOutlineTwitter size={18} />
                </div>
                <div
                  className="mx-2 flex justify-between p-4 border-b-2 border-neutral-100
          hover:bg-neutral-200 hover:rounded-sm hover:cursor-pointer transition-all duration-200 ease-in-out"
                >
                  <span className="text-sm">Instagram</span>
                  <AiFillInstagram size={18} />
                </div>
                <div
                  className="mx-2 flex justify-between p-4 border-b-2 border-neutral-100
          hover:bg-neutral-200 hover:rounded-sm hover:cursor-pointer transition-all duration-200 ease-in-out"
                >
                  <span className="text-sm">Facebook</span>
                  <AiFillFacebook size={18} />
                </div>
              </div>
            </div>
          </div>
          <div className="col-span-8 hover:bg-neutral-200 hover:rounded-full  hover:cursor-pointer transition-all duration-200 ease-in-out">
            <div className="w-full h-full mt-8 bg-white rounded-lg mx-2 p-5">
              <div className="flex border-b-2 border-neutral-200">
                <h1
                  onClick={() => {
                    setPage(1);
                  }}
                  className="border-b-2 cursor-pointer font-semibold text-md p-1 inline-block border-black"
                >
                  Main Information
                </h1>
                <h1
                  onClick={() => {
                    setPage(2);
                  }}
                  className="border-b-1 mx-4 cursor-pointer text-md p-1 inline-block border-neutral-200"
                >
                  {" "}
                  Address Information
                </h1>
              </div>
              <div className="flex mt-4">
                <div className="flex flex-col w-full">
                  <label className="text-sm">First Name</label>
                  <input
                    className="inputText mt-2 rounded-lg border-2 border-neutral-100 text-sm bg-white  "
                    placeholder={client.name}
                    name="name"
                    onChange={(e) => {
                      handleForm(e);
                    }}
                  ></input>
                </div>
                <div className="flex flex-col w-full mx-3">
                  <label className="text-sm">Phone Number</label>
                  <input
                    className="inputText mt-2 rounded-lg border-2 border-neutral-100 text-sm bg-white  "
                    placeholder={client.phoneNumber}
                    name="phoneNumber"
                    onChange={(e) => {
                      handleForm(e);
                    }}
                  ></input>
                </div>
              </div>
              <div className="flex mt-4">
                <div className="flex flex-col w-full">
                  <label className="text-sm">Email Address</label>
                  <input
                    placeholder="Email Address"
                    className="inputText mt-2 rounded-lg border-2 border-neutral-100 text-sm bg-white  "
                  ></input>
                </div>
                <div className="flex flex-col w-full mx-3">
                  <label className="text-sm">Identification Number</label>
                  <input
                    className="inputText mt-2 rounded-lg border-2 border-neutral-100 text-sm bg-white  "
                    placeholder={client.noIdentification}
                    name="noIdentification"
                    onChange={(e) => {
                      handleForm(e);
                    }}
                  ></input>
                </div>
              </div>
              <div className="flex justify-end m-5">
                <button
                  onClick={() => {
                    setPage(2);
                    handleUpdatAndPost();
                  }}
                  className="p-2 w-36 text-sm rounded-full bg-black text-white"
                >
                  Next
                </button>
              </div>
            </div>
          </div>
          <div className="col-span-12"></div>
        </div>
      </>
    );
  } else {
    return (
      <div className="grid grid-cols-12">
        <div className="col-span-3">
          <div className="flex mt-8">
            <div className=" w-full h-full bg-white rounded-lg flex flex-col p-8 justify-left">
              <img
                className="rounded-full w-32 h-32 mx-auto"
                src="https://avataaars.io/?avatarStyle=Circle&topType=LongHairBigHair&accessoriesType=Round&hairColor=Auburn&facialHairType=Blank&clotheType=ShirtVNeck&clotheColor=Red&eyeType=Default&eyebrowType=Default&mouthType=Default&skinColor=Pale"
              ></img>
              <span className="mx-auto my-1">Alam Mena</span>
              <span className="mx-auto text-xs text-neutral-400 mb-4">
                Comprador
              </span>

              <div
                className="mx-2 flex justify-between p-4 border-y-2 border-neutral-100 
          hover:bg-neutral-200 hover:rounded-sm  hover:cursor-pointer transition-all duration-200 ease-in-out"
              >
                <span className="text-sm ">Twitter</span>
                <AiOutlineTwitter size={18} />
              </div>
              <div
                className="mx-2 flex justify-between p-4 border-b-2 border-neutral-100
          hover:bg-neutral-200 hover:rounded-sm hover:cursor-pointer transition-all duration-200 ease-in-out"
              >
                <span className="text-sm">Instagram</span>
                <AiFillInstagram size={18} />
              </div>
              <div
                className="mx-2 flex justify-between p-4 border-b-2 border-neutral-100
          hover:bg-neutral-200 hover:rounded-sm hover:cursor-pointer transition-all duration-200 ease-in-out"
              >
                <span className="text-sm">Facebook</span>
                <AiFillFacebook size={18} />
              </div>
            </div>
          </div>
        </div>
        <div className="col-span-8">
          <div className="w-full h-full mt-8 bg-white rounded-lg mx-2 p-5">
            <div className="flex border-b-2 border-neutral-200">
              <h1
                onClick={() => {
                  setPage(1);
                }}
                className="border-b-1 mx-4 cursor-pointer text-md p-1 inline-block border-neutral-200"
              >
                Main Information
              </h1>
              <h1
                onClick={() => {
                  setPage(2);
                }}
                className="border-b-2 cursor-pointer font-semibold text-md p-1 inline-block border-black"
              >
                {" "}
                Address Information
              </h1>
            </div>
            <div className="flex mt-4">
              <div className="flex flex-col w-full">
                <label className="text-sm">Address</label>
                <input
                  className="inputText mt-2 rounded-lg border-2 border-neutral-100 text-sm bg-white  "
                  placeholder={currentAddress.address}
                  name="address"
                  onChange={(e) => {
                    handleFormAddress(e);
                  }}
                ></input>
              </div>
              <div className="flex flex-col w-full mx-3">
                <label className="text-sm">Postal Code</label>
                <input
                  className="inputText mt-2 rounded-lg border-2 border-neutral-100 text-sm bg-white  "
                  placeholder="Phone number "
                ></input>
              </div>
            </div>
            <div className="flex mt-4">
              <div className="flex flex-col w-full">
                <label className="text-sm">City</label>
                <input
                  className="inputText mt-2 rounded-lg border-2 border-neutral-100 text-sm bg-white  "
                  placeholder="First name"
                ></input>
              </div>
              <div className="flex flex-col w-full mx-3">
                <label className="text-sm">State</label>
                <input
                  className="inputText mt-2 rounded-lg border-2 border-neutral-100 text-sm bg-white  "
                  placeholder="Identification"
                ></input>
              </div>
            </div>
            <div className="flex flex-col">
              <div className="flex justify-end mx-2 mt-4 items-center">
                <div
                  onClick={() => {
                    handleAddAddress();
                  }}
                  className=" bg-black text-white rounded-full p-4 cursor-pointer"
                >
                  <AiOutlinePlus />
                </div>
              </div>
              <table className="mt-1">
                <thead className="border-b-2">
                  <th className="px-4 text-sm py-2 text-left">Id</th>
                  <th className="px-4 text-sm text-left">Address</th>
                  <th className="px-4 text-sm text-left">PostalCode</th>
                  <th className="px-4 text-sm text-left">City</th>
                  <th className="px-4 text-sm text-left">Estate</th>
                </thead>
                <tbody>
                  {addressList.map((item, index) => {
                    console.log(item);
                    console.log(item.address);
                    return (
                      <tr
                        onClick={() => {
                          handleCurrentAddress(item.id);
                        }}
                        className="my-2 p-4 hover:bg-neutral-200 hover:rounded-full  hover:cursor-pointer transition-all duration-200 ease-in-out"
                      >
                        <td className="text-left px-4  py-4 text-xs">
                          {item.id}
                        </td>
                        <td className="text-left px-4 text-sm">
                          {item.addresses}
                        </td>
                        <td className="text-left px-4 text-sm">
                          {item.postalCode}
                        </td>
                        <td className="text-left px-4 text-sm">{item.city}</td>
                        <td className="text-left px-4 text-sm">{item.state}</td>
                      </tr>
                    );
                  })}

                  <tr className="my-2 p-4 hover:bg-neutral-200 hover:rounded-full  hover:cursor-pointer transition-all duration-200 ease-in-out">
                    <td className="text-left px-4  py-4 text-xs">01</td>
                    <td className="text-left px-4 text-sm">Default Address</td>
                    <td className="text-left px-4 text-sm">
                      Default postal code
                    </td>
                    <td className="text-left px-4 text-sm">Default City</td>
                    <td className="text-left px-4 text-sm">Default State</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
