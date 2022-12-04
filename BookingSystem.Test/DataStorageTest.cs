using BookingSystem;
using BookingSystem.Test.TestCases;
using NUnit.Framework;
using System.Text.Json;

namespace BookingSystemTest
{
    public class DataStorageTest
    {
        private string _path;

        private DataStorage _dataStorage;

        [SetUp]

        public void SetUp()
        {
            _path = "../DataStorageTest.txt";
            _dataStorage = new DataStorage();
            _dataStorage.Path= _path;
        }

        [TestCaseSource(typeof(TestCaseForDataStorageTest))]
        public void RewriteFileTest(List<Table>tables,List<Reservation>reservations)
        {
            _dataStorage.Tables.AddRange(tables);
            _dataStorage.Reservations.AddRange(reservations);
            _dataStorage.RewriteFile();

            using(StreamReader sr = new StreamReader(_path))
            {
                string jsn = sr.ReadLine();
                tables = JsonSerializer.Deserialize<List<Table>>(jsn);
                jsn = sr.ReadLine();
                reservations = JsonSerializer.Deserialize<List<Reservation>>(jsn);
            }

            List<Table> expectedTables = tables;
            List<Table> actualTables = _dataStorage.Tables;
            List<Reservation> expectedRservation = reservations;
            List<Reservation> actualReservation = _dataStorage.Reservations;

            CollectionAssert.AreEqual(expectedTables, actualTables);
            CollectionAssert.AreEqual(actualReservation, actualReservation);
        }

        [TestCaseSource(typeof(TestCaseForDataStorageTest))]
        public void ReturnFromFileTest(List<Table> tables, List<Reservation> reservations)
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                string jsn = JsonSerializer.Serialize(tables);
                sw.WriteLine(jsn);
                jsn = JsonSerializer.Serialize(reservations);
                sw.WriteLine(jsn);
            }

            _dataStorage.ReturnFromFile();
            List<Table> expectedTables = tables;
            List<Table> actualTables = _dataStorage.Tables;
            List<Reservation> expectedRservation = reservations;
            List<Reservation> actualReservation = _dataStorage.Reservations;

            CollectionAssert.AreEqual(expectedTables, actualTables);
            CollectionAssert.AreEqual(actualReservation, actualReservation);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_path);
        }
    }
}