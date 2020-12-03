namespace BestPaws.Web.Controllers
{
    using System.Linq;
    using BestPaws.Services.Data;
    using BestPaws.Web.ViewModels.Services;
    using Microsoft.AspNetCore.Mvc;

    public class ServiceController : BaseController
    {
        private readonly IServicesService service;

        public ServiceController(IServicesService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var servicesList = this.service.GetAll<ServiceViewModel>();
            servicesList = servicesList.OrderBy(x => x.Name);
            var model = new ServiceListViewModel { Services = servicesList };
            return this.View(model);
        }
    }
}
