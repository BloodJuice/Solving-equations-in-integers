using DiophantineEq;
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
            string path = "E:\\Магистр_3_сем\\Рояк\\Lab_2\\DiophantineEq\\input.txt";
            List<List<int>> B = readFile(path);
            List<List<int>> outputB = new List<List<int>>();
            int n = B[0][0];
            int m = B[0][1];
            B.Remove(B[0]);
            
            List<List<int>> identity = identityMatrix(m);
            path = "E:\\Магистр_3_сем\\Рояк\\Lab_2\\DiophantineEq\\output.txt";

            if (n == 1)
            {
                foreach (List<int> array in identity)
                {
                    B.Add(array);
                }
                int c = B[0][B[0].Count - 1];
                B[0].Remove(c);
                
                LinearEquationEasy linearEquation = new LinearEquationEasy();
                linearEquation.main_matrix = B;
                linearEquation.calculationOfMatrix();
                outputB = linearEquation.main_matrix;
                linearEquation.searcherMatrixResult();
                getResult(outputB, n, m, c, linearEquation.flag, path);
                if (c % linearEquation.resultCalculateMatrix == 0)
                {
                    Console.WriteLine($"Fx : {c} делится на {linearEquation.resultCalculateMatrix}");
                    linearEquation.disisionMatrix(c);
                }
                else
                    Console.WriteLine($"Fx : {c} не делится на {linearEquation.resultCalculateMatrix}");

            }
            else
            {
                for (int i = 0; i < B.Count; i++)
                {
                    B[i][B[i].Count - 1] *= -1; 
                }
                foreach (List<int> array in identity)
                {
                    array.Add(0);
                    B.Add(array);
                }
                LinearEquationHard linearEquation = new LinearEquationHard();
                linearEquation.n = n;
                linearEquation.main_matrix = B;
                linearEquation.calculationOfMatrix();
                outputB = linearEquation.main_matrix;
                getResult(outputB, n, m, 0, linearEquation.flag, path);
            }
            
        }
        static void getResult(List<List<int>> matrix, int n, int m, int c, int flag, string path)
        {
            int d, j;
            d = 0;
            
            
            int[,] result = new int[m, matrix[0].Count];

            if (n == 1 && flag == 0)
            {
                for (j = matrix[0].Count - 1; j != -1; j--)
                {
                    if (matrix[0][j] != 0)
                    {
                        d = matrix[0][j];
                        break;
                    }
                        
                }
                for (int i = 0; i < matrix.Count - 1; i++)
                {
                    result[i, 0] = matrix[i + 1][j] * c / d;
                    matrix[i + 1].Remove(j);
                    for (int z = 1;  z < matrix[i + 1].Count; z++)
                    {
                        result[i, z] = matrix[i + 1][z];
                    }
                }
            }
            else if (n > 1 && flag == 0)
            {
                for (j = matrix[n - 1].Count - 2; j != -1; j--)
                {
                    if (matrix[n - 1][j] != 0)
                    {
                        break;
                    }
                }

                for (int i = 0; i < m; i++)
                {
                    int numberElement = matrix[i + n].Count;
                    int count = 1;
                    result[i, 0] = matrix[i + n][numberElement - 1];
                    matrix[i + n].RemoveAt(numberElement - 1);
                    for (int z = j + 1; z < matrix[i + n].Count; z++, count++)
                    {
                        result[i, count] = matrix[i + n][z];
                    }
                }
            }
            writeFile(path, flag, result);
        }

        static void writeFile(string path, int flag, int[,] massive)
        {
            StreamWriter sw = new StreamWriter(path);
            int n, m;
            n = massive.GetLength(0);
            m = massive.Length / n;
            if (flag == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (j == 0)
                            sw.Write(massive[i, j] + "\t");
                        else if (massive[i, j] == 0)
                            break;
                        else
                            sw.Write(massive[i, j] + "\t");
                    }
                            
                    sw.WriteLine();
                }
            }
            else
            {
                sw.WriteLine("NO SOLUTIONS");
            }
            sw.Close();
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
            Regex rx = new Regex(@"[-+]?\d+");

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


        
        
    }
}
