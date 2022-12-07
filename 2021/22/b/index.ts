import input from "../input.js";

const start = () => {
  const inputs = input.split("\n").map((x) => {
    const split = x.split(" ");
    const command = split[0] === "on";
    const coords = split[1].split(",");
    const xCoords = coords[0]
      .slice(2)
      .split("..")
      .map((y) => parseInt(y));
    const yCoords = coords[1]
      .slice(2)
      .split("..")
      .map((y) => parseInt(y));
    const zCoords = coords[2]
      .slice(2)
      .split("..")
      .map((y) => parseInt(y));

    return {
      command,
      xCoords,
      yCoords,
      zCoords,
    };
  });

  const map = new Map<string, boolean>();

  for (const element of inputs) {
    for (let x = element.xCoords[0]; x <= element.xCoords[1]; ++x) {
      for (let y = element.yCoords[0]; y <= element.yCoords[1]; ++y) {
        for (let z = element.zCoords[0]; z <= element.zCoords[1]; ++z) {
          const key = `${x},${y},${z}`;
          if (element.command) {
            map.set(key, false);
          } else {
            map.delete(key);
          }
        }
      }
    }
  }

  console.log(`The final result is ${map.size}`);
};

start();
