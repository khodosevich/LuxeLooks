import React from 'react';
import './stylesForMenuCategories.css'
import CategoriesItems from "./CategoriesItems";

const Man = () => {

    return (
        <>
            <CategoriesItems isForMen={true} isForKids={false}/>
        </>
    );
};

export default Man;