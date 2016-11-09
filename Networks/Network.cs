using System;
using System.Collections.Generic;
using CPMEngine;
using Interfaces;
using Relationships;

namespace Networks
{
    public class Network
    {
        private List<IRelationship> relations;
        private List<IActivity> activities;
        private int duration;

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

        public void addRelationship(IActivity pred, IActivity succ, relType reltype, int Lag)
        {
            Relationship rel = new Relationship(pred, succ, reltype, Lag);
            _addRel(rel);
        }

        public void addRelationship(Relationship rel)
        {
            _addRel(rel);
        }

        public void addRelationship(List<Relationship> relationsList)
        {
            if (relationsList!=null)
            {
                foreach (Relationship rel in relationsList)
                {
                    _addRel(rel);
                }
            }
        }
        private void _addRel(Relationship rel)
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

        public void calculate()
        {
            CPM.compute(this.Activities);
            this.output();
        }

        public void output()
        {
            Console.WriteLine("\tID\tDes.\t\tES\tEF\tLS\tLF\tTF");
            foreach (IActivity act in this.Activities)
            {

                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", act.Id, act.Description, act.Est, act.Eet, act.Lst, act.Let, act.Tf);
            }
            Console.ReadLine();
        }
    }
}
