// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyBbVNEvqsH1qjhnmpLMMzPRRb8aDHVnhT0",
  authDomain: "oriontek-482c8.firebaseapp.com",
  projectId: "oriontek-482c8",
  storageBucket: "oriontek-482c8.appspot.com",
  messagingSenderId: "740000265852",
  appId: "1:740000265852:web:b6c20b7bc597c141393bf9",
  measurementId: "G-Q5NGD8DVHR",
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);

export default app;
