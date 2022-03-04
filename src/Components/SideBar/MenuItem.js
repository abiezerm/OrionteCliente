import { AiOutlineHome } from "react-icons/ai";
import { IconContext } from "react-icons/lib";
export default function ({ Icon, Title, Route }) {
  return (
    <>
      <a>
        <div className="text-center cursor-pointer p-4 m-2 text-white hover:bg-white flex rounded-full hover:text-black hover:cursor-pointertransition-all duration-500 ease-in-out">
          <div className="">
            <Icon size={24} />
          </div>
          <span className="ml-3">{Title}</span>
        </div>
      </a>
    </>
  );
}
