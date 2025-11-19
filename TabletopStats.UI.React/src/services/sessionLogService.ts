import ky from "ky";
import { SessionLog } from "../models/SessionLog";
import { GUID } from "../models/types/Guid";
import { PlayerSessionLogRequest } from "../models/SessionLogRequest";
import { ApiResponse } from "../models/ApiResponse";

const apiRoute = "api/sessionLog"

const sessionLogService = {
    async fetchPlayerSessionLogs(pageNumber: number, pageSize: number, playerId: GUID) {
        const model: PlayerSessionLogRequest = {
            playerId: playerId,
            pageSize: pageSize,
            pageNumber: pageNumber
        }
        return await ky.post(`http://localhost:5176/${apiRoute}/GetPlayerLogs`, {json: model}).json<ApiResponse<SessionLog[]>>()
    }
}


export default sessionLogService;