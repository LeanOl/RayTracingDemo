
import routes  from './api-routes.json' assert { type: "json" };
import userinfo from './user-info.json' assert { type: "json" };
import axios from 'axios';
import { Figure } from './data-models/figureModel';

export const createFigure = async (name: string, radius: number) :Promise<number> => {
    const apiUrl:string= routes['api-url'];
    const apiRoute:string= routes['api-routes']['figure'];
    const username:string= userinfo['username'];

    const figure = {
        name: name,
        radius: radius,
        username: username
    };
    try{
        const response=await axios.post(`${apiUrl}${apiRoute}`, figure);
        return response.status;
    }catch(error){
        return 500;
    }

}

export const getFigures = async () :Promise<Figure[]> => {
    const username:string= userinfo['username'];
    const apiUrl:string= routes['api-url'];
    const apiRoute:string= routes['api-routes']['figure'];
    try{
        const response=await axios.get(`${apiUrl}${apiRoute}`, {
            params: {
                username: username
            }
        });
        return response.data;
    }catch(error){
        return [];
    }
}

export const deleteFigure = async (name: string) :Promise<number> => {
    const apiUrl:string= routes['api-url'];
    const apiRoute:string= routes['api-routes']['figure'];
    const username:string= userinfo['username'];
    try{
        const response=await axios.delete(`${apiUrl}${apiRoute}`, {
            params: {
                name,
                username
            }
        }
        );
        return response.status;
    }catch(error){
        return 500;
    }
}
