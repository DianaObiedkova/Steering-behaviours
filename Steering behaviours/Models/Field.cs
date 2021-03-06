using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public class Field
    {
        public static int Height = 500;
        public static int Width = 750;
        public static int precipiceLength = 100;
        public static List<Creature> Members { get; private set; }

        public Field() {
            Members = new List<Creature>();
        }

        //нужно прописать спавн в рандомных позициях для Rabbit(), Wolf()  -- уже в рандоме в конструкторах
        //спавн для Doe(): первая рандомно, остальные рядом + немного рандома --надо подумать, пока полный рандом
        public void Populate(int rabbitsNum, int wolvesNum, int doeNum) {
            Members.Add(new Hunter());
            for(int i=0; i<rabbitsNum; i++) 
                Members.Add(new Rabbit());
            for(int i=0; i<wolvesNum; i++) 
                Members.Add(new Wolf());
            for(int i=0; i<doeNum; i++) 
                Members.Add(new Doe());
        }  

        public Hunter GetHunter() {
            return (Hunter)Members.Find(c => c.GetType() == typeof(Hunter));
        }  

        //ID, position, health, color
        public List<string[]> GetCreatures() {
            List<string[]> result = new List<string[]>();
            foreach(Creature creature in Members) {
                result.Add(new string[] {
                    creature.ID.ToString(), 
                    creature.Position.X.ToString()+" "+creature.Position.Y.ToString(), 
                    creature.Health.ToString(),
                    creature.Color.Name});
            }
            return result;
        }  

        //harmValue int[]: [ID, harmValue]
        public void UpdateInjuries(Vector3 position, int harm) {
            Creature current = Members.Find(c => c.Position ==  position);
            if(!(current is null))
            {
                bool isAlive = current.Injure(harm);
                if (!isAlive)
                    Members.Remove(current);
            }

            //HarmByWolves();
        } 
        
        public void HarmByWolves()
        {
            foreach(var member in Members)
            {
                if(!(member is Wolf) && member.IsAlive)
                {
                    foreach(var inner in Members)
                    {
                        if(inner is Wolf wolf && wolf.CanHarm(member))
                        {
                            member.Injure(wolf.harm);
                        }
                    }
                }
            }
        }

        public void UpdatePositions() {
            foreach (var creature in Members)
            {
                creature.Update();
            }
            HarmByWolves();
            for (int i=0; i<Members.Count(); i++)
            {
                if(!Members.ElementAt(i).IsAlive) {
                    Members.RemoveAt(i);
                    i--;
                }
            }          
        }  
    }
}
