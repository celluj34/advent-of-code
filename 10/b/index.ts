import input from "../input.js";

const openingParen = "(",
  closingParen = ")",
  openingBrace = "[",
  closingBrace = "]",
  openingCurlyBrace = "{",
  closingCurlyBrace = "}",
  openingCaret = "<",
  closingCaret = ">";

const openingCharacters = [
  openingParen,
  openingBrace,
  openingCurlyBrace,
  openingCaret,
];

const closingCharacters = [
  closingParen,
  closingBrace,
  closingCurlyBrace,
  closingCaret,
];

const start = () => {
  const inputs = input.split("\n");

  let scores = new Array<number>();
  for (const line of inputs) {
    const emptyPairs = getIncompletePairs(line);
    scores.push(getIncompleteLineScore(emptyPairs));
  }

  scores = scores.sort((a, b) => a - b).filter((x) => x !== 0);
  const middle =
    scores.length % 2 === 1 ? (scores.length - 1) / 2 : scores.length / 2;
  console.log(`The final result is ${scores[middle]}`);
};

const getIncompletePairs = (line: string) => {
  let stack = new Array<string>();

  for (const character of line.split("")) {
    if (stack.length === 0) {
      if (openingCharacters.includes(character)) {
        stack.push(character);
        continue;
      } else if (closingCharacters.includes(character)) {
        return [];
      }
    }

    if (openingCharacters.includes(character)) {
      stack.push(character);
      continue;
    } else if (closingCharacters.includes(character)) {
      const lastCharacter = stack[stack.length - 1];
      if (
        (lastCharacter === openingParen && character === closingParen) ||
        (lastCharacter === openingBrace && character === closingBrace) ||
        (lastCharacter === openingCurlyBrace &&
          character === closingCurlyBrace) ||
        (lastCharacter === openingCaret && character === closingCaret)
      ) {
        stack.pop();
        continue;
      }
    }

    return [];
  }

  return stack;
};

const getIncompleteLineScore = (characters: Array<string>) => {
  let total = 0;
  while (characters!.length > 0) {
    const currentCharacter = characters.pop();

    total *= 5;

    switch (currentCharacter) {
      case openingParen:
        total += 1;
        break;
      case openingBrace:
        total += 2;
        break;
      case openingCurlyBrace:
        total += 3;
        break;
      case openingCaret:
        total += 4;
        break;
    }
  }

  return total;
};

start();
