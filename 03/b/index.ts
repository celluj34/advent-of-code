import input from "../input.js";

const getMostCommonDigits = (input: Array<Array<string>>) => {
  return input
    .reduce((totals, bits) => {
      for (let i = 0; i < bits.length; ++i) {
        const result = totals[i] ?? { zeroes: 0, ones: 0 };
        switch (bits[i]) {
          case "0":
            ++result.zeroes;
            break;
          case "1":
            ++result.ones;
            break;
        }

        totals[i] = result;
      }

      return totals;
    }, new Array<{ zeroes: number; ones: number }>())
    .map((x) => (x.zeroes > x.ones ? "0" : "1"));
};

const start = () => {
  const lines = input.split("\n").map((x) => x.split(""));

  const result = lines.reduce((totals, bits) => {
    for (let i = 0; i < bits.length; ++i) {
      const result = totals[i] ?? { zeroes: 0, ones: 0 };
      switch (bits[i]) {
        case "0":
          ++result.zeroes;
          break;
        case "1":
          ++result.ones;
          break;
      }

      totals[i] = result;
    }

    return totals;
  }, new Array<{ zeroes: number; ones: number }>());

  let i = 0;
  let oxygenRating = null;
  let carbonDioxideRating = null;
  let remaining = [...lines];

  while (oxygenRating === null) {
    const mostCommon = getMostCommonDigits(remaining);

    remaining = remaining.filter((x) => x[i] === mostCommon[i]);

    if (remaining.length === 1) {
      oxygenRating = parseInt(remaining[0].join(""), 2);
    }

    ++i;
  }

  i = 0;
  remaining = [...lines];

  while (carbonDioxideRating === null) {
    const mostCommon = getMostCommonDigits(remaining);

    remaining = remaining.filter((x) => x[i] !== mostCommon[i]);

    if (remaining.length === 1) {
      carbonDioxideRating = parseInt(remaining[0].join(""), 2);
    }

    ++i;
  }

  console.log(`The final result is ${oxygenRating * carbonDioxideRating}`);
};

start();
