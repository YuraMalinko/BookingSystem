namespace BookingSystem
{
    public class Table
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
                if (value <= 0 && value > 20)
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

        public void ShowInfoTable()
        {
            Console.WriteLine($"Номер стола {NumberTable} Вместимость {NumberSeats}");
        }
    }
}
