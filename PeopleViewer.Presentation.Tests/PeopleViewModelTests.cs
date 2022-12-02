namespace PeopleViewer.Presentation.Tests;

[TestClass]
public class PeopleViewModelTests
{
    [TestMethod]
    public void People_OnRefreshPeople_IsPopulated()
    {
        var reader = new FakeReader();
        var vm = new PeopleViewModel(reader);

        vm.RefreshPeople();

        Assert.IsNotNull(vm.People);
        Assert.AreEqual(2, vm.People.Count());
    }

    [TestMethod]
    public void People_OnClearPeople_IsEmpty()
    {
        var reader = new FakeReader();
        var vm = new PeopleViewModel(reader);
        vm.RefreshPeople();
        Assert.AreNotEqual(0, vm.People.Count(), 
            "Invalid arrange");

        vm.ClearPeople();

        Assert.AreEqual(0, vm.People.Count());
    }
}