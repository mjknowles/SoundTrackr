using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Web.Tests.Repositories
{
    [TestClass]
    public class TrackRepoTests
    {
        /*private Mock<ITrackService> _mockTrackService;
        private HomeController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockTrackService = new Mock<ITrackService>();
            _controller = new HomeController(_mockTrackService.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockTrackService.VerifyAll();
        }

        [TestMethod]
        public void Index_ExpectViewResultReturned()
        {
            var stubTrack = new TrackDTO()
            {
                Id = 1,
                TrackStart = DateTime.Now,
                TrackEnd = DateTime.Now.AddHours(1),
                StartCity = "Nashville",
                StartState = "TN",
                TrackStats = new List<TrackStatDTO>()
            };

            _mockTrackService.Setup(x => x.GetTrack(new GetTrackRequest(1))).Returns(new GetTrackResponse() {Track = stubTrack});
            var expectedModel = new TrackDTO()
            {
                Id = 1,
                TrackStart = DateTime.Now,
                TrackEnd = DateTime.Now.AddHours(1),
                StartCity = "Nashville",
                StartState = "TN",
                TrackStats = new List<TrackStatDTO>()
            };

            var result = _controller.Index() as ViewResult;

            var actualModel = result.Model as List<ContactViewModel>;
            for (int i = 0; i < expectedModel.Count; i++)
            {
                Assert.AreEqual(expectedModel[i].Id, actualModel[i].Id);
                Assert.AreEqual(expectedModel[i].Email, actualModel[i].Email);
                Assert.AreEqual(expectedModel[i].FirstName, actualModel[i].FirstName);
                Assert.AreEqual(expectedModel[i].LastName, actualModel[i].LastName);
            }
        }*/
    }
}
