import input from "../input";

const start = () => {
  const inputs = input
    .split(",")
    .map((x) => parseInt(x))
    .sort((a, b) => a - b);

  const median = getMedian(inputs);

  const fuel = inputs.reduce(
    (previous, current) => (previous += Math.abs(median - current)),
    0
  );

  console.log(`The final result is ${fuel}`);
};

const getMedian = (values: Array<number>): number => {
  values.sort((a, b) => a - b);

  var half = Math.floor(values.length / 2);

  if (values.length % 2) {
    return values[half];
  }

  return (values[half - 1] + values[half]) / 2.0;
};

start();
