using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    abstract class Asker
    {
        private Bolge koordinat;
        public Bolge Koordinat { get { return koordinat; } set { koordinat = value; } }
        public bool yaşıyorMu;
        public int sağlıkPuanı;
        public bool hangiTakım;//True ise takım 1, False ise takım 2
        public Random rd = new Random(); //Full random sayılar için


        //Abstract sınıfların implementasyonları çoçuk sınıflarda gerçekleştirilmelidir.
        public abstract void HareketEt();

        public abstract void Bekle();

        public abstract void AteşEt(List<Asker> düşman);


        // ..... //

    }
}
