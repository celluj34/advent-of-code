import input from "../input";

const start = async () => {
  const lines = input.split("\n");

  let depth = 0;
  let length = 0;
  let aim = 0;

  for (const value of lines) {
    const [command, magnitude] = value.split(" ");

    switch (command) {
      case "forward":
        length += parseInt(magnitude);
        depth += parseInt(magnitude) * aim;
        break;
      case "down":
        aim += parseInt(magnitude);
        break;
      case "up":
        aim -= parseInt(magnitude);
        break;
    }
  }

  console.log(`The final depth is ${depth}`);
  console.log(`The final length is ${length}`);
  console.log(`The final result is ${depth * length}`);
};

(async () => {
  await start();
})();
