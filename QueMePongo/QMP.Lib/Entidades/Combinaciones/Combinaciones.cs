using System;
using System.Collections.Generic;
using System.Text;

namespace Ar.UTN.QMP.Lib.Entidades.Combinaciones
{
    public class Combinaciones :
        IComparable,
        System.Collections.IEnumerable,
        IComparable<Combinaciones>,
        IEquatable<Combinaciones>,
        IEnumerable<int>
    {
        private int[] data;     // The picks for the current rank. Length is 'k'.
        private int choices;    // Number of possible values 'n'.
        private long rowCount;  // Row count of the table of k-combinations.
        private long rank;      // Row index.

        #region Constructors
        /*public Combinaciones()
        {
            this.data = new int[0];
            this.choices = 0;
            this.rowCount = 0;
            this.rank = 0;
        }
        
        public Combinaciones(Combinaciones source)
        {
            if (source == null) throw new ArgumentNullException("source");

            this.data = new int[source.data.Length];
            source.data.CopyTo(this.data, 0);

            this.choices  = source.choices;
            this.rowCount = source.RowCount;
            this.rank     = source.rank;
        }
        
        public Combinaciones(int choices)
        {
            if (choices < 0) throw new ArgumentOutOfRangeException("choices", "Value is less than zero.");

            this.data = new int[choices];
            for (int ki = 0; ki < this.data.Length; ++ki)
                this.data[ki] = ki;

            this.choices  = choices;
            this.rowCount = choices == 0? 0 : 1;
            this.rank     = 0;
        }*/
        
        // USO ESTA
        public Combinaciones(int choices, int picks)
        {
            if (choices < 0) throw new ArgumentOutOfRangeException("choices", "Value is less than zero.");
            if (picks < 0) throw new ArgumentOutOfRangeException("picks", "Value is less than zero.");
            if (picks > choices) throw new ArgumentOutOfRangeException("picks", "Value is greater than choices.");

            this.data = new int[picks];
            for (int ki = 0; ki < picks; ++ki)
                this.data[ki] = ki;

            this.choices  = choices;
            this.rowCount = picks == 0? 0 : Combinatoric.BinomialCoefficient (choices, picks);
            this.rank     = 0;
        }
        
        /*public Combinaciones(int choices, int picks, long rank)
        {
            if (choices < 0) throw new ArgumentOutOfRangeException ("choices", "Value is less than zero.");
            if (picks < 0) throw new ArgumentOutOfRangeException ("picks", "Value is less than zero.");
            if (picks > choices) throw new ArgumentOutOfRangeException ("picks", "Value is greater than choices.");

            this.data     = new int[picks];
            this.choices  = choices;
            this.rowCount = picks == 0? 0 : Combinatoric.BinomialCoefficient (choices, picks);
            Rank          = rank;
        }

        public Combinaciones(int choices, int[] source)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (choices < 0) throw new ArgumentOutOfRangeException("choices", "Value is less than zero.");
            if (choices < source.Length) throw new ArgumentOutOfRangeException("choices", "Value is less than picks.");

            this.data = new int[source.Length];
            source.CopyTo(this.data, 0);
            Array.Sort(this.data);

            this.choices = choices;
            this.rowCount = Picks == 0? 0 : Combinatoric.BinomialCoefficient (choices, Picks);

            for (int ki = 0; ki < Picks; ++ki)
            {
                if (this.data[ki] < 0 || this.data[ki] >= choices)
                    throw new ArgumentOutOfRangeException ("source", "Element is out of range.");

                if (ki > 0)
                    if (this.data[ki] == this.data[ki-1])
                        throw new ArgumentOutOfRangeException ("source", "Elements must be unique.");
            }

            // Perform ranking:
            this.rank = 0;
            int ji = 0;
            for (int ki = 0; ki < Picks; ++ki)
            {
                for (; ji < this.data[ki]; ++ji)
                    rank += Combinatoric.BinomialCoefficient (Choices - ji - 1, Picks - ki - 1);

                ji = this.data[ki] + 1;
            }
        }*/
        #endregion Constructors

        #region Properties
        public int Choices
        {
            get { return choices; }
        }
        
        public int Picks
        {
            get { return data.Length; }
        }
        
        public long Rank
        {
            get { return rank; }
            set
            {
                if (RowCount == 0)
                    return;

                // Normalize the new rank.
                if (value < 0)
                {
                    rank = value % RowCount;
                    if (rank < 0)
                        rank += RowCount;
                }
                else
                    rank = value < RowCount? value : value % RowCount;

                // Perform unranking:
                long diminishingRank = RowCount - rank - 1;
                int combinaticAtom = Choices;

                for (int ki = Picks; ki > 0; --ki)
                    for (;;)
                    {
                        --combinaticAtom;

                        long trialCount = Combinatoric.BinomialCoefficient (combinaticAtom, ki);
                        if (trialCount <= diminishingRank)
                        {
                            diminishingRank -= trialCount;
                            data[Picks - ki] = Choices - combinaticAtom - 1;
                            break;
                        }
                    }
            }
        }
        
        public long RowCount
        {
            get { return rowCount; }
        }
        
        public int this[int index]
        {
            get { return data[index]; }
        }
        #endregion Properties

        #region Instance methods
        public int CompareTo(object obj)
        {
            return CompareTo(obj as Combinaciones);
        }
        
        public int CompareTo(Combinaciones other)
        {
            if ((object) other == null)
                return 1;

            int result = this.Picks - other.Picks;
            if (result == 0)
            {
                result = this.Choices - other.Choices;
                if (result == 0)
                {
                    long rankDiff = this.Rank - other.Rank;

                    if (rankDiff == 0)
                        result = 0;
                    else
                        result = rankDiff < 0 ? -1 : 1;
                }
            }

            return result;
        }
        
        /*public void CopyTo(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException ("array");

            if (array.Length < Picks)
                throw new ArgumentException ("Destination array is not long enough.");

            this.data.CopyTo(array, 0);
        }*/
        
        /*public override bool Equals(object obj)
        {
            return Equals(obj as Combinaciones);
        }*/
        
        public bool Equals(Combinaciones other)
        {
            return (object) other != null && other.Rank == Rank && other.Choices == Choices && other.Picks == Picks;
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        
        public IEnumerator<int> GetEnumerator()
        {
            for (int ei = 0; ei < Picks; ++ei)
                yield return this.data[ei];
        }
        
        /*public override int GetHashCode()
        {
            return unchecked((int) Rank);
        }*/
        
        // USO ESTA
        public IEnumerable<Combinaciones> GetRows()
        {
            if (RowCount > 0)
            {
                long startRank = rank;
                for (Combinaciones current = (Combinaciones) MemberwiseClone();;)
                {
                    yield return current;
                    current.Rank = current.Rank + 1;
                    if (current.Rank == startRank)
                        break;
                }
            }
        }
        
        /*public IEnumerable<Combinaciones> GetRowsForAllPicks()
        {
            for (int k = 1; k <= Picks; ++k)
            {
                Combinaciones current = (Combinaciones) MemberwiseClone();

                current.data = new int[k];
                for (int ei = 0; ei < current.data.Length; ++ei)
                    current.data[ei] = ei;
                current.rowCount = Combinatoric.BinomialCoefficient(choices, k);
                current.rank = 0;

                for (;;)
                {
                    yield return current;
                    current.Rank = current.Rank + 1;
                    if (current.Rank == 0)
                        break;
                }
            }
        }*/
        
        /*public override string ToString()
        {
            if (RowCount == 0)
                return ("{ }");

            StringBuilder result = new StringBuilder ("{ ");

            for (int ei = 0;;)
            {
                result.Append (this.data[ei]);

                ++ei;
                if (ei >= Picks)
                    break;

                result.Append (", ");
            }

            result.Append (" }");

            return result.ToString();
        }*/
        #endregion Instance methods

        #region Static methods
        // USO ESTA
        public static List<T> Permute<T>(Combinaciones arrangement, IList<T> source)
        {
            if (arrangement == null) throw new ArgumentNullException ("arrangement");
            if (source == null) throw new ArgumentNullException ("source");
            if (source.Count < arrangement.Choices) throw new ArgumentException ("Not enough supplied values.", "source");

            List<T> result = new List<T> (arrangement.Picks);

            for (int ai = 0; ai < arrangement.Picks; ++ai)
                result.Add (source[arrangement[ai]]);

            return result;
        }
        
        /*public static bool operator ==(Combinaciones param1, Combinaciones param2)
        {
            if ((object) param1 == null)
                return (object) param2 == null;
            else
                return param1.Equals (param2);
        }
        
        public static bool operator !=(Combinaciones param1, Combinaciones param2)
        {
            return !(param1 == param2);
        }
        
        public static bool operator <(Combinaciones param1, Combinaciones param2)
        {
            if ((object) param1 == null)
                return (object) param2 != null;
            else
                return param1.CompareTo (param2) < 0;
        }
        
        public static bool operator >=(Combinaciones param1, Combinaciones param2)
        {
            return !(param1 < param2);
        }
        
        public static bool operator >(Combinaciones param1, Combinaciones param2)
        {
            if ((object) param1 == null)
                return false;
            else
                return param1.CompareTo (param2) > 0;
        }
        
        public static bool operator <=(Combinaciones param1, Combinaciones param2)
        {
            return !(param1 > param2);
        }*/
        #endregion Static methods
    }
}
