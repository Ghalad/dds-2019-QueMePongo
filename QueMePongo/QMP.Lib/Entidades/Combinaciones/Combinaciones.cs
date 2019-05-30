using System;
using System.Collections.Generic;

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
        
        #endregion Instance methods

        #region Static methods
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
        #endregion Static methods
    }
}
