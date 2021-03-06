﻿using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Relationships;
using CPMcon;
using System;
using Utilities;


namespace CPMEngine
{
    public class CPM
    {
        private int longDur;
        public static void compute(List<IActivity> list)
        {
            DateTime startDate = new DateTime(2016, 11, 10);
            List<IActivity> startNodes = new List<IActivity>();
            startNodes = getStartNodes(list, startDate);
            forwardCalculation(startNodes, new DateTime(2016,11,10));
            List<IActivity> endNodes = new List<IActivity>();
            endNodes = getEndNodes(list, startDate);
            backwardCalculation(endNodes, startDate);
        }
        /// <summary>
        /// Checks for activities with no predecessors and assigns early start and finish
        /// the function returns a list of all start nodes
        /// </summary>
        /// <param name="list">List of all activities already entered.</param>
        /// <returns>List</IActivity></returns>
        /// 
        public static List<IActivity> getStartNodes(List<IActivity> list, DateTime startDate)
        {
            List<IActivity> startNodes = new List<IActivity>();
            foreach (IActivity activity in list)
            {
                if (activity.Predecessors == null)
                {
                    activity.Est = 0;
                    activity.ES = startDate;
                    activity.EF = Utilities.HelperFunctions.AddWorkdays(startDate, activity.Duration);
                    activity.Eet = activity.Est + activity.Duration - 1;
                    startNodes.Add(activity);
                }
            }
            return startNodes;
        }

        /// <summary>
        /// Checks for activities with no successors and assigns late start and finish
        /// the function returns a list of all end nodes
        /// </summary>
        /// <param name="list">List of all activities already entered.</param>
        /// <returns>List</IActivity></returns>
        /// 
        public static List<IActivity> getEndNodes(List<IActivity> list, DateTime startDate)
        {
            List<IActivity> endNodes = new List<IActivity>();
            int dur = longestDuration(list);
            foreach (IActivity activity in list)
            {
                activity.Let = dur;
                activity.Lst = activity.Let - activity.Duration + 1;
                if (activity.Successors == null)
                {
                    activity.Let = dur;
                    activity.Lst = activity.Let - activity.Duration + 1;
                    activity.Tf = activity.Let - activity.Eet;
                    activity.LS = HelperFunctions.AddWorkdays(startDate, activity.Lst + 1);
                    activity.LF = HelperFunctions.AddWorkdays(activity.LS, activity.Duration);
                    endNodes.Add(activity);
                }
            }
            return endNodes;
        }

        /// <summary>
        /// Performs the forward path calculations to define for each
        /// activity its earliest start time and earliest end time.
        /// </summary>
        /// <param name="list">Array storing the activities already entered.</param>
        /// <returns>void</returns>
        /// 
        private static void forwardCalculation(List<IActivity> list, DateTime startDate)
        {
            List<IActivity> currentSuccessors = new List<IActivity>(); ;
            foreach (IActivity act in list)
            {

                if (act.Successors != null)
                {
                    //currentSuccessors = new List<IActivity>();
                    for (int i = 0; i < act.Successors.Count; i++)
                    {
                        IActivity succ = (IActivity) act.Successors[i].Succ;
                        currentSuccessors.Add(succ);
                        switch (act.Successors[i].RelationshipType)
                        {

                            case relType.FS:
                                if (succ.Est < act.Eet + 1 + act.Successors[i].Lag)
                                    succ.Est = act.Eet + 1 + act.Successors[i].Lag;
                                succ.Eet = succ.Est + succ.Duration - 1;
                                succ.ES = HelperFunctions.AddWorkdays(startDate, succ.Est+1);
                                succ.EF = HelperFunctions.AddWorkdays(succ.ES, succ.Duration);
                                break;
                            case relType.FF:
                                if (succ.Eet < act.Eet + act.Successors[i].Lag)
                                    succ.Eet = act.Eet + act.Successors[i].Lag;
                                succ.Est = succ.Eet - succ.Duration + 1;
                                succ.ES = HelperFunctions.AddWorkdays(startDate, succ.Est+1);
                                succ.EF = HelperFunctions.AddWorkdays(succ.ES, succ.Duration);
                                break;
                            case relType.SS:
                                if (succ.Est < act.Est + act.Successors[i].Lag)
                                    succ.Est = act.Est + act.Successors[i].Lag;
                                succ.Eet = succ.Est + succ.Duration - 1;
                                succ.ES = HelperFunctions.AddWorkdays(startDate, succ.Est+1);
                                succ.EF = HelperFunctions.AddWorkdays(succ.ES, succ.Duration);
                                break;
                            case relType.SF:
                                if (succ.Eet < act.Est + act.Successors[i].Lag)
                                    succ.Est = act.Eet + act.Successors[i].Lag;
                                succ.Eet = succ.Est + succ.Duration - 1;
                                succ.ES = HelperFunctions.AddWorkdays(startDate, succ.Est+1);
                                succ.EF = HelperFunctions.AddWorkdays(succ.ES, succ.Duration);
                                break;
                        }

                    }
                    forwardCalculation(currentSuccessors,startDate);
                }

            }
        }

