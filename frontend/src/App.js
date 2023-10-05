import React, {useState} from 'react';


import style from './App.module.css';
import Header from "./components/header/Header";
import {Route, Routes, useLocation, useNavigate, useNavigation} from "react-router-dom";
import Home from "./pages/home/Home";
import About from "./pages/about/About";
import Man from "./pages/menu-categories/Man";
import Women from "./pages/menu-categories/Women";
import Boys from "./pages/menu-categories/Boys";
import Sale from "./pages/sale/Sale";
import Girls from "./pages/menu-categories/Girls";
import Footer from "./components/footer/Footer";
import axios from "axios";
import {method} from "./api/methods";
import Registration from "./pages/registration/Registration";
import Bag from "./pages/Bag/Bag";
import SignIn from "./pages/signin/SignIn";
import SideBar from "./pages/sidebar/SideBar";
import Profile from "./components/profile/Profile";


export const MyContext = React.createContext();


function App() {
    const location = useLocation();

    const [user, setUser] = useState({
        token: "",
        username: "",
        email:"",
        isAuthenticated: false,
    })

    const renderHeaderCondition = location.pathname !== "/registration" &&  location.pathname !== "/signin";
    const renderFooterCondition = location.pathname !== "/registration" &&  location.pathname !== "/signin";

  return (
    <div className={style.App}>
        <MyContext.Provider value={{user,setUser}}>
            {renderHeaderCondition && <Header/>}
                <Routes>
                    <Route path="/" element={<Home/>} />
                    <Route path="/about" element={<About/>} />
                    <Route path="/man" element={<Man/>} />
                    <Route path="/women" element={<Women/>} />
                    <Route path="/boys" element={<Boys/>} />
                    <Route path="/girls" element={<Girls/>} />
                    <Route path="/sale" element={<Sale/>} />
                    <Route path="/bag" element={<Bag/>} />
                    <Route path="/registration" element={<Registration/>} />
                    <Route path="/signin" element={<SignIn/>} />
                    <Route path="/account/*" element={<Profile/>} />
                </Routes>
            {renderFooterCondition && <Footer/>}
        </MyContext.Provider>
    </div>
  );
}

export default App;
