import React from "react";
import { Button, Header, List, Segment } from "semantic-ui-react";

const ListViewerControl = (props: any) => {
  const { data, deleteObjectMethod, objectName } = props;

  const generateBody = (data: any[]) => {
    return data.map((d) => {
      let body: any[] = [];

      body.push(
        <List.Item>
          {deleteObjectMethod !== undefined ? (
            <List.Content red floated="right">
              <Button color="red" onClick={() => deleteObjectMethod(d.id)}>
                Delete
              </Button>
            </List.Content>
          ) : null}

          <List.Content>
            <div className="content">{d.name}</div>
          </List.Content>
        </List.Item>
      );

      return body;
    });
  };

  return (
    <Segment>
      <Header as="h3" dividing>
        All {`${objectName}`}
      </Header>
      <List divided verticalAlign="middle">
        {generateBody(data)}
      </List>
    </Segment>
  );
};

export default ListViewerControl;
