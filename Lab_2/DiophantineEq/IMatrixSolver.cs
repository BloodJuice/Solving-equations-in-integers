using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal interface IMatrixSolver
    {
        public List<List<int>> main_matrix { set; get; }
        public void calculationOfMatrix();
        protected int[] Ai(List<int> massive, int iNow);
        protected int[] searchOtherValue(List<int> massive, int i, int deleteValue);

    }
}
