

//Чисто для теста, нужен файл у программы
//Student 0 Student0 0
//Teacher 0 Teacher0 0 0
//Course 0 Course0 0 0
StreamReader file = new StreamReader("text.txt");
Factory[] test = new Factory[0];
while (!file.EndOfStream) { test = test.Append(Import(file)).ToArray(); test = test.Append(Import(file)).ToArray(); test = test.Append(Import(file)).ToArray(); }
file.Close();
test = test.Append(new Student((test.Length - test.Length % 3) / 3, "Student" + Convert.ToString((test.Length - test.Length % 3) / 3), [(test.Length - test.Length % 3) / 3 - 1])).ToArray();
test = test.Append(new Teacher((test.Length - test.Length % 3) / 3, "Teacher" + Convert.ToString((test.Length - test.Length % 3) / 3), [(test.Length - test.Length % 3) / 3 - 1], (test.Length - test.Length % 3) / 3)).ToArray();
test = test.Append(new Course((test.Length - test.Length % 3) / 3, "Course" + Convert.ToString((test.Length - test.Length % 3) / 3), [(test.Length - test.Length % 3) / 3 - 1], (test.Length - test.Length % 3) / 3)).ToArray();
StreamWriter file_w = new StreamWriter("text.txt");
foreach (Factory factory in test) { file_w.WriteLine(factory.Export()); }
file_w.Close();
Console.ReadLine();




Factory Import(StreamReader file)
{
    if (file.EndOfStream) return null;
    string input = file.ReadLine();
    if (input.Split(' ')[0] == "Student") return new Student(string.Join(' ', input.Split(' ').Skip(1)));
    else if (input.Split(' ')[0] == "Teacher") return new Teacher(string.Join(' ', input.Split(' ').Skip(1)));
    else if (input.Split(' ')[0] == "Course") return new Course(string.Join(' ', input.Split(' ').Skip(1)));
    else return null;
}


abstract class Factory
{
    public int ID { get; set; }
    public string Name { get; set; }
    public Factory(int ID, string Name)
    {
        this.ID = ID;
        this.Name = Name;
    }
    abstract public string Export();
}


class Student: Factory
{
    public int[] Courses { get; set; }
    public Student(int ID, string Name, int[] Courses) : base(ID, Name)
    {
        this.Courses = Courses;
    }
    public Student(string input):base(Convert.ToInt32(input.Split(' ')[0]), input.Split(' ')[1])
    {
        Courses = new int[0];
        foreach (string i in input.Split(' ').Skip(2)) Courses = Courses.Append(Convert.ToInt32(i)).ToArray();
    }
    override public string Export()
    {
        string s = "";
        foreach (int i in Courses) s += ' ' + Convert.ToString(i);
        return "Student " + Convert.ToString(ID) + ' ' + Name + s;
    }
}

class Teacher : Factory
{
    public int[] Courses { get; set; }
    public int Experience {  get; set; }
    public Teacher(int ID, string Name, int[] Courses, int Experience) : base(ID, Name)
    {
        this.Experience = Experience;
        this.Courses = Courses;
    }
    public Teacher(string input) : base(Convert.ToInt32(input.Split(' ')[0]), input.Split(' ')[1])
    {
        Experience = Convert.ToInt32(input.Split(' ')[2]);
        Courses = new int[0];
        foreach (string i in input.Split(' ').Skip(3)) Courses = Courses.Append(Convert.ToInt32(i)).ToArray();
    }
    override public string Export()
    {
        string s = "";
        foreach (int i in Courses) s += ' ' + Convert.ToString(i);
        return "Teacher " + Convert.ToString(ID) + ' ' + Name + ' ' + Convert.ToString(Experience) + s;
    }
}

class Course : Factory
{
    public int[] Students { get; set; }
    public int Teacher { get; set; }
    public Course(int ID, string Name, int[] Students, int Teacher) : base(ID, Name)
    {
        this.Teacher = Teacher;
        this.Students = Students;
    }
    public Course(string input) : base(Convert.ToInt32(input.Split(' ')[0]), input.Split(' ')[1])
    {
        Teacher = Convert.ToInt32(input.Split(' ')[2]);
        Students = new int[0];
        foreach (string i in input.Split(' ').Skip(3)) Students = Students.Append(Convert.ToInt32(i)).ToArray();
    }
    override public string Export()
    {
        string s = "";
        foreach (int i in Students) s += ' ' + Convert.ToString(i);
        return "Course " + Convert.ToString(ID) + ' ' + Name + ' ' + Convert.ToString(Teacher) +  s;
    }
}