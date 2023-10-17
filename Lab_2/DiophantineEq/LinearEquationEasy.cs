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
        public int flag { get; set; }
        public LinearEquationEasy() { }

        public void calculationOfMatrix()
        {
            int i, j, r, q, count, aj;
            flag = 0;
            count = 0;

            // First point
            while (flag == 0)
            {
                int[] intermValue = Ai(main_matrix[0], 0);
                int ai = intermValue[0];
                i = intermValue[1];

                // Second point
                intermValue = searchOtherValue(main_matrix[0], i, 0);
                aj = intermValue[0];
                j = intermValue[1];

                if ((aj == ai && i == j) || aj == 0)
                {
                    break;
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
                    break;
            }
            print(main_matrix);
        }
        public int[] Ai(List<int> massive, int iNow)
        {
            int[] result = noZeroValue(massive);

            // Убираем из расчётов последний столбец, т.к. его мы не можем вычитать из других элементов.
            for (int i = 0; i < massive.Count; i++)
            {
                if (Math.Abs(massive[i]) < Math.Abs(result[0]) && massive[i] != 0)
                {
                    result[0] = massive[i];
                    result[1] = i;
                }
            }
            return result;
        }
        protected int[] noZeroValue(List<int> massive)
        {
            int[] value = new int[] { 0, 0 };
            for (int j = 0; j < massive.Count; j++)
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
        //public int[] Ai(List<int> massive, int iNow)
        //{
        //    int minValue = massive[0];
        //    int[] result = new int[2];

        //    for (int i = 0; i < massive.Count; i++)
        //    {
        //        if (Math.Abs(massive[i]) <= Math.Abs(minValue) && massive[i] != 0)
        //        {
        //            minValue = massive[i];
        //            result[0] = minValue;
        //            result[1] = i;
        //        }
        //    }
        //    return result;
        //}
        public int[] searchOtherValue(List<int> massive, int i, int deleteValue)
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
