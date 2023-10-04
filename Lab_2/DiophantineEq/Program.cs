using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\Магистр_3_сем\\Рояк\\Lab_2\\input.txt";
            List<List<int>> B = readFile(path);
            List<List<int>> identity = identityMatrix(B[0].Count);
            foreach (List<int> array in identity)
            {
                B.Add(array);
            }

            LinearEquation linearEquation = new LinearEquation();
            linearEquation.main_matrix = B;
            linearEquation.calculationOfMatrix();
        }
        static List<List<int>> readFile(string path)
        {
            String line;
            StreamReader sr = new StreamReader(path);
            List<List<int>> arrayLine = new List<List<int>>();


            line = sr.ReadLine();
            while (line != null)
            {
                arrayLine.Add(reglexReturn(line));
                line = sr.ReadLine();
            }
            sr.Close();
            return arrayLine;
        }
        static List<int> reglexReturn(string line)
        {
            List<int> ret = new List<int>();
            Regex rx = new Regex(@"\d+");

            foreach (Match match in rx.Matches(line))
            {
                ret.Add(Convert.ToInt32(match.Value));
            }
            return ret;
        }
        static List<List<int>> identityMatrix(int n)
        {
            List<List<int>> M =
            Enumerable.Range(0, n).Select(i => Enumerable.Repeat(0, n).Select((z, j) => j == i ? 1 : 0).ToList()).ToList();
            return M;
        }


        class LinearEquation
        {
            public List<List<int>> main_matrix { set; get; }
            public List<int> result { get; set; }
            public LinearEquation() { }

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
                    
                    if (aj == ai || aj == 0)
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
                    if (count == main_matrix[0].Count)
                        flag = false;
                }
                print(main_matrix);

            }
            private int[] minimum(List<int> massive)
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
            private int[] searchOtherValue(List<int> massive, int i)
            {
                int[] result = new int[2];
                
                for (int j = 0; j < massive.Count; j++)
                {
                    if (massive[i] != massive[j] && massive[i] != 0)
                    {
                        result[0] = massive[j];
                        result[1] = j;
                    }
                }
                
                return result;
            }
            private void print(List<List<int>>massive)
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
}
