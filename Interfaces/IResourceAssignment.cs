using Interfaces;

namespace Interfaces
{
    public interface IResourceAssignment
    {
        IActivity Activity { get; set; }
        float BudgetedUnits { get; set; }
        IResource Resource { get; set; }
        float UnitRate { get; set; }
    }
}