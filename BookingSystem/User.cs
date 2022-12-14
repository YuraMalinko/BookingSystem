namespace BookingSystem
{
    public class User
    {
        public DataStorage DataFile { get;private set; }

        public User()
        {
            DataFile = new DataStorage();
            DataFile.ReturnFromFile();
        }

        private bool CheckingTable(int numberTable)
        {
            return DataFile.Tables.Exists(table => table.NumberTable == numberTable);
        }

        public void AddNewTable(Table newTable)
        {
            if (!CheckingTable(newTable.NumberTable))
            {
                DataFile.Tables.Add(newTable);
                DataFile.Tables.Sort();
                Console.WriteLine($"\nСтол с номером {newTable.NumberTable} создан !");
            }
            else
            {
                Console.WriteLine("\nСтол с таким номером уже есть!");
            }

            DataFile.RewriteFile();
        }

        public void RemoveTable(int numberTable)
        {
            if (CheckingTable(numberTable))
            {
                DataFile.Tables.Remove(DataFile.Tables.Find(table => table.NumberTable == numberTable));
                Console.WriteLine($"\nСтол с номером {numberTable} удалён !");
            }
            else
            {
                Console.WriteLine("\nСтола с таким номером нет !");
            }

            DataFile.RewriteFile();
        }

        public void ShowAllTables()
        {
            Console.WriteLine("Доступные столы:");

            foreach (Table table in DataFile.Tables)
            {
                Console.WriteLine(table);
            }
        }

        private bool ChekReservSpecificDay(DateTime dateTime, int numberTable)
        {
            return DataFile.Reservations.Exists(reservation => reservation.NumberTable == numberTable && reservation.DateReservation == dateTime);
        }



        public List<Table> ReturnCorrectTable(DateTime dateTime, int numberOfGuest)
        {
            List<Table> tables = new List<Table>();

            foreach (Table table in DataFile.Tables)
            {
                if (table.NumberSeats >= numberOfGuest)
                {
                    if (!ChekReservSpecificDay(dateTime, table.NumberTable))
                    {
                        tables.Add(table);
                    }
                }
            }

            return tables;
        }

        public List<Reservation> ReturnReservationsForSpecificDayAndSeatz(DateTime dateTime, int numberOfGuest)
        {
            List<Reservation> reservations = new List<Reservation>();

            foreach (Reservation reservation in DataFile.Reservations)
            {
                if (reservation.DateReservation == dateTime)
                {
                    foreach (Table table in DataFile.Tables)
                    {
                        if (table.NumberSeats >= numberOfGuest && reservation.NumberTable == table.NumberTable)
                        {
                            reservations.Add(reservation);
                        }
                    }
                }
            }

            return reservations;
        }

        public int GeneratesNumberReservation()
        {
            Random rnd = new Random();
            int numberReservation;

            do
            {
                numberReservation = rnd.Next(1000, 9999);
            }
            while (DataFile.Reservations.Exists(reserv => reserv.NumberReservation == numberReservation));

            return numberReservation;
        }

        public void AddNewReservation(Reservation newReservation)
        {
            if (!ChekReservSpecificDay(newReservation.DateReservation, newReservation.NumberTable) 
                && CheckingTable(newReservation.NumberTable))
            {
                DataFile.Reservations.Add(newReservation);
                DataFile.Reservations.Sort();
                Console.WriteLine("\nБронь записана : ");
            }

            DataFile.RewriteFile();
        }

        private bool CheckingReservation(int numberReservation)
        {
            return DataFile.Reservations.Exists(reservation => reservation.NumberReservation == numberReservation);
        }

        public Reservation ReturnReservationByItsNumber(int numberReservation)
        {
            return DataFile.Reservations.Find(resrvation => resrvation.NumberReservation == numberReservation);
        }

        public void RemoveReservation(int numberReservation)
        {
            if (CheckingReservation(numberReservation))
            {
                DataFile.Reservations.Remove(ReturnReservationByItsNumber(numberReservation));
                Console.WriteLine($"Бронь номер {numberReservation} удалена");
            }
            else
            {
                Console.WriteLine("Брони с таким номером нет");
            }

            DataFile.RewriteFile();
        }

        public void ShowAllReservations()
        {
            Console.WriteLine("Список броней : ");

            foreach (Reservation reserv in DataFile.Reservations)
            {
                {
                    Console.WriteLine("");
                    reserv.ToString();
                }
            }
        }

        public List<Reservation> ReturnReservationsForSpecificDay(DateTime dateTime)
        {
            return DataFile.Reservations.FindAll(reservation => reservation.DateReservation == dateTime);
        }

        public List<Reservation> ReturnReservationsForSpecificTable(int numberTable)
        {
            return DataFile.Reservations.FindAll(reservation => reservation.NumberTable == numberTable);
        }

    }
}
