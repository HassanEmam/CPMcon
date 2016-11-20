using System.Collections.Generic;
using Relationships;
using Interfaces;
using Networks;
using System;
using Utilities;
using Resources;
using ResourceAssignments;
using WBSs;

namespace CPMcon
{
    /// <summary>
    /// Number of activities
    /// </summary>

    class Program
    {
        private static void Main(string[] args)
        {
            Project project = new Project("HS2", "Central Enabling Works");
            Activity a = new Activity();
            a.Id = "a";
            a.Description = "Activity A";
            a.Duration = 5;
            a.Predecessors = null;
            project.addActivity(a);
            Activity b = new Activity();
            b.Id = "b";
            b.Description = "Activity B";
            b.Duration = 10;
            project.addActivity(b);
            Activity c = new Activity();
            c.Id = "c";
            c.Description = "Activity C";
            c.Duration = 8;
            project.addActivity(c);
            Activity d = new Activity();
            d.Id = "d";
            d.Description = "Activity D";
            d.Duration = 6;
            project.addActivity(d);
            Activity E = new Activity();
            E.Id = "e";
            E.Description = "Activity E";
            E.Duration = 8;
            project.addActivity(E);
            Relationship rel3 = new Relationship(a, d, relType.FS, 0);
            Relationship rel4 = new Relationship(d, E, relType.FF, 0);
            Relationship rel = new Relationship(a,b,relType.FS, 0);
            Relationship rel2 = new Relationship(b,c,relType.SS,0);

            List<IRelationship> rels = new List<IRelationship>();
            rels.Add(rel);
            rels.Add(rel2);
            rels.Add(rel3);
            rels.Add(rel4);
            project.Relations = rels;

            project.calculate();
            DateTime startDate = new DateTime(2016, 11, 7);
            List<DateTime> daysOff = new List<DateTime>();
            daysOff.Add(new DateTime(2016,11,10));
            Console.WriteLine(HelperFunctions.AddWorkdays(startDate, 10, daysOff));
            Resource steelFixer = new Resource("SF", "Steelfixer", resourceType.Labour, 0, 80);
            ResourceAssignment assign = new ResourceAssignments.ResourceAssignment(a, steelFixer, 100, 80);
            List<IResourceAssignment> x =  new List<IResourceAssignment>();
            x.Add(assign);
            a.Resources = x;
            Console.WriteLine(a.Resources[0].Resource.ResName);
            WBS wbsProject = new WBS("10", "Hassan Emam Project", null);
            WBS wbsNode1 = new WBS("20", "Node 1", wbsProject);
            WBS wbsNode2 = new WBS("30", "Node 2", wbsNode1);
            List<WBS> wbsElements = new List<WBS>();
            wbsElements.Add(wbsProject);
            wbsElements.Add(wbsNode1);
            wbsElements.Add(wbsNode2);
            foreach (WBS node in wbsElements)
            {
                if (node != null && node.Parent != null)
                {
                    Console.WriteLine(node.WbsName + "\t" + node.Parent.WbsName);
                }
                if (node != null && node.Parent == null)
                {
                    Console.WriteLine(node.WbsName + "\t Root");
                }
            }
        }

    }
}
