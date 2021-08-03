import * as React from "react";

function DogImage(props: { url: string }) {
  return <img src={props.url}></img>;
}

const AppTest = () => {
  const [dogImages, setDogImages] = React.useState<[string]>([""]);

  React.useEffect(() => {
    fetch("https://dog.ceo/api/breeds/image/random")
      .then((res) => res.json())
      .then((data) => setDogImages([data.message]));
  }, []);

  const dogList = dogImages.map((url) => {
    if (dogImages !== undefined) {
      return <DogImage url={url} />;
    } else return null;
  });

  return <div>{dogList}</div>;
};

export default AppTest;
