namespace Interfaces
{
    public enum resourceType
    {
        Labour = 1,
        Material = 2,
        Equipment = 3,
        Money = 4
    };
    public interface IResource
    {
        float DefUnitTime { get; set; }
        string ResID { get; set; }
        string ResName { get; set; }
        resourceType ResType { get; set; }
        float UnitCost { get; set; }
    }
}