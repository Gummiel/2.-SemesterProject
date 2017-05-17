using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestillingApp.Singleton;

namespace BestillingApp.ViewModel
{
    class InformationViewModel
    {

        #region Constructor

        public InformationViewModel()
        {
            InformationSingleton = InformationSingleton.Instance;
            InformationSingleton.LoadInformationAsync();
        }

        #endregion

        #region Properties

        public static InformationSingleton InformationSingleton { get; set; }

        #endregion
    }
}
