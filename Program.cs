using System;

namespace katas
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int[] testArray = new int[5] {1,2,3,4,5};
            //int[] testArray = new int[6] {-9,9,-8,8,66,23};

            int[] result = FoldArray(testArray, 2);

            foreach(var e in result)
                Console.Write(e); */
            int[,] maze = new int[,] { { 1, 1, 1, 1, 1, 1, 1 },
                                       { 1, 0, 0, 0, 0, 0, 3 },
                                       { 1, 0, 1, 0, 1, 0, 1 },
                                       { 0, 0, 1, 0, 0, 0, 1 },
                                       { 1, 0, 1, 0, 1, 0, 1 },
                                       { 1, 0, 0, 0, 0, 0, 1 },
                                       { 1, 2, 1, 0, 1, 0, 1 } };
            //string[] directions = new string[] { "N", "N", "N", "N", "N", "E", "E", "E", "E", "E" };
            string[] directions = new string[] { "N","N","N","N","N","E","E","E","E","E","W","W" };

            Console.WriteLine(mazeRunner(maze, directions));
        }

        public static string mazeRunner(int[,] maze, string[] directions)
        {
            Tuple<int, int> currentPosition = GetStartPosition(maze);
            Tuple<int, int> testPosition;
            
            foreach(var d in directions)
            {
                switch(d)
                {
                    case "N":
                        testPosition = Tuple.Create(currentPosition.Item1 - 1, currentPosition.Item2);
                        if(CanMoveToNewPosition(testPosition, maze))
                            currentPosition = testPosition;
                        else
                            return "Dead";
                        break;
                    case "S":
                        testPosition = Tuple.Create(currentPosition.Item1 + 1, currentPosition.Item2);
                        if(CanMoveToNewPosition(testPosition, maze))
                            currentPosition = testPosition;
                        else
                            return "Dead";
                        break;
                    case "E":
                        testPosition = Tuple.Create(currentPosition.Item1, currentPosition.Item2 + 1);
                        if(CanMoveToNewPosition(testPosition, maze))
                            currentPosition = testPosition;
                        else
                            return "Dead";

                        break;
                    case "W":
                        testPosition = Tuple.Create(currentPosition.Item1, currentPosition.Item2 - 1);
                        if(CanMoveToNewPosition(testPosition, maze))
                            currentPosition = testPosition;
                        else
                            return "Dead";
                        break;
                }
            }

            if(maze[currentPosition.Item1, currentPosition.Item2] == 3)
                return "Finish";
            else 
                return "Lost";
        }

        public static bool CanMoveToNewPosition(Tuple<int, int> coordinates, int[,] maze)
        {
            try{
                if (maze[coordinates.Item1, coordinates.Item2] == 0  || maze[coordinates.Item1, coordinates.Item2] == 3)
                return true;
            else
                return false;
            } catch (IndexOutOfRangeException) {
                return false;
            }
            
        }

        public static Tuple<int, int> GetStartPosition(int[,] maze)
        {
            for(int x = 0; x < maze.GetLength(0); x++)
            {
                for(int y = 0; y < maze.GetLength(1); y++)
                {
                    if(maze[x,y] == 2)
                        return Tuple.Create(x,y);
                }
            }

            return Tuple.Create(-1,-1);
        }


        public static int[] FoldArray(int[] array, int runs)
        {
            int[] tmpArray = array;
            do {
                tmpArray = PerformFold(tmpArray);
                runs--;
            } while(runs > 0);

            return tmpArray;
        }

        public static int[] PerformFold(int[] array)
        {
            int foldedArrayLength = 0;
            
            if (array.Length % 2 == 0) //if even
                foldedArrayLength = array.Length / 2;
            else //else odd
                foldedArrayLength = array.Length / 2 + 1;

            int[] foldedArray = new int[foldedArrayLength];

            for (int i = 0; i < foldedArrayLength; i++) 
            {
                if (i == foldedArrayLength-1 && array.Length % 2 != 0)
                    foldedArray[i] = array[i];
                else
                    foldedArray[i] = array[i] + array[(array.Length - 1) - i];
            }

            return foldedArray;
        }
    }
}
