import React from 'react';
import { TextField, Button, Container, Typography } from '@mui/material';

export default function CreateFigure() {
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
                />
                <TextField
                    fullWidth
                    margin="normal"
                    id="radius"
                    label="Radius"
                    variant="outlined"
                    type="number"
                />
                <Button variant="contained" color="primary" type="submit">
                    Submit
                </Button>
            </form>
        </Container>
    );
};
