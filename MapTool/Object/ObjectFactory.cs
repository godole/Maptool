using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool
{
    class ObjectFactory
    {
        public static BaseObject CreateObject(BaseObject.ObjectType type, Vector2 pos)
        {
            BaseObject obj = null;
            string objecttype = "";

            switch (type)
            {
                case BaseObject.ObjectType.Platform:
                    objecttype = "platform";
                    obj = new Platform();
                    ObjectContainer.PlatformList.Add(obj);
                    break;

                case BaseObject.ObjectType.Niddle:
                    objecttype = "niddle";
                    obj = new Niddle();
                    break;

                case BaseObject.ObjectType.Fire:
                    objecttype = "fire";
                    obj = new Platform();
                    break;

                case BaseObject.ObjectType.Double:
                    objecttype = "double";
                    obj = new Double();
                    break;

                case BaseObject.ObjectType.Fever:
                    objecttype = "fever";
                    obj = new Fever();
                    break;

                case BaseObject.ObjectType.Rope:
                    objecttype = "rope";
                    obj = new Rope();
                    break;

                case BaseObject.ObjectType.Spring:
                    objecttype = "spring";
                    obj = new Spring();
                    break;

                default:
                    break;
            }

            if(obj != null)
            {
                Program.MainMap.AddChild(obj);
                obj.ObjectName = objecttype;
                obj.WorldPosition = pos;
            }

            return obj;
        }
    }
}
