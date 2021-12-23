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

  let total = 0;
  for (const line of inputs) {
    const firstIllegalCharacter = findFirstIllegalCharacter(line);
    total += getIllegalCharacterScore(firstIllegalCharacter);
  }

  console.log(`The final result is ${total}`);
};

const findFirstIllegalCharacter = (line: string) => {
  let stack = new Array<string>();

  for (const character of line.split("")) {
    if (stack.length === 0) {
      if (openingCharacters.includes(character)) {
        stack.push(character);
        continue;
      } else if (closingCharacters.includes(character)) {
        return character;
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

    return character;
  }

  return null;
};

const getIllegalCharacterScore = (character: string | null) => {
  switch (character) {
    case closingParen:
      return 3;
    case closingBrace:
      return 57;
    case closingCurlyBrace:
      return 1197;
    case closingCaret:
      return 25137;
    default:
      return 0;
  }
};

start();
