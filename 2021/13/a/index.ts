import input from "../input.js";

const start = () => {
  const grid = generateGrid();
  const instructions = generateFoldInstructions();

  const foldedGrid = foldGrid(grid, instructions);

  console.log(
    `The final result is ${foldedGrid.flat().filter((x) => x === "#").length}`
  );
};

const generateGrid = (): Array<Array<string>> => {
  const gridInputs = new Array<Array<number>>();
  const inputs = input.split("\n");

  for (const row of inputs) {
    if (row === "") {
      break;
    }

    gridInputs.push(row.split(",").map((x) => parseInt(x)));
  }

  const maxX = Math.max(...gridInputs.map((x) => x[0]));
  const maxY = Math.max(...gridInputs.map((x) => x[1]));

  let grid = new Array<Array<string>>(maxY + 1);

  const emptyRow = new Array<string>(maxX + 1);
  emptyRow.fill(" ");

  grid.fill(emptyRow);

  grid = JSON.parse(JSON.stringify(grid));

  for (const gridInput of gridInputs) {
    grid[gridInput[1]][gridInput[0]] = "#";
  }

  return grid;
};

const generateFoldInstructions = (): Array<{
  type: "x" | "y";
  index: number;
}> => {
  return input
    .split("\n")
    .filter((x) => x.startsWith("fold along"))
    .map((x) => {
      const pairs = x.split("fold along ")[1].split("=");

      return {
        type: pairs[0] as any,
        index: parseInt(pairs[1]),
      };
    });
};

const foldGrid = (
  grid: Array<Array<string>>,
  instructions: Array<{ type: "x" | "y"; index: number }>
): Array<Array<string>> => {
  for (const instruction of instructions) {
    if (instruction.type === "y") {
      const topHalf = grid.slice(0, instruction.index);
      const bottomHalf = grid.slice(instruction.index + 1).reverse();

      for (let rowIndex = 0; rowIndex < topHalf.length; ++rowIndex) {
        const topRow = topHalf[rowIndex];
        const bottomRow = bottomHalf[rowIndex];

        for (let columnIndex = 0; columnIndex < topRow.length; ++columnIndex) {
          topRow[columnIndex] = [
            topRow[columnIndex],
            bottomRow[columnIndex],
          ].includes("#")
            ? "#"
            : " ";
        }
      }

      grid.length = instruction.index;
    } else if (instruction.type === "x") {
      for (const row of grid) {
        const leftHalf = row.slice(0, instruction.index);
        const rightHalf = row.slice(instruction.index + 1).reverse();

        for (
          let columnIndex = 0;
          columnIndex < leftHalf.length;
          ++columnIndex
        ) {
          row[columnIndex] = [
            leftHalf[columnIndex],
            rightHalf[columnIndex],
          ].includes("#")
            ? "#"
            : " ";
        }

        row.length = instruction.index;
      }
    }
  }

  return grid;
};

start();
