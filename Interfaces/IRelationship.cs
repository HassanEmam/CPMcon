using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public enum relType
    {
        FS = 1,
        FF = 2,
        SS = 3,
        SF = 4
    };

    public interface IRelationship
    {
        
        void Add();
        relType RelationshipType { set; get; }
        int Lag { set; get; }
        IActivity Pred { set; get; }
        IActivity Succ { set; get; }
        
    }
}
