using GuepardoApps.OpenWeatherLib.Crosscutting.Attributes;
using FluentAssertions;
using GuepardoApps.OpenWeatherLib.Services.Validation;
using Xunit;

namespace GuepardoApps.OpenWeatherLib.Services.Test.Validation
{
    public class ValidationServiceTests
    {
        private readonly IValidationService _sut;

        public ValidationServiceTests()
        {
            _sut = new ValidationService();
        }

        [Theory]
        [InlineData("IsRequired", 420, true)]
        [InlineData("", 420, false)]
        [InlineData("IsRequired", 0, false)]
        public void Validate_ShouldReturnExpected(string testRequired, int testIsNotDefault, bool expected)
        {
            // Arrange
            var testClass = new ValidationServiceTestClass
            {
                TestRequired = testRequired,
                TestIsNotDefault = testIsNotDefault
            };

            // Act
            var actual = _sut.Validate(testClass);

            // Assert
            actual.Should().Be(expected);
        }

        private class ValidationServiceTestClass
        {
            [Required(typeof(string))]
            public string TestRequired { get; set; }

            [IsNotDefault(typeof(int), 0)]
            public int TestIsNotDefault { get; set; }
        }
    }
}
