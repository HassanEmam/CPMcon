using System;
using System.Collections.Generic;
using Interfaces;


namespace Interfaces
{
    public interface INetwork
    {
        List<IActivity> Activities { get; set; }
        int Duration { get; set; }
        DateTime EndDate { get; set; }
        List<IRelationship> Relations { get; set; }
        DateTime StartDate { get; set; }

        void addRelationship(IRelationship rel);
        void addRelationship(List<IRelationship> relationsList);
        void addRelationship(IActivity pred, IActivity succ, relType reltype, int Lag);
        void calculate();
        void output();
    }
}