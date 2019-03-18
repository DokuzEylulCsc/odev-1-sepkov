using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Yuzbasi : Asker
    {
        public override void AteşEt(List<Asker> düşman)
        {
            if (yaşıyorMu)
            {
                string takım;
                takım = hangiTakım ? "Takım 1" : "Takım 2";
                Console.WriteLine(takım + "Yüzbaşı'sı ateş etti");
                int[] hasar = { 15, 25, 40 };
                int verilecekHasar = hasar[rd.Next(3)];
                foreach (var asker in düşman)
                {
                    Console.WriteLine("Düşman Canı: " + asker.sağlıkPuanı.ToString());
                    if (asker.sağlıkPuanı > verilecekHasar)
                        asker.sağlıkPuanı = 0;
                    else
                        asker.sağlıkPuanı = asker.sağlıkPuanı - verilecekHasar;
                    Console.WriteLine("Düşman Canı: " + asker.sağlıkPuanı.ToString());
                }
            }
        }

        public override void Bekle()
        {
            //EMPTYYYYY
        }

        public override void HareketEt()
        {
            string takım;
            takım = hangiTakım ? "Takım 1" : "Takım 2";
            int gidilecekKonum = rd.Next(7);
            if (yaşıyorMu)
            {
                if (Koordinat.ReturnY() > 0 && gidilecekKonum == 0)//Yukarı git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() - 1);
                    Console.WriteLine(takım + "Yüzbaşı'sı yukarı hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnY() < 15 && gidilecekKonum == 1)//Aşağı git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() + 1);
                    Console.WriteLine(takım + "Yüzbaşı'sı aşağı hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnX() < 15 && gidilecekKonum == 2)//Sağa git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX() + 1, Koordinat.ReturnY());
                    Console.WriteLine(takım + "Yüzbaşı'sı sağa hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnX() > 0 && gidilecekKonum == 3)//Sola git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX() - 1, Koordinat.ReturnY());
                    Console.WriteLine(takım + "Yüzbaşı'sı sola hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnY() > 0 && Koordinat.ReturnX() > 0 && gidilecekKonum == 4)//Yukarı-sola git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX() - 1, Koordinat.ReturnY() - 1);
                    Console.WriteLine(takım + "Yüzbaşı'sı yukarı sola hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnY() > 0 && Koordinat.ReturnX() < 15 && gidilecekKonum == 5)//Yukarı-sağa git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX() + 1, Koordinat.ReturnY() - 1);
                    Console.WriteLine(takım + "Yüzbaşı'sı yukarı-sağa hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnY() < 15 && Koordinat.ReturnX() > 0 && gidilecekKonum == 6)//Aşağı-sola git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX() - 1, Koordinat.ReturnY() + 1);
                    Console.WriteLine(takım + "Yüzbaşı'sı aşağı-sola hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnY() < 15 && Koordinat.ReturnX() < 15 && gidilecekKonum == 7)//Aşağı-sağa git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX() + 1, Koordinat.ReturnY() + 1);
                    Console.WriteLine(takım + "Yüzbaşı'sı aşağı-sağa hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
            }
        }

    }
}
