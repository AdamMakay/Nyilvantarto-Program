using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public class Nyilvantarto
    {
        //kor, nev, szolgalati ido, fizetes, szakterulet

        private string kor;
        private string nev;
        private string szolgalatiIdo;
        private string fizetes;
        private string szakterulet;


        public Nyilvantarto(string nev, string kor, string szolgalatiIdo, string fizetes, string szakterulet)
        {
            this.kor = kor;
            this.nev = nev;
            this.szolgalatiIdo = szolgalatiIdo;
            this.fizetes = fizetes;
            this.szakterulet = szakterulet;

        }


        public override string ToString()
        {
            return nev + ";" + kor + ";" + szolgalatiIdo + ";" + fizetes + ";" + szakterulet;
        }
    }




    
}
