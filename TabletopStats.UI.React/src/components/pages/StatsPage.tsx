import { keepPreviousData, useQuery } from "@tanstack/react-query";
import { createFileRoute } from "@tanstack/react-router";
import { useCallback, useMemo, useState } from "react";
import { SimpleTable, HeaderObject, Theme } from "simple-table-core";
import "simple-table-core/styles.css";
import sessionLogService from "../../services/sessionLogService";
import { guid } from "../../models/types/Guid";
import { SessionLogParsed } from "../../models/SessionLog";

const ROWS_PER_PAGE = 10;
const headers: HeaderObject[] = [
  { accessor: "sessionId", label: "ID", width: 80, isSortable: false, type: "string" },
  {
    accessor: "sessionName",
    label: "Session Name",
    minWidth: 80,
    width: "1fr",
    isSortable: true,
    type: "string",
  },
  { accessor: "rpgSystemName", label: "Rpg System", width: 150, isSortable: true, type: "string" },
  { accessor: "description", label: "Description", width: 100, isSortable: true, type: "string" },
  { accessor: "gameMasterName", label: "Game Master", width: 150, isSortable: true, type: "string" },
  { accessor: "players", label: "Players", width: 150, isSortable: true, type: "other" },
  { accessor: "parsedStartTime", label: "Date", width: 150, isSortable: true, type: "date" },
  { accessor: "duration", label: "Duration [h]", width: 150, isSortable: true, type: "string" },
];

const StatsPage = ({
  height = "300px",
  theme,
}: {
  height?: string | number;
  theme?: Theme;
}) => {
  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize, setPageSize] = useState(ROWS_PER_PAGE);
  
  const { isPending, isError, error, data, isFetching } =
    useQuery({
      queryKey: ['playerSessionLogs', pageNumber, pageSize],
      queryFn: () => sessionLogService.fetchPlayerSessionLogs(pageNumber, pageSize, guid("D6434E4D-0B8C-4892-9803-4702038BB818")),
      placeholderData: keepPreviousData,
    })

  const parsedRows: SessionLogParsed[] = useMemo(() => {
    if(!data) return [];
    return data.data.map(value => {
      const parsedRow: SessionLogParsed = {
        sessionId: value.sessionId,
        sessionName: value.sessionName,
        description: value.description,
        parsedStartTime: value.startTime.split('T')[0],
        parsedEndTime: value.endTime.split('T')[0],
        duration: `${value.duration.split(':')[0]}:${value.duration.split(':')[1]}`,
        playerNames: value.players.map(x => x.name),
        gameMasterName: value.gameMaster?.name,
        rpgSystemName: value.rpgSystem.name
      }
      return parsedRow;
    })
  }, [pageNumber, pageSize, data])

  if (isPending) {
    return <span>Loading...</span>
  }

  if (isError) {
    return <span>Error: {error.message}</span>
  }

  return (
    <SimpleTable
      defaultHeaders={headers}
      editColumns
      height={height}
      rowIdAccessor="sessionId"
      rowHeight={32}
      selectableCells
      rows={parsedRows}
      rowsPerPage={pageSize}
      serverSidePagination
      shouldPaginate
      theme={theme}
      // onPageChange={pageChange}
      // totalRowCount={data.totalRowCount}
    />
  );
};

export default StatsPage;