import input from "../input";

const maxSteps = 100;

const start = () => {
  const grid = generateGrid();

  let totalFlashCount = 0;
  for (let step = 0; step < maxSteps; ++step) {
    incrementEntireGrid(grid);
    propagateEnergy(grid);
    totalFlashCount += flashLights(grid);
  }

  console.log(`The final result is ${totalFlashCount}`);
};

const generateGrid = () => {
  const grid = new Array<Array<{ energy: number; flashed: boolean }>>();
  const inputs = input.split("\n");

  for (let rowIndex = 0; rowIndex < inputs.length; ++rowIndex) {
    const row = inputs[rowIndex];
    grid.push(
      row.split("").map((x) => ({ energy: parseInt(x), flashed: false }))
    );
  }

  return grid;
};

const incrementEntireGrid = (
  grid: Array<Array<{ energy: number; flashed: boolean }>>
) => {
  for (let rowIndex = 0; rowIndex < grid.length; ++rowIndex) {
    for (let colIndex = 0; colIndex < grid[0].length; ++colIndex) {
      ++grid[colIndex][rowIndex].energy;
    }
  }
};

const propagateEnergy = (
  grid: Array<Array<{ energy: number; flashed: boolean }>>
) => {
  let propagated = true;
  while (propagated === true) {
    propagated = false;

    for (let rowIndex = 0; rowIndex < grid.length; ++rowIndex) {
      for (let colIndex = 0; colIndex < grid[0].length; ++colIndex) {
        const cell = grid[colIndex][rowIndex];

        if (cell.energy > 9 && !cell.flashed) {
          //spread energy to adjacent octopodes

          tryIncreaseEnergy(grid, colIndex - 1, rowIndex - 1);
          tryIncreaseEnergy(grid, colIndex - 1, rowIndex);
          tryIncreaseEnergy(grid, colIndex - 1, rowIndex + 1);
          tryIncreaseEnergy(grid, colIndex, rowIndex - 1);
          tryIncreaseEnergy(grid, colIndex, rowIndex + 1);
          tryIncreaseEnergy(grid, colIndex + 1, rowIndex - 1);
          tryIncreaseEnergy(grid, colIndex + 1, rowIndex);
          tryIncreaseEnergy(grid, colIndex + 1, rowIndex + 1);

          cell.flashed = true;

          propagated = true;
        }
      }
    }
  }
};

const tryIncreaseEnergy = (
  grid: Array<Array<{ energy: number; flashed: boolean }>>,
  colIndex: number,
  rowIndex: number
) => {
  try {
    ++grid[colIndex][rowIndex].energy;
  } catch {}
};

const flashLights = (
  grid: Array<Array<{ energy: number; flashed: boolean }>>
) => {
  let flashCount = grid.flat().filter((x) => x.flashed === true).length;
  for (let rowIndex = 0; rowIndex < grid.length; ++rowIndex) {
    for (let colIndex = 0; colIndex < grid[0].length; ++colIndex) {
      const cell = grid[colIndex][rowIndex];

      if (cell.flashed) {
        cell.energy = 0;
        cell.flashed = false;
      }
    }
  }

  return flashCount;
};

start();
