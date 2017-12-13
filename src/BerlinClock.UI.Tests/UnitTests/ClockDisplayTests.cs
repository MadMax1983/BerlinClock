using System;
using BerlinClock.Domain;
using Moq;
using NUnit.Framework;

namespace BerlinClock.UI.Tests.UnitTests
{
    [TestFixture]
    public sealed class ClockDisplayTests
    {
        private const string EXPECTED_FORMAT = @"OOOO

OOOO
OOOO

OOOOOOOOOOO
OOOO
";

        private readonly Mock<IClockRow> _mockHoursFirstRow = new Mock<IClockRow>();
        private readonly Mock<IClockRow> _mockHoursSecondRow = new Mock<IClockRow>();

        private readonly Mock<IClockRow> _mockMinutesFirstRow = new Mock<IClockRow>();
        private readonly Mock<IClockRow> _mockMinutesSecondRow = new Mock<IClockRow>();

        private readonly Mock<IClockRow> _mockSecondsRow = new Mock<IClockRow>();

        private readonly Mock<IClock> _mockClock = new Mock<IClock>();

        [SetUp]
        public void SetUp()
        {
            _mockHoursFirstRow.SetupGet(m => m.Lamps).Returns(new[] { false, false, false, false });
            _mockHoursSecondRow.SetupGet(m => m.Lamps).Returns(new[] { false, false, false, false });

            _mockMinutesFirstRow.SetupGet(m => m.Lamps).Returns(new[] { false, false, false, false, false, false, false, false, false, false, false });
            _mockMinutesSecondRow.SetupGet(m => m.Lamps).Returns(new[] { false, false, false, false });

            _mockSecondsRow.SetupGet(m => m.Lamps).Returns(new[] { false, false, false, false });

            _mockClock.SetupGet(m => m.HoursFirstRow).Returns(_mockHoursFirstRow.Object);
            _mockClock.SetupGet(m => m.HoursSecondRow).Returns(_mockHoursSecondRow.Object);
            _mockClock.SetupGet(m => m.MinutesFirstRow).Returns(_mockMinutesFirstRow.Object);
            _mockClock.SetupGet(m => m.MinutesSecondRow).Returns(_mockMinutesSecondRow.Object);
            _mockClock.SetupGet(m => m.SecondsRow).Returns(_mockSecondsRow.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockClock.Reset();
        }

        [Test]
        public void Given_When_Then_()
        {
            var display = new ClockDisplay(_mockClock.Object);

            var result = display.Display(DateTime.Now);

            Assert.AreEqual(EXPECTED_FORMAT, result);

            _mockClock.Verify(m => m.GenerateClockState(It.IsAny<DateTime>()), Times.Once());
        }
    }
}