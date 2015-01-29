///Anneli Idnert
///TGSYS 2014.11.20
///Snake-projekt
///Datastruktur och Algoritmer
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Snake14._10._29
{
    public class Brick : Node
    {
        public bool Blocked { get; set; }    ///Blockade bricks
        public bool Visited { get; set; }     ///Blockade besökt


         public Brick(int X, int Y, bool blocked ) : base(X, Y)       ///KOnstruktor
         {
             this.Blocked = blocked;
             
         }

         
       



    }
}
