import input from "../input.js";

const juvenileSpawnTimer = 9;
const adultSpawnTimer = 7;
const dayCount = 256;

const start = () => {
  const adultBuckets = generateBuckets();

  const juvenileBuckets = new Array<number>(juvenileSpawnTimer);
  juvenileBuckets.fill(0);

  for (let day = 0; day < dayCount; ++day) {
    const date = day % adultSpawnTimer;
    const juvenileDate = day % juvenileSpawnTimer;

    const adultCount = adultBuckets[date];
    const juvenileCount = juvenileBuckets[juvenileDate];

    adultBuckets[date] += juvenileCount;
    juvenileBuckets[juvenileDate] = adultCount + juvenileCount;
  }

  console.log(
    `The final result is ${adultBuckets
      .concat(juvenileBuckets)
      .reduce((previous, current) => (previous += current), 0)}`
  );
};

const generateBuckets = () => {
  const inputs = input.split(",").map((x) => ({
    value: x,
  }));

  const initialBuckets = new Array<number>(adultSpawnTimer);
  initialBuckets.fill(0);

  const buckets = groupBy(inputs, "value", (key, value) => {
    return {
      value: parseInt(key),
      count: value.length,
    };
  }).reduce((previous, current) => {
    previous[current.value] = current.count;

    return previous;
  }, initialBuckets);
  return buckets;
};

const groupBy = function <T, K>(
  array: Array<T>,
  key: keyof T,
  callbackfn: (key: string, value: Array<T>) => K
): Array<K> {
  const keyValuePairs = array.reduce(
    (storage: { [x: string]: Array<T> }, item: T) => {
      const objKey = `${item[key]}`;
      if (storage[objKey]) {
        storage[objKey].push(item);
      } else {
        storage[objKey] = [item];
      }
      return storage;
    },
    {} as { [key: string]: Array<T> }
  );

  return Object.keys(keyValuePairs).map((x) => callbackfn(x, keyValuePairs[x]));
};

start();
