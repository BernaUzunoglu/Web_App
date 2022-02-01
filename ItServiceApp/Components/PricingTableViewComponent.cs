using AutoMapper;
using ItServiceApp.Data;
using ItServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ItServiceApp.Components
{
    public class PricingTableViewComponent:ViewComponent//Component tanımlarken ViewComponentten kalıtım almak gerekir.
    {
        private readonly MyContext _dbContext;
        private readonly IMapper _mapper;

        public PricingTableViewComponent(MyContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var data = _dbContext.SubscriptionTypes
               .ToList()
               .Select(x => _mapper.Map<SubscriptionTypeViewModel>(x))// burda maplama işlemi yaperken elimşzdeki data içerisinde foreach gibi dönüyor
               .OrderBy(x => x.Price)
               .ToList();

            return View(data);
        }
    }
}
