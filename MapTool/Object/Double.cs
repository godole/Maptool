using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    class Double :
        NormalObject
    {
        public Double() : base("double")
        {
            ObjectName = "double";
            Judge = new ObjectJudge(this, ObjectName, 0);
        }

        public Double(NormalObjectlData data) :
            base(data)
        {
            ObjectName = "double";
            Judge = new ObjectJudge(this, ObjectName, 0);
        }
    }
}
