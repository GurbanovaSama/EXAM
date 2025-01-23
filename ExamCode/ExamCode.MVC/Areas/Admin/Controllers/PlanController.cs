using ExamCode.BL.DTOs;
using ExamCode.BL.Exceptions;
using ExamCode.BL.Services.Abstractions;
using ExamCode.BL.Services.Implementations;
using ExamCode.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamCode.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlanController : Controller
    {
        readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        public async Task<IActionResult> Index(int id)
        {
            ICollection<PlanListItemDto> list = await _planService.GetPlanListAsync();  
            
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id)
        {
            try
            {
                await _planService.CreateAsync(id);
                await _planService.SaveChangeAsync();
                return View();
            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IActionResult Update()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PlanUpdateDto planUpdateDto)
        {
            try
            {
                await _planService.UpdateAsync(planUpdateDto);
                await _planService.SaveChangeAsync();
                return View("Index");

            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Details()
        {
            await _planService.GetPlanViewItemsAsync();
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _planService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
