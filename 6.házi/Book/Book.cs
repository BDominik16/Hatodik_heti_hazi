using System;
using System.Collections.Generic;
using System.Text;

namespace book
{
    /*
    A szerző, cím és ár adattagok változatlanok. 
    A megjelenés éve (yearOfPublication) legyen readonly konstans, az objektum létrehozás éve (dátumkezeléssel!).
    Egészítse ki az osztályt új adattaggal:
    - oldalszám (pages)

    Módosítsa a 2 konstruktort.
    - Az első konstruktor 4 paraméteres (szerző, cím, ár, oldalszám).
    Az ár és az oldalszám nem lehet negatív (default értékük 0).
    - A második konstruktor 2 paraméteres (szerző, cím). Az árat 2500 Ft-ra, az oldalszámot 100-ra állítja.

    Törölje a DisplayInformation() metódust.
    Módosítsa a ToString() metódust, amely String-ben összefűzve adja vissza a könyv adatait.
    (formatum: szerzo: cim, kiadaseve. Price: ar Ft, pp oldalszam)
    Hozza létre az új adattagokhoz a getter, setter tulajdonságokat és metódusokat. 
    Ha oldalszámnak negatív számot adunk, ne változzon az értéke.
    Írjon osztályszintű metódust, amely két paraméterként kapott könyv közül a hosszabbat adja vissza (GetLonger()). 
    Azonos oldalszám esetén az első könyvet. 
    Írjon példányszintű metódust, amely igazat ad vissza, ha a könyv oldalszáma páros (HasEvenPages()).

    Oldja meg az alábbi feladatokat:
    - A Program osztály Main függvényében olvasson be n darab könyvet egy tömbbe! 
      n értékét ellenőrzött módon olvassa be 1 és 10 között (ReadInteger())! 
      A könyvek létrehozásához az 1. konstruktort használja!
    - A Book osztályba írjon public static módosítójú tömbkiíró metódust (void ListBookArray(Book[])) 
    és írja ki vele a beolvasott könyveket a Program.Main függvényen belül!
    - A Book osztályba írjon public static módosítójú Book GetLongestBook(Book[]) metódust, 
    ami megkeresi és visszaadja a leghosszabb könyvet! 
    Írja ki ennek a könyvnek az adatait a Program osztály Main függvényén belül!
    - A Book osztályba írjon public static módosítójú Book GetLongestEvenPagesBook(Book[]) metódust, 
    ami megkeresi és visszaadja a leghosszabb páros oldalszámú könyvet! 
    Ha nincs páros oldalszámú könyv a kapott tömbben, adjon vissza null-t! 
    Írja ki ennek a könyvnek az adatait a Homework osztály main függvényén belül!
        Algoritmus:
            Beállítjuk a maxBook változót null-ra.
            A tömb elemein végighaladva
                megvizsgáljuk, hogy az adott elem páros oldalszámú-e,
                    ha igen,
                        eltároljuk az elemet a maxBook változóban
                        kilépünk a ciklusból
            A tömb elemein végighaladva
                megvizsgáljuk, hogy az adott elem páros oldalszámú-e és nagyobb-e az oldalszáma a maxBook-ban tárolt könyvnél
                ha igen
                    A maxBook-ot beállítjuk a jelenlegi tömbelemre
            Visszatérünk a maxBook változóval
    - A Book osztályba írjon public static módosítójú (void AuthorStatistics(Book[])) metódust, 
    amely kiírja mely szerzőnek hány könyve jelent meg! 
    A Program.Main függvényen belül írassa ki a beolvasott könyvek statisztikáit!
    Algoritmus: Veszem a következő könyvet. 
    Ha a szerzője megegyezik egy korábban már vizsgált könyv szerzőjével, akkor továbblépek a következő könyvre. 
    Ha ez az adott szerző első előfordulása, akkor létrehozok egy számláló változót 1 értékkel és kiírom a szerző nevét. 
    Az aktuális indextől kezdve nézem a könyvek szerzőit, ha azonos szerzőt találok, növelem eggyel a számlálót.
    A végén kiírom a számláló értékét.
    
         */
    public class Book : IComparable
    {
        string author;
        string title;
        readonly DateTime yearOfPublication = DateTime.Now;
        int price;
        int pages;
        

        public Book(string author, string title) :this(author,title,2500,100)
        {
        }

        public Book(string author, string title, int price, int pages)
        {
            this.author = author;
            this.title = title;
            if (price < 0)
            {
                this.price = 0;
            }
            else
            {
                this.price = price;
            }
            if (pages < 0)
            {
                this.pages = 0;
            }
            else
            {
                this.pages = pages;
            }

        }

        public string Author { get => author; set => author = value; }
        public string Title { get => title; set => title = value; }
        public DateTime YearOfPublication => yearOfPublication;
        public int Price { get => price; set => price = value; }
        //public int Pages { get => pages; set => pages = value; }
        public int Pages
        {
            get { return pages; }
            set
            {

                if (value > 0)
                {
                    pages = value;
                }
            }
        }


        public override string ToString()
        {
            return $"Szerző: {Author}, cím:{Title}, kiadáséve: {YearOfPublication.Year}, Ár: {Price} Ft, {Pages} oldalszám";
        }


        public static int GetLonger(Book a, Book b)
        {
            if(a.pages > b.pages)
            {
                return a.pages;
            }
            else if(a.pages < b.pages)
            {
                return b.pages;
            }
            else
            {
                return a.pages;
            }
        }

        public bool HasEvenPages()
        {
            if (pages % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        


        public static int GetLongestBook(Book[] bookArray)
        {
            int seged = 0;
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[seged].pages<bookArray[i].pages)
                {
                    seged = i;
                }
            }
            return seged;
        }

        public static int? GetLongestEvenPagesBook(Book[] bookArray)
        {
            int i = -1;
            /*do
            {
                i++;
            } while (bookArray[i].pages % 2 == 1);*/
            for ( int z = 0; z < bookArray.Length; z++)
            {
                if (bookArray[z].pages % 2 == 0) { i = z; break; } 
            }
            if(i!=-1)
            {
                for (int j = i; j < bookArray.Length; j++)
                {
                    if ((bookArray[j].pages > bookArray[i].pages) && (bookArray[j].pages % 2 == 0))
                    {
                        i = j;
                    }
                }
            }
            if(i==-1)
            {
                return null;
            }
            else
            return i;
        }





        public int CompareTo(object obj)
        {
            Book obj_ = (Book)obj;
            return this.author.CompareTo(obj_.author);
        }

        /*
        public int Price
         {
             get { return price; }
             set
             {
                 //Értékadás előtti ellenőrzés:
                 //- az ár legyen 1000 forint 1000-nél kisebb értékekre, egyébként a megadott érték
                 price = value;
             }
         }

         public int YearOfPublication
         {
             get { return yearOfPublication; }
             set
             {
                 //Értékadás előtti ellenőrzés:
                 //- a megjelenés éve, ha nem 1950 és 2021 között van, legyen 2021, egyébként a megadott érték
                 yearOfPublication = value;
             }
         }*/


        /*public void IncreasePrice(int percentage)
        {
            if (percentage > 0)
                price += (int)Math.Round(price * percentage / 100.0);
        }

        */

    }
        }
