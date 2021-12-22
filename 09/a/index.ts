import input from "../input";

const start = () => {
  const inputs = input.split("\n");

  const grid = createEmptyGrid(inputs);

  fillGrid(inputs, grid);

  console.log(grid.join("\n"));

  let risk = 0;
  for (let rowIndex = 0; rowIndex < grid.length - 2; ++rowIndex) {
    const rowIndexOffset = rowIndex + 1;
    const row = grid[rowIndexOffset];

    for (let columnIndex = 0; columnIndex < row.length - 2; ++columnIndex) {
      const columnIndexOffset = columnIndex + 1;
      const cell = row[columnIndexOffset];

      const adjacentCells = [
        grid[rowIndexOffset - 1][columnIndexOffset],
        grid[rowIndexOffset][columnIndexOffset - 1],
        grid[rowIndexOffset + 1][columnIndexOffset],
        grid[rowIndexOffset][columnIndexOffset + 1],
      ];

      const neighboringMinima = Math.min(...adjacentCells);

      if (cell < neighboringMinima) {
        console.log({ rowIndexOffset, columnIndexOffset, cell });
        risk += cell + 1;
      }
    }
  }

  console.log(`The final result is ${risk}`);
};

const createEmptyGrid = (inputs: string[]): Array<Array<number>> => {
  const grid = new Array<Array<number>>(inputs.length + 2);

  const arr = new Array<number>(inputs[0].length + 2);
  arr.fill(10);

  grid.fill(arr);
  return JSON.parse(JSON.stringify(grid));
};

const fillGrid = (inputs: string[], grid: Array<Array<number>>) => {
  for (let rowIndex = 0; rowIndex < inputs.length; ++rowIndex) {
    const row = inputs[rowIndex];

    for (let columnIndex = 0; columnIndex < row.length; ++columnIndex) {
      const cell = row[columnIndex];

      grid[rowIndex + 1][columnIndex + 1] = parseInt(cell);
    }
  }
};

start();
