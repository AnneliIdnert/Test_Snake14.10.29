///Anneli Idnert
///TGSYS 2014.11.20
///Snake-projekt
///Datastruktur och Algoritmer
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Test_Snake14._10._29
{
    class Logic
    {
         Queue<Brick> snakeNode = new Queue<Brick>();/// Kön som samlar noder för till printen 
        Brick[,] grid;       ///Rutnätet
     
        public void Start()
        {
            ParseTextFile("../../input.txt");
            Search();
            Print();

            Console.WriteLine();
  
           
            Console.ReadLine();
  
        }
        public void ParseTextFile(string textToParse)         ///Läser ifrån fil
        {
            try
            {
                using (StreamReader sr = new StreamReader(textToParse))
                {
                    string line = sr.ReadToEnd();
                    line = line.Replace(System.Environment.NewLine, ",");
                    string[] splitted = line.Split(new Char[] { ',' });
                    InitializeVariables(splitted);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("The file could not be read:");          ///Felmeddelande om det inte går att läsa fil
                Console.WriteLine(e.Message);
            }
        }

       
        private void InitializeVariables(string[] parsedText)
        {
            int nbrColums = ConvertStringIntoInt(parsedText[0]);
            int nbrRows = ConvertStringIntoInt(parsedText[1]);
            int nbrOfObstacles = ConvertStringIntoInt(parsedText[2]);
            int obstacle_X;
            int obstacle_Y;

            // Array med storleken enligt rader & kolumner.
            grid = new Brick[nbrColums, nbrRows];

            ///Initierar brickorna och hindren i spelet.
            InitializeBricks();

            // En 3:a då första positionen på första hindret är [3] enligt input.txt
            int indexCounter = 3;

            // Loop som körs lika många ggr som det finns hinder. 
            for (int i = 0; i < nbrOfObstacles; i++)
            {
                obstacle_X = ConvertStringIntoInt(parsedText[indexCounter]);
                obstacle_Y = ConvertStringIntoInt(parsedText[indexCounter + 1]);
                grid[obstacle_X, obstacle_Y].Blocked = true;

                // Öka med 2 pga av varje hinder representeras av [x],[y]
                indexCounter += 2;
            }

        }

        /// <summary>
        /// Metod som skapar lika många brick-objekt som det finns rader & kolumner och lägger dom i brick-Arrayen.
        /// </summary>
        private void InitializeBricks()
        {
            for (int x = 0; x < grid.GetLength(0); x += 1)
            {
                for (int y = 0; y < grid.GetLength(1); y += 1)
                {
                    grid[x, y] = new Brick(x,y, false);
                }
            }
            
        }

        /// <summary>
        /// Metod som konventerar en sträng till en int. 
        /// </summary>
        public int ConvertStringIntoInt(string text)
        {
            int number = Convert.ToInt32(text);
            return number;
        }
    



 
        
        public void AddToQuee(Brick nodeToBeAdded) ///Lägger till kö
        {
            snakeNode.Enqueue(nodeToBeAdded);
      
	         
        }
        private bool Accesible(int x, int y)             ///För att se vart i snaken befinner sig
        {
            if (x >= 0 && x < grid.GetLength(0) )
            {
                if (y >= 0 && y < grid.GetLength(1))
                {
                    if (!grid[x,y].Blocked)
                    {
                            if (!grid[x,y].Visited)
                            {
                                return true;
                                
                            }
                    }  
                }
               
         
            }
            return false;
        }
        
         public void Search( ) 
        {
            Brick currentBrick = grid[0, 0];       ///Brick som blir till en snakeNode
                                    
            
             AddToQuee(currentBrick);          ///Metod för att lägga till i kön för att göra snaken
             currentBrick.Visited = true;       ///Sätter brick till falskt
             while  (true)
             {
                 if (Accesible(currentBrick.X, currentBrick.Y +1))             ///Går Y och ser om det är möjligt att gå ner där
                 {
                     currentBrick = grid[currentBrick.X, currentBrick.Y +1];      ///Markerar vart på spelålanen som snaken är
                       AddToQuee(currentBrick);                                    ///Lägger till en bricka på snaken
                     currentBrick.Visited=true;                                     ///sätter bricken till besökt
                     
                 }
                 else if    (Accesible(currentBrick.X +1, currentBrick.Y ))     ///Går till höger dvs X 
                 {
                     currentBrick = grid[currentBrick.X +1, currentBrick.Y ];      ///om det går sätter värdet på spelplanen 
                     AddToQuee(currentBrick);                                    ///Lägger till en bricka på snaken
                     currentBrick.Visited = true;                                ///Sätter brickan till besökt
                     
                 }
                 else if( Accesible(currentBrick.X, currentBrick.Y -1))              ///Om det inte går att gå på Y värdet
                 {
                     currentBrick = grid[currentBrick.X, currentBrick.Y - 1];     ///Sätter vilken bricka i griden som det itne går att gå på
                     AddToQuee(currentBrick);
                     currentBrick.Visited = true;                          ///Säger att brickan är besökt
                 }
                 else if (Accesible(currentBrick.X -1, currentBrick.Y))          ///Om det inte går att gå på X delen 
                 {
                     currentBrick = grid[currentBrick.X - 1, currentBrick.Y];       ///Säger vilekn bricka värdet har i griden.
                     AddToQuee(currentBrick);
                     currentBrick.Visited = true;                                  ///Säger att den är besökt
                 }
                 else
                 { break; }
             }
        }
         public void Print()
         {
             while (snakeNode.Count != 0)
             {
                
                 Brick b = snakeNode.Dequeue();
                 Console.Write(b.X.ToString() + ", " + b.Y.ToString());
                 Console.WriteLine();
             }
         }
   
    }
}
