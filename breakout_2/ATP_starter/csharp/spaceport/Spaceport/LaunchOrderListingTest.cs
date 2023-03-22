using NUnit.Framework;
using System.Collections.Generic;

namespace SpacePort
{
    [TestFixture]
    public class LaunchOrderListingTest
    {

        //TODO - Use the Stub Recipe to test that launches are sorted correctly
        [Test]
        public void LaunchList_IsEmpty_WhenNoLaunchesProvided()
        {
            ISpacelineLaunchInfoProvider mock = new ProviderWithNoLaunches();

            var sut = new SpaceportDepartureBoard(mock);

            Assert.IsEmpty(sut.LaunchList);
        }

        [Test]
        public void LaunchList_HasSingleLaunch_WhenSingleLaunchProvided()
        {
            // Assert - Verify the results are sorted correctly
            ISpacelineLaunchInfoProvider mock = new ProviderWithSingleLaunch();

            var sut = new SpaceportDepartureBoard(mock);

            Assert.AreEqual(1, sut.LaunchList.Count);
        }

        [Test]
        public void LaunchesAreSortedByDestination_DestinationsAreUnique()
        {
            ISpacelineLaunchInfoProvider mock = new ProviderWithMultipleUniqueLaunches();
            
            var sut = new SpaceportDepartureBoard(mock);

            Assert.Multiple(() => {
                Assert.AreEqual("A", sut.LaunchList[0].Destination);
                Assert.AreEqual("B", sut.LaunchList[1].Destination);
            });
        }
    }

    internal class ProviderWithMultipleUniqueLaunches : ISpacelineLaunchInfoProvider
    {
        public List<LaunchInfo> GetCurrentLaunches()
        {
            return new List<LaunchInfo>
            {
                new  LaunchInfo(System.Guid.NewGuid()){
                     Destination="B"
                },
                new LaunchInfo(System.Guid.NewGuid())
                {
                    Destination ="A"
                }
            };
        }
    }

    internal class ProviderWithSingleLaunch : ISpacelineLaunchInfoProvider
    {
        public List<LaunchInfo> GetCurrentLaunches()
        {
            return new List<LaunchInfo>
            {
                new LaunchInfo(System.Guid.NewGuid())
                {

                }
            };
        }
    }

    internal class ProviderWithNoLaunches : ISpacelineLaunchInfoProvider
    {
        public List<LaunchInfo> GetCurrentLaunches()
        {
            return new List<LaunchInfo>();
        }
    }
}