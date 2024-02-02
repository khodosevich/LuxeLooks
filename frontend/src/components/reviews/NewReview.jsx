import React, {useState} from 'react';
import {Alert, AlertTitle, Box} from "@mui/material";
import {method} from "../../api/methods";
import jwt_decode from "jwt-decode";

const NewReview = ({productId,userToken, newReview}) => {

    const [isAlert, setIsAlert] = useState(false)
    const [alertData,setAlertData] = useState("")

    const [reviewInput, setReviewInput] = useState("")

    const createReview = async () => {

        const token = JSON.parse(localStorage.getItem("token"));

        if( !token ){
            setAlertData("Need authorization")
            setIsAlert(true)

            setTimeout(() =>{
                setIsAlert(false)
                setAlertData("")
            },3000)
            return
        }

        const decoded = jwt_decode(token)

        const data = {
            "UserId": decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],
            "Title": reviewInput,
            "ProductId": productId
        }


        try{
            const response = await method.reviews.createReview(data, userToken)

            setReviewInput("")

            newReview(prev => !prev)

        }catch(e) {

            setAlertData(e.response.data)
            setIsAlert(true)

            setTimeout(() =>{
                setIsAlert(false)
                setAlertData("")
            },3000)

            setReviewInput("")
        }

    }

    return (
        <Box mt={2}>

            {
                isAlert &&
                <Alert severity="error">
                    <AlertTitle>{alertData}</AlertTitle>
                </Alert>
            }

            <Box mt={2}>
                <input
                    placeholder={"Enter our review"}
                    style={{
                    padding:"15px 10px",
                    width:"500px",
                    borderRadius:"10px",
                    outline:"0",
                    border:"1px solid grey",
                }}
                       value={reviewInput}  onChange={(e) => setReviewInput(e.target.value) } type="text"/>
                <button onClick={createReview} style={{padding:"15px 60px",color:"white", borderRadius:"5px",  border:"none",marginLeft:"20px", background: "#17696A"}} >add</button>
            </Box>
        </Box>
    );
};

export default NewReview;