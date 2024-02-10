import React, {useContext} from 'react';
import {MyContext} from "../../App";
import SideBar from "../../pages/sidebar/SideBar";
import {Navigate, Route, Routes} from "react-router-dom";
import Man from "../../pages/menu-categories/Man";
import MyOrders from "../myorders/MyOrders";
import ProfileInfo from "./ProfileInfo";
import Bag from "../../pages/Bag/Bag";
import UserBag from "./UserBag";


const Profile = () => {

    const {user,setUser} = useContext(MyContext)


    return (
        <div style={{width:"1232px" , margin:"0 auto" , height:"100vh"}}>
            {
                user.isAuthenticated ?
                    <div style={{display:"flex" , alignItems: "start" , gap:"50px" , padding:"40px 0" }}>
                        <SideBar/>

                        <Routes>
                            <Route path="/profileinfo" element={<ProfileInfo />} />
                            <Route path="/bag" element={<UserBag />} />
                            <Route path="/myorders" element={<MyOrders />} />
                        </Routes>
                    </div>
                        : <Navigate to='/'/>
            }
        </div>
    );
};

export default Profile;