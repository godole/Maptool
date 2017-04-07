using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    class Fever :
        NormalObject
    {
        public Fever() : base("fever")
        {
            ObjectName = "fever";
            Judge = new ObjectJudge(this, ObjectName, 0);
        }

        public Fever(NormalObjectlData data) :
            base(data)
        {
            ObjectName = "fever";
            Judge = new ObjectJudge(this, ObjectName, 0);
        }
    }
}
