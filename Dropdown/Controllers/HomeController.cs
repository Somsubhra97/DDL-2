using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dropdown.Models;
using Dropdown.EmployeeViewModel;

namespace Dropdown.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.State= new SelectList(_context.State.ToList() "Id", "Name");
            return View();
        } 


       public Task<IActionResult> GetAll(){

        return View(await ( from a in _context.Employee                            
                            select new EmpView
                              {
                                  Name = a.FullName,
                                  Address = a.Address,
                                  Designation = a.Position,
                                  Email =a.Email,
                                  CityName=a.CityName,
                                  StateName=a.StateName
                              }).ToListAsync()
                   );
                      
            }
       }
        
   }

