import React from 'react';
import {Box, Typography} from "@mui/material";

const ReviewItem = ({title,createDate, userId}) => {
    return (
        <Box sx={{
            border:"1px solid grey",
            borderRadius:"20px",
            padding:"15px"
        }}>
            <Box sx={{display:"flex" , alignItems:"center" , justifyContent:"space-between"}}>

                <Typography variant="h6">
                    {title}
                </Typography>

                <Box>
                    <Typography variant="body1">
                        {
                            createDate
                        }
                    </Typography>
                </Box>


            </Box>
        </Box>
    );
};

export default ReviewItem;