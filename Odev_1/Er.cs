using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Odev_1
{
    class Er : Asker
    {
        public override void AteşEt(List<Asker> düşman,StreamWriter streamWriter)
        {
            if (yaşıyorMu)
            {
                string takım;
                takım = hangiTakım ? "Takım 1" : "Takım 2";
                int[] hasar = { 10, 15, 20 };
                int verilecekHasar = hasar[rd.Next(3)];
                foreach (var asker in düşman)
                {
                    Console.WriteLine(takım + "Er'i düşman" + asker.GetType().Name + "askerine ateş etti. Hasar:" + verilecekHasar);
                    streamWriter.WriteLine(takım + "Er'i düşman" + asker.GetType().Name + " askerine ateş etti. Hasar:" + verilecekHasar);
                    if (asker.sağlıkPuanı < verilecekHasar)
                        asker.sağlıkPuanı = 0;
                    else
                        asker.sağlıkPuanı = asker.sağlıkPuanı - verilecekHasar;
                    if(asker.sağlıkPuanı <= 0)
                    {
                        asker.yaşıyorMu = false;
                        streamWriter.WriteLine("ve öldürdü");
                        Console.WriteLine(" ve öldürdü");
                    }
                }
            }

        }

        public override void Bekle(StreamWriter streamWriter)
        {
            string takım;
            takım = hangiTakım ? "Takım 1" : "Takım 2";
            streamWriter.WriteLine(takım + "Er'i bekledi");
        }

        public override void HareketEt(StreamWriter streamWriter)
        {
            string takım;
            takım = hangiTakım ? "Takım 1" : "Takım 2";
            bool yukarı = rd.Next(2) == 1 ? true : false;
            if (yaşıyorMu)
            {
                if (Koordinat.ReturnY() > 0 && yukarı == true)//Yukarı git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() - 1);
                    streamWriter.WriteLine(takım + "Er'i yukarı hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnX() < 15 && yukarı == true)//Mümkün değilse sağa git.
                {
                    Koordinat = new Bolge(Koordinat.ReturnX() + 1, Koordinat.ReturnY());
                    streamWriter.WriteLine(takım + "Er'i sola hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                if (Koordinat.ReturnY() < 15 && yukarı == false)//Aşağı git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() + 1);
                    streamWriter.WriteLine(takım + "Er'i aşağı hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnX() > 0 && yukarı == false)//Mümkün değilse sola git.
                {
                    Koordinat = new Bolge(Koordinat.ReturnX() + 1, Koordinat.ReturnY());
                    streamWriter.WriteLine(takım + "Er'i sağa hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
            }
        }
        
    }
}
