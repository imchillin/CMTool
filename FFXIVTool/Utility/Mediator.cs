using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVTool.Utility
{
    public delegate void WorkEventHandler();
    public delegate void EntitySelectionEventHandler(string offset);
    public class Mediator
    {
        public event WorkEventHandler Work;
        public event EntitySelectionEventHandler EntitySelection;

        public void SendEntitySelection(string offset)
        {
            EntitySelection?.Invoke(offset);
        }

        public void SendWork()
        {
            Work?.Invoke();
        }
    }
}