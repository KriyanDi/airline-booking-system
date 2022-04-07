import { useState } from "react";
import { Link } from "react-router-dom";
import { Icon, Menu } from "semantic-ui-react";

const Navigation = (items: string[], additionalMenuItems: any) => {
  const [activeItem, setActiveItem] = useState<string>("");

  let handleItemClick = (name: string) => setActiveItem(name);

  let configureMenuItems = (items: string[]) => {
    return items && items.length
      ? items.map((item: string) => {
          return (
            <Link to={item}>
              <Menu.Item
                name={item}
                active={activeItem === item}
                onClick={() => handleItemClick(item)}
              >
                {item.toLocaleUpperCase()}
              </Menu.Item>
            </Link>
          );
        })
      : null;
  };

  return (
    <Menu stackable>
      <Menu.Item>
        <Icon name="paper plane outline" />
      </Menu.Item>

      {configureMenuItems(items)}

      {additionalMenuItems}
    </Menu>
  );
};

export default Navigation;
