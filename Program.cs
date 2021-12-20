using System;
using System.IO;

namespace APSL_P_III_Zad4
{
    class Program
    {
        class wyjatek: ApplicationException
        {
            public string komunikat;
            public string link = "https://pl.wikipedia.org/wiki/Znak_liczby";
            public wyjatek(string t){
                komunikat = t;
            }
        }
        static void Main(string[] args)
        {   
            try{
                FileStream plik = new FileStream("dane.txt", FileMode.Open, FileAccess.Read);
                StreamReader czytaj = new StreamReader(plik);
                
                int x;
                int n = Convert.ToInt32(czytaj.ReadLine());

                try{
                    if(n<0){
                        throw new wyjatek("Liczba linii nie powinna byc mniejsza od 0!");
                    }
                }
                catch(wyjatek w){
                    Console.WriteLine(w.komunikat);
                    Console.WriteLine(w.link);
                }

                for(int i=0;i<n;i++){
                    x=Convert.ToInt32(czytaj.ReadLine());
                    var wynik = parametry(x);
                    Console.WriteLine("{0} * {1} + {2} = {3}",wynik.m,x,wynik.a,wynik.m*x+wynik.a);
                }
                czytaj.Close();
            }
            catch(FileNotFoundException){
                Console.WriteLine("Nie znaleziono pliku dane.txt!");
            }
            catch(FormatException){
                Console.WriteLine("Nieprawidlowe dane w pliku!");
            }
            finally{
                Console.WriteLine("Koniec");
            }   

            (int m, int a) parametry(int x){   
                int m=0; int a=0;
                if(x==1){
                    return(1,0);
                }
                else{
                    for(int i=1;i<=x;i++){
                        if(x%i==0){
                            m++;
                        }
                        if(czy_pierwsza(i)){
                            a++;
                        }
                    }
                    return(m,a); 
                }
            }

            bool czy_pierwsza(int x){
                int licznik=0;
                for(int i=1;i<=x;i++){
                    if(x%i==0){
                        licznik++;
                    }
                }
                if(licznik==2){
                    return true;
                }
                else{
                    return false;
                }
            }
        }   
    }
}
