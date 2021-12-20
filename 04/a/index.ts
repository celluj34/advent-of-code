import input from "../input";

const start = () => {
  const lines = input.split("\n");

  const calledNumbers = lines[0].split(",").map((x) => parseInt(x));

  //skip first two lines
  const boards = createBoards(lines.slice(2));

  const winningTotal = getWinningBoard(boards, calledNumbers);

  console.log(`The final result is ${winningTotal}`);
};

const createBoards = (lines: Array<string>) => {
  const boards = new Array<Array<Array<number>>>();

  let currentBoard = new Array<Array<number>>();
  for (const line of lines) {
    if (line === "") {
      boards.push(currentBoard);
      currentBoard = new Array<Array<number>>();
      continue;
    }

    const boardNumbers = line
      .split(" ")
      .map((x) => x.trim())
      .filter((x) => x !== "")
      .map((x) => parseInt(x));

    currentBoard.push(boardNumbers);
  }

  boards.push(currentBoard);

  return boards;
};

const getWinningBoard = (
  boards: Array<Array<Array<number>>>,
  calledNumbers: Array<number>
) => {
  for (
    let calledNumberIndex = 4;
    calledNumberIndex < calledNumbers.length;
    ++calledNumberIndex
  ) {
    for (const board of boards) {
      const inputNumbers = calledNumbers.slice(0, calledNumberIndex);
      const winningNumbers = getWinningNumbers(board, inputNumbers);

      if (winningNumbers !== null) {
        const lastCalledNumber = inputNumbers[inputNumbers.length - 1];

        return board
          .flat()
          .filter((x) => !inputNumbers.includes(x))
          .reduce(
            (previous, current) => (previous += current * lastCalledNumber),
            0
          );
      }
    }
  }

  return null;
};

const getWinningNumbers = (
  board: Array<Array<number>>,
  calledNumbers: Array<number>
): Array<number> | null => {
  const rows = [board[0], board[1], board[2], board[3], board[4]];

  for (const row of rows) {
    if (row.every((x) => calledNumbers.includes(x))) {
      return row;
    }
  }

  const columns = [
    board.map((x) => x[0]),
    board.map((x) => x[1]),
    board.map((x) => x[2]),
    board.map((x) => x[3]),
    board.map((x) => x[4]),
  ];

  for (const column of columns) {
    if (column.every((x) => calledNumbers.includes(x))) {
      return column;
    }
  }

  return null;
};

start();
