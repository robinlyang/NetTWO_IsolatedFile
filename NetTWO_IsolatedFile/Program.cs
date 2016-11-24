using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage; //created files for each user
using System.Runtime.Serialization; //used for Serialization
using System.Runtime.Serialization.Formatters.Binary; //used for Serialization

namespace NetTWO_IsolatedFile
{
    //Serializable class
    [Serializable]
    class emp
    {
        public string name;
        public double salary;
    }
    class Program
    {
        static void Main(string[] args)
        {
            IsolatedStorageFileStream f = new IsolatedStorageFileStream("abc", FileMode.Create);
            //do NOT give a directory for file name
            StreamWriter w = new StreamWriter(f);
            w.WriteLine("password");
            w.WriteLine("menu");
            w.Close();
            f.Close();

            //read back
            f = new IsolatedStorageFileStream("abc", FileMode.Open);
            StreamReader r = new StreamReader(f);
            string data = r.ReadLine();
            Console.WriteLine(data);
            r.Close();
            f.Close();

            Console.ReadLine();

            //Serialization Example
            emp e = new emp();
            emp fe = new emp();
            e.name = "Bob";
            e.salary = 80000;
            //copy one class to another
            //you must use a memory file
            MemoryStream m = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(m, e); //turns a class into a bit stream
            m.Seek(0, 0); //like rewind memory
            fe = (emp)b.Deserialize(m);
            e.name = "Robert";
            Console.WriteLine(fe.name);



            Console.ReadLine();
        }
    }
}
