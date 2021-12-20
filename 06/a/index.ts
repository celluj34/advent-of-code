import input from "../input-sample";

const juvenileSpawnTimer = 8;
const adultSpawnTimer = 6;
const dayCount = 80;

const start = () => {
  const inputs = input.split(",").map((x) => parseInt(x));

  for (let day = 0; day < dayCount; ++day) {
    const fishCount = inputs.length;

    for (let fishIndex = 0; fishIndex < fishCount; ++fishIndex) {
      if (inputs[fishIndex] === 0) {
        inputs.push(juvenileSpawnTimer);
        inputs[fishIndex] = adultSpawnTimer;
      } else {
        --inputs[fishIndex];
      }
    }
  }

  console.log(`The final result is ${inputs.length}`);
};

start();
