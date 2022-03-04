import axios from "axios";
import { getAuth } from "firebase/auth";

let token;
if (typeof window !== "undefined") {
  token = window.localStorage.getItem("token");
}
const api = axios.create({
  baseURL: "https://localhost:7273",
  timeout: 1000,
  headers: {
    Authorization: `Bearer ${token}`,
  },
});

export default api;
