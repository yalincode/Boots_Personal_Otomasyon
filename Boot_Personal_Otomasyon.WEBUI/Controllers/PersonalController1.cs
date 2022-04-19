using AutoMapper;
using Boots_Personal_Otomasyon.BL.Abstract;
using Boots_Personal_Otomasyon.DAL.Migrations;
using Boots_Personal_Otomasyon.Entities;
using Boots_Personal_Otomasyon.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        [HttpGet("personal/{id?}")]
        public async Task<IActionResult> PersonalDetail(int? id)
        {
            PersonalVM personalVM = null;
            
            if (id>0 && id!=null)
            {
                var personal = await _personalBusiness.GetById(Convert.ToInt32(id));
                if (personal!=null)
                {
                    personalVM = _mapper.Map<PersonalVM>(personal);
                    
                }
            }
            return View(personalVM);
        }
        [HttpPost("personal/{id?}")]
        public async Task<IActionResult> PersonalDetail(int? id,PersonalVM item)
        {
            var personal=_mapper.Map<Personal>(item);

            if (personal.Id>0)
            {
                //update
                //_personalBusiness.Update(personal);
                await _personalBusiness.Update(personal);//await demezsek kod beklemeden devam eder

            }
            else
            {
                //ınsert
                //_personalBusiness.Add(personal);
                await _personalBusiness.Add(personal);
                return Redirect("personal/" + personal.Id.ToString());
                //Yeniden url atıldığı için. Request yönlendiriliyor.
            }
            return View();
        }


        [HttpGet("personal-datatable-list")]
        public IActionResult PersonalDataTableList(int? id)
        {
            return View();
        }
    }
}
