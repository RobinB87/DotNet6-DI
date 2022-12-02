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

    [TestMethod]
    public void GetPeople_WithNoFile_ThrowsFileNotFoundException()
    {
        var reader = new CSVReader();
        // If FileLoader not overridden by property injection,
        // The StreamReader in the LoadFile method
        // will look for actual file on system
        Assert.ThrowsException<FileNotFoundException>(
            () => reader.GetPeople());
    }

    [TestMethod]
    public void GetPeople_WithSomeBadRecords_ReturnsGoodRecords()
    {
        var reader = new CSVReader();
        reader.FileLoader = new FakeFileLoader("Mixed");

        var result = reader.GetPeople();

        Assert.AreEqual(2, result.Count());
    }
}