import React, {useEffect, useState} from 'react';

import clock from "../../assets/Clock.svg"
import plus from "../../assets/Plus.svg"
import OrderElement from "./OrderElement";

const OrderItem = ({props}) => {

    const [formattedOrderTime, setFormattedOrderTime] = useState("")

    const formattedData = (dateString) => {
        const months = [
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        ];

        const dateObject = new Date(dateString);

        const day = dateObject.getDate();
        const monthName = months[dateObject.getMonth()];
        const year = dateObject.getFullYear();

        const formattedDate = `${monthName} ${day}, ${year}`;
        setFormattedOrderTime(formattedDate);

    }

    const statusStyles = {
        0: { background: "#5A87FC" },
        1: { background: "#03CEA4" },
        2: { background: "#119a1b" }
    };

    const statusText = {
        0: "В обработке",
        1: "Отправлен",
        2: "Завершен"
    };

    const [ids, setIds] = useState([]);

    const [isOpen, setIsOpen] = useState(false)

    const openOrdersItems =  () => {

        if(isOpen) {
            setIsOpen(false)
        }else{
            const arr = []
            props.productsIds.map((item,index) => {
                arr.push(props.productsIds[index])
            });

            setIds(arr)

            setIsOpen(true)
        }

    }



    useEffect(() => {
        formattedData(props.createTime)
    }, [ids]);

    return (
        <div>
            <div style={{
                width: "810px",
                display:"flex",
                alignItems:"center",
                justifyContent:"space-between",
                padding:"24px 0"
            }}>
                <div style={{
                    color:"#1E212C",
                    fontFamily: "Lato",
                    fontSize: "16px",
                    fontStyle: "normal",
                    fontWeight: "400",
                    lineHeight: "160%"
                }}>
                    #{props.id}
                </div>
                <div style={{
                    display:"flex",
                    gap:"10px",
                }}>
                    <div>
                        <img src={clock} alt=""/>
                    </div>
                    <div>
                       {formattedOrderTime}
                    </div>
                </div>

                <div style={{...statusStyles[props.status] ,
                    padding: "1px 8px",
                    borderRadius: "4px",
                    color:"#FFF",
                    fontFamily: "Lato",
                    fontSize: "14px",
                    fontStyle: "normal",
                    fontWeight: "400",
                    lineHeight: "150%"
                }}>

                    {statusText[props.status]}
                </div>
                <div>
                    ${props.price}
                </div>

                <div>
                    <img onClick={openOrdersItems} style={{cursor:"pointer"}} src={plus} alt=""/>
                </div>
            </div>

            {
                ids.length > 0 && isOpen
                    ? ids.map(el => (<OrderElement props={el}/>))
                    : <></>
            }

            <div style={{
                width: "810px",
                height: "1px",
                background:"#E5E8ED"
            }}>
            </div>
        </div>
    );
};

export default OrderItem;