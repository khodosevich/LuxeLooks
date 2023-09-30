import React from 'react';
import { Swiper, SwiperSlide } from 'swiper/react';

import { Navigation, Scrollbar, A11y  } from 'swiper/modules';
import 'swiper/css/navigation';
import 'swiper/css/pagination';
import 'swiper/css/scrollbar';
import 'swiper/css';


import Slide from "../slide/Slide";
import sliders from "./slides.json"

const Landing = () => {
    return (
        <div className="swiper">
            <Swiper
                modules={[Navigation, Scrollbar, A11y ]}
                spaceBetween={50}
                slidesPerView={1}
                navigation

                scrollbar={{ draggable: true }}
                onSlideChange={() => console.log('slide change')}
                onSwiper={(swiper) => console.log(swiper)}
            >
                    {sliders.map((el,index) => (
                        <SwiperSlide>
                          <Slide key={index} props={el}/>
                        </SwiperSlide>
                    ))}
            </Swiper>
        </div>
    );
};

export default Landing;