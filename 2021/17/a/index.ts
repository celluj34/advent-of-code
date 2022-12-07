import input from "../input.js";

const start = () => {
  const inputs = input.split("target area: ")[1].split(", ");
  const xCoords = getCoords(inputs[0]);
  const yCoords = getCoords(inputs[1]);

  let maxHeight = 0;
  for (let xVelocity = 1; xVelocity < xCoords[1]; xVelocity++) {
    for (let yVelocity = 1; yVelocity < 5000; yVelocity++) {
      const height = getHeight(xCoords, yCoords, xVelocity, yVelocity);
      if (height === null) {
        continue;
      }

      maxHeight = Math.max(maxHeight, height);
    }
  }

  console.log(`The final result is ${maxHeight}`);
};

const getCoords = (val: string) => {
  return val
    .slice(2)
    .split("..")
    .map((x) => parseInt(x))
    .sort((a, b) => a - b);
};

const getHeight = (
  xCoords: number[],
  yCoords: number[],
  xVelocity: number,
  yVelocity: number
) => {
  const minX = xCoords[0];
  const maxX = xCoords[1];
  const minY = yCoords[0];
  const maxY = yCoords[1];

  let height = 0;
  let currentX = 0;
  let currentY = 0;

  while (true) {
    if (
      currentY < minY ||
      maxX < currentX ||
      (xVelocity === 0 && currentX < minX) ||
      (0 < xVelocity && maxX < currentX)
    ) {
      return null;
    }

    if (
      minX <= currentX &&
      currentX <= maxX &&
      minY <= currentY &&
      currentY <= maxY
    ) {
      return height;
    }

    currentX += xVelocity;
    currentY += yVelocity;
    height = Math.max(height, currentY);

    xVelocity = xVelocity === 0 ? 0 : xVelocity - 1;
    yVelocity -= 1;
  }

  return null;
};

start();
