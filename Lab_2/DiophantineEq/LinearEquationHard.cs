using Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiophantineEq
{
    internal class LinearEquationHard : IMatrixSolver
    {
        public List<List<int>> main_matrix { set; get; }
        public int resultCalculateMatrix { get; set; }
        public int n { get; set; }
        public LinearEquationHard() { }
        public void calculationOfMatrix()
        {
            int i, j, r, q, count, aj, iNow; 
            bool flag = true;
            count = 0;
            iNow = 0; // номер рассматриваемой строки матрицы main_matrix

            // First point
            while (iNow < n)
            {
                int[] intermValue = minimum(main_matrix[iNow]);
                int ai = intermValue[0];
                i = intermValue[1];

                // Second point
                intermValue = searchOtherValue(main_matrix[iNow], i);
                aj = intermValue[0];
                j = intermValue[1];

                if ((aj == ai && i == j) || aj == 0)
                {
                    if (main_matrix[iNow][iNow] != 1)
                        swap(iNow);
                    iNow++;
                }

                //Third point
                r = aj % ai;
                q = aj / ai;
                if (r < 0 || r > Math.Abs(ai))
                {
                    Console.WriteLine($"NO SOLUTIONS");
                    break;
                }
                    

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

                // Проверяем число нулевых элементов в текущей строке матрицы для создания треугольного вида
                if (count == (main_matrix[iNow].Count - 1) - iNow)
                {
                    if (main_matrix[iNow][iNow] != 1)
                        swap(iNow);
                    iNow++;

                }
                
            }
            print(main_matrix);
        }
        public int[] minimum(List<int> massive)
        {
            int minValue = massive[0];
            int[] result = new int[2];

            for (int i = 0; i < massive.Count; i++)
            {
                if (Math.Abs(massive[i]) <= Math.Abs(minValue) && massive[i] != 0)
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
        protected void swap(int iNow)
        {
            int depot, location;
            location = 0;

            // Свободный элемент не рассматриваем, оттого и main_matrix[iNow].Count - 1 
            for (int j = 0; j < main_matrix[iNow].Count - 1; j++)
            {
                if (main_matrix[iNow][j] == 0)
                    location = j;
            }
            for (int i = 0; i < main_matrix.Count; i++)
            {
                depot = main_matrix[i][location];
                main_matrix[i][location] = main_matrix[i][iNow];
                main_matrix[i][iNow] = depot;
            }
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
