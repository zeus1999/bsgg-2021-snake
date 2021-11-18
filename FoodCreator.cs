using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_OOP {
    class FoodCreator {
        int mapWidht;
        int mapHeight;
        string symbol;

        Random random = new Random();

        public FoodCreator(int mapWidht, int mapHeight, string symbol){
            this.mapWidht = mapWidht;
            this.mapHeight = mapHeight;
            this.symbol = symbol;
        }

        public Block CreateFood(){
            int x = random.Next(2, mapWidht - 2);
            int y = random.Next(2, mapHeight - 2);
            return new Block(x, y, symbol);
        }
    }
}
