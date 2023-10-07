using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class LinearEquationEasy : IMatrixSolver
    {
        public List<List<int>> main_matrix { set; get; }
        public int resultCalculateMatrix { get; set; }
        public LinearEquationEasy() { }

        public void calculationOfMatrix()
        {
            int i, j, r, q, count, aj;
            bool flag = true;
            count = 0;

            // First point
            while (flag)
            {
                int[] intermValue = minimum(main_matrix[0]);
                int ai = intermValue[0];
                i = intermValue[1];

                // Second point
                intermValue = searchOtherValue(main_matrix[0], i);
                aj = intermValue[0];
                j = intermValue[1];

                if ((aj == ai && i == j) || aj == 0)
                {
                    flag = false;
                    continue;
                }

                //Third point
                r = aj % ai;
                q = aj / ai;


                //Forth point
                for (int z = 0; z < main_matrix.Count; z++)
                {
                    main_matrix[z][j] -= q * main_matrix[z][i];
                }
                for (int z = 0; z < main_matrix[0].Count; z++)
                {
                    if (main_matrix[0][z] == 0)
                    {
                        count++;
                    }
                }
                if (count == main_matrix[0].Count - 1)
                    flag = false;
            }
            print(main_matrix);
        }
        public void searcherMatrixResult()
        {
            for (int i = 0; i < main_matrix[0].Count;i++)
            {
                if (main_matrix[0][i] != 0)
                    resultCalculateMatrix = main_matrix[0][i];
            }
        }
        public void disisionMatrix(int c)
        {
            int d = resultCalculateMatrix;
            int[,] exitMatrix = new int[main_matrix.Count - 1, main_matrix[1].Count];
            for (int i = 1; i < main_matrix.Count; i++)
            {
                for (int j = 0; j < main_matrix[i].Count; j++)
                {
                    if (j == 0)
                        exitMatrix[i - 1, j] = (c / d * main_matrix[i][j]);
                    else
                        exitMatrix[i - 1, j] = (main_matrix[i][j]);
                }
            }
        }
        public int[] minimum(List<int> massive)
        {
            int minValue = massive[0];
            int[] result = new int[2];

            for (int i = 0; i < massive.Count; i++)
            {
                if (massive[i] <= minValue && massive[i] != 0)
                {
                    minValue = massive[i];
                    result[0] = minValue;
                    result[1] = i;
                }
            }
            return result;
        }
        public int[] searchOtherValue(List<int> massive, int i)
        {
            int[] result = new int[2];

            for (int j = 0; j < massive.Count; j++)
            {
                if (i != j && massive[i] != 0)
                {
                    result[0] = massive[j];
                    result[1] = j;
                    break;
                }
            }

            return result;
        }
        protected void print(List<List<int>> massive)
        {
            foreach (List<int> ar in massive)
            {
                foreach (int a in ar)
                    Console.Write($"{a}\t");
                Console.WriteLine();
            }
        }

    }
}
