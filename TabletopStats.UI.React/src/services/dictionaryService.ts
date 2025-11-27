import ky from "ky";
import { ApiResponse } from "../models/ApiResponse";
import { RpgSystem } from "../models/RpgSystem";

const apiRoute = "api/dictionary"

const dictionaryService = {
    async fetchRpgSystems(name: string) {
        return await ky.get(`http://localhost:5176/${apiRoute}/GetRpgSystems?` + new URLSearchParams({ Name: name ?? "" }), {}).json<ApiResponse<RpgSystem[]>>()
    }
}


export default dictionaryService;