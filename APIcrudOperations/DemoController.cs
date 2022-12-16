using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDwebAPI.Models;

namespace CRUDwebAPI.Controllers
{
    public class DemoController : ApiController
    {
        DemoEntities db= new DemoEntities();
        //POST request
        public string POST(student std) 
        {
           db.students.Add(std);
            db.SaveChanges();
            return "added success";
        }
        //Get request
        public IEnumerable<student> Get()
        {
            return db.students.ToList();
        }
        //Get single record
        public student Get(int id)
        {
            student std = db.students.Find(id);
            return std;
        }
        //updating the recordmo

        public string PUT(int id, student std)
        {
            var std_ = db.students.Find(id);
            std_.Name = std.Name;
            std_.marks = std.marks;
            std_.gender = std.gender;



            db.Entry(std_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "student details are updated";



        }
        //deleting the record
        public string DELETE(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
            db.SaveChanges();
            return "record deleted successfully";
        }
    }
}
    

