"use client"

import React, { createContext, useContext, useState } from 'react';
import { Snackbar, Alert } from '@mui/material';
import './SnackbarProvider.css';

type SnackbarContextType = {
    showMessage: (message: string, severity: "success" | "error") => void;
};

const SnackbarContext = createContext<SnackbarContextType | undefined>(undefined);

type SnackbarProviderProps = {
    children: React.ReactNode;
};

export const SnackbarProvider: React.FC<SnackbarProviderProps> = ({ children }) => {
    const [open, setOpen] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<"success" | "error">("success");

    const showMessage = (message: string, severity: "success" | "error") => {
        setMessage(message);
        setSeverity(severity);
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    return (
        <SnackbarContext.Provider value={{ showMessage }}>
            {children}
            <Snackbar
                open={open}
                autoHideDuration={6000}
                onClose={handleClose}
                anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }} // Centered at the bottom
                className="snackbar-content"
            >
                <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                    {message}
                </Alert>
            </Snackbar>
        </SnackbarContext.Provider>
    );
};

export const useSnackbar = () => {
    const context = useContext(SnackbarContext);
    if (!context) {
        throw new Error('useSnackbar must be used within a SnackbarProvider');
    }
    return context;
};