namespace ChallengeLab6._1
{
    internal class Program
    {
        public static int[,] GetMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(1, 10);
                }
            }
            Console.WriteLine("Original Matrix:");
            PrintMatrix(matrix);
            Console.WriteLine("90 Degrees Clockwise Rotated Matrix:");
            Clockwise90DegreesRotateMatrix(matrix);
            Console.WriteLine("Transposition Matrix:");
            TranspositionMatrix(matrix);
            Console.WriteLine("90 Degrees Clockwise Rotated Matrix (In-Place):");
            ReverseRows(TransposeMatrixInPlace(matrix));
            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }               
                Console.WriteLine();
            }
            Console.WriteLine("\n===============================\n");
        }

        public static void Clockwise90DegreesRotateMatrix(int[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);
            int[,] rotatedMatrix = new int[rowLength, rowLength];
            for (int i = 0; i < colLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    rotatedMatrix[j, rowLength - 1 - i] = matrix[i, j];
                }
            }

            PrintMatrix(rotatedMatrix);
        }

        public static int[,] TranspositionMatrix(int[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);
            int[,] transpositionMatrix = new int[rowLength, rowLength];
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    transpositionMatrix[j, i] = matrix[i, j];
                }
            }

            PrintMatrix(transpositionMatrix);
            return transpositionMatrix;
        }

        //Matrix In Place solution
        public static int[,] TransposeMatrixInPlace(int[,] matrix)
        {
            int n = matrix.GetLength(0); // Assuming a square matrix
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++) // Iterate only for upper triangle
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }
            return matrix;
        }

        public static void ReverseRows(int[,] matrix)
        {
            int n = matrix.GetLength(0); // Number of rows
            int m = matrix.GetLength(1); // Number of columns
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m / 2; j++) // Iterate up to half the row length
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, m - 1 - j];
                    matrix[i, m - 1 - j] = temp;
                }
            }
            PrintMatrix(matrix);
        }

        static void Main(string[] args)
        {
            GetMatrix(4, 4);

        }
    }
}
