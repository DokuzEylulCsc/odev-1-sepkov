using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Odev_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter streamWriter = File.AppendText("Kayıt.txt");
            streamWriter.WriteLine("Oyun başladı");
            Console.WriteLine("Oyun başladı. Askerler birbirini bulup ateş edene kadar bir süre ekran boş olabilir.");
            //Oyun kurulumu
            Random rd = new Random();
            Ermeydani oyun = new Ermeydani();
            Takim t1 = new Takim();
            Takim t2 = new Takim();
            oyun.TakımOlustur(t1);
            oyun.TakımOlustur(t2);
            oyun.HaritaYerleşimi(t1, t2);

            for (int i = 0; i < 7; i++)
            {
                streamWriter.WriteLine("Takım 1 Koordinatları -> " + t1.Birlik[i].Koordinat.ReturnX() + " " + t1.Birlik[i].Koordinat.ReturnY());
            }
            for (int i = 0; i < 7; i++)
            {
                streamWriter.WriteLine("Takım 2 Koordinatları -> " + t2.Birlik[i].Koordinat.ReturnX() + " " + t2.Birlik[i].Koordinat.ReturnY());
            }
            System.Threading.Thread.Sleep(500);


            //Oyun başlasın
            bool herkesÖlüMü = false;
            Asker asker;
            while (true)
            {
                for (int i = 0; i < 7; i++)
                {
                    if(t1.Birlik[i].sağlıkPuanı == 0)
                    t1.Birlik[i].yaşıyorMu = false;
                }
                asker = t1.Birlik[rd.Next(7)];//Her seferinde takım 1in rastgele bir askeri işlem yapacak.
                oyun.İşlemYap(asker, t1, t2, asker.Koordinat,streamWriter);
                asker = t2.Birlik[rd.Next(7)];//Her seferinde takım 2nin rastgele bir askeri işlem yapacak.
                oyun.İşlemYap(asker, t1, t2, asker.Koordinat,streamWriter);
                //Takımların can değerleri sadece Kayıt.txt'ye kaydediliyor.
                for (int i = 0; i < 7; i++)
                {
                    streamWriter.WriteLine("Takım 1 " + t1.Birlik[i].GetType().Name + " Can " + t1.Birlik[i].sağlıkPuanı);
                }
                for (int i = 0; i < 7; i++)
                {
                    streamWriter.WriteLine("Takım 2" + t1.Birlik[i].GetType().Name + " Can " + t2.Birlik[i].sağlıkPuanı);

                }

                for (int i = 0; i < 7; i++)
                {
                    if (t1.Birlik[i].sağlıkPuanı > 0)
                        break;
                    else if(i == 6)
                    {
                        herkesÖlüMü = true;
                        Console.WriteLine("Takım 1 öldü");
                        streamWriter.WriteLine("Takım 1 öldü");
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    if (t1.Birlik[i].sağlıkPuanı > 0)
                        break;
                    else if (i == 6)
                    {
                        herkesÖlüMü = true;
                        Console.WriteLine("Takım 2 öldü");
                        streamWriter.WriteLine("Takım 2 öldü");
                    }
                }
                if (herkesÖlüMü)
                break;
                System.Threading.Thread.Sleep(60);
            }


            Console.Read();
        }
    }
}
