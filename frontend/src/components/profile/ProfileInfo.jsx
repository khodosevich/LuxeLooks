import React, {useContext} from 'react';
import {MyContext} from "../../App";

const ProfileInfo = () => {

    const {user,setUser} = useContext(MyContext)

    return (
        <div>
            <h3>My profile</h3>

            <div style={{marginTop:"50px"}}>
                <h4>Username: {user.username}</h4>
                <h4>Email:{user.email}</h4>
            </div>

        </div>
    );
};

export default ProfileInfo;