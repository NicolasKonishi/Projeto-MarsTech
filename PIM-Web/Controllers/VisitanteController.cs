using Microsoft.AspNetCore.Mvc;
using PIM_Web.Services;

namespace PIM_Web.Controllers
{
    public class VisitanteController:Controller
    {
        private readonly VisitanteAPI _visitanteAPI;

        public VisitanteController(VisitanteAPI visitanteAPI)
        {
            _visitanteAPI = visitanteAPI;
        }
    }
}
