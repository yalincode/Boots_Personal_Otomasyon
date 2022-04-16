using AutoMapper;
using Boots_Personal_Otomasyon.BL.Abstract;
using Boots_Personal_Otomasyon.DAL.Migrations;
using Boots_Personal_Otomasyon.Entities;
using Boots_Personal_Otomasyon.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Boots_Personal_Otomasyon.WEBUI.Controllers
{
    public class PersonalController1 : Controller
    {
        private IPersonalBusiness _personalBusiness;
        private IMapper _mapper;
        public PersonalController1(IPersonalBusiness personalBusiness, IMapper mapper)
        {
            _personalBusiness = personalBusiness;
            _mapper = mapper;
        }
        [HttpGet("personal-list")]
        public IActionResult PersonalList()
        {
            return View();
        }
        [HttpGet("personal")]
        public IActionResult PersonalDetail()
        {
            return View();
        }
        [HttpPost("personal")]
        public IActionResult PersonalDetail(PersonalVM item)
        {
            var personal=_mapper.Map<Personal>(item);

            if (personal.Id>0)
            {
                //update
                //_personalBusiness.Update(personal);
                _personalBusiness.Update(personal);
            }
            else
            {
                //ınsert
                //_personalBusiness.Add(personal);
                _personalBusiness.Add(personal);
            }
            return View();
        }
    }
}
