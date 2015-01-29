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
    public class Node
    {
        public int X { get; set; }     ///Koordinater till snake
        public int Y { get; set; }      ///Koordinater till snake


       public Node(int myPositionX, int myPositionY) ///Konstruktorn med värden
        {

           X = myPositionX; 
           Y = myPositionY;                     
        }

       
    }
}
