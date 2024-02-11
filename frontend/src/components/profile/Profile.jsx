import React, {useContext} from 'react';
import {MyContext} from "../../App";
import SideBar from "../../pages/sidebar/SideBar";
import {Navigate, Route, Routes} from "react-router-dom";
import Man from "../../pages/menu-categories/Man";
import MyOrders from "../myorders/MyOrders";
import ProfileInfo from "./ProfileInfo";
import Bag from "../../pages/Bag/Bag";
import UserBag from "./UserBag";
import AdminOrder from "../../admin-panel/order/AdminOrder";
import AdminProducts from "../../admin-panel/products/AdminProducts";
import AdminNewProduct from "../../admin-panel/products/AdminNewProduct";
import AdminChangeProduct from "../../admin-panel/products/AdminChangeProduct";


const Profile = () => {

    const {user,setUser} = useContext(MyContext)


    return (
        <div style={{width:"1232px" , margin:"0 auto" , minHeight:"100vh"}}>
            {
                user.isAuthenticated ?
                    <div style={{display:"flex" , alignItems: "start" , gap:"50px" , padding:"40px 0" }}>
                        <SideBar/>

                        <Routes>
                            <Route path="/profileinfo" element={<ProfileInfo />} />
                            <Route path="/bag" element={<UserBag />} />
                            <Route path="/myorders" element={<MyOrders />} />
                            {
                                user.username === "Admin" && <>
                                    <Route path="/admin-orders" element={<AdminOrder />} />
                                    <Route path="/admin-new-product" element={<AdminNewProduct />} />
                                    <Route path="/admin-update-product" element={<AdminChangeProduct />} />
                                </>
                            }
                        </Routes>
                    </div>
                        : <Navigate to='/'/>
            }
        </div>
    );
};

export default Profile;