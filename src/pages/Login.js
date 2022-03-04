import { useEffect, useState } from "react";
import app from "../API/Firebase";
import { getAuth, signInWithEmailAndPassword } from "firebase/auth";
import api from "../API/AxiosInstance";
import { Navigate, useHistory, useNavigate } from "react-router-dom";

export default function () {
  const [email, setEmail] = useState("");
  const [emailIsValid, setEmailIsValid] = useState(true);
  const [emailErrorMessage, setEmailErrorMessage] = useState("");

  const [passwordIsValid, setPasswordIsValid] = useState(true);
  const [passwordErrorMessage, setPasswordErrorMessage] = useState("");
  const [password, setPassword] = useState("");

  const handleEmailChange = (e) => {
    setEmail(e.target.value);
    setEmailIsValid(
      RegExp(
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      ).test(email)
    );
  };

  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
    if (e.target.value.length < 5) {
      setPasswordErrorMessage("Password must have 5 characters");
      setPasswordIsValid(false);
    } else {
      setPasswordIsValid(true);
    }
  };

  //   const navigate = useNavigate();
  const navigate = useNavigate();
  const login = () => {
    const auth = getAuth(app);
    signInWithEmailAndPassword(auth, email, password)
      .then((userCredential) => {
        // Signed in
        console.log(userCredential);
        localStorage.setItem("token", userCredential.user.accessToken);
        localStorage.setItem("user", JSON.stringify(userCredential));
        localStorage.setItem("userMail", userCredential.user.email);

        navigate("/Clients");
      })
      .catch((error) => {
        console.log(error);
      });
  };
  return (
    <>
      <div className="h-screen bg-black">
        <div className="flex justify-center w-screen my-10 sm:my-0 sm:h-screen md:h-screen md:justify-center md:items-center sm:m-auto">
          {/* image side */}
          <div className="bg-white flex p-16 rounded-lg">
            <figure className=" flex mr-6">
              <img
                className="rounded-l-md w-96 h-full m-auto"
                src="https://cdn.dribbble.com/users/1731254/screenshots/17054663/media/12313c2a1d84818bfebbf46a3127186e.png?compress=1&resize=1600x1200&vertical=top"
              ></img>
            </figure>
            <div className="flex flex-col w-64 sm:w-64 md:w-64 md:self-center sm:self-center">
              <h1 className="mx-auto my-5">Sign In</h1>
              <span className="px-2 font-semibold text-xs"> Email</span>
              <input
                type="text"
                placeholder="Email"
                className={`p-2 border-2 rounded-lg m-2 text-xs  border-neutral-100 ${
                  emailIsValid === true
                    ? ""
                    : " border-red-600 focus:outline-red-600"
                }`}
                onChange={handleEmailChange}
              ></input>
              <span
                className={`px-2 font-semibold text-xs text-red-600 ${
                  emailIsValid ? "hidden" : "mb-2"
                }`}
              >
                {" "}
                {emailErrorMessage}
              </span>
              <span className="px-2 text-xs">Password</span>
              <input
                type="password"
                placeholder="Password"
                onChange={handlePasswordChange}
                className={` p-2 border-2 rounded-lg m-2 text-xs  border-neutral-100 ${
                  passwordIsValid === true
                    ? ""
                    : " border-red-600 focus:outline-red-600"
                }`}
              ></input>
              <span
                className={`px-2 font-semibold text-xs text-red-600 ${
                  passwordIsValid ? "hidden" : "mb-2"
                }`}
              >
                {" "}
                {passwordErrorMessage}
              </span>
              <a className="px-2 font-semibold text-xs self-end" href="">
                Forgot Password?
              </a>

              <button
                onClick={login}
                className=" p-2 mt-6 mb-2 bg-black text-sm text-white rounded-lg"
              >
                Login
              </button>
              <div className="flex justify-center">
                <span className="text-xs ">
                  Don't have account?
                  <a className=" text-blue-400 text-xs ml-1" href="">
                    Sign up
                  </a>
                </span>
              </div>
              <div className="flex items-center justify-center mt-4">
                <hr className="m-2 w-full" />
                <span className="text-xs"> Or</span>
                <hr className="m-2 w-full" />
              </div>
              <button className=" flex justify-center p-2 mt-6 mb-2 text-sm border-2 border-neutral-100 rounded-lg">
                <img
                  className=" w-4 h-4 mx-2 "
                  src="https://cdn-icons-png.flaticon.com/512/300/300221.png"
                />
                <span className="text-xs">Login with google</span>
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
