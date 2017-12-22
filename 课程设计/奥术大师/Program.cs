using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatService;
using Client;
using System.Diagnostics;

namespace 奥术大师
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string[]> a = new List<string[]>();

            string[] ad = new string[] { "张", "王", "李", "赵", "孙" };
            string[] bd = new string[] { "123456", "aaa", "王舒婷" };
            string[] bd1 = new string[] { "张", "321", "啊这使得", "强无敌" };
            string[] bd12 = new string[] { "王", "321", "啊这使得", "强无敌" };
            string[] bd13 = new string[] { "张", "321", "啊这使得", "强无敌" };
            string[] bd14 = new string[] { "李", "321", "啊这使得", "强无敌" };
            string[] bd15 = new string[] { "赵", "321", "啊这使得", "强无敌" };
            string[] bd16 = new string[] { "孙", "311","啊的这使得", "强无敌" };
            a.Add(ad);
            a.Add(bd);
            a.Add(bd1);
            a.Add(bd13);
            a.Add(bd14);

            a.Add(bd15);
            a.Add(bd16);
            string c = ProcessingCenter.ObjectToJson(a);
            string[] b = new string[] { "L","true", c };
            string e= ProcessingCenter.ObjectToJson(b);
            Console.WriteLine(e);
            Debug.Print(e);
            Console.ReadLine();
            
        }
    }
    /*
          List<string[]> a = new List<string[]>();

            string[] ad = new string[] {"张","王","李","赵","孙"};
            string[] bd = new string[] { "123456","aaa","王舒婷"};
            string[] bd1 = new string[] { "张", "321", "啊这使得", "强无敌" };
            string[] bd12 = new string[] { "王", "321", "啊这使得", "强无敌" };
            string[] bd13 = new string[] { "张", "321", "啊这使得", "强无敌" };
            string[] bd14 = new string[] { "李", "321", "啊这使得", "强无敌" };
            string[] bd15 = new string[] { "赵", "321", "啊这使得", "强无敌" };
            string[] bd16 = new string[] { "张", "31221", "啊的这使得", "强无敌" };
            a.Add(ad);
            a.Add(bd);
            a.Add(bd1);
            a.Add(bd13);
            a.Add(bd14);

            a.Add(bd15);
            a.Add(bd16);
         */
    class pro
    {
        private static string a="";
        public  static string  A
        {
            get {
                return a;
            }
            set
            {
                a = value;
            }
        }
    }
}
