using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UniversityRegistrar.Models;

namespace UniversityRegistrar.Controllers 
  {
    public class StudentsController : Controllers
    {
      private readonly UniversityRegistrarContext _db;
      public StudentsController(UniversityRegistrarContext db)
      {
        _db = db;
      }

      public ActionResult Index()
      {
        List<Student> model = _db.Students.ToList();
        return View(model);
      }

      public ActionResult Create()
      {
        return View();
      }

      [HttpPost]
      public ActionResult Create(Student student)
      {
        _db.Students.Add(student);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult Details(int id)
      {
        Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
        return View(thisStudent);
      }
    }
  }