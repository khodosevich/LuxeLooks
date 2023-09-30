import React, {useContext} from 'react';
import {MyContext} from "../../App";
import {Navigate} from "react-router-dom";
import BagElement from "../../components/bagelement/BagElement";

import './bag.css'

const Bag = () => {


    const {user,setUser} = useContext(MyContext);


    return (
        <div className="bag-page">
            <div className="bag-container">

                <div className="bag-content">
                    <div className="bag-items">
                        <h2 className="bag-content-title">My bag</h2>

                        <div className="bag__elements">
                            <BagElement/>
                            <BagElement/>
                            <BagElement/>
                            <BagElement/>
                            <BagElement/>
                            <BagElement/>
                        </div>

                        <div className="confirm-order">
                            <button className="btn__confirm-order">
                                Complete order
                            </button>
                        </div>

                    </div>
                    <div className="bag-info__user">
                        <h3 className="bag-info__user__name">
                            {user.username}
                        </h3>
                        <p className="bag-info__user__email">
                            annetteb@example.com
                        </p>
                    </div>
                </div>
            </div>
            {/*{*/}
            {/*    user.isAuthenticated*/}
            {/*        ? <div>*/}
            {/*            bag*/}
            {/*        </div>*/}
            {/*        :<Navigate to="/signin"/>*/}
            {/*}*/}
        </div>
    );
};

export default Bag;