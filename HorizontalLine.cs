using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_OOP {
    class HorizontalLine : Figure {

        public HorizontalLine(int xLeft, int xRight, int y, string symbol){
            blockList = new List<Block>();
            for(int x = xLeft; x<= xRight; x++){
                Block block = new Block(x, y, symbol);
                blockList.Add(block);
            }           
        }
    }
}
