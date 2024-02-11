import React, { useState } from 'react';
import {Card, CardContent, Typography, Button, Collapse, CardMedia, CardActions, Box} from '@mui/material';
import {method} from "../../api/methods";
import ProductEditModal from "./ProductEditModal";

const ProductCard = ({ product , setUpdateState}) => {

    const {id, price, name, description, type, imageUrl, isForMen, isForKids } = product;
    const [expanded, setExpanded] = useState(false);
    const [isEditModalOpen, setEditModalOpen] = useState(false);

    const handleExpandClick = () => {
        setExpanded(!expanded);
    };

    const handleDelete = async () => {
        const token = JSON.parse(localStorage.getItem("token"))

        try{
            const data = await method.admin.deleteProduct(token,id)
            console.log(data)

            setUpdateState(prev => !prev)
        }catch (e) {
            console.log(e)
        }

    }

    const handleUpdate = () => {
        setEditModalOpen(true);
    }

    const handleModalClose = () => {
        setEditModalOpen(false);
        setUpdateState(prev => !prev)
    }


    return (<>
            <Card sx={{width:"400px", height:"100%"}}>
                <CardMedia
                    component="img"
                    image={imageUrl}
                    alt={name}
                    sx={{height:"300px", width:"100%", objectFit:"contain"}}
                />
                <CardContent>
                    <Typography sx={{minHeight:"32px"}} gutterBottom variant="h5" component="div">
                        {name}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Price: ${price}
                    </Typography>
                </CardContent>
                <Box sx={{display:"flex" , justifyContent:"space-between"}}>
                    <CardActions>
                        <Button onClick={handleExpandClick} size="small">
                            {expanded ? 'Скрыть детали' : 'Показать детали'}
                        </Button>
                    </CardActions>
                    <Button sx={{color:"#3ebb4f", marginRight:"-70px"}} onClick={handleUpdate} size="small">
                        Update
                    </Button>
                    <Button sx={{color:"red", marginRight:"20px"}} onClick={handleDelete} size="small">
                        Delete
                    </Button>
                </Box>
                <Collapse in={expanded} timeout="auto" unmountOnExit>
                    <CardContent>
                        <Typography sx={{width:"100%"}} paragraph>Description: {description}</Typography>
                        <Typography paragraph>Type: {type}</Typography>
                        <Typography paragraph>For Men: {isForMen ? 'Yes' : 'No'}</Typography>
                        <Typography paragraph>For Kids: {isForKids ? 'Yes' : 'No'}</Typography>
                    </CardContent>
                </Collapse>
            </Card>


            {
                isEditModalOpen && <ProductEditModal
                    handleModalClose={handleModalClose}
                    productData={product}
                />
            }

        </>
    );
};

export default ProductCard;
