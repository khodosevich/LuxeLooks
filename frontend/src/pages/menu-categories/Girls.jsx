import React from 'react';
import CategoriesItems from "./CategoriesItems";

const Girls = () => {

    return (
      <>
        <CategoriesItems isForMen={false} isForKids={true}/>
      </>
    );
};

export default Girls;