
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LinqData
{
    public class Program
    {
        
        
        public class Game
        {
            public static int game_ID = 0;
            public int G_ID { get; set; }
            public string Title { get; set; }
            public int Rate { get; set; }
            public Game(string title, int rate)
            {
                this.G_ID = Game.game_ID;
                Game.game_ID++;
                this.Title = title;
                this.Rate = rate;
            }

        }

        public class Player
        {
            public static int player_ID = 0;
            public int P_ID { get; set; }
            public string Name { get; set; }
            public int Game_ID { get; set; }

 
            public Player(string name, int Game_ID)
            {
                this.P_ID = Player.player_ID;
                Player.player_ID++;
                this.Name = name;
                this.Game_ID=(Game_ID);
            }

        }



        private Game[] videoGames = { new Game("Morrowind",10), new Game("Uncharted 2", 7), new Game("Fallout 3", 2), new Game("Dexter", 1), new Game("System Shock 2", 5) };
        private Player[] players = { new Player("Bartek", 1), new Player("Artur", 1), new Player("Ala", 2) , new Player("Weronika", 3) };

        

        public void Lambda()
        {

            var subset = from player in players join game in videoGames on player.Game_ID equals game.G_ID select game.Title;

            var lam = videoGames.Join(players,
                c => c.G_ID,
                b => b.Game_ID,
                (c, b) => new { c, b }).
                OrderBy(x => x.c.Title).
                Select(x => new { x.c.Title, x.b.Name });

            var distinct = videoGames.Distinct().Select(x => x);

            


              
            foreach (var dis in distinct)
            {

                foreach (var game in lam)
                {
                    if (game.Title == dis.Title)
                    {
                            
                    }
                }
            }
            
            

            foreach(var game in lam)
            {
                Console.WriteLine(game);
            }
        }

        public void Facebook()
        {
            Process p = null;
            try
            {
                p = Process.Start("Chrome", "www.facebook.pl");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Print()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}");
            }
        }
        public static void Paint(string s)
        {
            for(int i = 0;i<10;i++)
            {
                Console.WriteLine($"{s}");
            }
           
        }

        
        
    }
}
