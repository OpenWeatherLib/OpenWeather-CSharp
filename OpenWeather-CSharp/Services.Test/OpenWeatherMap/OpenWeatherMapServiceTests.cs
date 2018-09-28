using AutoMapper;
using Crosscutting.Attributes;
using FluentAssertions;
using NSubstitute;
using Services.OpenWeatherMap;
using Services.Validation;
using Xunit;

namespace Services.Test.OpenWeatherMap
{
    public class OpenWeatherMapServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;

        private IOpenWeatherMapService _sut;

        public OpenWeatherMapServiceTests()
        {
            _mapper = Substitute.For<IMapper>();
            _validationService = Substitute.For<IValidationService>();

            _sut = new OpenWeatherMapService(_mapper, _validationService);
        }
    }
}
