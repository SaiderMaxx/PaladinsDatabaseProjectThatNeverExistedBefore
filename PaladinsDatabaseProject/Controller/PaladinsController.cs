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
        
        //Delete - Dev 1
        public void DeleteChampion(int id)
        {
            using (PaladinsChampionsDBEntities db = new PaladinsChampionsDBEntities())
            {
                var championToDelete = db.Champions.Where(p => p.Id == id).FirstOrDefault();
                if (championToDelete != null)
                {
                    db.Champions.Remove(championToDelete);
                    db.SaveChanges();
                }
            }
        }

/*
        //Update - Dev 2
        public void UpdateChampion(int id, Champion champion)
        {
            using (PaladinsChampionsDBEntities db = new PaladinsChampionsDBEntities())
            {
                var championToUpdate = db.Champion.ToList().Where(c => c.Id == id).FirstOrDefault();
                if (championToUpdate != null)
                {
                    championToUpdate.Id = id;
                    championToUpdate.Name = champion.Name;
                    championToUpdate.Price = champion.Level;
                    db.SaveChanges();
                }
            }    
        } 
        */
    }
    
}
