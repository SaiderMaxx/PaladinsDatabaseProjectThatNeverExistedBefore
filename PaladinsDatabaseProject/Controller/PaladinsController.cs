using PaladinsDatabaseProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaladinsDatabaseProject.Controller
{
    internal class PaladinsController
    {
        //Read
        public List<Champion> GetAllChampions()
        {
            using (PaladinsChampionsDBEntities db = new PaladinsChampionsDBEntities())
            {
                return db.Champions.ToList();
            }
        }

        //Create/Add
        public void AddChampion(Champion champion)
        {
            using (PaladinsChampionsDBEntities db = new PaladinsChampionsDBEntities())
            {
                Random rnd = new Random();
                int rNumber = rnd.Next(1, 10);
                champion.Id = db.Champions.ToList().LastOrDefault().Id + rNumber;
                db.Champions.Add(champion);
                db.SaveChanges();
            }
        }

        //Update


        //Delete
    }
    
}
