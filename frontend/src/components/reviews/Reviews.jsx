import React, {useEffect, useState} from 'react';
import {method} from "../../api/methods";
import ReviewItem from "./ReviewItem";
import {Box, Typography} from "@mui/material";
import NewReview from "./NewReview";

const Reviews = ({productId,userToken}) => {

    const [user,setUser] = useState()

    const [newReview,setNewReview] = useState(false)

    const [reviewsProduct, setReviewsProduct] = useState([])

    const fetchReviews = async () => {
        const data = await method.reviews.getReviewsByProduct(productId)
        console.log(data)
        setReviewsProduct(data)
    }

    useEffect(() => {
        fetchReviews();
    }, [newReview]);

    return (
        <Box>
            <Typography mb={2} variant={"h5"}>
                Reviews:
            </Typography>
            <Box sx={{display:"flex",gap:"20px" , flexDirection:"column"}}>
                {
                    reviewsProduct > 0 && reviewsProduct.map(item => (
                        <ReviewItem key={item.id} title={item.title} createDate={item.createDate} userId={item.userId}/>
                    ))
                }
            </Box>

            <NewReview productId={productId} userToken={userToken} newReview={setNewReview}/>

        </Box>
    );
};

export default Reviews;