using Facs;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS485
{
    class Program
    {
        static void Main(string[] args)
        {
            string x;
            int Indirizzo;
            int Comando;
            int Temperatura;
            char[] c = new char[4];
            SerialPort sp = new SerialPort("COM4");
            sp.DataReceived += (s, e) =>
            {
                x = sp.ReadLine();
                c = x.ToCharArray();
                if (c != null)
                {
                    if (c[0] != '\0' && c[1] != '\0' && c[2] != '\0' && c[3] != '\0')
                    {
                        Indirizzo = int.Parse(c[0].ToString());
                        Comando = int.Parse(c[1].ToString());
                        Temperatura = int.Parse(c[2].ToString() + int.Parse(c[3].ToString()));
                        Console.Write("Camera: " + Indirizzo);
                        Console.Write("Comando: " + Comando);
                        Console.WriteLine("Temperatura: " + Temperatura);
                        if (Comando == 1)
                        {
                            facUsers.setTemperatureCamera(Indirizzo, Temperatura);
                        }

                    }
                }
            };
            sp.DataBits = 8;
            sp.Parity = Parity.None;
            sp.StopBits = StopBits.One;
            sp.BaudRate = 9600;
            sp.Open();
            Console.WriteLine("Invio/Gestione dati in corso...");
            Console.WriteLine("CTRL + C per fermare l'esecuzione");
            Console.ReadLine();
            sp.Close();
        }
    }
}
