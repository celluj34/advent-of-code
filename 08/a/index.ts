import input from "../input";

const start = () => {
  const inputs = input
    .toLowerCase()
    .split("\n")
    .map((x) => {
      const pairs = x.split("|");
      const keys = pairs[0].trim().split(" ");
      const displayed = pairs[1].trim().split(" ");

      return {
        keys,
        displayed,
        zero: 0,
        one: displayed.filter((y) => y.length === 2).length,
        two: 0,
        three: 0,
        four: displayed.filter((y) => y.length === 4).length,
        five: 0,
        six: 0,
        seven: displayed.filter((y) => y.length === 3).length,
        eight: displayed.filter((y) => y.length === 7).length,
        nine: 0,
      };
    });

  console.log(
    `The final result is ${inputs.reduce(
      (previous, current) =>
        (previous +=
          current.one + current.four + current.seven + current.eight),
      0
    )}`
  );
};

start();
