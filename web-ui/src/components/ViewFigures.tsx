"use client"

import { getFigures,deleteFigure } from "@/api-handling/figureHandler";
import { use, useEffect, useState } from "react";
import { Figure } from "@/api-handling/data-models/figureModel";
import { Button, Card, CardActions, CardContent, Container, Typography } from "@mui/material";
import { useSnackbar } from "./SnackbarProvider";
import './ViewFigures.css';
import { useRouter } from "next/navigation";

export default function ViewFigures() {
    const [figures, setFigures] = useState<Figure[]>([]);
    const { showMessage } = useSnackbar();
    const router = useRouter();

    useEffect(() => {
        getFigures().then((figures) => {
            setFigures(figures);
        });
    }, []);

    

    const handleDeleteFigure = async (name: string) => {
        const response = await deleteFigure(name);
        if(response===200){
            setFigures(figures.filter((figure) => figure.name !== name));
            showMessage("Figure deleted successfully", "success");
        }else{
            showMessage("Failed to delete figure", "error");
        }
    }
    const handleGoBack = () => {
        router.push("/")
    }
    return (
        <Container>
            <Button variant="outlined" color="secondary" className="go-back-button" onClick={handleGoBack} >
                Go Back
            </Button>
            <Container className="figure-card-list">
                {figures.map((figure) => (
                    <Card key={figure.figureId} className="figure-card">
                        <CardContent>
                            <Typography variant="h5" component="div">
                                {figure.name}
                            </Typography>
                            
                        </CardContent>
                        <CardActions className="figure-card-actions">
                            <Button variant="contained" color="error" onClick={() => handleDeleteFigure(figure.name)}>
                                Delete
                            </Button>
                        </CardActions>
                    </Card>                
                ))}
            </Container>
        </Container>
    );
}