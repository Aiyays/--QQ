using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatService;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatingDatabase.DeleteFriend("4","5");
            Console.ReadLine();
        }
    }
}
