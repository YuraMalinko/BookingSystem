namespace BookingSystem
{
    public class Reservation
    {
        public int NumberReservation { get; private set; }

        public string NameGuest { get; private set; }

        public string TelephoneNumberGuest { get; private set; }

        public DateTime DateReservation { get; private set; } = new DateTime();

        public int NumberOfGuest { get; private set; }

        public int NumberTable { get; set; }

        public Reservation(int numberTable,int numberReservation, string nameGuest, string telephoneNumberGuest, DateTime dateReservation, int numberOfGuest)
        {
            NumberTable = numberTable;
            DateReservation = dateReservation;
            NumberOfGuest = numberOfGuest;
            NumberReservation = numberReservation;
            NameGuest = nameGuest;
            TelephoneNumberGuest = telephoneNumberGuest;
        }

        public void ShowFullInfoReservation()
        {
            Console.WriteLine($"Бронь номер : \t{NumberReservation}");
            Console.WriteLine($"Cтол номер : \t{NumberTable}");
            Console.WriteLine($"Дата брони: \t{DateReservation:D}");
            Console.WriteLine($"На имя : \t{NameGuest}");
            Console.WriteLine($"Телефон : \t{TelephoneNumberGuest}");
            Console.WriteLine($"Колличество гостей : {NumberOfGuest} ");
        }

        public override string ToString()
        {
            return $"Reservation #{NumberReservation} Date {DateReservation:D} ";
        }

        public override bool Equals(object? obj)
        {
            return obj is Reservation reservation &&
                   NumberReservation==reservation.NumberReservation &&
                   NumberTable==reservation.NumberTable &&
                   DateReservation == reservation.DateReservation &&
                   NumberOfGuest==reservation.NumberOfGuest &&
                   NameGuest==reservation.NameGuest &&
                   TelephoneNumberGuest == reservation.TelephoneNumberGuest;
        }
    }
}
