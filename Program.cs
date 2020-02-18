using System;
using System.Net.Http;
using System.Linq;

namespace dowhile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            int i = 0;
            do
            {
                i++;
                Console.WriteLine($"{i}");
            }while(i < 10);
            Console.WriteLine("end");
        }

        public static async void ReadAsync(HttpResponseMessage msg)
        {
            using (var stream = await msg.Content.ReadAsStreamAsync()) 
            {
                var totalRead = 0;
                var buffer = new byte[1024];
                var isMoreRead = true;
                
                do 
                {
                    var read = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (read == 0)
                    {
                        isMoreRead = false;
                    }                        
                    else
                    {
                        var data = new byte[read];
                        buffer.ToList().CopyTo(0, data, 0, read);
                        totalRead += read;
                    }
                }while(isMoreRead);
            }
        }
    }    
}
