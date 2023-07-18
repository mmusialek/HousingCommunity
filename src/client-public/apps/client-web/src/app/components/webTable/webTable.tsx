import { TableContainer, Paper, Table, TableHead, TableRow, TableCell, TableBody, Theme, SxProps } from "@mui/material";

export interface ITableRow {
  id: string;
}

export interface IWebTableColumn<TType extends ITableRow> {
  name: string;
  label: string;
  render?: (item: TType) => JSX.Element;
  sx?: SxProps<Theme>;
}

export interface IWebTable<TType extends ITableRow> {
  items: TType[];
  columns: IWebTableColumn<TType>[];
}

export const WebTable = <TType extends ITableRow>(props: IWebTable<TType>) => {
  const renderRow = (row: TType): JSX.Element => {
    const cells = [];
    let counter = 0;

    for (const col of props.columns) {
      const content = col.render ? col.render(row) : (row as any)[col.name];
      cells.push(<TableCell key={`${row.id}-${counter}`}>{content}</TableCell>);
      counter++;
    }

    const renderedRow = (
      <TableRow key={row.id} sx={{ "&:last-child td, &:last-child th": { border: 0 } }}>
        {cells}
      </TableRow>
    );
    return renderedRow;
  };

  const renderWebTable = () => {
    return (
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              {props.columns.map((col) => (
                <TableCell key={col.name} align="left">
                  {col.label}
                </TableCell>
              ))}
            </TableRow>
          </TableHead>
          <TableBody>{props.items.map((row) => renderRow(row))}</TableBody>
        </Table>
      </TableContainer>
    );
  };

  return renderWebTable();
};
