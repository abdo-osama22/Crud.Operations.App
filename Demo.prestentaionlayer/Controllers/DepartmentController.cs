using Demo.BusinessLogicLayer.Interfaces;
using Demo.DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Demo.prestentaionlayer.Controllers
{
    public class DepartmentController : Controller
    {
        //private readonly IdepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _unitOfWork.departmentRepository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
              await _unitOfWork.departmentRepository.Add(department);
                int count = await _unitOfWork.complete();

                // 3. TempData
                if (count>0)
                {
                    TempData["Message"] = "Department Is Created Scuccefully";
                }

                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        public async Task<IActionResult> Details(int? id,string viewname = "Details")
        {
            if (id is null)

                return BadRequest();
            var department = await _unitOfWork.departmentRepository.Get(id.Value);
            if (department is null)
            {
                return NotFound();
            }

            return View(viewname,department);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return await Details(id,"Edit");
            ///if (id is null)
            ///    return BadRequest();
            ///var department = _departmentRepository.Get(id.Value);
            ///if (department is null)
            ///{
            ///    return NotFound();
            ///}
            ///else
            ///    return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id,Department department) 
        {
            if (id !=null)
            {
                return BadRequest();
            }
            try
            {
               _unitOfWork.departmentRepository.update(department);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
             
            }
            return View(department);
         
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id) 
        
        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
    public IActionResult Delete([FromRoute]int id ,Department department) 
        {
            if (id !=department.Id)
            {
                return BadRequest();
            }
            try
            {
                _unitOfWork.departmentRepository.delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                
            }
            return View(department);
        }
    }
}
