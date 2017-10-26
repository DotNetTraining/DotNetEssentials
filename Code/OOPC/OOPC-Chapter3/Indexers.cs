using System;
using System.Collections.Generic;
using System.Linq;
namespace OOPCChapter3
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FathersName { get; set; }
        public override bool Equals(object obj)
        {
            return ((Student)obj).Name.ToLower() == Name.ToLower();
        }

        /*
         * The class can have additional attributes which is just a dictionary of keys (Type: string) and values (ty both of type string and we can access them using indexers
        */
        Dictionary<string, object> attributes = new Dictionary<string, object>();   //initialized the object to avoid null reference exception
        public Dictionary<string, object> Attributes => attributes;
        public object this[string attribute]
        {
            get
            {
                switch(attribute.ToLower())
                {
                    case "id":
                        return this.Id;
                    case "name":
                        return this.Name;
                    case "dob":
                        return this.DateOfBirth;
                    case "father":
                        return this.FathersName;
                    default:
                        return attributes[attribute.ToLower()];
                }
            }
            set
            {
                switch(attribute.ToLower())
                {
                    case "id":
                        this.Id = (int)value;
                        break;
                    case "name":
                        this.Name = value.ToString();
                        break;
                    case "dob":
                        this.DateOfBirth = (DateTime)value;
                        break;
                    case "father":
                        this.FathersName = value.ToString();
                        break;
                    default:
                        attributes[attribute.ToLower()] = value;
                        break;
                }
            }
        }
    }

    public class ClassStudents
    {
        private List<Student> students;
        public ClassStudents()
        {
            students = new List<Student>();
        }

        public int StudentCount { get => students != null ? students.Count : 0; }

        public Student this[string name]
        {
            get => students.First(x => x.Name.ToLower() == name.ToLower());
            set
            {
                if (students.Count(x => x.Name.ToLower() == value.Name.ToLower()) < 1)
                    students.Add(value);
                else
                {
                    students.Remove(students.First(x=>x.Name.ToLower()==value.Name.ToLower()));
                    students.Add(value);
                }
            }
        }
    }   
}