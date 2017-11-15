using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace LinqExamples
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                PADBEntities Db = new PADBEntities();

                Db.Database.Log = Console.WriteLine;
                ///Simple LINQ Query
                //var emp = (from e in Db.HRISMSTEmployees
                //           //where e.txtcompany == "EVERVE"
                //           orderby e.txtempname
                //           select e).ToList();
                //foreach (var item in emp)
                //{
                //    Console.WriteLine("Company Name " + item.Key + " EmpName :" + item.Count);
                //}

                ///Using Join 
                #region "Using Join"
                //single column join
                var res = from e in Db.Albums
                          join a in Db.Artists on e.ArtistId equals a.ArtistId
                          select new
                          {
                              AlbumName = e.Title,
                              AlbumArtist = a.Name
                          };//).OrderBy(x => x.AlbumArtist).ThenBy(y => y.AlbumName).ToList();
                
                //foreach (var item in res)
                    //Console.WriteLine(" Artist : " + item.AlbumArtist + " \tAlbum : " + item.AlbumName);

                //Group join
                var hell = from e in Db.Artists
                           join a in Db.Albums
                           on  e.ArtistId equals a.ArtistId
                           into q
                           select new { Artist = e.Name, AlbumList = q };

                //foreach (var ch in hell)
                //{
                //    Console.WriteLine("Artist : " + ch.Artist);
                //    foreach (var dd in ch.AlbumList)
                //        Console.Write(" \n \t Albums : " + dd.Title);
                //}
                foreach (var ch in hell)
                {
                    try
                    {
                        Console.WriteLine("Artist : " + ch.Artist);
                        Console.Write(" \t Albums : " + ch.AlbumList.FirstOrDefault().Title);
                    }
                    catch (Exception)
                    { }
                }


                #endregion

                ///Using Group By Clause
                #region "Group By Clause"
                //var emp = (from e in Db.HRISMSTEmployees
                //           group e by e.txtcompany into g
                //           select g).ToList();
                //foreach (var item in emp)
                //{
                //    foreach (var empl in item)
                //    {
                //        Console.WriteLine("Company Name " + item.Key + " EmpName :" + empl.txtempname);
                //    }
                //    //Console.WriteLine("Company Name " + item.Key + " EmpName :" + item.FirstOrDefault().txtempname);

                //    //Using count with group by clause
                //    Console.WriteLine("Company Name " + item.Key + " EmpName :" + item.Count());
                //} 
                #endregion


                ///Using Dynamic filters
                //Dynfilter("GenreId", "10");
                //Console.WriteLine();
                //Dynfilter("ArtistId", "248");
                
                
                ///Using SubQuery
                
                Console.ReadKey();
            }
            catch (Exception)
            {
                
                //throw;
            }
            
        }

        static void Dynfilter(string Col, string val)
        {
            PADBEntities Db = new PADBEntities();
            var valbum = (from a in Db.Albums select a).ToArray();

            PropertyInfo prp = valbum[0].GetType().GetProperty(Col);

            var result = valbum.Where(x => prp.GetValue(x, null).ToString() == val);

            foreach (var r in result)
            {
                Console.WriteLine(" Name " + r.Title + " GenreId :" + r.GenreId + " ArtistId : " + r.ArtistId);
            }

        }
    }
}
