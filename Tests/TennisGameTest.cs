using Katas;
namespace Tests
{
	public class TennisGameTest
	{
        Player victor;
        Player sarah;
        TennisGame game;

        [SetUp]
        public void BeforeGameTest()
        {
            victor = new Player("Victor");
            sarah = new Player("Sarah");
            game = new TennisGame(victor, sarah);
        }

        [Test]
        public void LoveShouldBeDescriptionForScore0()
        {
            Assert.That(game, Has.Property("Score").EqualTo("love, love"));
        }

        [Test]
        public void FifteenShouldBeDescriptionForScore1()
        {
            sarah.WinBall();
            Assert.That(game, Has.Property("Score").EqualTo("love, fifteen"));
        }

        [Test]
        public void ThirtyShouldBeDescriptionForScore2()
        {
            victor.WinBall();
            victor.WinBall();
            sarah.WinBall();
            Assert.That(game, Has.Property("Score").EqualTo("thirty, fifteen"));
        }

        [Test]
        public void FortyShouldBeDescriptionForScore3()
        {
            Enumerable.Range(1, 3).ToList().ForEach(_ => victor.WinBall());
            Assert.That(game, Has.Property("Score").EqualTo("forty, love"));
        }

        [Test]
        public void AdvantageShouldBeDescriptionWhenLeastThreePointsHaveBeenScoredByEachSideAndPlayerHasOnePointMoreThanHisOpponent()
        {
            Enumerable.Range(1, 3).ToList().ForEach(_ => victor.WinBall());
            Enumerable.Range(1, 4).ToList().ForEach(_ => sarah.WinBall());
            Assert.That(game, Has.Property("Score").EqualTo("advantage Sarah"));
        }

        [Test]
        public void DeuceShouldBeDescriptionWhenAtLeastThreePointsHaveBeenScoredByEachPlayerAndTheScoresAreEqual()
        {
            Enumerable.Range(1, 3).ToList().ForEach(_ => victor.WinBall());
            Enumerable.Range(1, 3).ToList().ForEach(_ => sarah.WinBall());
            Assert.That(game, Has.Property("Score").EqualTo("deuce"));
            victor.WinBall();
            Assert.That(game, Has.Property("Score").Not.EqualTo("deuce"));
            sarah.WinBall();
            Assert.That(game, Has.Property("Score").EqualTo("deuce"));
        }

        [Test]
        public void GameShouldBeWonByTheFirstPlayerToHaveWonAtLeastFourPointsInTotalAndWithAtLeastTwoPointsMoreThanTheOpponent()
        {
            Enumerable.Range(1, 4).ToList().ForEach(_ => victor.WinBall());
            Enumerable.Range(1, 3).ToList().ForEach(_ => sarah.WinBall());
            Assert.That(game, Has.Property("Score").Not.EqualTo("Victor won"));
            Assert.That(game, Has.Property("Score").Not.EqualTo("Sarah won"));
            victor.WinBall();
            Assert.That(game, Has.Property("Score").EqualTo("Victor won"));
        }
    }
}

