using FFXIVTool.Models;
using FFXIVTool.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVTool.ViewModel
{
    public class BaseViewModel
    {
        public static BaseModel model;
        protected Mediator mediator;

        public BaseViewModel(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }
}

