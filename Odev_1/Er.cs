using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Er : Asker
    {
        public override void AteşEt(List<Asker> düşman)
        {
            if (yaşıyorMu)
            {
                string takım;
                takım = hangiTakım ? "Takım 1" : "Takım 2";
                Console.WriteLine(takım + "Er'i ateş etti");
                Random rd = new Random();
                int[] hasar = { 10, 15, 20 };
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
            //EMPTYYYYYYYYY
        }

        public override void HareketEt()
        {
            string takım;
            takım = hangiTakım ? "Takım 1" : "Takım 2";
            Random rd = new Random();
            bool yukarı = rd.Next(2) == 1 ? true : false;
            if (yaşıyorMu)
            {
                if (Koordinat.ReturnY() > 0 && yukarı == true)//Yukarı git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() - 1);
                    Console.WriteLine(takım + "Er'i yukarı hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnX() > 0 && yukarı == true)//Mümkün değilse sola git.
                {
                    Koordinat = new Bolge(Koordinat.ReturnX() - 1, Koordinat.ReturnY());
                    Console.WriteLine(takım + "Er'i sola hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                if (Koordinat.ReturnY() < 15 && yukarı == false)//Aşağı git
                {
                    Koordinat = new Bolge(Koordinat.ReturnX(), Koordinat.ReturnY() + 1);
                    Console.WriteLine(takım + "Er'i aşağı hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
                else if (Koordinat.ReturnX() < 15 && yukarı == false)//Mümkün değilse sağa git.
                {
                    Koordinat = new Bolge(Koordinat.ReturnX() + 1, Koordinat.ReturnY());
                    Console.WriteLine(takım + "Er'i sağa hareket etti." + " Koordinatları" + Koordinat.ReturnX().ToString() + " " + Koordinat.ReturnY().ToString());
                }
            }
        }
        
    }
}
