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

        [HttpPost]
        [Route("Createcase")]
        public async Task<IActionResult> CreateCase(CaseCreateVM newCase)
        {
            newCase.Creator = User.Identity.Name;

            if (!ModelState.IsValid)
                return View(nameof(Index), await service.GetAllCasesAsync());
            await service.CreateCaseAsync(newCase);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await service.GetCaseDetailsByIdAsync(id));
        }

        [HttpGet]
        [Route("EditCase")]
        public async Task<IActionResult> EditCase(int id)
        {
            return View(await service.GetEditDetailsByIdAsync(id));
        }

        [HttpPost]
        [Route("EditCase")]
        public async Task<IActionResult> EditCase(CaseEditVM newCase)
        {
            if (!ModelState.IsValid)
                return View(nameof(Index), await service.GetAllCasesAsync());
            await service.EditCaseAsync(newCase);
            return RedirectToAction(nameof(Index));

        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteCaseByIdAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}