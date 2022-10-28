using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Template.DAL;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            C1 c1 = new C1();
            Program p=new Program();
            Action action = new Action(p.Method1);
            action += p.Method2;
            action += p.Method3;
            action += p.Method4;

            var a = action.GetInvocationList();
            a[1].DynamicInvoke();
            Console.ReadLine();
        }

        public void Method1() {
            Console.WriteLine("这是第一个方法");
        }
        public void Method2() {
            Console.WriteLine("这是第二个方法");
        }
        public void Method3() {
            Console.WriteLine("这是第三个方法");
        }
        public void Method4() {
            Console.WriteLine("这是第四个方法");
        }
    }
    public class C1
    {
        public C1() {
            IPAddress address = new IPAddress(new byte[] { 127, 0, 0, 1 });
            var b=address.ToString();
            TcpClient client = new TcpClient(b,502);
        }
        
    }

}
