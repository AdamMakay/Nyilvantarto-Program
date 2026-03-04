

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Nyilvantarto szemelyek;

            if (!File.Exists("szemelyek.txt"))
            {
                File.WriteAllText("szemelyek.txt", "Név;Kor;Szolgalati ido;Fizetes;Szakterulet\n");
            }
            StreamWriter sw = new StreamWriter("szemelyek.txt", true);
   
            Console.Write("Melyik opciot valasztja: \n1: Adatok irasa \n2: Adatok kiirasa\n3: Adatok torlese\n4: Statisztika\n5: Kilepes");
            string valasztas = Console.ReadLine();
            if (valasztas == "1")
            {
                szemelyek = AdatokIrasa();
                sw.WriteLine(szemelyek);
                sw.Close();
            }
            else if (valasztas == "2")
            {
                sr_Readline();
            }
             else if (valasztas == "3")
            {
                Console.Write("1: 1 Szemely adatainak a torlese\n2: osszes adat torlese");
                string torles = Console.ReadLine();
                if(torles == "1")
                {
                    Console.Write("Adja meg a szemely nevét akinek a adatait torolni szeretné: ");
                    string nev = Console.ReadLine();
                    SzemelzAdatainakTorlese(nev);
                }
                else if (torles == "2")
                {
                    string elsoSor = File.ReadLines("szemelyek.txt").First();
                    File.WriteAllText("szemelyek.txt", elsoSor+ "\n");

                }
                else
                {
                    Console.WriteLine("Hibás opció!");
                }
            }
             else if (valasztas == "4")
            {
                Statisztika();
            }
             else if (valasztas == "5")
            {
                Console.WriteLine("Viszontlatasra!");
            }
             else
            {
                Console.WriteLine("Hibás opció!");
            }






        }


        //Név;Kor;Szolgalati ido;Fizetes;Szakterulet
        private static void Statisztika()
        {
           List<string> AdatokListaja = File.ReadAllLines("szemelyek.txt").ToList();
           int ossz = 0;
           int osszEletkor = 0;
           int osszSzolgalatiIdo = 0;
           int osszFizetes = 0;

            for (int i = 1; i < AdatokListaja.Count; i++) // 1-től indul
            {
                string[] adatok = AdatokListaja[i].Split(';');

                ossz++;
                osszEletkor += int.Parse(adatok[1]);
                osszSzolgalatiIdo += int.Parse(adatok[2]);
                osszFizetes += int.Parse(adatok[3]);
            }

            Console.WriteLine($"Átlag életkor: {osszEletkor / ossz}");
            Console.WriteLine($"Átlag szolgálati idő: {osszSzolgalatiIdo / ossz}");
            Console.WriteLine($"Átlag fizetés: {osszFizetes / ossz}");
        }



        private static void SzemelzAdatainakTorlese(string nev)
        {
            
            List<string> ujAdatok = File.ReadAllLines("szemelyek.txt").ToList();
            for (int i = 0; i < ujAdatok.Count; i++)
            {
                string[] adatok = ujAdatok[i].Split(';');
                if (adatok[0]==nev)
                {
                    ujAdatok.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines("szemelyek.txt", ujAdatok);
        }




        private static  Nyilvantarto AdatokIrasa()
        {
            int ellenorzes;
            Console.Write("Adja meg a személyek nevet: ");
            string nev = Console.ReadLine();
            while (int.TryParse(nev, out ellenorzes))
            {
                Console.WriteLine("Hibás adat! Nem lehet szam benne:");
                nev = Console.ReadLine();
            }
            Console.Write("Adja meg a személyek korát: ");
            string kor = Console.ReadLine();
            while (!int.TryParse(kor, out ellenorzes))
            {
                Console.WriteLine("Hibás adat! Adjon meg számot:");
                kor = Console.ReadLine();
            }
            Console.Write("Adja meg a személy szolgalati idejét: ");
            string szolgalatiIdo = Console.ReadLine();
            while (!int.TryParse(szolgalatiIdo, out ellenorzes))
            {
                Console.WriteLine("Hibás adat! Adjon meg számot:");
                szolgalatiIdo = Console.ReadLine();
            }
            Console.Write("Adja meg a személy fizetését: ");
            string fizetes = Console.ReadLine();
            while (!int.TryParse(fizetes, out ellenorzes))
            {
                Console.WriteLine("Hibás adat! Adjon meg számot:");
                fizetes = Console.ReadLine();
            }
            Console.Write("Adja meg a személy szakterületét: ");
            string szakterulet = Console.ReadLine();
            while (int.TryParse(szakterulet, out ellenorzes))
            {
                Console.WriteLine("Hibás adat! Nem lehet szam benne:");
                szakterulet = Console.ReadLine();
            }
             return new Nyilvantarto(nev, kor, szolgalatiIdo, fizetes, szakterulet);
        }




        private static void sr_Readline()
        {
            StreamReader sr = new StreamReader("szemelyek.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
            }
            sr.Close();
        }




    }
}
