using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace WBSs
{
    public class WBS : IWBS
    {
        private string _wbsID;
        private string _wbsName;
        private IWBS _parent;

        #region Constructor
        public WBS()
        {

        }

        public WBS(string wbsID, string wbsName, WBS parent)
        {
            this.WbsID = wbsID;
            this.WbsName = wbsName;
            this.Parent = parent;
        }
        #endregion

        #region Properties
        public string WbsID
        {
            get
            {
                return _wbsID;
            }

            set
            {
                this._wbsID = value;
            }
        }

        public string WbsName
        {
            get
            {
                return this._wbsName;
            }

            set
            {
                this._wbsName = value;
            }
        }

        public IWBS Parent
        {
            get
            {
                return _parent;
            }

            set
            {
                this._parent = value;
            }
        }

        #endregion
    }
}
