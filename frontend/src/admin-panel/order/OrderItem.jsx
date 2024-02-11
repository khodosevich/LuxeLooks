import React, { useState } from 'react';
import {Card, CardContent, Typography, Button, Collapse, List, ListItem, ListItemText, Box, Alert} from '@mui/material';
import {method} from "../../api/methods";

const OrderItem = ({ order, onUpdateStatus, onDeleteOrder }) => {
    const { id, address, createTime, email, name, price, productsIds, status, userId } = order;

    const [expanded, setExpanded] = useState(false);
    const [alertMessage, setAlertMessage] = useState(null);


    const handleStatusUpdate = async (newStatus) => {

        const token = JSON.parse(localStorage.getItem("token"))
        try {
            const data = await method.admin.updateOrderStatus(token,id,newStatus)
            console.log(data)

            onUpdateStatus(prev => !prev)
            setAlertMessage("Статус заказа успешно обновлен.");
            setTimeout(() => {
                setAlertMessage(null)
            },3000)
        } catch (e) {
            console.log(e)
        }

    };

    const handleDelete =  async () => {

        const token = JSON.parse(localStorage.getItem("token"))

        try {
            const data = await method.admin.deleteOrder(token,id)
            console.log(data)
            onUpdateStatus(prev => !prev)
            setAlertMessage("Заказ успешно удален.");
            setTimeout(() => {
                setAlertMessage(null)
            },3000)
        }catch (e) {
            console.log(e)
        }
    };

    const statusStyles = {
        0: { color: "#5A87FC" },
        1: { color: "#03CEA4" },
        2: { color: "#119a1b" }
    };

    const statusText = {
        0: "В обработке",
        1: "Отправлен",
        2: "Завершен"
    };

    return (
        <Card className="order-item" variant="outlined">
            <CardContent>
                <Typography variant="h5">Order ID: {id}</Typography>
                <Typography gutterBottom variant="subtitle1">Status: <span style={{...statusStyles[status]}}>{statusText[status]}</span></Typography>
                <Collapse in={expanded} timeout="auto" unmountOnExit>
                    <List component="div" disablePadding>
                        <ListItem>
                            <ListItemText primary={`Address: ${address}`} />
                        </ListItem>
                        <ListItem>
                            <ListItemText primary={`Create Time: ${createTime}`} />
                        </ListItem>
                        <ListItem>
                            <ListItemText primary={`Email: ${email}`} />
                        </ListItem>
                        <ListItem>
                            <ListItemText primary={`Name: ${name}`} />
                        </ListItem>
                        <ListItem>
                            <ListItemText primary={`Price: ${price} $`} />
                        </ListItem>
                        <ListItem>
                            <ListItemText primary={`Product Ids: ${productsIds.join(', ')}`} />
                        </ListItem>
                        <ListItem>
                            <ListItemText primary={`User ID: ${userId}`} />
                        </ListItem>
                    </List>
                </Collapse>

                {alertMessage && (
                    <Box sx={{ mt: 2 }}>
                        <Alert severity="success">{alertMessage}</Alert>
                    </Box>
                )}

                <Box sx={{display:"flex", flexDirection:"row" , gap:"30px"}}>
                    <Button onClick={() => setExpanded(!expanded)}>{expanded ? 'Скрыть детали' : 'Показать детали'}</Button>
                    <Button onClick={() => handleStatusUpdate(0)}>В обработке</Button>
                    <Button onClick={() => handleStatusUpdate(1)}>Отправлен</Button>
                    <Button onClick={() => handleStatusUpdate(2)}>Завершен</Button>
                    <Button onClick={() => handleDelete()}>Удалить заказ</Button>
                </Box>
            </CardContent>
        </Card>
    );
};

export default OrderItem;
