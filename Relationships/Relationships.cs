using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;


namespace Relationships
{
    public class Relationship: IRelationship
    {
        /*public enum relType
        {
            FS=1,
            FF=2,
            SS=3,
            SF=4
        }; */
        private relType _relationshipType;
        private int _lag;
        private IActivity _pred;
        private IActivity _succ;
        private IActivity pred;
        private IActivity succ;
        private relType reltype;

        public Relationship()
        {

        }
        public Relationship(IActivity pred, IActivity succ, relType relationType, int lag)
        {
            this.Pred = pred;
            this.Succ = succ;
            this.RelationshipType = relationType;
            this.Lag = lag;
            Add();
        }


        public relType RelationshipType
        {
            get
            {
                return _relationshipType;
            }

            set
            {
                _relationshipType = value;
            }
        }

        public int Lag
        {
            get
            {
                return _lag;
            }

            set
            {
                _lag = value;
            }
        }

        public IActivity Pred
        {
            get
            {
                return _pred;
            }

            set
            {
                //value.SetSuccessors(this);
                _pred = value;
            }
        }

        public IActivity Succ
        {
            get
            {
                return _succ;
            }

            set
            {
                _succ = value;
            }
        }

        public void Add()
        {
            this.Pred.SetSuccessors(this);
            this.Succ.setPredecessors(this);
        }
    }
}
