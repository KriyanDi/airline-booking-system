import axios from "axios";
import React, { useEffect, useState } from "react";
import { Dropdown, Form, Header, Segment } from "semantic-ui-react";
import { useAppDispatch } from "../../_redux/hooks";

const FlightSectionsList = (props: any) => {
  const dispatch = useAppDispatch();

  const [sections, setSections] = useState([{ id: -1, seatClass: "" }]);
  const { flightId, setSectionId } = props;

  const getFlightById = async (obj: { id: number }) => {
    const response = await axios.get(
      `https://localhost:44318/api/Flight/${obj.id}`
    );
    return response.data;
  };

  useEffect(() => {
    getFlightById({ id: flightId }).then((res) =>
      setSections(res.flightSections)
    );
  }, [dispatch, flightId]);

  let sectionsOptions =
    sections !== undefined
      ? sections.map((sec) => ({
          key: sec.id,
          text: sec.seatClass,
          value: sec.id,
        }))
      : null;

  return (
    <Segment>
      <Header as="h3" dividing>
        Select Section
      </Header>

      <Form>
        <Form.Group widths="equal">
          <Form.Field
            control={Dropdown}
            label="Sections"
            clearable
            options={sectionsOptions}
            selection
            onChange={(e: any, data: any) => {
              setSectionId(data.value);
            }}
          />
        </Form.Group>
      </Form>
    </Segment>
  );
};

export default FlightSectionsList;
