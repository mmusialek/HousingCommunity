import { TableContainer, Paper, Table, TableHead, TableRow, TableCell, TableBody } from "@mui/material";
import { useEffect } from "react";
import { ProgressIndicator } from "../../components";
import { useFailureReportService, useFailureReportStore } from "./failureReportStore";

export const FailureReports = () => {
  const { getData, isLoading } = useFailureReportService();
  const store = useFailureReportStore();

  useEffect(() => {
    const data = getData();
    store.setItems(data);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const renderList = () => {
    return (
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Title</TableCell>
              <TableCell align="right">Created at</TableCell>
              <TableCell align="right">Created by</TableCell>
              <TableCell align="right">Status</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {store.items.map((row) => (
              <TableRow key={row.id} sx={{ "&:last-child td, &:last-child th": { border: 0 } }}>
                <TableCell component="th" scope="row">
                  {row.title}
                </TableCell>
                <TableCell align="right">{row.createdAt.toISOString()}</TableCell>
                <TableCell align="right">{row.createdBy}</TableCell>
                <TableCell align="right">{row.status}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    );
  };

  const renderWithProgress = () => {
    return (
      <ProgressIndicator size="5rem" isLoading={isLoading}>
        <>
          <div>failure reports</div>
          <div>{renderList()}</div>
        </>
      </ProgressIndicator>
    );
  };

  return <div>{renderWithProgress()}</div>;
};
