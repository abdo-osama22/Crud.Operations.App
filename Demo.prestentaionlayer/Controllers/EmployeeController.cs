using AutoMapper;
using Demo.BusinessLogicLayer.Interfaces;
using Demo.DataAccessLayer.Model;
using Demo.prestentaionlayer.Helpers;
using Demo.prestentaionlayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.prestentaionlayer.Controllers
{
    [Authorize]
    public class EmployeeController : Controller

    {
        //private readonly IEmployeeReopsitory _employeeReopsitory;
        //private readonly IdepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            //_employeeReopsitory = employeeReopsitory;
            //_departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {

                var Employees = await _unitOfWork.EmployeeReopsitory.GetAll();
                var mapedEmp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(Employees);

                return View(mapedEmp);
            }
            else
            {
                var employees = _unitOfWork.EmployeeReopsitory.SearchEmployeeByName(SearchValue);
                var mapedEmp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
                return View(mapedEmp);
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments =  _unitOfWork.departmentRepository.GetAll();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeevm)
        {
            employeevm.ImageName = DocumentSettings.UploadFiles(employeevm.Image, "Images");
            var mapperdEmployee =_mapper.Map<EmployeeViewModel,Employee>(employeevm);
          

            if (ModelState.IsValid)
            {
               await _unitOfWork.EmployeeReopsitory.Add(mapperdEmployee);
                await _unitOfWork.complete();
               
                return RedirectToAction(nameof(Index));
            }
            return View(employeevm);
        }
        public async Task<IActionResult> Details(int? id, string viewname = "Details")
        {
            if (id is null)

                return BadRequest();
            var Employee = await _unitOfWork.EmployeeReopsitory.Get(id.Value);
            if (Employee is null)
            {
                return NotFound();
            }
            var mapemp = _mapper.Map<Employee, EmployeeViewModel>(Employee);

            return View(viewname, mapemp);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Departments = _unitOfWork.departmentRepository.GetAll();
            return await Details(id, "Edit");
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
        public async Task<IActionResult> Edit([FromRoute] int id, EmployeeViewModel employeevm)
        { 
            if (id != employeevm.Id)
            
                return BadRequest();
            if (ModelState.IsValid) 
            {
                try
                {
                    var mappedvm = _mapper.Map<EmployeeViewModel, Employee>(employeevm);
                    _unitOfWork.EmployeeReopsitory.update(mappedvm);
                    await _unitOfWork.complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }

         
            return View(employeevm);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)

        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int id, EmployeeViewModel employeevm)
        {
            if (id != employeevm.Id)
            {
                return BadRequest();
            }
            try
            {
                var mapemployee = _mapper.Map<EmployeeViewModel, Employee>(employeevm);
                    
                _unitOfWork.EmployeeReopsitory.delete(mapemployee);
               int count =  await _unitOfWork.complete();
                if (count > 0)
                    DocumentSettings.DeleteFile(employeevm.ImageName, "Images");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View(employeevm);
        }

    }
}
