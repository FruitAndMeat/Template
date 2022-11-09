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
            //byte0=0x4B   byte1=0x12   byte2=0xAF   解析获得的y1=302   y2=701
            byte[] buffer = new byte[] { 0xFF, 0X33, 0XFF }; //01001011 xx01xx10 10101111 

            int y1 = (buffer[0] * 4) + (buffer[1] & 0x03);
            int y2 = (buffer[2] * 4) + ((buffer[1] >> 4) & 0x03);

            Console.WriteLine($"Y1:{y1}          Y2:{y2}");
            Console.Read();
            
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
            //TcpClient client = new TcpClient(b,502);
        }
        public void c2() {
            throw new Exception("丢出异常");
        }
    }

}
