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
            List<string> MisTitulos = new List<string>();
            HtmlWeb obWeb = new HtmlWeb();
            HtmlDocument obDoc = obWeb.Load("https://www.solotodo.cl/consoles?families=580852");
            

            //HtmlNode Body = obDoc.DocumentNode.CssSelect("body").First();
            //string sBody = Body.InnerHtml;


            //Console.WriteLine("Hello World!");
            foreach (var Nodo in obDoc.DocumentNode.CssSelect(".category-browse-result"))
            {
                var NodoA = Nodo.CssSelect("a").First();
                MisTitulos.Add(NodoA.InnerHtml);

                Console.WriteLine($"{Nodo.InnerText}");
            }
            try
            {
                Console.WriteLine("Segunda Pagina");
                List<string> MisTitulos2 = new List<string>();
                HtmlWeb obWeb2 = new HtmlWeb();
                HtmlDocument obDocPage2 = obWeb2.Load("https://www.solotodo.cl/consoles?families=580852&ordering=offer_price_usd&page=2&");
                foreach (var Nodo2 in obDocPage2.DocumentNode.CssSelect(".category-browse-result"))
                {
                    var NodoA = Nodo2.CssSelect("a").First();
                    MisTitulos2.Add(NodoA.InnerText);
                    Console.WriteLine($"{Nodo2.InnerText}");


                }
            }catch (Exception ex)
            {
                Console.Write(ex);
            }
            Console.Read();
            
        }

    }
}
