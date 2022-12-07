import input from "../input.js";

const maxScore = 21;

const start = () => {
  let [playerOnePosition, playerTwoPosition] = input
    .split("\n")
    .map((x) => parseInt(x[x.length - 1]));

  const scorePossibilities = preCompute();

  const result = Math.max(
    ...playGame(
      playerOnePosition,
      playerTwoPosition,
      0,
      0,
      true,
      scorePossibilities
    )
  );

  console.log(`The final result is ${result}`);
};

const preCompute = () => {
  const scorePossibilities = new Map<number, number>();

  for (let i = 1; i <= 3; i++) {
    for (let j = 1; j <= 3; j++) {
      for (let k = 1; k <= 3; k++) {
        const total = i + j + k;
        scorePossibilities.set(total, (scorePossibilities.get(total) || 0) + 1);
      }
    }
  }

  return scorePossibilities;
};

const playGame = (
  playerOnePosition: number,
  playerTwoPosition: number,
  playerOneScore: number,
  playerTwoScore: number,
  isPlayerOneTurn: boolean,
  scorePossibilities: Map<number, number>
) => {
  if (playerOneScore >= maxScore) {
    return [1, 0];
  }

  if (playerTwoScore >= maxScore) {
    return [0, 1];
  }

  let totalWins = [0, 0];

  for (let spacesToMove = 3; spacesToMove <= 9; ++spacesToMove) {
    let wins: Array<number>;

    if (isPlayerOneTurn) {
      const nextPlayerOnePosition =
        ((playerOnePosition - 1 + spacesToMove) % 10) + 1;

      wins = playGame(
        nextPlayerOnePosition,
        playerTwoPosition,
        playerOneScore + nextPlayerOnePosition,
        playerTwoScore,
        !isPlayerOneTurn,
        scorePossibilities
      );
    } else {
      const nextPlayerTwoPosition =
        ((playerTwoPosition - 1 + spacesToMove) % 10) + 1;

      wins = playGame(
        playerOnePosition,
        nextPlayerTwoPosition,
        playerOneScore,
        playerTwoScore + nextPlayerTwoPosition,
        !isPlayerOneTurn,
        scorePossibilities
      );
    }

    totalWins = [
      totalWins[0] + wins[0] * scorePossibilities.get(spacesToMove)!,
      totalWins[1] + wins[1] * scorePossibilities.get(spacesToMove)!,
    ];
  }

  return totalWins;
};

start();
