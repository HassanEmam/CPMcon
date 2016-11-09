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
        string Id { get; set; }
        string Description { get; set; }
        int Duration { get; set; }
        int Est { get; set; }
        int Lst { get; set; }
        int Eet { get; set; }
        int Let { get; set; }
        int Tf { get; set; }
        List<IRelationship> Predecessors { get; set; }
        List<IRelationship> Successors { get; set; }
        IActivity CheckActivity(List<IActivity> list, string id, int i);
        //var successor {get; set;}
        int GetIndex(List<IActivity> list, IActivity aux, int i);
        void setPredecessors(IRelationship relation);
        void SetSuccessors(IRelationship relation);


    }
}
