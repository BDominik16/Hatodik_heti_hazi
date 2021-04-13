using System;
using System.Collections.Generic;

namespace book
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
			    - A Program osztály Main függvényében olvasson be n darab könyvet egy tömbbe! 
                n értékét ellenőrzött módon olvassa be 1 és 10 között (ReadInteger())! 
                
                A könyvek létrehozásához az 1. konstruktort (4 parameteres) használja!
			*/


            
            Console.WriteLine("Number of books: ");
            int numberOfBooks = ReadInteger();
            
            //Console.WriteLine($"A beovlasott szam: {numberOfBooks}");

            //MEGOLDASOK HELYE
            //tomb letrehozasa

            Book[] bookArray = new Book[numberOfBooks];

            for (int i = 0; i < bookArray.Length; i++)
            {
                //konyv adatainak bekerese
                //konyv letrehozasa

                string szerzo;
                string cim;
                int ar;
                int oldalszam;

                Console.WriteLine("Kérem a szerzőt: ");
                szerzo=Console.ReadLine(); 
                Console.WriteLine("Kérem a cim: ");
                cim = Console.ReadLine();
                Console.WriteLine("Kérem a árát: ");
                ar = ReadPriceAndPages();
                Console.WriteLine("Kérem az oldalszámot: ");
                oldalszam = ReadPriceAndPages();

                bookArray[i] = new Book(szerzo, cim, ar, oldalszam);
            }

            //MEGOLDASOK HELYE
            //ListBookArray() hasznalata
            ListBookArray(bookArray);
            //Leghosszabb könyv
            Console.WriteLine("Leghosszabb könyv");
            Console.WriteLine(bookArray[Book.GetLongestBook(bookArray)].ToString());
            Console.WriteLine("Leghosszabb páros könyv");
            //Leghosszabb páros oldalszámú könyv
            int? paros = Book.GetLongestEvenPagesBook(bookArray);
            if(paros != null)
            {
                int seged = (int)paros;
                Console.WriteLine(bookArray[seged].ToString());
            }
            else
            {
                Console.WriteLine("Nincs páros könyv megadva");
            }
            //Console.WriteLine(bookArray[Book.GetLongestEvenPagesBook(bookArray)].ToString());
            //AuthorStatistics() hasznalata

            Console.WriteLine("Rendezés: ");
            AuthorStatistics(bookArray);

            Console.ReadKey();

        }


        private static int ReadInteger()
        {
            //IMPLEMENTALNI
            string s;
            int n;
            bool ok;
            do
            {
                Console.WriteLine("Kérem adjon meg egy számot 1 és 10 között:");
                do
                {
                    s = Console.ReadLine();
                    ok = Int32.TryParse(s, out n);
                    if (!ok)
                    {
                        Console.WriteLine("Nem jó szám add meg mégegyszer!");
                    }
                } while (!ok);
            } while (n < 1 || n > 10);
            return n;
        }

        private static int ReadPriceAndPages()
        {
            string s;
            bool ok;
            int n;
            do
            {
                s = Console.ReadLine();
                ok = Int32.TryParse(s, out n);
                if (!ok)
                {
                    Console.WriteLine("Nem jó az érték add meg mégegyszer!");
                }
            } while (!ok);
            return n;
        }


        public static void ListBookArray(Book[] bookArray)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                Console.WriteLine(bookArray[i].ToString());
            }
        }

        public static void AuthorStatistics(Book[] bookArray)
        {
            int counter = 1;
            List<Book> lista = new List<Book>();
            lista.AddRange(bookArray);
            lista.Sort();
            for (int i = 0; i < lista.Count; i++)
            {
                if (i != lista.Count-1)
                {
                    if (lista[i].Author == lista[i + 1].Author)
                    {
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine(lista[i].Author + " " + counter);
                        counter = 1;
                    }
                }
                else
                {
                    Console.WriteLine(lista[i].Author + " " + counter);
                }
            }

        }

    }
}
