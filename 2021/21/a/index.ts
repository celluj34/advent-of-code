import input from "../input.js";

const maxScore = 1000;

const start = () => {
  let [playerOnePosition, playerTwoPosition] = input
    .split("\n")
    .map((x) => parseInt(x[x.length - 1]));

  let playerOneScore = 0,
    playerTwoScore = 0;

  let dieRolls = 1;
  while (playerOneScore < maxScore && playerTwoScore < maxScore) {
    let spacesToMove =
      ((dieRolls - 1) % 100) +
      1 +
      ((dieRolls % 100) + 1) +
      (((dieRolls + 1) % 100) + 1);
    dieRolls += 3;

    playerOnePosition = (playerOnePosition + spacesToMove) % 10;
    playerOneScore += playerOnePosition === 0 ? 10 : playerOnePosition;

    if (playerOneScore >= maxScore) {
      break;
    }

    spacesToMove =
      ((dieRolls - 1) % 100) +
      1 +
      ((dieRolls % 100) + 1) +
      (((dieRolls + 1) % 100) + 1);
    dieRolls += 3;

    playerTwoPosition = (playerTwoPosition + spacesToMove) % 10;
    playerTwoScore += playerTwoPosition === 0 ? 10 : playerTwoPosition;
  }

  console.log(
    `The final result is ${
      Math.min(playerOneScore, playerTwoScore) * (dieRolls - 1)
    }`
  );
};

start();
