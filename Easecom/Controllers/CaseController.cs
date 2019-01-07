using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easecom.Models;
using Easecom.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easecom.Controllers
{
    [Authorize]
    public class CaseController : Controller
    {
        CaseService service;

        public CaseController(CaseService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("Case")]
        public async Task<IActionResult> Index()
        {
            return View(await service.GetAllCasesAsync());
        }

        [HttpGet]
        [Route("CreateCase")]
        public IActionResult CreateCase()
        {
            return View();
        }
    }
}