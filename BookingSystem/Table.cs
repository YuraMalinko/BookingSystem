namespace BookingSystem
{
    public class Table : IComparable<Table>
    {
        private int _numberTable;

        private int _numberSeats;

        public int NumberTable
        {
            get
            {
                return _numberTable;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Number table incorrect");
                }

                _numberTable = value;
            }
        }

        public int NumberSeats
        {
            get
            {
                return _numberSeats;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Number of seats incorrect");
                }

                _numberSeats = value;
            }
        }

        public Table(int numberTable, int numberSeats)
        {
            NumberTable = numberTable;
            NumberSeats = numberSeats;
        }

        public override bool Equals(object? obj)
        {
            return obj is Table table &&
                   NumberTable == table.NumberTable &&
                   NumberSeats == table.NumberSeats;
        }

        public override string ToString()
        {
            return $"Table #{NumberTable} / number seats : {NumberSeats}";
        }

        public int CompareTo(Table table)
        {
            if (table.NumberTable > NumberTable)
            {
                return -1;
            }
            else if (table.NumberTable < NumberTable)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
