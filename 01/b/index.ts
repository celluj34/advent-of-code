import input from "../input.js";

const start = () => {
  const lines = input.split("\n").map((x) => parseInt(x));

  let values: Array<number> = [];
  let count = 0;

  for (const value of lines) {
    if (values.length !== 3) {
      values.push(value);

      continue;
    }

    const currentValue = values.reduce(
      (previous, current) => previous + current,
      0
    );

    values.shift();
    values.push(value);

    const newValue = values.reduce(
      (previous, current) => previous + current,
      0
    );

    if (newValue > currentValue) {
      ++count;
    }
  }

  console.log(`number of increases: ${count}`);
};

start();
