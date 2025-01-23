using ExamCode.BL.DTOs;
using ExamCode.BL.Exceptions;
using ExamCode.BL.Services.Abstractions;
using ExamCode.DAL.Models;
using ExamCode.MVC.HomeVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamCode.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        readonly IMemberService _memberService;

        

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public async Task<IActionResult> Index( int id)
        {
            ICollection<MemberListItemDto>  list = await _memberService.GetMemberListAsync();        
          
            return View(list);
        }


        public IActionResult Create()
        {
            return View();
        }

        public  async Task<IActionResult> Create(int id)
        {
            try
            {
                await _memberService.CreateAsync(id);
                await _memberService.SaveChangeAsync();
                return View();
            }
            catch(BaseException ex)
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
        public async Task<IActionResult> Update(MemberUpdateDto memberUpdateDto)
        {
            try
            {
                await _memberService.UpdateAsync(memberUpdateDto);      
                await _memberService.SaveChangeAsync();
                return View("Index");

            }
            catch (BaseException ex)
            {
                return BadRequest (ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Details()
        {
            await _memberService.GetMemberViewItemsAsync();
            return View();          
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _memberService.DeleteAsync(id);
            return RedirectToAction("Index");      
        }
    }
}
