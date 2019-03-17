using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Tegmen : Asker
    {
        public override void AteşEt(List<Asker> düşman)
        {
            Random rd = new Random();
            int[] hasar = { 10, 20, 25 };
            foreach (var asker in düşman)
            {
                asker.sağlıkPuanı = asker.sağlıkPuanı - hasar[rd.Next()];
            }
        }

        public override void Bekle()
        {
            //EMPTYYYYYY
        }

        public override void HareketEt(Bolge[] olasıKonumlar)
        {

        }

    }
}
