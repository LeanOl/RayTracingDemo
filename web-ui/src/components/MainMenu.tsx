"use client";

import React from "react";
import Button from '@mui/material/Button';
import CategoryIcon from '@mui/icons-material/Category';
import FormatColorFillIcon from '@mui/icons-material/FormatColorFill';
import {useRouter} from "next/navigation";


import "./MainMenu.css";

export default function MainMenu() {

    const router = useRouter();

    const handleCreateFigureClick = () => {
        router.push('/create-figure');
    };

    return (
        <div>
        <div className="main-menu-text">
            <h1 className="main-menu-title">Ray Tracing Demo</h1>
            <p className="main-menu-normal-text">Choose an option below to get started</p>
        </div>
        <div className="main-menu-buttons">
        <Button variant="outlined" startIcon={<CategoryIcon />} onClick={handleCreateFigureClick}>
            Create Figure
        </Button>
        <Button variant="outlined" startIcon={<FormatColorFillIcon/>}>
            Create Material
        </Button>
        <Button variant="outlined">
            <CategoryIcon />
            <FormatColorFillIcon/>
            Create Model
        </Button>
        </div>
        </div>
        
    );
}
