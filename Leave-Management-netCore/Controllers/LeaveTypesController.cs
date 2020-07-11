using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Leave_Management_netCore.Contracts;
using Leave_Management_netCore.Data;
using Leave_Management_netCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Management_netCore.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }
        // GET: LeaveTypesController
        public ActionResult Index()
        {
            var leavetypes = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leavetypes);
            return View(model);
            
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExists(id))
                return NotFound();

            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(model);
                }
                var leavetype = _mapper.Map<LeaveType>(model);
                leavetype.DateCreated = DateTime.Now;

                var isSuccess=_repo.Create(leavetype);
                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Algo paso");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", "Algo paso");
                return View(model);
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExists(id))
                return NotFound();

            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM model)
        {
            try
            {
                if (!_repo.IsExists(model.Id))
                    return View(model);

                var leavetype = _mapper.Map<LeaveType>(model);
                leavetype.DateCreated = DateTime.Now;

                var isSuccess = _repo.Update(leavetype);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Algo paso");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Algo paso");
                return View();
            }
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            /*if (!_repo.IsExists(id))
                return NotFound();

            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);*/

            var leavetype = _repo.FindById(id);
            if (leavetype == null)
            {
                return NotFound();
            }

            var isSuccess = _repo.Delete(leavetype);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));

        }

 
    }

}
