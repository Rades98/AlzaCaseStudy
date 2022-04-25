namespace UnitTests.Mocks.MockMediator
{
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.Extensions.Logging;
    using Moq;
    using System.Collections.Generic;

    public static class MockProvider<T> where T : class
    {
        public static readonly IActionDescriptorCollectionProvider ADCP = GetADCP();

        public static readonly ILogger<T> Logger = GetLogger();

        private static IActionDescriptorCollectionProvider GetADCP()
        {
            var actionDescriptorCollectionProviderMock = new Mock<IActionDescriptorCollectionProvider>();

            actionDescriptorCollectionProviderMock.Setup(m => m.ActionDescriptors).Returns(new ActionDescriptorCollection(new List<ActionDescriptor>(), 0));

            return actionDescriptorCollectionProviderMock.Object;
        }

        private static ILogger<T> GetLogger()
        {
            var loggerMock = new Mock<ILogger<T>>();

            return loggerMock.Object;
        }
    }
}
