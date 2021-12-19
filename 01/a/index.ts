import input from "../input";

const start = async () => {
  const lines = input.split("\n").map((x) => parseInt(x));

  let lastValue = lines[0];
  let count = 0;

  for (const value of lines) {
    if (value > lastValue) {
      ++count;
    }

    lastValue = value;
  }

  console.log(`number of increases: ${count}`);
};

(async () => {
  await start();
})();
