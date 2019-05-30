using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Combinaciones
{
    public static class Combinatoric
    {
        #region Private static fields
        static private List<long[]> pascalsTriangle = null;
        static private int pascalsTriangleMaxN = -1;
        #endregion Private static fields


        #region Private static methods
        static private List<long[]> BuildPascalsTriangle ()
        {
            var result = new List<long[]> { new long[] { 1 } };

            try
            {
                for (int n = 1; ; ++n)
                {
                    var row = new long[n+1];
                    row[0] = 1;
                    for (int k = 1; k <= n-1; ++k)
                        row[k] = checked (result[n-1][k-1] + result[n-1][k]);
                    row[n] = 1;
                    result.Add (row);
                }
            }
            catch (OverflowException)
            { }

            return result;
        }
        #endregion Private static methods


        #region Public static methods
        static public long BinomialCoefficient(int n, int k)
        {
            if (k < 0 || k > n)
                return 0;

            if (n <= pascalsTriangleMaxN)
                return pascalsTriangle[n][k];

            if (pascalsTriangle == null)
            {
                pascalsTriangle = BuildPascalsTriangle ();
                pascalsTriangleMaxN = pascalsTriangle.Count - 1;

                if (n < pascalsTriangleMaxN)
                    return pascalsTriangle[n][k];
            }

            // Row is beyond precalculated table so fall back to multiplicative formula:
            if (k > n - k)
                k = n - k;

            int factor = n - k;
            long bc = 1;

            for (int ki = 1; ki <= k; ++ki)
            {
                ++factor;
                bc = checked (bc * factor) / ki;
            }

            return bc;
        }
        #endregion Public static methods
    }
}
