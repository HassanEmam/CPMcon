using System;
using System.Collections.Generic;
using CPMEngine;
using Interfaces;
using Relationships;
using CPMcon;

namespace Networks
{
    public class Network : INetwork
    {
        private List<IRelationship> relations;
        private List<IActivity> activities;
        private int duration;
        private DateTime _startDate;
        private DateTime _endDate;
        #region proprties
        public List<IRelationship> Relations
        {
            get
            {
                return relations;
            }

            set
            {
                relations = value;
            }
        }
        public List<IActivity> Activities
        {
            get
            {
                return activities;
            }

            set
            {
                activities = value;
            }
        }
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

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }

            set
            {
                _startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }

            set
            {
                _endDate = value;
            }
        }
        #endregion

        #region Relationships Functions
        public void addRelationship(IActivity pred, IActivity succ, relType reltype, int Lag)
        {
            Relationship rel = new Relationship(pred, succ, reltype, Lag);
            _addRel(rel);
        }
        public void addRelationship(IRelationship rel)
        {
            _addRel(rel);
        }
        public void addRelationship(List<IRelationship> relationsList)
        {
            if (relationsList!=null)
            {
                foreach (Relationship rel in relationsList)
                {
                    _addRel(rel);
                }
            }
        }
        private void _addRel(IRelationship rel)
        {
            if (this.Relations != null)
            {
                this.Relations.Add(rel);
            }
            else
            {
                this.Relations = new List<IRelationship>();
                this.Relations.Add(rel);
            }
        }
        #endregion

        #region Activities Functions
        public void addActivity(IActivity activity)
        {
            this.activities.Add(activity);
        }

        public void addActivity(string ID, string Desc, int Duration)
        {
            Activity a = new Activity(ID, Desc, Duration);
            activities.Add(a);
        }

        #endregion
        public void calculate()
        {
            CPM.compute(this.Activities);
            this.output();
        }
        public void output()
        {
            Console.WriteLine("\tID\tDes.\t\tDur\tES\t\t\tEF\t\t\tLS\t\t\t\tLF\t\t\tTF");
            foreach (IActivity act in this.Activities)
            {

                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", act.Id, act.Description,act.Duration, act.ES.Date, act.EF.Date, act.LS.Date, act.LF.Date, act.Tf);
            }
            Console.ReadLine();
        }
    }
}
