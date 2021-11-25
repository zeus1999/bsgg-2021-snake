using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using MongoDB.Bson;

namespace Snake_OOP {
    class Program {
        static void Main(string[] args){

            string name = "";

            Database db = new Database();

            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Drücke 'enter' um das Spiel zu starten.");
            Console.ReadLine();
            Console.WriteLine("Gebe deinen Namen ein.");
            name = Console.ReadLine();
            Console.ResetColor();
            Console.Clear();

            Walls walls = new Walls(80, 25);
            walls.Draw();


            Block snakeBlock = new Block(4, 6, '*');
            Snake snake = new Snake(snakeBlock, 5, Direction.RIGHT);
            snake.Draw();

            Console.SetCursorPosition(0, 26);
            Console.Write("Score: " + snake.counter);
            Console.SetCursorPosition(0, 0);

            FoodCreator foodCreator = new FoodCreator(80, 25, '*');
            Block food = foodCreator.CreateFood();
            food.Draw();

            while(true){


                if(walls.IsHit(snake) || snake.isHitTail()){
                    break;
                }

                if(snake.Eat(food)){
                    food = foodCreator.CreateFood();
                    food.Draw();
                    Console.SetCursorPosition(7, 26);
                    Console.Write(snake.counter);
                    Console.SetCursorPosition(0, 0);
                } else {
                    snake.Move();
                }

                Thread.Sleep(snake.speed);

                if(Console.KeyAvailable){
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }   
            }

            
            db.insertPoints(name, snake.counter);
            gameOver(db);
            Console.ReadLine();
        }

        static void gameOver(Database db){
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Verloren! Drücke 'enter' um das Spiel zu verlassen.");
            Console.WriteLine("");
            var documents = db.getScoreboard();
            foreach (BsonDocument doc in documents){
                Console.WriteLine(doc.GetValue("name") + "\t" + doc.GetValue("counter"));
            }


        }
    }
    
}
