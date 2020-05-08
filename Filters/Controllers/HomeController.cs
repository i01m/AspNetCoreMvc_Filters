using Microsoft.AspNetCore.Mvc;
using Filters.Infrastructure;
using System;

namespace Filters.Controllers
{

    //[Profile] // - applying ProfileAttribute from Infra folder
    //[HttpsOnly] - applying HttpsOnlyAttribute from Infrastructure folder
    //[ViewResultDetails] // - applying ViewResultDetailsAttribute from Infra folder
    //[RangeException]

    //[TypeFilter(typeof(DiagnosticsFilter))] 
    //[ServiceFilter(typeof(TimeFilter))]

    [Message("This is Controller-Scoped Filter",Order = 10)]
    public class HomeController: Controller
    {
        //can change order using int values
        [Message("This is the First Action-Scoped Filter",Order = 1)]
        [Message("This is the Second Action-Scoped Filter", Order = -1)]

        public ViewResult Index() => View("Message",
            "This is the Index action of the Home controller.");

       
        //public ViewResult SecondAction() => View("Message",
        //    "This is the SecondAction action of the Home controller.");

        public ViewResult GenerateException(int? id)
        {
            if (id == null) {
                throw new ArgumentNullException(nameof(id));
            } else if (id > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            } else
            {
                return View("Message", $"The value is {id}");
            }

        }
    }
}
