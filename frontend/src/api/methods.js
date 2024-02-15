import axios from "axios";
import {logDOM} from "@testing-library/react";

export const api = axios.create({
    withCredentials:true,
    baseURL: "http://localhost:5219/",
});


export const method = {

    async register(data) {
        let value = {} ;
        await api.post("Account/Register", data).then(r => {
            value = r.data
        })

        return value;
    },
   async revoke(person){
       console.log(person.name)
       console.log(person.token)
       await api.post(`Account/Revoke/${person.name}`, {
            headers: {
                'Authorization': `Bearer ${person.token}`
            }
        }).then(r => {
           console.log(r)
       })

    }
    ,
    async login(data){
        console.log(data)
        let value = {} ;
        await api.post("Account/Login", data).then(r => {
            value = r.data
        })

        return value;
    },
    async getAllProduct() {
        return await api.get("Product/GetAll").then(r => {
            return r.data
        })
    },

    async subscribe(data){
        await api.put("Subscribe/CreateSubscribe",data)
    },

    async getPopularProducts() {
        return await api.get("Product/GetPopularProducts").then(r => {
            return r.data
        })
    },
    async getProductById(id) {
        return api.get(`/Product/GetById/${id}`).then(r => {
            return r.data
        })
    },
    async getProductByName(name) {
        return api.get(`/Product/GetByName/${name}`).then(r => {
            return r.data
        })
    },
    async getCart(userToken) {
        console.log(userToken)
        try {
            const response = await api.get('/Cart/GetCart', {
                headers: {
                    'Authorization': `Bearer ${userToken}`,
                    'Content-Type': 'application/json'
                }
            });
            return response.data;
        } catch (error) {
            console.error(error);
            // throw error;
        }
    },
    async addToCart(productId,userToken) {
        const data = {
            "Id": productId
        };
        try {

            return await api.put('/Cart/AddToCart', data, {
                headers: {
                    'Authorization': `Bearer ${userToken}`
                }
            });
        } catch (error) {
            console.error(error);
            // throw error;
        }
    },
    async removeFromCart(productId, userToken) {

        try {
            const response = await api.delete(`/Cart/RemoveFromCart`, {
                data: {
                    "Id": productId
                },
                headers: {
                    'Authorization': `Bearer ${userToken}`,
                    'Content-Type': 'application/json'
                },
            });

            return response.data;
        } catch (error) {
            console.error(error);
            // throw error;
        }
    },
    async getOrderById(userId, userToken) {

        try{
            const response = await api.get(`/Order/GetOrderByUserId/${userId}`, {
                headers: {
                    'Authorization': `Bearer ${userToken}`
                }
            });
            return response.data;
        }catch (error){
            console.log("Error: " , error)
        }
    },
    async createOrder(data ,userToken) {


        try{
            const response = await api.post(`/Order/CreateOrder`,
                data
            ,{
                headers: {
                    'Authorization': `Bearer ${userToken}`
                }});
            return response.data;
        }catch (error){
            console.log("Error: " , error)
        }
    },
    async removeAllCart(userToken){
        try{
            const response = await api.delete("/Cart/DeleteCart",{
                headers: {
                    'Authorization': `Bearer ${userToken}`
                }});
        }catch (e) {
            console.log("error" , e)
        }
    },

    reviews : {
        async getReviewsByProduct(productId) {
                try{
                    const reviews = await api.get(`http://localhost:5219/review/GetByProductId/${productId}`)
                    return reviews.data;
                }catch (e) {
                    console.log(e)
                }
        },
        async createReview(data,userToken) {
            try{
                const response = await api.post("http://localhost:5219/review/CreateReview",
                    data,
                    {
                        headers: {
                            'Authorization': `Bearer ${userToken}`
                        }
                    }
                )

                return response.data;
            }catch (e) {
               throw e;
            }
        },
        async getReviewsByUserId() {

        }
    },

    async getUserById(id) {
        try{
            return await api.get(`http://localhost:5219/User/GetByid/${id}`)

        }catch (e) {
            throw e;
        }
    },
    admin: {
        async getAllOrder(adminToken) {
            try{
                const response = await api.get(`/Admin/Order/GetAll`, {
                    headers: {
                        'Authorization': `Bearer ${adminToken}`
                    }
                });
                return response
            }catch (e) {
                console.log(e)
            }
        },
        async updateOrderStatus(adminToken, orderId, statusType) {
            let status = "";

            if (statusType === 1) {
                status = "Sent";
            } else if (statusType === 2) {
                status = "Completed";
            } else if (statusType === 0) {
                status = "Processing";
            }

            try {
                const response = await api.put(`/Admin/Order/UpdateStatus`, {
                    "NewStatus": status,
                    "Id": orderId
                }, {
                    headers: {
                        'Authorization': `Bearer ${adminToken}`
                    }
                });
                return response;
            } catch (e) {
                console.log(e);
                throw e;
            }
        },
        async deleteOrder(adminToken, orderId) {
            try {
                const response = await api.delete(`/Admin/Order/Delete/${orderId}`, {
                    headers: {
                        'Authorization': `Bearer ${adminToken}`
                    }
                });
                return response;
            } catch (e) {
                console.log(e);
                throw e;
            }
        },
        async createProduct (adminToken,product) {
            try{
                const response = await api.post(`/Admin/Product/Create`, product ,{
                    headers: {
                        'Authorization': `Bearer ${adminToken}`
                    }
                });
                return response;
            }catch (e) {
                console.log(e)
            }
        },
        async getAllProducts(adminToken) {
            return await api.get("/Admin/Product/GetAll", {
                headers:{
                    'Authorization': `Bearer ${adminToken}`
                }
            })
        },
        async deleteProduct (adminToken , productId ) {
            return await api.delete(`/Admin/Product/Delete/${productId}`, {
                headers:{
                    'Authorization': `Bearer ${adminToken}`
                }
            })
        },
        async updateProduct (adminToken,newProduct) {
            console.log("new",  newProduct)
            return await api.put(`/Admin/Product/Update`, newProduct ,{
                headers: {
                    'Authorization': `Bearer ${adminToken}`
                }
            });
        }
    },
    async getAllProductsName () {
        return await api.get("/Product/GetAllNames")
    }
}