import input from "../input.js";

const start = () => {
  const lines = input.split("\n");

  let depth = 0;
  let length = 0;

  for (const value of lines) {
    const [command, magnitude] = value.split(" ");

    switch (command) {
      case "forward":
        length += parseInt(magnitude);
        break;
      case "down":
        depth += parseInt(magnitude);
        break;
      case "up":
        depth -= parseInt(magnitude);
        break;
    }
  }

  console.log(`The final result is ${depth * length}`);
};

start();
