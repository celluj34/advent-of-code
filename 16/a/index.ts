import input from "../input.js";

type MyType = {
  version: number;
  type: "literal" | "operator";
  value: number | null;
  totalLength: number;
  children: Array<MyType>;
};

const start = () => {
  const inputs = hex2bin(input);

  const packetInfo = getPacketInfo(inputs);
  const total = sumPacketVersions(packetInfo!);

  console.log(`The final result is ${total}`);
};

const hex2bin = (hex: string) => {
  const hexMap = new Map<string, string>();
  hexMap.set("0", "0000");
  hexMap.set("1", "0001");
  hexMap.set("2", "0010");
  hexMap.set("3", "0011");
  hexMap.set("4", "0100");
  hexMap.set("5", "0101");
  hexMap.set("6", "0110");
  hexMap.set("7", "0111");
  hexMap.set("8", "1000");
  hexMap.set("9", "1001");
  hexMap.set("A", "1010");
  hexMap.set("B", "1011");
  hexMap.set("C", "1100");
  hexMap.set("D", "1101");
  hexMap.set("E", "1110");
  hexMap.set("F", "1111");

  let output = "";
  for (const char of hex) {
    output += hexMap.get(char);
  }

  return output;
};

const getPacketInfo = (input: string): MyType | null => {
  if (input.length === 0 || [...input].every((x) => x === "0")) {
    return null;
  }

  const version = parseInt(input.slice(0, 3), 2);
  const type = parseInt(input.slice(3, 6), 2);

  if (type === 4) {
    const chunks = new Array<string>();
    while (true) {
      const sliceStart = 6 + chunks.length * 5;
      const sliceEnd = sliceStart + 5;
      const [first, ...rest] = input.slice(sliceStart, sliceEnd);

      chunks.push(rest.join(""));

      if (first === "0") {
        break;
      }
    }

    return {
      version,
      type: "literal",
      value: parseInt(chunks.join(""), 2),
      totalLength: 3 + 3 + chunks.length * 5,
      children: [],
    };
  }

  const lengthId = input.slice(6, 7);

  const children = new Array<MyType>();
  if (lengthId === "0") {
    const length = 15;
    const childrenIndexStart = 7 + length;
    const childrenLength = parseInt(input.slice(7, childrenIndexStart), 2);
    const childPackets = input.slice(
      childrenIndexStart,
      childrenIndexStart + childrenLength
    );

    let childPacketLengthOffset = 0;
    while (true) {
      const child = getPacketInfo(childPackets.slice(childPacketLengthOffset));

      if (child == null) {
        break;
      }

      children.push(child);
      childPacketLengthOffset += child.totalLength;
    }
  } else if (lengthId === "1") {
    const length = 11;
    const childrenIndexStart = 7 + length;
    const numberOfChildren = parseInt(input.slice(7, childrenIndexStart), 2);

    for (let childCount = 0; childCount < numberOfChildren; ++childCount) {
      const childrenLength = children.reduce(
        (previous, current) => (previous += current.totalLength),
        0
      );

      const child = getPacketInfo(
        input.slice(childrenIndexStart + childrenLength)
      );

      if (child == null) {
        break;
      }

      children.push(child);
    }
  }

  return {
    version,
    type: "operator",
    value: null,
    children: children,
    totalLength:
      3 +
      3 +
      1 +
      (lengthId === "0" ? 15 : 11) +
      children.reduce(
        (previous, current) => (previous += current.totalLength),
        0
      ),
  };
};

const sumPacketVersions = (packet: MyType) => {
  let total = packet.version;

  for (const child of packet.children) {
    total += sumPacketVersions(child);
  }

  return total;
};

start();
