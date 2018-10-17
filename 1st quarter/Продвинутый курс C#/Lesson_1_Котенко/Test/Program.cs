using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(-5, 5);
            Vector v2 = (Vector)10;
            Vector v3 = v1 + v2;

            Console.WriteLine($"v1.x={v1.X} v1.y={v1.Y}");
            Console.WriteLine($"v2.x={v2.X} v2.y={v2.Y}");
            Console.WriteLine($"(v1+v2):{v3}");
            Console.WriteLine($"-(v1+v2):{-v3}");
            Console.ReadKey();
        }
    }
}
