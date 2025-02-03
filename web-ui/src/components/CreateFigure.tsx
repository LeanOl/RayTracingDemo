"use client"

import React from 'react';
import { TextField, Button, Container, Typography } from '@mui/material';
import { useRouter } from "next/navigation";
import { createFigure } from '../api-handling/figureHandler';
import { useSnackbar } from "./SnackbarProvider";
import './CreateFigure.css';

export default function CreateFigure() {
    const [name, setName] = React.useState("");
    const [radius, setRadius] = React.useState(0);
    const router = useRouter();
    const { showMessage } = useSnackbar();

    const handleSubmit = async () => {
        const response=await createFigure(name, radius);
        if(response===201){
            showMessage("Figure created successfully", "success");
            router.push('/');
        }
        else{
            showMessage("Failed to create figure", "error");
        }
    };

    return (
        <Container maxWidth="sm">
            <Typography variant="h4" component="h1" gutterBottom>
                Create Figure
            </Typography>
            <form noValidate autoComplete="off">
                <TextField
                    fullWidth
                    margin="normal"
                    id="name"
                    label="Name"
                    variant="outlined"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    className="text-field"
                />
                <TextField
                    fullWidth
                    margin="normal"
                    id="radius"
                    label="Radius"
                    variant="outlined"
                    type="number"
                    value={radius}
                    onChange={(e) => setRadius(parseInt(e.target.value))}
                    className="text-field"
                />
                <Button variant="contained" color="primary" onClick={() => handleSubmit()}>
                    Submit
                </Button>
            </form>
        </Container>
    );
};