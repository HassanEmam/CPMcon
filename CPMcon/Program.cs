using System.Collections.Generic;
using Relationships;
using Interfaces;
using Networks;
using System;
using Utilities;
using Resources;
using ResourceAssignments;

namespace CPMcon
{
    /// <summary>
    /// Number of activities
    /// </summary>

    class Program
    {
        private static int na;

        private static void Main(string[] args)
        {
            Network project = new Network();
            Activity a = new Activity();
            a.Id = "a";
            a.Description = "Activity A";
            a.Duration = 5;
            a.Predecessors = null;
            Activity b = new Activity();
            b.Id = "b";
            b.Description = "Activity B";
            b.Duration = 10;
            Activity c = new Activity();
            c.Id = "c";
            c.Description = "Activity C";
            c.Duration = 8;
            Activity d = new Activity();
            d.Id = "d";
            d.Description = "Activity D";
            d.Duration = 6;
            Activity E = new Activity();
            E.Id = "e";
            E.Description = "Activity E";
            E.Duration = 8;
            Relationship rel3 = new Relationship(a, d, relType.FS, 0);
            Relationship rel4 = new Relationship(d, E, relType.FF, 0);
            Relationship rel = new Relationship(a,b,relType.FS, 0);
            Relationship rel2 = new Relationship(b,c,relType.SS,0);
            List<IActivity> list = new List<IActivity>();
            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Add(d);
            list.Add(E);
            project.Activities = list;
            List<IRelationship> rels = new List<IRelationship>();
            rels.Add(rel);
            rels.Add(rel2);
            rels.Add(rel3);
            rels.Add(rel4);
            project.addRelationship(rels);
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
        }

        /// <summary>
        /// Gets the activities that'll be evaluated by the critical path method.
        /// </summary>
        /// <param name="list">Array to store the activities that'll be evaluated.</param>
        /// <returns>list</returns>
    //    private static List<Activity> GetActivities(List<Activity> list)
    //    {
    //        do
    //        {
    //            Console.Write("\n       Number of activities: ");
    //            if ((na = int.Parse(Console.ReadLine())) < 2)
    //            {
    //                Console.Beep();
    //                Console.Write("\n Invalid entry. The number must be >= 2.\n");
    //            }
    //        }
    //        while (na < 2);

    //        list = new List<Activity>();

    //        for (int i = 0; i < na; i++)
    //        {
    //            Activity activity = new Activity();

    //            Console.Write("\n                Activity {0}\n", i + 1);

    //            Console.Write("\n                     ID: ", i + 1);
    //            activity.Id = Console.ReadLine();

    //            Console.Write("            Description: ", i + 1);
    //            activity.Description = Console.ReadLine();

    //            Console.Write("               Duration: ", i + 1);
    //            activity.Duration = int.Parse(Console.ReadLine());

    //            Console.Write(" Number of predecessors: ", i + 1);
    //            int np = int.Parse(Console.ReadLine());

    //            if (np != 0)
    //            {
    //                activity.Predecessors = new List<Relationship>();

    //                string id;

    //                for (int j = 0; j < np; j++)
    //                {
    //                    Console.Write("    #{0} predecessor's ID: ", j + 1);
    //                    id = Console.ReadLine();

    //                    Activity aux = new Activity();

    //                    if ((aux = aux.CheckActivity(list, id, i)) != null)
    //                    {
    //                        activity.Predecessors.Add(aux);

    //                        list[aux.GetIndex(list, aux, i)] = aux.SetSuccessors(aux, activity);
    //                    }
    //                    else
    //                    {
    //                        Console.Beep();
    //                        Console.Write("\n No match found! Try again.\n\n");
    //                        j--;
    //                    }
    //                }
    //            }
    //            list.Add(activity);
    //        }

    //        return list;
    //    }

 



    //    /// <summary>
    //    /// Calculates the critical path by verifyng if each activity's earliest end time
    //    /// minus the latest end time and earliest start time minus the latest start
    //    /// time are equal zero. If so, then prints out the activity id that match the
    //    /// criteria. Plus, prints out the project's total duration. 
    //    /// </summary>
    //    /// <param name="list">Array containg the activities already entered.</param>
    //    private static void CriticalPath(List<Activity> list)
    //    {
    //        Console.Write("\n          Critical Path: ");

    //        foreach (Activity activity in list)
    //        {
    //            if ((activity.Eet - activity.Let == 0) && (activity.Est - activity.Lst == 0))
    //                Console.Write("{0} ", activity.Id);
    //        }

    //        Console.Write("\n\n         Total duration: {0}\n\n", list[list.Count - 1].Eet);
    //    }
    }
}
