import input from "../input";

const start = () => {
  const inputs = input
    .split("\n")
    .map((x) => {
      const [start, end] = x.split("-");
      return [
        { start, end },
        { start: end, end: start },
      ];
    })
    .flat()
    .sort((a, b) => {
      const startResult = a.start.localeCompare(b.start);
      return startResult === 0 ? a.end.localeCompare(b.end) : startResult;
    });

  const nodes: Array<{ name: string; type: "small" | "big" }> = [
    ...new Set(inputs.map((x) => [x.start, x.end]).flat()),
  ].map((x) => {
    const char = x[0];

    return {
      name: x,
      type:
        char == x[0].toLowerCase() && x[0] != x[0].toUpperCase()
          ? "small"
          : "big",
    };
  });

  const allPaths = getAllPaths(["start"], inputs, nodes);

  console.log(`The final result is ${allPaths.length}`);
};

const getAllPaths = (
  currentPath: Array<string>,
  allEdges: Array<{ start: string; end: string }>,
  nodes: Array<{ name: string; type: "small" | "big" }>
) => {
  const availableEdges = getAvailableEdges(currentPath, allEdges, nodes);
  if (availableEdges.length === 0) {
    if (currentPath[currentPath.length - 1] !== "end") {
      return [];
    }
    return [currentPath];
  }

  const allPaths = new Array<Array<string>>();
  for (const availableEdge of availableEdges) {
    const childNodes = getAllPaths(
      [...currentPath, availableEdge],
      allEdges,
      nodes
    );

    allPaths.push(...childNodes);
  }

  return allPaths;
};

const getAvailableEdges = (
  path: Array<string>,
  allEdges: Array<{ start: string; end: string }>,
  nodes: Array<{ name: string; type: "small" | "big" }>
) => {
  const currentNode = path[path.length - 1];

  if (currentNode === "end") {
    return [];
  }

  return allEdges
    .filter((x) => {
      if (x.start !== currentNode) {
        return false;
      }

      if (!path.includes(x.end)) {
        return true;
      }

      const childNode = nodes.find((y) => y.name === x.end);
      return childNode!.type === "big";
    })
    .map((x) => x.end);
};

start();
