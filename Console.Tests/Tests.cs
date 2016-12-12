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
            var testFile = "./Sample.txt";

            var results = sut.ProcessFile(testFile);

            Assert.Equal(7, results.Count);
          
        }

        [Fact]
        public void ValueOfResultsTest()
        {
            var sut = new HistogramService();
            var testFile = "./Sample.txt";
            
            var results = sut.ProcessFile(testFile).First();

            Assert.Equal(2, results.Value);

        }
    }
}
