using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_OOP {
    class VerticalLine : Figure {

        public VerticalLine(int yTop, int yDown, int x, string symbol){
            blockList = new List<Block>();
            
            for(int y = yTop; y <= yDown; y++){
                Block block = new Block(x, y, symbol);
                blockList.Add(block);
            }
        }
    }
}
