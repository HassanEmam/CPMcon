
using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using ResourceAssignments;


/*This class handles activities and their associated properties
 * the initial version was created by Hassan Emam on 10.Nov.2016
 * It is part of a wider solution to produce an outstanding construction
 * scheduling system that is no where comparable to those existing in the market
 * the project is ambitious and expected to be the state-of-the-art in construction
 * planning and scheduling. Main diffrentiators include: integration with BIM, GIS,
 * ERP systems, Application of data warehousing algorithms & predictive analytics,
 * implementation of the most efficient optimisation algorithms for resource assignment
 * , levelling, and others.
 * */

namespace CPMcon
{
    /// <summary>
    /// Describes an activity according to the Critical Path Method.
    /// </summary>
    public class Activity : IActivity
    {
        private string id;
        private string description;
        private int duration;
        private ICalendar _calendar;
        private List<IRelationship> successors;
        private List<IRelationship> predecessors;
        private List<IResourceAssignment> _resources;
        private DateTime _eS;
        private DateTime _eF;
        private DateTime _lS;
        private DateTime _lF;
        private IWBS _wbs;

        //calculated feilds
        private int est;
        private int lst;
        private int eet;
        private int let;
        private int tf;
        
        

        public Activity()
        {
            // TODO: Add Constructor Logic here
        }

        public Activity(string ID, string Descrptn, int dur)
        {
            this.Duration = dur;
            this.Id = ID;
            this.Description = Descrptn;
        }

        public Activity(string id, string description, int duration, ICalendar _calendar, List<IRelationship> successors, List<IRelationship> predecessors)
        {
            this.Id = id;
            this.Description = description;
            this.Duration = duration;
            this.Calendar = _calendar;
            this.Successors = successors;
            this.Predecessors = predecessors;
        }

        public Activity(string id, string description, int duration, ICalendar _calendar, List<IRelationship> successors, List<IRelationship> predecessors, IWBS wbs)
        {
            this.Id = id;
            this.Description = description;
            this.Duration = duration;
            this.Calendar = _calendar;
            this.Successors = successors;
            this.Predecessors = predecessors;
            this.Wbs = wbs;
        }

        /// <summary>
        /// Identification concerning the activity.
        /// </summary>
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        /// <summary>
        /// Brief description concerning the activity.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        /// <summary>
        /// Total amount of time taken by the activity.
        /// </summary>
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }

        /// <summary>
        /// Earliest start time
        /// </summary>
        public int Est
        {
            get
            {
                return est;
            }
            set
            {
                est = value;
            }
        }

        /// <summary>
        ///  Latest start time
        /// </summary>
        public int Lst
        {
            get
            {
                return lst;
            }
            set
            {
                lst = value;
            }
        }

        /// <summary>
        /// Earliest end time
        /// </summary>
        public int Eet
        {
            get
            {
                return eet;
            }
            set
            {
                eet = value;
            }
        }


        /// <summary>
        /// Latest end time
        /// </summary>
        public int Let
        {
            get
            {
                return let;
            }
            set
            {
                let = value;
            }
        }

        /// <summary>
        /// Activities that come before the activity.
        /// </summary>
        public List<IRelationship> Predecessors
        {
            get
            {
                return predecessors;
            }
            set
            {
                predecessors = value;
            }
        }

        /// <summary>
        /// Activities that come after the activity.
        /// </summary>
        public List<IRelationship> Successors
        {
            get
            {
                return successors;
            }
            set
            {
                successors = value;
            }
        }

        public int Tf
        {
            get
            {
                return tf;
            }

            set
            {
                tf = value;
            }
        }

        public ICalendar Calendar
        {
            get
            {
                return _calendar;
            }

            set
            {
                _calendar = value;
            }
        }

        public List<IResourceAssignment> Resources
        {
            get
            {
                return _resources;
            }

            set
            {
                _resources = value;
            }
        }

        public DateTime ES
        {
            get
            {
                return _eS;
            }

            set
            {
                _eS = value;
            }
        }

        public DateTime EF
        {
            get
            {
                return _eF;
            }

            set
            {
                _eF = value;
            }
        }

        public DateTime LS
        {
            get
            {
                return _lS;
            }

            set
            {
                _lS = value;
            }
        }

        public DateTime LF
        {
            get
            {
                return _lF;
            }

            set
            {
                _lF = value;
            }
        }

        public IWBS Wbs
        {
            get
            {
                return _wbs;
            }

            set
            {
                _wbs = value;
            }
        }

        /// <summary>
        /// Performs a check to verify if an activity exists.
        /// </summary>
        /// <param name="list">Array storing the activities already entered.</param>
        /// <param name="id">ID being checked.</param>
        /// <param name="i">Current activities' array index.</param>
        /// <returns>Found activity or null.</returns>
        public IActivity CheckActivity(List<IActivity> list, string id, int i)
        {
            for (int j = 0; j < i; j++)
            {
                if (list[j].Id == id)
                    return list[j];
            }
            return null;
        }

        /// <summary>
        /// Returns the index of a given activity.
        /// </summary>
        /// <param name="aux">Activity serving as an auxiliary referencing an existing
        /// activity.</param>
        /// <param name="i">Current activities' array index.</param>
        /// <returns>index</returns>
        public int GetIndex(List<IActivity> list, IActivity aux, int i)
        {
            for (int j = 1; j < i; j++)
            {
                if (list[j].Id == aux.Id)
                    return j;
            }
            return 0;
        }

        public void setPredecessors(IRelationship rel)
        {
            IRelationship relation = rel;
            if (predecessors != null)
            {
                predecessors.Add(relation);
            }
            else
            {
                this.predecessors = new List<IRelationship>();
                this.predecessors.Add(relation);
            }
        }

        public void SetSuccessors(IRelationship relation)
        {
            
            if (successors != null)
            {              
                successors.Add(relation);
            }

            else
            {
                this.Successors = new List<IRelationship>();
                this.Successors.Add(relation);
            }
            //return relation;
        }
    }
}

