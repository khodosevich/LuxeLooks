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

function App() {
  return (
    <div className={style.App}>
        <Header/>
            <Routes>
                <Route path="/" element={<Home/>} />
                <Route path="/about" element={<About/>} />
                <Route path="/man" element={<Man/>} />
                <Route path="/women" element={<Women/>} />
                <Route path="/boys" element={<Boys/>} />
                <Route path="/girls" element={<Girls/>} />
                <Route path="/sale" element={<Sale/>} />
            </Routes>
    </div>
  );
}

export default App;