        /// <summary>
        /// Performs the backward path for calculating each
        /// activity its latest start time and latest end time.
        /// </summary>
        /// <param name="list">Array storing the activities already entered.</param>
        /// <returns>void</returns>
        private static void backwardCalculation(List<IActivity> list, DateTime startDate)
        {
            List<IActivity> currentPred = new List<IActivity>();
            foreach (IActivity act in list)
            {

                if (act.Predecessors != null)
                {
                    //currentSuccessors = new List<IActivity>();
                    for (int i = 0; i < act.Predecessors.Count; i++)
                    {
                        IActivity pred = (IActivity) act.Predecessors[i].Pred;
                        currentPred.Add(pred);
                        switch (act.Predecessors[i].RelationshipType)
                        {

                            case (relType.FS):
                                if (pred.Let == 0)
                                    pred.Let = act.Lst - act.Predecessors[i].Lag - 1;
                                else if (pred.Let > act.Lst - act.Predecessors[i].Lag-1)
                                    pred.Let = act.Lst - act.Predecessors[i].Lag-1;
                                pred.Lst = pred.Let - pred.Duration + 1;
                                pred.Tf = pred.Let - pred.Eet;
                                pred.LS = HelperFunctions.AddWorkdays(startDate, pred.Lst+1);
                                pred.LF = HelperFunctions.AddWorkdays(pred.LS, pred.Duration);
                                break;
                            case relType.FF:
                                if (pred.Let == 0)
                                    pred.Let = act.Let - act.Predecessors[i].Lag;
                                else if (pred.Let > act.Let - act.Predecessors[i].Lag)
                                    pred.Let = act.Let - act.Predecessors[i].Lag;
                                pred.Lst = pred.Let - pred.Duration + 1;
                                pred.Tf = pred.Let - pred.Eet;
                                pred.LS = HelperFunctions.AddWorkdays(startDate, pred.Lst + 1);
                                pred.LF = HelperFunctions.AddWorkdays(pred.LS, pred.Duration);
                                break;

                            case relType.SS:
                                if (pred.Lst == 0)
                                    pred.Lst = act.Lst - act.Predecessors[i].Lag;
                                else if (pred.Lst > act.Lst - act.Predecessors[i].Lag)
                                    pred.Lst = act.Lst - act.Predecessors[i].Lag;
                                pred.Let = pred.Lst + pred.Duration - 1;
                                pred.Tf = pred.Let - pred.Eet;
                                pred.LS = HelperFunctions.AddWorkdays(startDate, pred.Lst + 1);
                                pred.LF = HelperFunctions.AddWorkdays(pred.LS, pred.Duration);

                                break;
                            case relType.SF:

                                break;
                        }

                    }
                    backwardCalculation(currentPred, startDate);
                }

            }
        }

        private static int longestDuration(List<IActivity> list)
        {
            int maxDur = 0;
            foreach (IActivity a in list)
            {
                if (a.Eet > maxDur)
                    maxDur = a.Eet;
            }
            return maxDur;
        }
    }
}
