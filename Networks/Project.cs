using System;
using System.Collections.Generic;
using CPMEngine;
using Interfaces;
using Relationships;
using CPMcon;
using WBSs;

namespace Networks
{
    public class Project : IProject
    {
        private string _iD;
        private string _name;

        private List<IRelationship> relations;
        private List<IActivity> activities;
        private int duration;
        private DateTime _startDate;
        private DateTime _endDate;
        private DateTime _mustFinishBy;
        private DateTime _dataDate;
        private ICalendar _defaultCalendar;
        private IWBS _wbs;
        public Project(string iD, string name)
        {
            this.ID = iD;
            this.Name = name;
            this.Wbs = new WBS(iD, name);
        }
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

        public DateTime MustFinishBy
        {
            get
            {
                return _mustFinishBy;
            }

            set
            {
                _mustFinishBy = value;
            }
        }

        public DateTime DataDate
        {
            get
            {
                return _dataDate;
            }

            set
            {
                _dataDate = value;
            }
        }

        public ICalendar DefaultCalendar
        {
            get
            {
                return _defaultCalendar;
            }

            set
            {
                _defaultCalendar = value;
            }
        }

        public string ID
        {
            get
            {
                return _iD;
            }

            set
            {
                _iD = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
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
            if (activities == null)
                activities = new List<IActivity>();
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
