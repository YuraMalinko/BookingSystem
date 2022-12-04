using BookingSystem.Test.TestCases;
using NUnit.Framework;

namespace BookingSystem.Test
{
    public class UserTest
    {
        private string _path;

        private User _user;

        [SetUp]
        public void SetUp()
        {
            _path = "../UserTest.txt";
            _user = new User();
            _user.DataFile.Path = _path;
        }

        [TestCaseSource(typeof(TestCaseForAddNewTableTest))]
        public void AddNewTableTest(List<Table> tables, Table newTable, bool expected)
        {
            _user.DataFile.Tables.AddRange(tables);
            _user.AddNewTable(newTable);
            bool actual = _user.DataFile.Tables.Contains(newTable);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(TestCaseRemoveTableTest))]
        public void RemoveTable(List<Table> NowTables,int numberRemoveTable,bool expected)
        {
            _user.DataFile.Tables.AddRange(NowTables);
            _user.RemoveTable(numberRemoveTable);

            bool actual = _user.DataFile.Tables.SequenceEqual(NowTables);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(TestCaseReturnCorrectTableTest))]
        public void ReturnCorrectTableTest
                    (List<Table> NowTables,
                    List<Reservation> NowReservations,
                    DateTime searchDate,
                    int numberOfGuest,
                    List<Table> expectedTables)
        {
            _user.DataFile.Tables = NowTables;
            _user.DataFile.Reservations = NowReservations;

            List<Table> actualTAbles = _user.ReturnCorrectTable(searchDate, numberOfGuest);

            CollectionAssert.AreEqual(expectedTables, actualTAbles);
        }

        [TestCaseSource(typeof(TestCaseReturnReservationsForSpecificDayAndSeatzTest))]
        public void ReturnReservationsForSpecificDayAndSeatzTest
                    (List<Table> NowTables,
                    List<Reservation> NowReservations,
                    DateTime searchDate,
                    int numberOfGuest,
                    List<Reservation> expectedReservation)
        {
            _user.DataFile.Tables = NowTables;
            _user.DataFile.Reservations = NowReservations;
            List<Reservation> actualRreservations = _user.ReturnReservationsForSpecificDayAndSeatz(searchDate, numberOfGuest);

            CollectionAssert.AreEqual(expectedReservation, actualRreservations);
        }

        [TestCaseSource(typeof(TestCaseAddNewReservationTest))]
        public void AddNewReservationTest(List<Table> nowTables, List<Reservation> nowReservations,Reservation newReservation,bool expected)
        {
            _user.DataFile.Tables = nowTables;
            _user.DataFile.Reservations=nowReservations;
            _user.AddNewReservation(newReservation);
            bool actual = _user.DataFile.Reservations.Contains(newReservation);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(TestCaseRemoveReservationTest))]
        public void RemoveReservationTest(List<Reservation> nowReservations, int numberReservation, bool expected)
        {
            _user.DataFile.Reservations.AddRange(nowReservations);
            _user.RemoveReservation(numberReservation);
            bool actual = _user.DataFile.Reservations.SequenceEqual(nowReservations);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(TestCaseReturnReservationsForSpecificDay))]
        public void ReturnReservationsForSpecificDayTest(List<Reservation> nowReservations, DateTime DateTime, List<Reservation> expectedeReservation)
        {
            _user.DataFile.Reservations.AddRange(nowReservations);
            List<Reservation> actualReservations = _user.ReturnReservationsForSpecificDay(DateTime);

            CollectionAssert.AreEqual(expectedeReservation, actualReservations);
        }


        [TestCaseSource(typeof(TestCaseReturnReservationsForSpecificTableTest))]
        public void ReturnReservationsForSpecificTableTest(List<Reservation> nowReservations,int numberTable, List<Reservation> expectedeReservation)
        {
            _user.DataFile.Reservations.AddRange(nowReservations);
            List<Reservation> actualReservations = _user.ReturnReservationsForSpecificTable(numberTable);

            CollectionAssert.AreEqual(expectedeReservation, actualReservations);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_path);
        }
    }
}
