import input from "../input";

const start = async () => {
  const result = input
    .split("\n")
    .map((x) => x.split(""))
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
    .reduce(
      (result, counts) => {
        if (counts.zeroes > counts.ones) {
          result.gamma += "0";
          result.epsilon += "1";
        } else {
          result.gamma += "1";
          result.epsilon += "0";
        }

        return result;
      },
      { gamma: "", epsilon: "" }
    );

  const gamma = parseInt(result.gamma, 2);
  const epsilon = parseInt(result.epsilon, 2);

  console.log(`The final result is ${gamma * epsilon}`);
};

(async () => {
  await start();
})();
