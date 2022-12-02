namespace PersonDataReader.CSV.Tests;

[TestClass]
public class CSVReaderTests
{
    [TestMethod]
    public void GetPeople_WithGoodRecords_ReturnsAllRecords()
    {
        var reader = new CSVReader();
        reader.FileLoader = new FakeFileLoader("Good");

        var result = reader.GetPeople();

        Assert.AreEqual(2, result.Count());
    }
}