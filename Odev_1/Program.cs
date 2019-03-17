using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Oyun kurulumu
            Ermeydani oyun = new Ermeydani();
            Takim t1 = new Takim();
            Takim t2 = new Takim();
            oyun.takımOlustur(t1);
            oyun.takımOlustur(t2);
            oyun.haritaYerleşimi(t1, t2);


            /*
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(t1.Birlik[i].hangiTakım);
                Console.WriteLine(t2.Birlik[i].hangiTakım);
            }
            */
            //Oyun başlasın
            /*
            Console.WriteLine("Takım 1 Konumları");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("X: " + t1.Birlik[i].Koordinat.ReturnX() + ", Y:" + t1.Birlik[i].Koordinat.ReturnY());
            }
            Console.WriteLine("Takım 2 Konumları");

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("X: " + t2.Birlik[i].Koordinat.ReturnX() + ", Y:" + t2.Birlik[i].Koordinat.ReturnY());
            }*/
            t1.Birlik[1].AteşEt(oyun.askerVarsaAteşEt(t2,t1.Birlik[1].Koordinat));
            foreach (var item in t2.Birlik)
            {
                Console.WriteLine(item.sağlıkPuanı);
            }
            Console.Read();
        }
    }
}
