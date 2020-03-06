using System;
using HandsonEFCodeFirst.Context;
using HandsonEFCodeFirst.Models;
using System.Linq;
using System.Collections.Generic;

namespace HandsonEFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
         using(Mycontext db=new Mycontext())
            {
               // Student s = new Student() { Sname = "Karan", age = 10, Std = "II" };
                //db.Students.Add(s);
                //db.SaveChanges();
                //Student s = db.Students.Find(1);
                //Console.WriteLine("Welcome {0}", s.Sname);
                Student s1 = db.Students.SingleOrDefault(i => i.Sname == "Rohan");
                List<Student> list = db.Students.Where(i => i.age == 10).ToList();
                List<Student> list1 = db.Students.Where(i => i.age == 10&& i.Std=="II").ToList();

                Student s2 = db.Students.Find(2);
                s2.age = 11;
                db.Students.Update(s2);
                db.SaveChanges();

                Student s3 = db.Students.SingleOrDefault(i => i.Sname == "Rohan");
                db.Students.Remove(s3);
                db.SaveChanges();
            
            
            }
        }
    }
}
