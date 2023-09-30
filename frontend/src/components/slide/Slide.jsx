import React from 'react';
import landingImg from "../../assets/image.svg";
import {Box} from "@mui/material";

import "./slider.css"
import {NavLink} from "react-router-dom";

const Slide = ({props}) => {

    return (
        <div className="slider">
            <div className={props.color}>
             <div className="title__slider">

                 <div className="uptitle__slide">
                     {props.description}
                 </div>
                 <div className="title__slide">
                     {props.title}
                 </div>

                 <div className="btns__slider">
                     <NavLink to="/man">
                         <button className="btn__slider">{props.btnFirst}</button>
                     </NavLink>
                     <NavLink to="/man">
                         <button className="btn__slider__second">{props.btnSecond}</button>
                     </NavLink>
                 </div>
             </div>
             <div className="img__slider">
                 <img src={props.image} alt=""/>
             </div>
            </div>
        </div>
    );
};

export default Slide;