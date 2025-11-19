import { PaginationRequest } from "./PaginationRequest";
import { GUID } from "./types/Guid";

export interface GameMasterSessionLogRequest extends PaginationRequest {
    gameMasterId: GUID
}

export interface PlayerSessionLogRequest extends PaginationRequest {
    playerId: GUID
}