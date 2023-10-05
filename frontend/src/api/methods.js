import axios from "axios";

export const api = axios.create({
    baseURL: "http://localhost:5219/",
});


export const method = {

    async register(data) {
        let value = {} ;
        await api.post("Account/Register", data).then(r => {
            console.log( r.data)
            value = r.data
        })

        return value;
    },
    async login(data){

        let value = {} ;
        await api.post("Account/Login", data).then(r => {
            console.log( r.data)
            value = r.data
        })

        console.log("api login" , value)

        return value;
    },
    async getAllProduct() {
        return await api.get('Product/GetAll').then(r => {
            console.log( r.data)
            return r.data
        })
    },

    async subscribe(data){
        console.log(data.Email)
        console.log(data.Category)
        await api.put("Subscribe/CreateSubscribe",data)
    }

}