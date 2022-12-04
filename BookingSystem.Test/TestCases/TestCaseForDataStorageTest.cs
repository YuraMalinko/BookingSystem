using System.Collections;

namespace BookingSystem.Test.TestCases
{
    public class TestCaseForDataStorageTest: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Table> tables = new List<Table>()
            {
                new Table(1,1),
                new Table(2,2)
            };

            List<Reservation> reservations = new List<Reservation>()
            {
                new Reservation(1,1212,"VASYA","8800553535",new DateTime(2022,12,22),1),
                new Reservation(2,2222,"GHOSHA","8800553535",new DateTime(2022,12,22),2)
            };

            yield return new Object[]{tables, reservations};

            yield return new Object[]
            {
                new List<Table>(),
                new List<Reservation>()
            };

            tables = new List<Table>
            {
                new Table(1,1),
                new Table(2,2)
            };

            reservations = new List<Reservation>();

            yield return new Object[] { tables, reservations };
        }
    }
}
