using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using UniversityRegistrar.Models;

namespace UniversityRegistrar.Controllers 
  {
    public class StudentsController : Controller
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
        ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
        return View();
      }

      [HttpPost]
      public ActionResult Create(Student student, int courseId)
      {
        _db.Students.Add(student);
        _db.SaveChanges();
        if (courseId != 0)
        {
          _db.CourseStudents.Add(new CourseStudent() { StudentId=student.StudentId, CourseId=courseId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      
      public ActionResult Details(int id)
      {
        Student thisStudent = _db.Students
          .Include(student => student.JoinEntities)
          .ThenInclude(join => join.Course)
          .FirstOrDefault(student => student.StudentId == id);
        return View(thisStudent);
      }

      public ActionResult AddCourse(int id)
      {
        Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
        ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
        return View(thisStudent);
      }

      [HttpPost]
      public ActionResult AddCourse(Student student, int courseId)
      {
        if (courseId != 0)
        {
          _db.CourseStudents.Add(new CourseStudent() { StudentId=student.StudentId, CourseId=courseId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
  }