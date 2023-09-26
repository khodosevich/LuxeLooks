import React from 'react';
import Landing from "../../components/Landing/Landing";
import TrendingNow from "../../components/trendingnow/TrendingNow";
import Categories from "../../components/categories/Categories";

const Home = () => {
    return (
       <>
        <Landing/>
         <Categories/>
        <TrendingNow/>
       </>
    );
};

export default Home;