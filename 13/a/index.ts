import input from "../input-sample";

const start = () => {
  const grid = generateGrid();
  const instructions = generateFoldInstructions();

  // console.log(`The final result is ${grid}`);
  console.log(instructions);
  console.log(grid.map((x) => x.join("")).join("\r\n"));
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
  emptyRow.fill(".");

  grid.fill(emptyRow);

  grid = JSON.parse(JSON.stringify(grid));

  for (const gridInput of gridInputs) {
    grid[gridInput[1]][gridInput[0]] = "#";
  }

  return grid;
};

const generateFoldInstructions = (): Array<{ type: string; index: number }> => {
  return input
    .split("\n")
    .filter((x) => x.startsWith("fold along"))
    .map((x) => {
      const pairs = x.split("fold along ")[1].split("=");

      return {
        type: pairs[0],
        index: parseInt(pairs[1]),
      };
    });
};

start();
