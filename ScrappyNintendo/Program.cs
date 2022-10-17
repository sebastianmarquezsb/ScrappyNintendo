using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
namespace ScrappyNintendo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scrappy Nintendo - Developed by Sebastian Marquez");
            List<string> MisTitulos = new List<string>();
            HtmlWeb obWeb = new HtmlWeb();
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    HtmlDocument obDoc = obWeb.Load($"https://www.solotodo.cl/consoles?families=580852&page= {i}");
                    foreach (var Nodo in obDoc.DocumentNode.CssSelect(".category-browse-result"))
                    {
                        var NodoA = Nodo.CssSelect("a").First();
                        MisTitulos.Add(NodoA.InnerHtml);

                        Console.WriteLine($"{Nodo.InnerText}");
                    }

                }
                Console.WriteLine("Se ha finalizado el scrappy, presiona una tecla para cerrar");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            
            
        }

    }
}
