// import React from "react";
// import { Button, Table } from "semantic-ui-react";

// const TableViewerControl = (props: any) => {
//   let { data, deleteMethod, headers } = props;

//   const generateHeaders = (headers: string[]) => {
//     return headers.map((header) => <Table.HeaderCell>{header}</Table.HeaderCell>);
//   };

//   const generateBody = (props: any) => {
//     return data.map((d: any) => {
//       let dataProps = [];

//       for (const key of Object.keys(d)) {
//         const val = d[key];
//         dataProps.push(<Table.Cell>{val}</Table.Cell>);
//       }
//       return (
//         <Table.Row>
//           {dataProps}
//           {deleteMethod !== undefined ? <Button>Delete</Button> : null}
//         </Table.Row>
//       );
//     });
//   };

//   return (
//     <Table singleLine>
//       <Table.Header>
//         <Table.Row>{generateHeaders(headers)}</Table.Row>
//       </Table.Header>

//       <Table.Body>{generateBody(data)}</Table.Body>
//     </Table>
//   );
// };

// export default TableViewerControl;
export {};
