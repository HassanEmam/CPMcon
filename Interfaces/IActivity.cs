using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IActivity
    {
        ICalendar Calendar { get; set; }
        string Description { get; set; }
        int Duration { get; set; }
        int Eet { get; set; }
        DateTime EF { get; set; }
        DateTime ES { get; set; }
        int Est { get; set; }
        string Id { get; set; }
        int Let { get; set; }
        DateTime LF { get; set; }
        DateTime LS { get; set; }
        int Lst { get; set; }
        List<IRelationship> Predecessors { get; set; }
        List<IResourceAssignment> Resources { get; set; }
        List<IRelationship> Successors { get; set; }
        int Tf { get; set; }

        Interfaces.IActivity CheckActivity(List<Interfaces.IActivity> list, string id, int i);
        int GetIndex(List<Interfaces.IActivity> list, Interfaces.IActivity aux, int i);
        void setPredecessors(IRelationship rel);
        void SetSuccessors(IRelationship relation);
    }
}
