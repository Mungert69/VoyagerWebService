using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWorksVoyWebServiceTest.Controllers.Mocks
{
    public  class MockSessionObjects : Mock<ISessionObject>
    {
        public MockSessionObjects  SetUpObject()
        {

            SetupAllProperties();
            Setup(s => s.PageStates).Returns(new PageStates());
            Setup(s => s.Flight).Returns(new FlightObj());
            Setup(s => s.ArrivalAirportID).Returns(36);
            Setup(s => s.DepartAirportID).Returns(36);


            return this;
        }
    }
}
