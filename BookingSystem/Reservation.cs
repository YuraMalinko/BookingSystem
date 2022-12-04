namespace BookingSystem
{
    public class Reservation
    {
        public int NumberReservation { get; private set; }

        public string NameGuest { get; private set; }

        public string TelephoneNumberGuest { get; private set; }

        public int NumberOfGuest { get; private set; }

        public int NumberTable { get; private set; }
        public DateTime DateReservation { get; private set; } = new DateTime();

        public Reservation(int numberTable,int numberReservation, string nameGuest, string telephoneNumberGuest, DateTime dateReservation, int numberOfGuest)
        {
            NumberTable = numberTable;
            DateReservation = dateReservation;
            NumberOfGuest = numberOfGuest;
            NumberReservation = numberReservation;
            NameGuest = nameGuest;
            TelephoneNumberGuest = telephoneNumberGuest;
        }

        public override string ToString()
        {
            return $"Reservation #{NumberReservation}" +
                   $"\tDate {DateReservation}" +
                   $"\tNumber of guest : {NumberOfGuest}" +
                   $"\tTable #{NumberTable}" +
                   $"\tName guest : {NameGuest} " +
                   $"\tTelephone number : {TelephoneNumberGuest}";
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
