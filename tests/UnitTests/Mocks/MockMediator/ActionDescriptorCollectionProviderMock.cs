namespace UnitTests.Mocks.MockMediator
{
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Moq;
    using System.Collections.Generic;

    public abstract class ActionDescriptorCollectionProviderMock
    {
        public static readonly IActionDescriptorCollectionProvider ADCP = GetADCP();

        private static IActionDescriptorCollectionProvider GetADCP()
        {
            var actionDescriptorCollectionProviderMock = new Mock<IActionDescriptorCollectionProvider>();

            actionDescriptorCollectionProviderMock.Setup(m => m.ActionDescriptors).Returns(new ActionDescriptorCollection(new List<ActionDescriptor>(), 0));

            return actionDescriptorCollectionProviderMock.Object;
        }
    }
}
