using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Ermeydani
    {//Oyun mantığı burada işleniyor.
        static bool takımSeçimi = false;

        Bolge[,] harita = new Bolge[16, 16];

        public Bolge[,] Harita { get { return harita; } set { harita = value; } }
        
        public void TakımOlustur(Takim takım)
        {
            int rastgele, erSayisi = 7;
            Random rd = new Random();
            //Yüzbaşı olma olasılığı
            rastgele = rd.Next(2);
            if(rastgele == 1)
            {
                takım.Birlik[0] = new Yuzbasi();
                erSayisi--;
            }
            //Teğmen olma olasılığı
            takım.Birlik[7 - erSayisi] = new Tegmen();
            erSayisi--;
            rastgele = rd.Next(2);
            if(rastgele == 1)
            {
                takım.Birlik[7 - erSayisi] = new Tegmen();
                erSayisi--;
            }
            //Geri kalanı erle doldur
            for (int i = 7 - erSayisi; i < 7; i++)
            {
                takım.Birlik[i] = new Er();
            }
            for (int i = 0; i < 7; i++)
            {
                takım.Birlik[i].hangiTakım = takımSeçimi;
                takım.Birlik[i].sağlıkPuanı = 100;
                takım.Birlik[i].yaşıyorMu = true;
            }
            takımSeçimi = true;
        }
        public void HaritaYerleşimi(Takim takım1,Takim takım2)
        {
            //Takım1 haritanın sol alt köşesinde, Takım2 ise sağ üst köşede yer alacak.
            Random rd = new Random();
            bool tekrarOluştur = false;
            int x, y;
            for (int i = 0; i < 7; i++)
            {
                Bolge b1;
                Bolge b2;
                do {
                    x = rd.Next(5);
                    y = rd.Next(5);
                    b1 = new Bolge(x + 10, y);
                    b2 = new Bolge(x, y + 10);
                    for (int j = 0; j < i; j++)
                    {
                        if ((takım1.Birlik[j].Koordinat.ReturnX() == b1.ReturnX() && takım1.Birlik[j].Koordinat.ReturnY() == b1.ReturnY()) || (takım2.Birlik[j].Koordinat.ReturnX() == b2.ReturnX() && takım2.Birlik[j].Koordinat.ReturnY() == b2.ReturnY()))
                        {
                            tekrarOluştur = true;
                            break;
                        }
                        tekrarOluştur = false;
                    }
                } while (tekrarOluştur);
                takım1.Birlik[i].Koordinat = b1;
                takım2.Birlik[i].Koordinat = b2;
            }
        }
        public List<Asker> BölgedekiDüşmanlar(Asker ateşEdecekAsker,Takim düşmanTakım,Bolge merkezKonum)
        {//Verilen bölge içindeki askerleri tespit eden fonksiyon.
            List<Asker> düşmanlar = new List<Asker>();
            int rütbe = 0;//Askerin rütbesine göre kaç blok uzaktaki düşman olduğu tespit edilecek.
            if (ateşEdecekAsker is Er)
            {
                rütbe = 2;
            }
            else if (ateşEdecekAsker is Tegmen)
            {
                rütbe = 3;
            }
            else rütbe = 4;
            for (int i = 0; i < 7; i++)
            {
                if(düşmanTakım.Birlik[i].Koordinat.ReturnX() - merkezKonum.ReturnX() < rütbe && düşmanTakım.Birlik[i].Koordinat.ReturnX() - merkezKonum.ReturnX() > -rütbe)
                if(düşmanTakım.Birlik[i].Koordinat.ReturnY() - merkezKonum.ReturnY() < rütbe && düşmanTakım.Birlik[i].Koordinat.ReturnY() - merkezKonum.ReturnY() > -rütbe)
                    {
                        if(düşmanTakım.Birlik[i].yaşıyorMu)
                        düşmanlar.Add(düşmanTakım.Birlik[i]);
                        Console.WriteLine("Tespit edilen düşman sayısı" + düşmanlar.Count.ToString());
                    }
            }
            return düşmanlar;
        }
        public void İşlemYap(Asker asker,Takim takım1,Takim takım2,Bolge merkezBolge)
        {//30 ateş,60 hareket, 10 bekleme
            Random rd = new Random();
            double işlem = rd.NextDouble();
            if (işlem < 0.3)
            {
                if(asker.hangiTakım == takım1.Birlik[0].hangiTakım)
                    asker.AteşEt(BölgedekiDüşmanlar(asker, takım2, asker.Koordinat));
                else
                    asker.AteşEt(BölgedekiDüşmanlar(asker, takım1, asker.Koordinat));
            }
            else if (işlem < 0.9)
            {
                asker.HareketEt();
            }
            else
            {
                string takım;
                takım = asker.hangiTakım ? "Takım 1" : "Takım 2";
                Console.WriteLine(takım + " askeri bekledi");
                asker.Bekle();
            }
        }
    }
}
