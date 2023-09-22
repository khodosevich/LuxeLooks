import style from './App.module.css';
import Header from "./components/Header/Header";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Home from "./components/Home/Home";
import About from "./components/About/About";

function App() {
  return (
    <div className={style.App}>
        <Header/>


            <Routes>
                <Route path="/" element={<Home/>} />
                <Route path="/about" element={<About/>} />
                <Route path="/man" element={<About/>} />
                <Route path="/women" element={<About/>} />
                <Route path="/boys" element={<About/>} />
                <Route path="/girls" element={<About/>} />
                <Route path="/sale" element={<About/>} />
                <Route path="/bag" element={<About/>} />
            </Routes>
    </div>
  );
}

export default App;
