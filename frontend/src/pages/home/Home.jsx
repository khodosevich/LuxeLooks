import React from 'react';
import Landing from "../../components/landing/Landing";
import TrendingNow from "../../components/trendingnow/TrendingNow";
import Categories from "../../components/categories/Categories";
import PopularCategory from "../../components/popularcategory/PopularCategory";
import Support from "../../components/support/Support";
import FollowInstagram from "../../components/followinstagram/FolowInstagram";

const Home = () => {
    return (
       <>
        <Landing/>
         <Categories/>
         <PopularCategory/>
         <TrendingNow/>
         <Support/>
          <FollowInstagram/>
       </>
    );
};

export default Home;