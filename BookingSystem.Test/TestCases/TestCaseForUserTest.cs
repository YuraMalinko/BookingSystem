using System.Collections;

namespace BookingSystem.Test.TestCases
{
    public class TestCaseForAddNewTableTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Table> tables = new List<Table>()
            {
                new Table(1,2),
                new Table(2,4),
                new Table(3,6),
            };

            Table newTAble = new Table(4, 8);
            bool expected = true;

            yield return new Object[] { tables, newTAble, expected };

            newTAble = new Table(3, 8);
            expected = false;

            yield return new Object[] { tables, newTAble, expected };
        }
    }

    public class TestCaseRemoveTableTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Table> tables = new List<Table>()
            {
                new Table(1,2),
                new Table(2,4),
                new Table(3,6),
            };

            int numberRemoveTable = 2;
            bool expected = false;

            yield return new Object[] { tables, numberRemoveTable, expected };

            numberRemoveTable = 5;
            expected = true;

            yield return new Object[] { tables, numberRemoveTable, expected };
        }
    }

    public class TestCaseReturnCorrectTableTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Table> NowTables = new List<Table>()
            {
                new Table(1,2),
                new Table(2,4),
                new Table(3,6),
            };

            List<Reservation> NowReservations = new List<Reservation>()
            {
                new Reservation(1,1212,"VASYA","8800553535",new DateTime(2022,12,22),1),
                new Reservation(2,2222,"GHOSHA","8800553535",new DateTime(2022,12,22),2)
            };

            List<Table> expectedTables = new List<Table>()
            {
                new Table(3,6)
            };

            DateTime dateTime = new DateTime(2022, 12, 22);
            int numberOfGuest = 1;

            yield return new Object[] { NowTables, NowReservations, dateTime, numberOfGuest, expectedTables };

            NowReservations = new List<Reservation>()
            {
                new Reservation(1,1212,"VASYA","8800553535",new DateTime(2022,12,22),1),
                new Reservation(2,2222,"GHOSHA","8800553535",new DateTime(2022,12,22),2),
                new Reservation(3,2222,"GHOSHA","8800553535",new DateTime(2022,12,22),6)
            };

            expectedTables = new List<Table>();

            dateTime = new DateTime(2022, 12, 22);
            numberOfGuest = 1;

            yield return new Object[] { NowTables, NowReservations, dateTime, numberOfGuest, expectedTables };
        }
    }

    public class TestCaseReturnReservationsForSpecificDayAndSeatzTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Table> NowTables = new List<Table>()
            {
                new Table(1,2),
                new Table(2,4),
                new Table(3,6),
            };

            List<Reservation> NowReservations = new List<Reservation>()
            {
                new Reservation(1,1212,"VASYA","8800553535",new DateTime(2022,12,22),1),
                new Reservation(2,2222,"GHOSHA","8800553535",new DateTime(2022,12,23),2)
            };

            DateTime dateTime = new DateTime(2022, 12, 22);
            int numberOfGuest = 1;

            List<Reservation> expectedReservations = new List<Reservation>()
            {
                new Reservation(1,1212,"VASYA","8800553535",new DateTime(2022,12,22),1),
            };

            yield return new Object[] { NowTables, NowReservations, dateTime, numberOfGuest, expectedReservations };

            NowReservations = new List<Reservation>()
            {
                new Reservation(1,1212,"VASYA","8800553535",new DateTime(2022,11,22),1),
                new Reservation(2,2222,"GHOSHA","8800553535",new DateTime(2022,10,22),2),
                new Reservation(3,2222,"GHOSHA","8800553535",new DateTime(2022,9,22),6)
            };

            expectedReservations = new List<Reservation>();

            dateTime = new DateTime(2022, 12, 22);
            numberOfGuest = 1;

            yield return new Object[] { NowTables, NowReservations, dateTime, numberOfGuest, expectedReservations };
        }
    }

    public class TestCaseAddNewReservationTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Table> nowTables = new List<Table>()
            {
                new Table(1,2),
                new Table(2,4),
                new Table(3,6),
            };

            List<Reservation> NowReservations = new List<Reservation>()
            {
                new Reservation(1,1212,"VASYA","8800553535",new DateTime(2022,12,22),1),
                new Reservation(2,2222,"GHOSHA","8800553535",new DateTime(2022,12,23),2)
            };

            Reservation newReservation = new Reservation(2, 3333, "VASYA", "8800553535", new DateTime(2022, 12, 23), 1);

            bool expected = false;

            yield return new Object[] { nowTables, NowReservations, newReservation, expected };

            newReservation = new Reservation(5, 3333, "VASYA", "8800553535", new DateTime(2022, 12, 22), 1);

            yield return new Object[] { nowTables, NowReservations, newReservation, expected };

            newReservation = new Reservation(3, 3333, "VASYA", "8800553535", new DateTime(2022, 12, 22), 2);
            expected = true;

            yield return new Object[] { nowTables, NowReservations, newReservation, expected };
        }
    }

    public class TestCaseRemoveReservationTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Reservation> nowReservation = new List<Reservation>()
            {
                new Reservation(1,1212,"VASYA","8800553535",new DateTime(2022,12,22),1),
                new Reservation(2,2222,"GHOSHA","8800553535",new DateTime(2022,12,23),2)
            };

            int numberReservation = 2222;
            bool expected = false;

            yield return new Object[] { nowReservation, numberReservation, expected };

            numberReservation = 3333;
            expected = true;
            yield return new Object[] { nowReservation, numberReservation, expected };
        }
    }

    public class TestCaseReturnReservationsForSpecificDay : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Reservation> nowReservation = new List<Reservation>()
            {
                 new Reservation(1,1212,"VASYA","8800553535",new DateTime(2022,12,22),1),
                 new Reservation(2,2222,"GHOSHA","8800553535",new DateTime(2022,12,23),2),
                 new Reservation(3,2245,"PASHA","8800553535",new DateTime(2022,12,23),2),
                 new Reservation(4,2293,"GENA","8800553535",new DateTime(2022,12,22),2)
            };

            DateTime DateTime = new DateTime(2022, 12, 22);

            List<Reservation> expectedeReservations = new List<Reservation>()
            {
                 new Reservation(1,1212,"VASYA","8800553535",new DateTime(2022,12,22),1),
                 new Reservation(4,2293,"GENA","8800553535",new DateTime(2022,12,22),2)
            };

            yield return new Object[] { nowReservation, DateTime, expectedeReservations };

            DateTime = new DateTime(2022, 12, 24);

            expectedeReservations = new List<Reservation>();

            yield return new Object[] { nowReservation, DateTime, expectedeReservations };
        }
    }

    public class TestCaseReturnReservationsForSpecificTableTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Reservation> nowReservation = new List<Reservation>()
            {
                 new Reservation(1,1212,"VASYA","8800553535",new DateTime(2022,12,22),1),
                 new Reservation(2,2222,"GHOSHA","8800553535",new DateTime(2022,12,23),2),
                 new Reservation(2,2245,"PASHA","8800553535",new DateTime(2022,12,23),2),
                 new Reservation(4,2293,"GENA","8800553535",new DateTime(2022,12,22),2)
            };

            int numberTable = 2;

            List<Reservation> expectedeReservations = new List<Reservation>()
            {
                 new Reservation(2,2222,"GHOSHA","8800553535",new DateTime(2022,12,23),2),
                 new Reservation(2,2245,"PASHA","8800553535",new DateTime(2022,12,23),2),
            };

            yield return new Object[] { nowReservation, numberTable, expectedeReservations };

            numberTable = 5;

            expectedeReservations = new List<Reservation>();

            yield return new Object[] { nowReservation, numberTable, expectedeReservations };
        }
    }
}
