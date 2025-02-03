"use client";

import React from 'react';
import { Container } from '@mui/material';
import dynamic from 'next/dynamic';

const ViewFigures = dynamic(() => import('@/components/ViewFigures'), {ssr:false});

export default function CreateFigurePage() {
    return (
        <Container>
            <ViewFigures />
        </Container>
    );
};
