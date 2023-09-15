using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IDispensedProductRepository dispensedProductRepo;

        public ReportController(IDispensedProductRepository dispensedProductRepo)
        {
            this.dispensedProductRepo = dispensedProductRepo;
        }

        [HttpGet("{startDate}/{endDate}")]
        public ActionResult<IEnumerable<DispensedProduct>> GetSalesReport(DateTime startDate, DateTime endDate)
        {
            IEnumerable<DispensedProduct> reportToBeDisplayed = dispensedProductRepo.GetProductsByDates(startDate, endDate).Select(p => new DispensedProduct
           (
                p.Date,
                p.Name,
                p.Price,
                p.PaymentMethod
                ));

            return reportToBeDisplayed.ToList();
        }
    }
}
