using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public class Field
    {
        public static int Height = 1500;
        public static int Width = 1000;
        public static int precipiceLength = 100;
        public static List<Creature> Members { get; set; }

        public Field() {
            Members = new List<Creature>();
        }

        //нужно прописать спавн в рандомных позициях для Rabbit(), Wolf()
        //спавн для Doe(): первая рандомно, остальные рядом + немного рандома
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
    }
}
