using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string kucukHarfler = "";
            string buyukHarfler = "";
            string rakamlar = "";
            string semboller = "!\"\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                kucukHarfler += ch;
            }
            for (char ch = 'A'; ch <= 'Z'; ch++)
            {
                buyukHarfler += ch;
            }
            for (int i = 0; i <= 9; i++)
            {
                rakamlar += i;
            }

            int uzunluk = 16;
            string banner = @"
            __________                                               .___________               
            \______   \_____    ______ ________  _  _____________  __| _/  _____/  ____   ____  
             |     ___/\__  \  /  ___//  ___/\ \/ \/ /  _ \_  __ \/ __ /   \  ____/ __ \ /    \ 
             |    |     / __ \_\___ \ \___ \  \     (  <_> )  | \/ /_/ \    \_\  \  ___/|   |  \
             |____|    (____  /____  >____  >  \/\_/ \____/|__|  \____ |\______  /\___  >___|  /
                            \/     \/     \/                          \/       \/     \/     \/ 
                                       ____   ________    _______                               
                                       \   \ /   /_   |   \   _  \                              
                                        \   Y   / |   |   /  /_\  \                             
                                         \     /  |   |   \  \_/   \                            
                                          \___/   |___| /\ \_____  /                            
                                                        \/       \/                             ";

            Console.WriteLine(banner);

            Console.Write("Uzunuluk Gir (Varsayılan 16): ");
            string uzunlukInput = Console.ReadLine();
            Console.WriteLine("");

            try
            {
                if (!string.IsNullOrEmpty(uzunlukInput))
                {
                    uzunluk = int.Parse(uzunlukInput);
                }
                else
                {
                    Console.Write("!Uyarı: uzunluk 16 olarak ayarlandı");
                    uzunluk = 16;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Hata: Geçersiz uzunluk girdisi. Varsayılan uzunluk 16 olarak ayarlandı.\n");
                uzunluk = 16;
            }

            if (uzunluk > 128)
            {
                uzunluk = 128;
            }
            else if (uzunluk < 8)
            {
                uzunluk = 8;
            }

            string kumeler = "1- Büyük Harfler (A-Z) \n" + "2- Küçük Harfler (a-z) \n" +
            "3- Rakamlar (0-9) \n" + "4- Semboller (!%&$#)";
            Console.WriteLine(kumeler);

            string anaHavuz = "";
            while (true)
            {
                bool hatalıGirisYapildi = false;

                Console.Write("Karakter Kümesi Seçini (',' ile ayırın): ");
                string karakterKumesi = Console.ReadLine();

                // Boş giriş kontrolü
                if (string.IsNullOrEmpty(karakterKumesi))
                {
                    Console.WriteLine("Hata: En az bir karakter kümesi seçmelisiniz.\n");
                    Console.Write(kumeler + "\n");
                    continue;
                }

                string[] karakterKumeleri = karakterKumesi.Split(',');

                foreach (string secim in karakterKumeleri)
                {
                    // Kullanıcı "1, 2" yazarsa boşluğu silmek için Trim() kullanıyoruz
                    string temizSecim = secim.Trim();

                    if (temizSecim == "1")
                    {
                        anaHavuz += buyukHarfler;
                    }
                    else if (temizSecim == "2")
                    {
                        anaHavuz += kucukHarfler;
                    }
                    else if (temizSecim == "3")
                    {
                        anaHavuz += rakamlar;
                    }
                    else if (temizSecim == "4")
                    {
                        anaHavuz += semboller;
                    }
                    else
                    {
                        hatalıGirisYapildi = true;
                        break;
                    }
                }
                if (hatalıGirisYapildi)
                {
                    Console.WriteLine("Hata: Geçersiz karakter kümesi seçimi. Lütfen tekrar deneyin.\n");
                    continue;
                }
                else if (string.IsNullOrEmpty(anaHavuz))
                {
                    Console.WriteLine("Hata: En az bir karakter kümesi seçmelisiniz.\n");
                    continue;
                }
                else
                {
                    break; // Geçerli giriş, döngüden çık
                }
            }

            //sifre olusturma
            Random rd = new Random();
            string sifre = "";
            for (int i = 0; i < uzunluk; i++)
            {
                int rastgeleIndex = rd.Next(anaHavuz.Length);

                sifre += anaHavuz[rastgeleIndex];

            }

            Console.Clear();
            Console.Write(banner + "\n");
            Console.Write("Oluşturulan Şifre: " + sifre);
        }
    }
}
