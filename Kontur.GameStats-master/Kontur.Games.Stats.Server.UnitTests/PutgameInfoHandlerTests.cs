using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kontur.GameStats.Server.Handlers;
using Moq;
using Kontur.GameStats.Server.Reposit;
using Kontur.GameStats.Server.Helpers;
using Kontur.GameStats.Server.RequestParameters;
using Kontur.GameStats.Server.Models;
using System.Net;
using Ploeh.AutoFixture;
using Kontur.GameStats.Server.Entity;

namespace Kontur.Games.Stats.Server.UnitTests
{
    [TestClass]
    public class PutgameInfoHandlerTests
    {
        private PutGameInfoHandler _target;
        private Mock<IGameServerRepository> _repository;
        private Mock<IJsonConverter> _converter;
        private Fixture _fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new Mock<IGameServerRepository>(MockBehavior.Strict);
            _converter = new Mock<IJsonConverter>(MockBehavior.Strict);
            _fixture = new Fixture();
            _target = new PutGameInfoHandler(_repository.Object, _converter.Object);
        }

        [TestMethod]
        public void RequestHandleNullParametersTest()
        {
            GameParameters parameters = null;

            var expected = new ServerResponse()
            {
                StatusCode = HttpStatusCode.BadRequest,
                ResultText = string.Empty
            };

            var result = _target.RequestHandle(parameters);

            Assert.AreEqual(expected.StatusCode, result.StatusCode, "Invalid status code");
            Assert.AreEqual(expected.ResultText, result.ResultText, "Invalid result text");
        }
        [TestMethod]
        public void RequestHandleTest()
        {
            var parameters = _fixture.Create<PutGameInfoParameters>();
            var infoGameEntity = _fixture.Create<InfoGameEntity>();

            _converter.Setup(c => c.Deserialize<InfoGameEntity>(parameters.Json)).Returns(infoGameEntity);

            _repository.Setup(r => r.DeleteExistGameServer(parameters.EndPoint));

            _repository.Setup(r => r.AddGameServer(It.Is<GameServerEntity>(
                i => i.InfoId == infoGameEntity.Id &&
                i.EndPoint == parameters.EndPoint &&
                i.Info == infoGameEntity)));

            _repository.Setup(c => c.AddGameInfo(infoGameEntity));

            var result = _target.RequestHandle(parameters);

            _converter.Verify(c => c.Deserialize<InfoGameEntity>(parameters.Json), Times.Once());

            _repository.Verify(r => r.DeleteExistGameServer(parameters.EndPoint), Times.Once());

            _repository.Verify(r => r.AddGameServer(It.Is<GameServerEntity>(
                i => i.InfoId == infoGameEntity.Id &&
                i.EndPoint == parameters.EndPoint &&
                i.Info == infoGameEntity)), Times.Once());

            _repository.Verify(c => c.AddGameInfo(infoGameEntity), Times.Once());

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, "Invalid status code");
            Assert.AreEqual(string.Empty, result.ResultText, "Invalid result text");

        }
    }
}
