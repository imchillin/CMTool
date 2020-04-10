using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptMatrix.ViewModel
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

