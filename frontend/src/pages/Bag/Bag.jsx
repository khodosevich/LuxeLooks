import React, {useContext} from 'react';
import {MyContext} from "../../App";
import {Navigate} from "react-router-dom";

const Bag = () => {


    const {user,setUser} = useContext(MyContext);


    return (
        <>
            {
                user.isAuthenticated
                    ? <div>
                        bag
                    </div>
                    :<Navigate to="/signin"/>
            }
        </>
    );
};

export default Bag;