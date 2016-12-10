using System.Linq;
using ConsoleApplication;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void LengthOfResultsTest()
        {
            var sut = new HistogramService();
            var text = "The quick brown fox and the quick blue hare.";
            var results = sut.BuildModel(text);

            var count = results.Count;
            Assert.Equal(7, count);
          
        }

        [Fact]
        public void ValueOfResultsTest()
        {
            var sut = new HistogramService();
            var text = "The quick brown fox and the quick blue hare.";
            var results = sut.BuildModel(text).First();

            Assert.Equal(2, results.Occurences);

        }
    }
}
