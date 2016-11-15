using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace ResourceCurves
{
    public class ResourceCurve : IResourceCurve
    {
        private string _curveID;
        private string _curveName;
        private float[] _timePhasedPercent = new float[21];

        public ResourceCurve(string curveID, string curveName, float[] timePhasedPercent)
        {
            this.CurveID = curveID;
            this.CurveName = curveName;
            this.TimePhasedPercent = timePhasedPercent;
        }

        public string CurveID
        {
            get
            {
                return _curveID;
            }

            set
            {
                _curveID = value;
            }
        }

        public string CurveName
        {
            get
            {
                return _curveName;
            }

            set
            {
                _curveName = value;
            }
        }

        public float[] TimePhasedPercent
        {
            get
            {
                return _timePhasedPercent;
            }

            set
            {
                _timePhasedPercent = value;
            }
        }
    }
}
