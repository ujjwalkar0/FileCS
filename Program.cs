using System.IO;
using System.Runtime.Serialization.Formatters.Binary;  

[Serializable]  
class Student  
{  
    public int rollno;  
    public string name;  
    public Student(int rollno, string name)  
    {  
        this.rollno = rollno;  
        this.name = name;  
    }  
}  

class Hello{
    public static void Main(string[] args){
        FileStream f = new FileStream("hello.txt", FileMode.OpenOrCreate);
        f.WriteByte(255);

        StreamWriter s = new StreamWriter(f);

        StreamReader r = new StreamReader(f);

        s.WriteLine("Hello");

        System.Console.WriteLine(r.ReadLine());

            using (TextWriter writer = File.CreateText("f.txt"))  
            {  
                writer.WriteLine("Hello C#");  
                writer.WriteLine("C# File Handling by JavaTpoint");  
            }  

            using (TextReader tr = File.OpenText("f.txt"))  
            {  
                Console.WriteLine(tr.ReadToEnd());  
            }  

            using (BinaryWriter writer = new BinaryWriter(File.Open("binary.dat", FileMode.Create)))  
            {  
                writer.Write(2.5);  
                writer.Write("this is string data");  
                writer.Write(true);  
            }  

            using (BinaryReader read = new BinaryReader(File.Open("binary.dat", FileMode.Open)))  
            {  
                Console.WriteLine("Double Value : " + read.ReadDouble());  
                Console.WriteLine("String Value : " + read.ReadString());  
                Console.WriteLine("Boolean Value : " + read.ReadBoolean());  
            }  

            StringWriter str = new StringWriter();  
            str.WriteLine("Hello, this message is read by StringReader class");  
            str.Close();  

            StringReader reader = new StringReader(str.ToString());  

            while (reader.Peek() > -1)  
            {  
                Console.WriteLine(reader.ReadLine());  
            }  

            FileInfo file = new FileInfo("binary.txt");  
            System.Console.WriteLine(file.CreationTime);
            System.Console.WriteLine(file.DirectoryName);
            System.Console.WriteLine(file.GetHashCode());
            // System.Console.WriteLine(file);
        s.Close();
        f.Close();

        FileStream stream = new FileStream("student.bin", FileMode.OpenOrCreate);  
        BinaryFormatter formatter=new BinaryFormatter();  
        
        if (File.Exists("student.bin")){
            Student u=(Student)formatter.Deserialize(stream);  
            Console.WriteLine("Rollno: " + u.rollno);  
            Console.WriteLine("Name: " + u.name);  
        }
        else{
            Student t = new Student(101, "sonoo");  
            formatter.Serialize(stream, t);  
        }  

        stream.Close();  

    }
}