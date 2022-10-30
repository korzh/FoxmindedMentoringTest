
using MaxSumRowApp;

string? filePath;

if (args.Length >0) {
    filePath = args[0];
}
else {
    Console.WriteLine("Enter the path to the input file:");
    filePath = Console.ReadLine();
    if (filePath == null) {
        Console.WriteLine("No file name defined! Please try again");
        return;
    }
}

Console.Write($"Processing {filePath}...");

var processor = new TextProcessor(new StreamReader(filePath));
var rowNum = await processor.GetMaxSumRowNumAsync();
Console.WriteLine("done!");
Console.WriteLine();

Console.WriteLine($"Max SUM row: {rowNum}");

if (processor.DefectiveRows.Count > 0) {
    Console.WriteLine("Defective rows: " + string.Join(", ", processor.DefectiveRows));
}
