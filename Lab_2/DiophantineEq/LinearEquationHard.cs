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
        public int flag { get; set; }
        public int n { get; set; }
        public LinearEquationHard() { }
        public void calculationOfMatrix()
        {
            int i, j, r, q, count, aj, iNow, deleteValue, lenMatrix;
            iNow = 0; // номер рассматриваемой строки матрицы main_matrix
            deleteValue = 0;
            lenMatrix = main_matrix[iNow].Count;
            flag = 0;

            // First point
            while (iNow < n)
            {
                lenMatrix = main_matrix[iNow].Count;
                count = 0;
                int[] intermValue = Ai(main_matrix[iNow], iNow);
                int ai = intermValue[0];
                i = intermValue[1];

                // Second point
                intermValue = searchOtherValue(main_matrix[iNow], i, deleteValue);
                aj = intermValue[0];
                j = intermValue[1];

                if (i == j || aj == 0)
                {
                    if (main_matrix[iNow][iNow] != 1)
                        swap(iNow);
                    iNow++;
                    if (iNow == n)
                        flag = -1;
                    continue;
                }
                if (ai == 0)
                {
                    flag = -1;
                    break;
                }

                //Third point
                r = aj % ai;
                q = aj / ai;
                if (r != 0 && aj == main_matrix[iNow][lenMatrix - 1])
                {
                    flag = -1;
                    break;
                }
                if (r < 0 || r > Math.Abs(ai))
                {
                    deleteValue = aj;
                    continue;
                }


                //Forth point
                for (int z = 0; z < main_matrix.Count; z++)
                {
                    main_matrix[z][j] -= q * main_matrix[z][i];
                }
                for (int z = iNow; z < lenMatrix - 1; z++)
                {
                    if (main_matrix[iNow][z] == 0)
                    {
                        count++;
                    }
                }

                // Проверяем число нулевых элементов в текущей строке матрицы для создания треугольного вида
                if (count == (lenMatrix - 2) - iNow && main_matrix[iNow][lenMatrix - 1] == 0)
                {
                    if (main_matrix[iNow][iNow] == 0)
                        swap(iNow);
                    iNow++;
                }
                
            }
            //print(main_matrix);
        }
        public int[] Ai(List<int> massive, int iNow)
        {
            int[] result = noZeroValue(massive, iNow);

            // Убираем из расчётов последний столбец, т.к. его мы не можем вычитать из других элементов.
            for (int i = iNow; i < massive.Count - 1; i++)
            {
                if (Math.Abs(massive[i]) < Math.Abs(result[0]) && massive[i] != 0)
                {
                    result[0] = massive[i];
                    result[1] = i;
                }
            }
            return result;
        }
        public int[] searchOtherValue(List<int> massive, int i, int deleteValue)
        {
            int[] result = new int[2];

            for (int j = 0; j < massive.Count; j++)
            {
                if (i != j && massive[j] != 0 && massive[j] != deleteValue)
                {
                    result[0] = massive[j];
                    result[1] = j;
                    break;
                }
            }
            return result;
        }
        protected int[] noZeroValue(List<int> massive, int iNow)
        {
            int[] value = new int[] { 0, 0 };
            for (int j = iNow; j < massive.Count - 1; j++)
            {
                if (massive[j] != 0)
                {
                    value[0] = massive[j];
                    value[1] = j;
                    break;
                }
                    
            }
            return value;
        }
        protected void swap(int iNow)
        {
            int depot, location;
            location = 0;

            // Свободный элемент не рассматриваем, оттого и main_matrix[iNow].Count - 1 
            for (int j = iNow; j < main_matrix[iNow].Count - 1; j++)
            {
                if (main_matrix[iNow][j] != 0)
                {
                    location = j;
                    break;
                }
            }
            for (int i = 0; i < main_matrix.Count; i++)
            {
                if (location == 0)
                    break;
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
