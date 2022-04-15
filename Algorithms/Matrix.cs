using System;

namespace Algorithms
{
    public class Matrix
    {
        public int M { get; private set; }
        public int N { get; private set; }
        public double[,] Array { get; private set; }
        
        public Matrix(int m, int n, double[,] array)
        {
            N = n;
            M = m;
            Array = array;
        }

        public double[,] Multiply(Matrix secondMatrix)
        {
            if(this.N != secondMatrix.M)
            {
                throw new ArgumentException("Неправильная размерность матриц");
            }
            double[,] result = new double[this.M, secondMatrix.N];
            for(int m = 0; m < this.M; m++)
            {
                for(int n = 0; n < secondMatrix.N; n++)
                {
                    for(int k = 0; k < secondMatrix.M; k++)
                    {
                        result[m, n] += this.Array[m, k] * secondMatrix.Array[k, n]; 
                    }
                }
            }
            return result;
        }
    }
}
