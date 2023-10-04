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
            string path = "E:\\Магистр_3_сем\\Рояк\\Labs\\Lab_2\\input.txt";
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
            Console.WriteLine("Input a number:");
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
                int i, j, r, q;

                // First point
                int[] intermValue = minimum(main_matrix[0]);
                int minValue = intermValue[0];
                i = intermValue[1];
                
                // Second point
                if (minValue == main_matrix[0][0])
                    j = 1;
                else
                    j = 0;

                //Third point
                r = main_matrix[0][i] % minValue;
                q = main_matrix[0][i] / minValue;

                int a = 0;
                //Forth point

            }
            private int[] minimum(List<int> massive)
            {
                int minValue = massive[0];
                int[] result = new int[2]; 
                for (int i = 1; i < massive.Count; i++)
                {
                    if (massive[i] < minValue) 
                    {
                        minValue = massive[i];
                        result[0] = minValue;
                        result[1] = i;
                    } 
                }
                return result;
            }
        }
    }
}
