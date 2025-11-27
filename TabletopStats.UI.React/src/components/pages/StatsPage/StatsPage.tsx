import { keepPreviousData, useQuery } from "@tanstack/react-query";
import { useMemo, useState } from "react";
import { SimpleTable, HeaderObject, Theme } from "simple-table-core";
import "simple-table-core/styles.css";
import sessionLogService from "../../../services/sessionLogService";
import { guid } from "../../../models/types/Guid";
import { SessionLogParsed } from "../../../models/SessionLog";
import Footer from "./Footer";
import CreateSessionLogModal from "../../common/Modal/CreateSessionLogModal";
import StatsForm from "./StatsForm";

const ROWS_PER_PAGE = 10;
const headers: HeaderObject[] = [
  {
    accessor: "sessionId",
    label: "ID",
    width: 80,
    isSortable: false,
    type: "string",
    hide: true,
  },
  {
    accessor: "sessionName",
    label: "Session Name",
    width: 200,
    isSortable: true,
    type: "string",
  },
  {
    accessor: "rpgSystemName",
    label: "Rpg System",
    width: 120,
    isSortable: true,
    type: "string",
  },
  {
    accessor: "description",
    label: "Description",
    width: 100,
    isSortable: true,
    type: "string",
    hide: true,
  },
  {
    accessor: "gameMasterName",
    label: "Game Master",
    width: 150,
    isSortable: true,
    type: "string",
  },
  {
    accessor: "players",
    label: "Players",
    minWidth: 80,
    width: "1fr",
    isSortable: true,
    type: "other",
  },
  {
    accessor: "parsedStartTime",
    label: "Date",
    width: 150,
    isSortable: true,
    type: "date",
  },
  {
    accessor: "duration",
    label: "Duration [h]",
    width: 150,
    isSortable: true,
    type: "string",
  },
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
  const [showModal, onShowModal] = useState<boolean>(false);

  const { isPending, isError, error, data, isFetching } = useQuery({
    queryKey: ["playerSessionLogs", pageNumber, pageSize],
    queryFn: () =>
      sessionLogService.fetchPlayerSessionLogs(
        pageNumber,
        pageSize,
        guid("D6434E4D-0B8C-4892-9803-4702038BB818")
      ),
    placeholderData: keepPreviousData,
  });

  const parsedRows: SessionLogParsed[] = useMemo(() => {
    if (!data) return [];
    return data.data.map((value) => {
      const parsedRow: SessionLogParsed = {
        sessionId: value.sessionId,
        sessionName: value.sessionName,
        description: value.description,
        parsedStartTime: value.startTime.split("T")[0],
        parsedEndTime: value.endTime.split("T")[0],
        duration: `${value.duration.split(":")[0]}:${value.duration.split(":")[1]}`,
        playerNames: value.players.map((x) => x.name),
        gameMasterName: value.gameMaster?.name,
        rpgSystemName: value.rpgSystem.name,
      };
      return parsedRow;
    });
  }, [pageNumber, pageSize, data]);

  const onCreateLogClick = () => {
    onShowModal(true);
  };

  const onCloseModal = () => {
    onShowModal(false);
  };

  if (isPending) {
    return <span>Loading...</span>;
  }

  if (isError) {
    return <span>Error: {error.message}</span>;
  }

  return (
    <>
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
        footerRenderer={(props) => (
          <Footer {...props} onCreateLogClick={onCreateLogClick} />
        )}
      />
      {showModal && (
        <CreateSessionLogModal
          onCloseModal={onCloseModal}
          title="Create session log"
          children={<StatsForm/>}
        />
      )}
    </>
  );
};

export default StatsPage;
