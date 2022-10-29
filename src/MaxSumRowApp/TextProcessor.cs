namespace MaxSumRowApp;

public class TextProcessor
{
    private TextReader _reader;

    public TextProcessor(TextReader reader)
    {
        _reader = reader;
    }

    public SortedSet<int> DefectiveRows { get; } = new SortedSet<int>();

    public async Task<int> GetMaxSumRowNum()
    {
        string? row;
        float maxSum = float.MinValue;
        int maxSumRow = -1;
        int rowNum = 0;
        while ((row = await _reader.ReadLineAsync()) != null) {
            float sum = 0;
            var tokens = row.Split(',');
            foreach (var token in tokens) {
                if (float.TryParse(token.Trim(), out var fnum)) {
                    sum += fnum;
                }
                else {
                    DefectiveRows.Add(rowNum);
                }
            }

            if (sum > maxSum) {
                maxSum = sum;
                maxSumRow = rowNum;
            }

            rowNum++;
        }

        return maxSumRow;
    }
}
