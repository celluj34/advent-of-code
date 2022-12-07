// import input from "../input-sample.js";

// const start = () => {
//   const grid = generateGrid();

//   const distance = findShortestPath(grid);

//   console.log(`The final result is ${distance}`);
// };

// const generateGrid = () => {
//   const grid = new Array<Array<number>>();
//   const inputs = input.split("\n");

//   for (let rowIndex = 0; rowIndex < inputs.length; ++rowIndex) {
//     const row = inputs[rowIndex];
//     grid.push(row.split("").map((x) => parseInt(x)));
//   }

//   return grid;
// };

// const findShortestPath = (grid: Array<Array<number>>) => {
//   // Each "location" will store its coordinates
//   // and the shortest path required to arrive there
//   const location = {
//     distanceFromTop: 0,
//     distanceFromLeft: 0,
//     path: [],
//     status: "Start",
//   };

//   // Initialize the queue with the start location already inside
//   const queue = [location];

//   // Loop through the grid searching for the goal
//   while (queue.length > 0) {
//     // Take the first location off the queue
//     const currentLocation = queue.shift();

//     // Explore North
//     const newLocation = exploreInDirection(currentLocation, "North", grid);
//     if (newLocation.status === "Goal") {
//       return newLocation.path;
//     } else if (newLocation.status === "Valid") {
//       queue.push(newLocation);
//     }

//     // Explore East
//     const newLocation = exploreInDirection(currentLocation, "East", grid);
//     if (newLocation.status === "Goal") {
//       return newLocation.path;
//     } else if (newLocation.status === "Valid") {
//       queue.push(newLocation);
//     }

//     // Explore South
//     const newLocation = exploreInDirection(currentLocation, "South", grid);
//     if (newLocation.status === "Goal") {
//       return newLocation.path;
//     } else if (newLocation.status === "Valid") {
//       queue.push(newLocation);
//     }

//     // Explore West
//     const newLocation = exploreInDirection(currentLocation, "West", grid);
//     if (newLocation.status === "Goal") {
//       return newLocation.path;
//     } else if (newLocation.status === "Valid") {
//       queue.push(newLocation);
//     }
//   }

//   // No valid path found
//   return false;
// };

// // This function will check a location's status
// // (a location is "valid" if it is on the grid, is not an "obstacle",
// // and has not yet been visited by our algorithm)
// // Returns "Valid", "Invalid", "Blocked", or "Goal"
// const locationStatus = (location: {distanceFromTop: number, distanceFromLeft: number}, grid: Array<Array<number>>) => {
//   const gridSize = grid.length;
//   const dft = location.distanceFromTop;
//   const dfl = location.distanceFromLeft;

//   if (
//     location.distanceFromLeft < 0 ||
//     location.distanceFromLeft >= gridSize ||
//     location.distanceFromTop < 0 ||
//     location.distanceFromTop >= gridSize
//   ) {
//     // location is not on the grid--return false
//     return "Invalid";
//   } else if (dft === grid.length && dfl === grid[dft].length) {
//     return "Goal";
//   } else {
//     return "Valid";
//   }
// };

// // Explores the grid from the given location in the given
// // direction
// const exploreInDirection = (currentLocation: {path: Array, distanceFromTop: number, distanceFromLeft: number}, direction: "N" | "S" | "E" | "W", grid: Array<Array<number>>) => {
//   const newPath = currentLocation.path.slice();
//   newPath.push(direction);

//   const dft = currentLocation.distanceFromTop;
//   const dfl = currentLocation.distanceFromLeft;

//   if (direction === "N") {
//     dft -= 1;
//   } else if (direction === "E") {
//     dfl += 1;
//   } else if (direction === "S") {
//     dft += 1;
//   } else if (direction === "W") {
//     dfl -= 1;
//   }

//   const newLocation = {
//     distanceFromTop: dft,
//     distanceFromLeft: dfl,
//     path: newPath,
//     status: "Unknown",
//   };
//   newLocation.status = locationStatus(newLocation, grid);

//   // If this new location is valid, mark it as 'Visited'
//   if (newLocation.status === "Valid") {
//     grid[newLocation.distanceFromTop][newLocation.distanceFromLeft] = "Visited";
//   }

//   return newLocation;
// };

// start();
