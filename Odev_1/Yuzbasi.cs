﻿using System;
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

        public override void HareketEt(Bolge[] olasıKonumlar)
        {
            if (yaşıyorMu)
            {

            }
        }
        
    }
}
