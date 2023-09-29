import React, {useContext} from 'react';
import './man.css'
import {MyContext} from "../../App";

const Man = () => {

    const context = useContext(MyContext);

    return (
        <div className="man__page">
            <div className="man__container">
                <div className="man__content">
                  man
                </div>
            </div>
        </div>
    );
};

export default Man;