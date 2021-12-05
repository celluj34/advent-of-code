import { readFile } from "fs";
import { resolve, dirname } from "path";

const inputFilePath = resolve(dirname("./input.txt"), "input.txt");

const start = async () => {
  const lines = await new Promise<Array<number>>((resolve, reject) => {
    readFile(inputFilePath, (x, y) => {
      const result = y
        .toString()
        .split("\r\n")
        .map((b) => parseInt(b, 0));

      resolve(result);
    });
  });

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
