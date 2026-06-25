# Prototype Design Pattern

## Overview
- Creational design pattern that lets you copy existing objects without making your code dependent on their classes.
- When you want to make copy of any object , you have to go through all the properties of that object and assign them to new object. 
- This works but it's not perfect copy because some properties are private and you cannot access them outside of the class.
- Prototype design pattern solves this problem by creating a copy of the object using a method called `Clone()`.

## Use case
- When the cost of creating a new object is expensive or complicated.
- When you want to avoid the overhead of initializing an object from scratch.
- Avoid it when you have class with circular references.

## Code
```csharp
//Prototype of a Person class
public abstract class Person
{
    protected Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string Name { get; set; }
    public int Age { get; set; }

    public abstract Person Clone();
}

//Concrete Implementation of Teacher class
public class Teacher : Person
{
    public Teacher(string name, int age, string subject): base(name, age) 
    {
        Subject = subject;
    }
    public string Subject { get; set; }
    public override Person Clone()
    {
        return new Teacher(Name, Age, Subject);
    }
    public override string ToString()
    {
        return $"Teacher: {Name}, Age: {Age}, Subject: {Subject}";
    }
}

//Concrete Implementation of Student class
public class Student : Person
{
    public Student(string name, int age, string grade, Teacher teacher) : base(name, age)
    {
        Grade = grade;
        Teacher = teacher;
    }
    public string Grade { get; set; }
    public Teacher Teacher { get; set; }
    public override Person Clone()
    {
        return new Student(Name, Age, Grade, (Teacher)Teacher.Clone());
    }
    public override string ToString()
    {
        return $"Student: {Name}, Age: {Age}, Grade: {Grade}, Teacher: {Teacher.Name}";
    }
}
```
```csharp
private static void Main()
{
    //Client code
    var teacher = new Teacher("John Doe", 35, "Mathematics");
    Console.WriteLine(teacher);
    var student = new Student("Jane Smith", 16, "10th Grade", teacher);
    Console.WriteLine(student);

    var clonedTeacher = (Teacher)teacher.Clone();
    clonedTeacher.Name = "John Doe Clone";
    Console.WriteLine(clonedTeacher);

    var clonedStudent = (Student)student.Clone();
    clonedStudent.Name = "Jane Smith Clone";
    Console.WriteLine(clonedStudent);

    //You can create list of person and create copy of them without knowing their concrete type
    var people = new List<Person> { teacher, student };
    var clonedPeople = people.Select(p => p.Clone()).ToList();
}
```