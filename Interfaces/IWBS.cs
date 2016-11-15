namespace Interfaces
{
    public interface IWBS
    {
        IWBS Parent { get; set; }
        string WbsID { get; set; }
        string WbsName { get; set; }
    }
}