using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Risks
{
    public class Risk : IRisk
    {
        /*public enum riskType
        {
            Threat=1,
            Oppotunity=2
        }

        public enum riskStatus
        {
            Active=1,
            Impacted=2,
            Managed=3,
            Open=4,
            Proposed=5,
            Rejected=6
        }
        */

        private string _riskID;
        private string _riskDescription;
        private riskType _riskType;
        private riskStatus _riskStatus;

        #region Constructors
        public Risk()
        {

        }

        public Risk(string _riskID, string _riskDescription, riskType _riskType, riskStatus _riskStatus)
        {
            this._riskID = _riskID;
            this._riskDescription = _riskDescription;
            this._riskType = _riskType;
            this._riskStatus = _riskStatus;
        }
        #endregion

        #region Properties
        public string RiskID
        {
            get
            {
                return _riskID;
            }

            set
            {
                _riskID = value;
            }
        }

        public string RiskDescription
        {
            get
            {
                return _riskDescription;
            }

            set
            {
                _riskDescription = value;
            }
        }

        public riskType RiskType
        {
            get
            {
                return _riskType;
            }

            set
            {
                _riskType = value;
            }
        }

        public riskStatus RiskStatus
        {
            get
            {
                return _riskStatus;
            }

            set
            {
                _riskStatus = value;
            }
        }
        #endregion
    }
}
