import input from "../input";

const start = () => {
  const plotPoints = generatePlotPoints();
  const emptyGrid = generateEmptyGrid(plotPoints);
  const plotGrid = plotVectors(emptyGrid, plotPoints);

  const count = plotGrid.flat().filter((x) => x >= 2).length;

  console.log(`The final result is ${count}`);
};

const generatePlotPoints = (): Array<{
  x1: number;
  y1: number;
  x2: number;
  y2: number;
  type: "horiztonal" | "vertical" | "diagonal";
}> => {
  return input.split("\n").map((x) => {
    const coordPairs = x.split(" -> ").map((y) => {
      const plotPairs = y.split(",").map((z) => parseInt(z));

      return { x: plotPairs[0], y: plotPairs[1] };
    });

    const x1 = coordPairs[0].x,
      y1 = coordPairs[0].y,
      x2 = coordPairs[1].x,
      y2 = coordPairs[1].y;

    return {
      x1: x1,
      y1: y1,
      x2: x2,
      y2: y2,
      type: x1 === x2 ? "vertical" : y1 === y2 ? "horiztonal" : "diagonal",
    };
  });
};

const generateEmptyGrid = (
  plotPoints: Array<{ x1: number; x2: number; y1: number; y2: number }>
) => {
  const maxX =
    plotPoints
      .map((x) => [x.x1, x.x2])
      .flat()
      .reduce((x, y) => Math.max(y, x), 0) + 1;

  const maxY =
    plotPoints
      .map((x) => [x.y1, x.y2])
      .flat()
      .reduce((x, y) => Math.max(y, x), 0) + 1;

  const grid = new Array<Array<number>>();

  for (let index = 0; index < maxY; ++index) {
    const arr = new Array<number>();
    arr.length = maxX;
    arr.fill(0);
    grid.push(arr);
  }

  return grid;
};

const plotVectors = (
  grid: Array<Array<number>>,
  vectors: Array<{
    x1: number;
    y1: number;
    x2: number;
    y2: number;
    type: "horiztonal" | "vertical" | "diagonal";
  }>
) => {
  for (const vector of vectors) {
    if (vector.type === "diagonal") {
      const magnitude = Math.abs(vector.x2 - vector.x1);

      if (vector.x1 < vector.x2 && vector.y1 < vector.y2) {
        //"downward backslash"
        for (let index = 0; index <= magnitude; ++index) {
          ++grid[vector.y1 + index][vector.x1 + index];
        }
      } else if (vector.x1 > vector.x2 && vector.y1 > vector.y2) {
        //"upward backslash"
        for (let index = 0; index <= magnitude; ++index) {
          ++grid[vector.y1 - index][vector.x1 - index];
        }
      } else if (vector.x1 > vector.x2 && vector.y1 < vector.y2) {
        //"downward forward slash"
        for (let index = 0; index <= magnitude; ++index) {
          ++grid[vector.y1 + index][vector.x1 - index];
        }
      } else {
        //"upward forward slash"
        for (let index = 0; index <= magnitude; ++index) {
          ++grid[vector.y1 - index][vector.x1 + index];
        }
      }
    } else if (vector.type === "vertical") {
      const minY = Math.min(vector.y1, vector.y2);
      const mayY = Math.max(vector.y1, vector.y2);
      for (let index = minY; index <= mayY; ++index) {
        ++grid[index][vector.x1];
      }
    } else if (vector.type === "horiztonal") {
      const minX = Math.min(vector.x1, vector.x2);
      const maxX = Math.max(vector.x1, vector.x2);
      for (let index = minX; index <= maxX; ++index) {
        ++grid[vector.y1][index];
      }
    }
  }

  return grid;
};

start();
