namespace Interfaces
{
    public interface IResourceCurve
    {
        string CurveID { get; set; }
        string CurveName { get; set; }
        float[] TimePhasedPercent { get; set; }
    }
}