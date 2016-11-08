using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMcon
{
    class Network
    {
        private List<Relationships> relations;
        private List<Activity> activities;
        private int duration;

        public List<Relationships> Relations
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

        public List<Activity> Activities
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

        public void addRelationship(Activity pred, Activity succ, Relationships.relType reltype, int Lag)
        {
            Relationships rel = new Relationships(pred, succ, reltype, Lag);
            _addRel(rel);
        }

        public void addRelationship(Relationships rel)
        {
            _addRel(rel);
        }

        public void addRelationship(List<Relationships> relationsList)
        {
            if (relationsList!=null)
            {
                foreach (Relationships rel in relationsList)
                {
                    _addRel(rel);
                }
            }
        }
        private void _addRel(Relationships rel)
        {
            if (this.Relations != null)
            {
                this.Relations.Add(rel);
            }
            else
            {
                this.Relations = new List<Relationships>();
                this.Relations.Add(rel);
            }
        }

        public void calculate()
        {
            CPM.forwardPath(this.Activities);
            CPM.backwardPath(this.Activities);
            this.output();
        }

        public void output()
        {
            Console.WriteLine("\tID\tES\tEF\tLS\tLF");
            foreach (Activity act in this.Activities)
            {

                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", act.Id, act.Est, act.Eet, act.Lst, act.Let);
            }
            Console.ReadLine();
        }
    }
}
