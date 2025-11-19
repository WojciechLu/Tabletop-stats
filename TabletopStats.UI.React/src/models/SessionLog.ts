import { Row } from "simple-table-core";
import { Player } from "./Player";
import { RpgSystem } from "./RpgSystem";
import { GUID } from "./types/Guid";
import { TimeSpan } from "./types/timepan";

export interface SessionLog {
    sessionId: GUID,
    adventureId?: GUID,
    campaignId?: GUID,
    sessionName: string,
    description: string,
    startTime: string,
    endTime: string,
    duration: string,
    players: Player[],
    gameMaster?: Player,
    rpgSystem: RpgSystem
}

export interface SessionLogParsed extends Row {
    sessionId: GUID,
    sessionName: string,
    description: string,
    parsedStartTime: string,
    parsedEndTime: string,
    duration: string,
    playerNames: string[],
    gameMasterName?: string,
    rpgSystemName: string
}