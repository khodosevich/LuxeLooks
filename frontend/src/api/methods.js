import axios from "axios";

export const api = axios.create({
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
    async login(data){

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
    }
}