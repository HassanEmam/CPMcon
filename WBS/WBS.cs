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
        private List<IActivity> _activities;

        #region Constructor
        public WBS()
        {

        }

        public WBS(string wbsID, string wbsName)
        {
            this.WbsID = wbsID;
            this.WbsName = wbsName;
            
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

        public List<IActivity> Activities
        {
            get
            {
                return _activities;
            }

            set
            {
                _activities = value;
            }
        }

        #endregion

        #region Functions
        /// <summary>
        /// Add an activity to be associated with WBS node
        /// </summary>
        /// <param name="activity"></param>

        public void AddActivity(IActivity activity)
        {
            if (activity !=null && activity.Wbs.WbsID == this.WbsID)
            {
                Activities.Add(activity);
            }
            else if (activity != null && activity.Wbs!= this)
            {
                activity.Wbs = this;
                Activities.Add(activity);
            }
        }
        #endregion
    }
}
