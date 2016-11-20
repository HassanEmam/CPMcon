using System;
using System.Collections.Generic;
using Interfaces;

namespace Interfaces
{
    public enum actStatus
    {
        notStarted,
        InProgress,
        Finished
    }
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
        int RemDur { get; set; }
        List<IResourceAssignment> Resources { get; set; }
        actStatus Status { get; set; }
        List<IRelationship> Successors { get; set; }
        int Tf { get; set; }
        IWBS Wbs { get; set; }

        Interfaces.IActivity CheckActivity(List<Interfaces.IActivity> list, string id, int i);
        int GetIndex(List<Interfaces.IActivity> list, Interfaces.IActivity aux, int i);
        void setPredecessors(IRelationship rel);
        void SetSuccessors(IRelationship relation);
    }
}