using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources
{
    public class Resource
    {
        public enum resourceType
        {
            Labour=1,
            Material=2,
            Equipment=3,
            Money=4
        };
        private string resID;
        private string resName;
        private resourceType resType;
        private float defUnitTime;
        private float _unitCost;

        public Resource()
        {

        }
        public Resource( string ID, string Name, resourceType type, float defaultUnits, float unitCost)
        {
            this.ResID = ID;
            this.ResName = Name;
            this.ResType = type;
            this.DefUnitTime = defaultUnits;
            this.UnitCost = unitCost;
        }
        public string ResID
        {
            get
            {
                return resID;
            }

            set
            {
                resID = value;
            }
        }

        public string ResName
        {
            get
            {
                return resName;
            }

            set
            {
                resName = value;
            }
        }

        public resourceType ResType
        {
            get
            {
                return resType;
            }

            set
            {
                resType = value;
            }
        }

        public float DefUnitTime
        {
            get
            {
                return defUnitTime;
            }

            set
            {
                defUnitTime = value;
            }
        }

        public float UnitCost
        {
            get
            {
                return _unitCost;
            }

            set
            {
                _unitCost = value;
            }
        }
    }
}
