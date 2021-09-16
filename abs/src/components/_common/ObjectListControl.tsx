import React from "react";
import { Button, List, Segment } from "semantic-ui-react";

interface ObjectListControlProps {
  list: any[];
  onDelete?(element: any): void;
}

const generateListItem = (element: any, onDelete?: (element: any) => void) => {
  return (
    <List.Item key={element.id}>
      <List.Content>{element.name}</List.Content>
      <List.Content floated="right">
        {onDelete ? (
          <Button
            color="red"
            onClick={() => {
              onDelete(element.id);
            }}
          >
            Delete
          </Button>
        ) : null}
      </List.Content>
    </List.Item>
  );
};

const ObjectListControl = ({ list, onDelete }: ObjectListControlProps) => {
  return (
    <Segment>
      <List>{list && list.length ? list.map((element: any) => generateListItem(element, onDelete)) : null}</List>
    </Segment>
  );
};

export default ObjectListControl;
