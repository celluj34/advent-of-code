import input from "../input";

const start = () => {
  const inputs = input
    .split(",")
    .map((x) => parseInt(x))
    .sort((a, b) => a - b);

  const min = Math.min(...inputs);
  const max = Math.max(...inputs);

  let least = {
    position: 0,
    fuel: Number.MAX_SAFE_INTEGER,
  };

  for (let position = min; position <= max; ++position) {
    const fuel = inputs.reduce((previous, current) => {
      const distance = Math.abs(position - current);

      const res = (distance * (distance + 1)) / 2;

      return (previous += res);
    }, 0);

    if (fuel < least.fuel) {
      least = {
        position: position,
        fuel: fuel,
      };
      console.log(fuel);
    }
  }

  console.log(`The final result is`);
  console.log(least);
};

start();
