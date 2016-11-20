namespace Interfaces
{
    public enum riskType
    {
        Threat = 1,
        Oppotunity = 2
    }

    public enum riskStatus
    {
        Active = 1,
        Impacted = 2,
        Managed = 3,
        Open = 4,
        Proposed = 5,
        Rejected = 6
    }
    public interface IRisk
    {
        string RiskDescription { get; set; }
        string RiskID { get; set; }
        riskStatus RiskStatus { get; set; }
        riskType RiskType { get; set; }
    }
}