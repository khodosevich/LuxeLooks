import style from './App.module.css';
import Header from "./components/Header/Header";
import { Route, Routes} from "react-router-dom";
import Home from "./pages/Home/Home";
import About from "./pages/About/About";
import Man from "./pages/Man/Man";
import Women from "./pages/Women/Women";
import Boys from "./pages/Boys/Boys";
import Sale from "./pages/Sale/Sale";
import Girls from "./pages/Girls/Girls";
import Footer from "./components/footer/Footer";
import axios from "axios";

function App() {

    const request = () => {
        console.log("hello")

        axios.get("https://localhost:7227/Product/GetAll")
            .then(response => {
                console.log(response.data);
            })
            .catch(error => {
                console.error("Произошла ошибка:", error);
            });

    }

  return (
    <div className={style.App}>

        <button onClick={request}>click</button>

        {/*<Header/>*/}
        {/*    <Routes>*/}
        {/*        <Route path="/" element={<Home/>} />*/}
        {/*        <Route path="/about" element={<About/>} />*/}
        {/*        <Route path="/man" element={<Man/>} />*/}
        {/*        <Route path="/women" element={<Women/>} />*/}
        {/*        <Route path="/boys" element={<Boys/>} />*/}
        {/*        <Route path="/girls" element={<Girls/>} />*/}
        {/*        <Route path="/sale" element={<Sale/>} />*/}
        {/*    </Routes>*/}
        {/*<Footer/>*/}
    </div>
  );
}

export default App;
