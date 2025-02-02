
import routes  from './api-routes.json' assert { type: "json" };
import userinfo from './user-info.json' assert { type: "json" };
import axios from 'axios';

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
