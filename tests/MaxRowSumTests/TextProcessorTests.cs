namespace TextProcessorTests
{
    [TestClass]
    public class TextProcessorTests
    {
        [TestMethod]
        public async Task Calc_MaxSum_check_result()
        {
            var content = @"1.2,23,45,67,98,34.4
99.5,98.2,91.4,101.3,54.2
4.2,2.3,aaa,bbb,35
67,90,92,32,21,23
";
            var processor = new TextProcessor(new StringReader(content));
            var maxSumRow = await processor.GetMaxSumRowNumAsync();
            Assert.AreEqual(1, maxSumRow);
        }

    }
}