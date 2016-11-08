using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMcon
{
    public class Relationships
    {
        public enum relType
        {
            FS=1,
            FF=2,
            SS=3,
            SF=4
        };
        private relType _relationshipType;
        private int _lag;
        private Activity _pred;
        private Activity _succ;
        
        public Relationships()
        {

        }

        public Relationships(Activity pred, Activity succ, relType relationType, int lag)
        {
            this.Pred = pred;
            this.Succ = succ;
            this.RelationshipType = relationType;
            this.Lag = lag;
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

        public Activity Pred
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

        public Activity Succ
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
