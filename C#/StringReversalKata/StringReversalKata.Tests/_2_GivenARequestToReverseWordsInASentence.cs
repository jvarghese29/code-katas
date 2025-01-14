namespace StringReversalKata.Tests
{
    [TestFixture]
    [Parallelizable]
    public sealed class _2_GivenARequestToReverseWordsInASentence
    {
        [Test]
        public void ThenTheResultHasEachWordReversedButInTheSamePositions()
        {
            var result = StringReverser.ReverseWordsInString("The quick brown fox jumps over the lazy dog");
            Assert.That(result, Is.EqualTo("ehT kciuq nworb xof spmuj revo eht yzal god"));
        }
    }
}