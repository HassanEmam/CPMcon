using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using ResourceCurves;

namespace ResourceAssignments
{
    public class ResourceAssignment : IResourceAssignment
    {
        private IActivity _activity;
        private IResource _resource;
        private float _budgetedUnits;
        private float _unitRate;
        private IResourceCurve _resCurve;

        public ResourceAssignment(IActivity activity, IResource resource, float budgetedUnits, float unitRate, IResourceCurve resourceCurve =null)
        {
            if (resourceCurve==null)
            {
                float[] linear = { 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, };
                ResourceCurve linearCurve = new ResourceCurve("0", "Linear Distribution", linear);
            }
            this.Activity = activity;
            this.Resource = resource;
            this.BudgetedUnits = budgetedUnits;
            this.UnitRate = unitRate;
        }

        public IActivity Activity
        {
            get
            {
                return _activity;
            }

            set
            {
                _activity = value;
            }
        }

        public IResource Resource
        {
            get
            {
                return _resource;
            }

            set
            {
                _resource = value;
            }
        }

        public float BudgetedUnits
        {
            get
            {
                return _budgetedUnits;
            }

            set
            {
                _budgetedUnits = value;
            }
        }

        public float UnitRate
        {
            get
            {
                return _unitRate;
            }

            set
            {
                _unitRate = value;
            }
        }

        public static implicit operator List<object>(ResourceAssignment v)
        {
            throw new NotImplementedException();
        }
    }
}
