using NUnit.Framework;

namespace BookingSystem.Test
{
    public class TablesTest
    {
        [TestCase(0)]
        [TestCase(-5)]
        public void NumberTableTest_WhenNumberTableIncorrect_ShouldThrowArgumentOutOfRangeException(int numberTable)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Table(numberTable, 2));
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void NumberOfSeatz_WhenNumberOfSeatsIncorrect_ShouldThrowArgumentOutOfRangeException(int numberSeats)
        {
            Assert.Throws<ArgumentOutOfRangeException> (() => new Table(2,numberSeats));
        }
    }
}
