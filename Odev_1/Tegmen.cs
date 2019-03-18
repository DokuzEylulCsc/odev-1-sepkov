using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Odev_1
{
    class Tegmen : Asker
    {
        public override void AteşEt(List<Asker> düşman,StreamWriter streamWriter)
        {
            if (yaşıyorMu)
            {
                string takım;
                takım = hangiTakım ? "Takım 1" : "Takım 2";
                int[] hasar = { 10, 20, 25 };
                int verilecekHasar = hasar[rd.Next(3)];
                foreach (var asker in düşman)
                {
                    Console.WriteLine(takım + "Teğmen'i düşman" + asker.GetType().Name + "askerine ateş etti. Hasar:" + verilecekHasar);
                    streamWriter.WriteLine(takım + "Teğmen'i düşman" + asker.GetType().Name + "askerine ateş etti. Hasar:" + verilecekHasar);
                    if (asker.sağlıkPuanı < verilecekHasar)
                        asker.sağlıkPuanı = 0;
                    else
                        asker.sağlıkPuanı = asker.sağlıkPuanı - verilecekHasar;
                    if (asker.sağlıkPuanı <= 0)
                    {
                        asker.yaşıyorMu = false;
                        streamWriter.WriteLine("ve öldürdü");
                        Console.WriteLine("ve öldürdü");
                    }
                }
            }
        }

        public override void Bekle(StreamWriter streamWriter)
        {
            string takım;
            takım = hangiTakım ? "Takım 1" : "Takım 2";
            streamWriter.WriteLine(takım + "Teğmen'i bekledi");
        }

        public override void HareketEt(StreamWriter streamWriter)
        {
            string takım;
            takım = hangiTakım ? "Takım 1" : "Takım 2";
            int gidilecekKonum = rd.Next(3);
            if (yaşıyorMu)
            {
                if (Koordinat.ReturnY() > 0 && gidilecekKonum == 0)//Yukarı git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() - 1);
                    streamWriter.WriteLine(takım + "Teğmen'i yukarı hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnY() < 15 && gidilecekKonum == 1)//Aşağı git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() + 1);
                    streamWriter.WriteLine(takım + "Teğmen'i aşağı hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnX() > 0 && gidilecekKonum == 2)//Sağa git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY());
                    streamWriter.WriteLine(takım + "Teğmen'i sağa hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnX() < 15 && gidilecekKonum == 3)//Sola git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() + 1);
                    streamWriter.WriteLine(takım + "Teğmen'i sola hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
            }
        }

    }
}
