import input from "../input.js";

const numberOfMutations = 10;

const start = () => {
  const inputs = input.split("\n");
  let template = inputs[0].split("");
  const replacements = new Map<string, string>();

  inputs
    .slice(2)
    .map((x) => {
      const pair = x.split(" -> ");
      return {
        key: pair[0],
        replacement: pair[1],
      };
    })
    .forEach((x) => {
      replacements.set(x.key, x.replacement);
    });

  for (let index = 0; index < numberOfMutations; ++index) {
    for (let charIndex = template.length - 1; charIndex > 0; --charIndex) {
      const key = `${template[charIndex - 1]}${template[charIndex]}`;

      const replacement = replacements.get(key);

      if (replacement) {
        template.splice(charIndex, 0, replacement);
      }
    }
  }

  const groups = groupBy(
    template.map((x) => ({ char: x })),
    "char",
    (key, grouping) => {
      return {
        key,
        count: grouping.length,
      };
    }
  ).sort((a, b) => a.count - b.count);

  console.log(
    `The final result is ${groups[groups.length - 1].count - groups[0].count}`
  );
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
