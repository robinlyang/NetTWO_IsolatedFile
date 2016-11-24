using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage; //created files for each user

namespace NetTWO_IsolatedFile
{
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

            
        }
    }
}
