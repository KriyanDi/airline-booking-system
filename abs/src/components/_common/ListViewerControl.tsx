import React from "react";
import { Button, List, Segment } from "semantic-ui-react";

const ListViewerControl = (props: any) => {
  const { data } = props;

  const generateBody = (data: any[]) => {
    return data.map((d) => {
      let body: any[] = [];

      for (const key of Object.keys(d)) {
        const val = d[key];
        body.push(
          <List.Item>
            <List.Content red floated="right">
              <Button>Remove</Button>
            </List.Content>
            <List.Content>d.</List.Content>
          </List.Item>
        );
      }

      return body;
    });
  };

  return (
    <Segment>
      <List divided verticalAlign="middle">
        {generateBody(data)}
      </List>
      ;
    </Segment>
  );
};

export default ListViewerControl;
