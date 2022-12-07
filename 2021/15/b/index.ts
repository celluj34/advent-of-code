// import input from "../input.js";

// const numberOfMutations = 40;

// const start = () => {
//   const inputs = input.split("\n");
//   let template = inputs[0].split("");
//   const replacements = new Map<string, string>();

//   inputs
//     .slice(2)
//     .map((x) => {
//       const pair = x.split(" -> ");
//       return {
//         key: pair[0],
//         replacement: pair[1],
//       };
//     })
//     .forEach((x) => {
//       replacements.set(x.key, x.replacement);
//     });

//   let pairs = new Map<string, number>();
//   for (let charIndex = 0; charIndex < template.length - 1; ++charIndex) {
//     const key = `${template[charIndex]}${template[charIndex + 1]}`;
//     pairs.set(key, (pairs.get(key) || 0) + 1);
//   }

//   const characterCounts = new Map<string, number>();
//   const newLocal = groupBy(
//     template.map((x) => ({ char: x })),
//     "char",
//     (key, grouping) => {
//       return {
//         key,
//         count: grouping.length,
//       };
//     }
//   );

//   newLocal.forEach((x) => {
//     characterCounts.set(x.key, x.count);
//   });

//   for (let index = 0; index < numberOfMutations; ++index) {
//     const newPairs = new Map<string, number>();

//     for (const [key, previousCount] of pairs) {
//       const replacement = replacements.get(key);
//       if (replacement) {
//         const newPairKeys = [
//           `${key[0]}${replacement}`,
//           `${replacement}${key[1]}`,
//         ];

//         for (const newPairKey of newPairKeys) {
//           const newCount = newPairs.get(newPairKey) ?? 0;
//           newPairs.set(newPairKey, previousCount + newCount);
//         }

//         characterCounts.set(
//           replacement,
//           (characterCounts.get(replacement) ?? 0) + previousCount
//         );
//       }
//     }

//     pairs = newPairs;
//   }

//   const groups = [...characterCounts]
//     .map((x) => ({
//       key: x[0],
//       count: x[1],
//     }))
//     .sort((a, b) => a.count - b.count);

//   console.log(
//     `The final result is ${groups[groups.length - 1].count - groups[0].count}`
//   );
// };

// const groupBy = function <T, K>(
//   array: Array<T>,
//   key: keyof T,
//   callbackfn: (key: string, value: Array<T>) => K
// ): Array<K> {
//   const keyValuePairs = array.reduce(
//     (storage: { [x: string]: Array<T> }, item: T) => {
//       const objKey = `${item[key]}`;
//       if (storage[objKey]) {
//         storage[objKey].push(item);
//       } else {
//         storage[objKey] = [item];
//       }
//       return storage;
//     },
//     {} as { [key: string]: Array<T> }
//   );

//   return Object.keys(keyValuePairs).map((x) => callbackfn(x, keyValuePairs[x]));
// };

// start();
