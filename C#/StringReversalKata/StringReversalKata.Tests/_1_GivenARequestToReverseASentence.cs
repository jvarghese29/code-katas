namespace StringReversalKata.Tests
{
    [TestFixture]
    [Parallelizable]
    public sealed class _1_GivenARequestToReverseASentence
    {
        [Test]
        public void ThenTheResultIsTheReversedString()
        {
            var result = StringReverser.ReverseString("The quick brown fox jumps over the lazy dog");
            Assert.That(result, Is.EqualTo("god yzal eht revo spmuj xof nworb kciuq ehT"));
        }
    }
}