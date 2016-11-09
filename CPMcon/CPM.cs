using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMcon
{
    class CPM
    {
        /// <summary>
        /// Performs the walk ahead inside the array of activities calculating for each
        /// activity its earliest start time and earliest end time.
        /// </summary>
        /// <param name="list">Array storing the activities already entered.</param>
        /// <returns>list</returns>
        public static List<Activity> forwardPath(List<Activity> list)
        {
            list[0].Eet = list[0].Est + list[0].Duration;
            int na = list.Count;
            for (int i = 1; i < na; i++)
            {
                foreach (Relationships relation in list[i].Predecessors)
                {
                    switch(relation.RelationshipType)
                    {
                        case Relationships.relType.FS:
                            if (list[i].Est < relation.Pred.Eet +1+ relation.Lag)
                                list[i].Est = relation.Pred.Eet +1 + relation.Lag;
                            list[i].Eet = list[i].Est + list[i].Duration -1;
                            break;
                        case Relationships.relType.FF:
                            if (list[i].Eet < relation.Pred.Eet + relation.Lag)
                                list[i].Eet = relation.Pred.Eet + relation.Lag;
                            list[i].Est = list[i].Eet - list[i].Duration + 1;
                            break;
                        case Relationships.relType.SS:
                            if (list[i].Est < relation.Pred.Est + relation.Lag)
                                list[i].Est = relation.Pred.Est + relation.Lag;
                            list[i].Eet = list[i].Est + list[i].Duration - 1;
                            break;
                        case Relationships.relType.SF:
                            if (list[i].Eet < relation.Pred.Est + relation.Lag)
                                list[i].Est = relation.Pred.Eet + relation.Lag;
                            list[i].Eet = list[i].Est + list[i].Duration - 1;
                            break;
                    }
                    
                }

                
            }

            return list;
        }

        /// <summary>
        /// Performs the walk aback inside the array of activities calculating for each
        /// activity its latest start time and latest end time.
        /// </summary>
        /// <param name="list">Array storing the activities already entered.</param>
        /// <returns>list</returns>
        public static List<Activity> backwardPath(List<Activity> list)
        {
            int na = list.Count;
            list[na - 1].Let = list[na - 1].Eet;
            list[na - 1].Lst = list[na - 1].Let - list[na - 1].Duration;

            for (int i = na - 2; i >= 0; i--)
            {
                if(list[i].Successors != null)
                {
                    foreach (Relationships relation in list[i].Successors)
                    {
                        switch(relation.RelationshipType)
                        {
                            case (Relationships.relType.FS):
                                if (list[i].Let == 0)
                                    list[i].Let = relation.Succ.Lst - relation.Lag;
                                else if (list[i].Let > relation.Succ.Lst - relation.Lag)
                                    list[i].Let = relation.Succ.Lst - relation.Lag;
                                list[i].Lst = list[i].Let - list[i].Duration +1 ;
                                break;
                            case Relationships.relType.FF:
                                if (list[i].Let == 0)
                                    list[1].Let = relation.Succ.Let - relation.Lag;
                                else if (list[i].Let > relation.Succ.Let - relation.Lag)
                                    list[1].Let = relation.Succ.Let - relation.Lag;
                                break;

                            case Relationships.relType.SS:

                                break;

                            case Relationships.relType.SF:

                                break;
                        }
                        
                    }
                    
                }
                else
                {
                    int projDur = longestDuration(list);
                    list[i].Let = projDur;
                }
            }

            return list;
        }

        private static int longestDuration(List<Activity> list)
        {
            int maxDur =0;
            foreach(Activity a in list)
            {
                if (a.Eet > maxDur)
                    maxDur = a.Eet;
            }
            return maxDur;
        }
    }
}
