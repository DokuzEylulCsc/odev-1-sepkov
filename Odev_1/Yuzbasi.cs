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
                Random rd = new Random();
                int[] hasar = { 15, 25, 40 };
                int verilecekHasar = hasar[rd.Next(3)];
                foreach (var asker in düşman)
                {
                    if (asker.sağlıkPuanı > verilecekHasar)
                        asker.sağlıkPuanı = 0;
                    else
                        asker.sağlıkPuanı = asker.sağlıkPuanı - verilecekHasar;
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
            Random rd = new Random();
            int gidilecekKonum = rd.Next(3);
            Bolge gidilecekBolge;
            if (yaşıyorMu)
            {
                if (Koordinat.ReturnY() != 0 && gidilecekKonum == 0)//Yukarı git
                {
                    gidilecekBolge = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() - 1);
                    Console.WriteLine(takım + "Yüzbaşı'sı yukarı hareket etti.");
                }
                else if (Koordinat.ReturnY() != 15 && gidilecekKonum == 1)//Aşağı git
                {
                    gidilecekBolge = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() + 1);
                    Console.WriteLine(takım + "Yüzbaşı'sı aşağı hareket etti.");
                }
                else if (Koordinat.ReturnX() != 15 && gidilecekKonum == 0)//Sağa git
                {
                    gidilecekBolge = new Bolge(Koordinat.ReturnX() - 1, Koordinat.ReturnY());
                    Console.WriteLine(takım + "Yüzbaşı'sı sağa hareket etti.");
                }
                else if (Koordinat.ReturnX() != 0 && gidilecekKonum == 1)//Sola git
                {
                    gidilecekBolge = new Bolge(Koordinat.ReturnX() + 1, Koordinat.ReturnY());
                    Console.WriteLine(takım + "Yüzbaşı'sı sola hareket etti.");
                }
                else if (Koordinat.ReturnY() != 0 && Koordinat.ReturnX() != 0 && gidilecekKonum == 0)//Yukarı-sola git
                {
                    gidilecekBolge = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() - 1);
                    Console.WriteLine(takım + "Yüzbaşı'sı yukarı sola hareket etti.");
                }
                else if (Koordinat.ReturnY() != 0 && Koordinat.ReturnX() != 15 && gidilecekKonum == 1)//Yukarı-sağa git
                {
                    gidilecekBolge = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() + 1);
                    Console.WriteLine(takım + "Yüzbaşı'sı yukarı-sağa hareket etti.");
                }
                else if (Koordinat.ReturnY() != 15 && Koordinat.ReturnX() != 0 && gidilecekKonum == 0)//Aşağı-sola git
                {
                    gidilecekBolge = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() - 1);
                    Console.WriteLine(takım + "Yüzbaşı'sı aşağı-sola hareket etti.");
                }
                else if (Koordinat.ReturnY() != 15 && Koordinat.ReturnX() != 15 && gidilecekKonum == 1)//Aşağı-sağa git
                {
                    gidilecekBolge = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() + 1);
                    Console.WriteLine(takım + "Yüzbaşı'sı aşağı-sağa hareket etti.");
                }
            }
        }

    }
}
