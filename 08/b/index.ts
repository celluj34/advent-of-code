import input from "../input";

const start = () => {
  const inputs = input
    .toLowerCase()
    .split("\n")
    .map((x) => {
      const pairs = x.split("|");

      return {
        keys: pairs[0]
          .trim()
          .split(" ")
          .map((y) => [...y].sort((a, b) => a.localeCompare(b))),
        displayed: pairs[1]
          .trim()
          .split(" ")
          .map((y) => [...y].sort((a, b) => a.localeCompare(b))),
      };
    });

  let total = 0;
  for (const input of inputs) {
    const wirePositions = getWirePositions(input);
    const displayedNumber = getDisplayedNumber(input.displayed, wirePositions);

    console.log(displayedNumber);
    total += parseInt(displayedNumber);
  }

  console.log(`The final result is ${total}`);
};

const getWirePositions = (input: {
  keys: string[][];
  displayed: string[][];
}) => {
  const one = input.keys.find((x) => x.length === 2) ?? []; // 1
  const four = input.keys.find((x) => x.length === 4); // 4
  const seven = input.keys.find((x) => x.length === 3); // 7
  const eight = input.keys.find((x) => x.length === 7); // 8
  const length5 = input.keys.filter((x) => x.length === 5); // 2, 3, 5
  const length6 = input.keys.filter((x) => x.length === 6); // 0, 6, 9

  const positionA = seven!.find((x) => !one!.includes(x)) ?? "";

  const positionG = getWireWithCount([...length5, ...length6], [positionA], 6);

  const positionE = getWireWithCount(
    [...length5, ...length6],
    [positionA, positionG],
    3
  );

  const positionD = getWireWithCount(
    length5,
    [positionA, positionG, positionE],
    3
  );

  const positionB = getWireWithCount(
    length5,
    [positionA, positionG, positionE, positionD],
    1
  );

  const positionC = getWireWithCount(
    [...length5, ...length6],
    [positionA, positionG, positionE, positionD, positionB],
    4
  );

  const positionF = getWireWithCount(
    [one],
    [positionA, positionG, positionE, positionD, positionB, positionC],
    1
  );

  return {
    a: positionA,
    b: positionB,
    c: positionC,
    d: positionD,
    e: positionE,
    f: positionF,
    g: positionG,
  };
};

const getWireWithCount = (
  input: string[][],
  knownPositions: Array<string>,
  count: number
): string => {
  const wireGroups = input
    .flat()
    .filter((x) => !knownPositions.includes(x))
    .reduce((result, item) => {
      result[item] = (result[item] ?? 0) + 1;

      return result;
    }, [] as any);

  return (
    Object.keys(wireGroups).find((x: any) => wireGroups[x] === count) ?? ""
  );
};

const getDisplayedNumber = (
  displayed: string[][],
  wirePositions: {
    a: string;
    b: string;
    c: string;
    d: string;
    e: string;
    f: string;
    g: string;
  }
) => {
  const digits = [
    [
      wirePositions.a,
      wirePositions.b,
      wirePositions.c,
      wirePositions.e,
      wirePositions.f,
      wirePositions.g,
    ],
    [wirePositions.c, wirePositions.f],
    [
      wirePositions.a,
      wirePositions.c,
      wirePositions.d,
      wirePositions.e,
      wirePositions.g,
    ],
    [
      wirePositions.a,
      wirePositions.c,
      wirePositions.d,
      wirePositions.f,
      wirePositions.g,
    ],
    [wirePositions.b, wirePositions.c, wirePositions.d, wirePositions.f],
    [
      wirePositions.a,
      wirePositions.b,
      wirePositions.d,
      wirePositions.f,
      wirePositions.g,
    ],
    [
      wirePositions.a,
      wirePositions.b,
      wirePositions.d,
      wirePositions.e,
      wirePositions.f,
      wirePositions.g,
    ],
    [wirePositions.a, wirePositions.c, wirePositions.f],
    [
      wirePositions.a,
      wirePositions.b,
      wirePositions.c,
      wirePositions.d,
      wirePositions.e,
      wirePositions.f,
      wirePositions.g,
    ],
    [
      wirePositions.a,
      wirePositions.b,
      wirePositions.c,
      wirePositions.d,
      wirePositions.f,
      wirePositions.g,
    ],
  ];

  const newLocal = displayed
    .map((x) => {
      if (x.length === 2) {
        return 1;
      }

      if (x.length === 4) {
        return 4;
      }

      if (x.length === 3) {
        return 7;
      }

      if (x.length === 7) {
        return 8;
      }

      const i = 0;

      for (let index = 0; index < digits.length; index++) {
        const element = digits[index];

        if (
          element.length === x.length &&
          element.filter((y) => x.includes(y)).length === x.length
        ) {
          return index;
        }

        // if (x.every((y) => element.includes(y))) {
        //   return index;
        // }
      }

      return "";
    })
    .join("");

  return newLocal;
};

start();
