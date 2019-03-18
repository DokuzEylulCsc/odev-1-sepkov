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
            oyun.TakımOlustur(t1);
            oyun.TakımOlustur(t2);
            oyun.HaritaYerleşimi(t1, t2);

            /*
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(t1.Birlik[i].hangiTakım);
                Console.WriteLine(t2.Birlik[i].hangiTakım);
            }
            */
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



            //Oyun başlasın
            bool herkesÖlüMü = false;
            Asker asker;
            Random rd = new Random();
            while (true)
            {
                for (int i = 0; i < 7; i++)
                {
                    if(t1.Birlik[i].sağlıkPuanı == 0)
                    t1.Birlik[i].yaşıyorMu = false;
                }
                asker = t1.Birlik[rd.Next(7)];//Her seferinde takım 1in rastgele bir askeri işlem yapacak.
                oyun.İşlemYap(asker, t1, t2, asker.Koordinat);
                asker = t2.Birlik[rd.Next(7)];//Her seferinde takım 2nin rastgele bir askeri işlem yapacak.
                oyun.İşlemYap(asker, t1, t2, asker.Koordinat);
                //TODO: Debug amaçlı silmeyi unutma
                foreach (var item in t2.Birlik)
                {
                    Console.WriteLine(item.sağlıkPuanı);
                }
                for (int i = 0; i < 7; i++)
                {
                    if (t1.Birlik[i].sağlıkPuanı != 0)
                        break;
                    else if(i == 6)
                        herkesÖlüMü = true;
                }
                for (int i = 0; i < 7; i++)
                {
                    if (t1.Birlik[i].sağlıkPuanı != 0)
                        break;
                    else if(i == 6)
                        herkesÖlüMü = true;
                }
                if (herkesÖlüMü)
                break;
            }

            
            Console.Read();
        }
    }
}
