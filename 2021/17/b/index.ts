import input from "../input.js";

const start = () => {
  const inputs = input.split("target area: ")[1].split(", ");
  const xCoords = getCoords(inputs[0]);
  const yCoords = getCoords(inputs[1]);

  let validTrajectories = 0;
  for (let xVelocity = 0; xVelocity < xCoords[1]; xVelocity++) {
    for (let yVelocity = yCoords[0]; yVelocity < -yCoords[0]; yVelocity++) {
      if (reachesTarget(xCoords, yCoords, xVelocity, yVelocity)) {
        ++validTrajectories;
      }
    }
  }

  console.log(`The final result is ${validTrajectories}`);
};

const getCoords = (val: string) => {
  return val
    .slice(2)
    .split("..")
    .map((x) => parseInt(x))
    .sort((a, b) => a - b);
};

const reachesTarget = (
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
      return false;
    }

    if (
      minX <= currentX &&
      currentX <= maxX &&
      minY <= currentY &&
      currentY <= maxY
    ) {
      return true;
    }

    currentX += xVelocity;
    currentY += yVelocity;
    height = Math.max(height, currentY);

    xVelocity =
      xVelocity < 0 ? xVelocity + 1 : xVelocity > 0 ? xVelocity - 1 : 0;
    yVelocity -= 1;
  }

  return false;
};

start();
