namespace TextProcessorTests
{
    [TestClass]
    public class TextProcessorTests
    {
        [TestMethod]
        public async Task Check_maxSumRowNumNum_result()
        {
            var content = @"1.2,23,45,67,98,34.4
99.5,98.2,91.4,101.3,54.2
4.2,2.3,aaa,bbb,35
67,90,92,32,21,23";
            var processor = new TextProcessor(new StringReader(content));
            var maxSumRowNum = await processor.GetMaxSumRowNumAsync();           
            Assert.AreEqual(1, maxSumRowNum);
        }


        [TestMethod]
        public async Task Check_defective_rows()
        {
            var content = @"1.2,23,45,67,98,34.4
99.5,98.2,91.4,101.3,54.2
4.2,2.3,aaa,bbb,35
67,90,92,32,21,23
ddd, adfsdf, sdfdf,erwer,1,78";
            var processor = new TextProcessor(new StringReader(content));
            var maxSumRowNum = await processor.GetMaxSumRowNumAsync();
            var defectiveRows = processor.DefectiveRows.ToArray();
            Assert.AreEqual(2, defectiveRows[0]);
            Assert.AreEqual(4, defectiveRows[1]);
        }

        [TestMethod]
        public async Task Check_maxSumRowNumNum_in_defective_row()
        {
            var content = @"aaa, 999999999, bb, cc
1,2,3,4,5,6,7,8,9
4.2,2.3,aaa,bbb,35
10000, 10000, 1000.1, 20000
ddd, adfsdf, sdfdf,erwer,1,78";
            var processor = new TextProcessor(new StringReader(content));
            var maxSumRowNum = await processor.GetMaxSumRowNumAsync();
            Assert.AreEqual(0, maxSumRowNum);
        }

        [TestMethod]
        public async Task Check_no_numbers()
        {
            var content = @"aaa, bbb,ccc
ddd, adfsdf, sdfdf,erwer";
            var processor = new TextProcessor(new StringReader(content));
            var maxSumRowNum = await processor.GetMaxSumRowNumAsync();
            Assert.AreEqual(-1, maxSumRowNum);
        }

        [TestMethod]
        public async Task Check_empty_file()
        {
            var content = "";
            var processor = new TextProcessor(new StringReader(content));
            var maxSumRowNum = await processor.GetMaxSumRowNumAsync();
            Assert.AreEqual(-1, maxSumRowNum);
        }
    }
}