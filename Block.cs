using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_OOP
{
    class Block {
        public int x;
        public int y;
        public string symbol;

        public Block(){}

        public Block(int x, int y, string symbol){
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }
        
        public Block(Block block){
            x = block.x;
            y = block.y;
            symbol = block.symbol;
        }

        public void Move(int offset, Direction direction){
            if(direction == Direction.RIGHT){
                x = x + offset;
            } else if (direction == Direction.LEFT){
                x = x - offset;
            } else if (direction == Direction.UP){
                y = y - offset;
            } else if (direction == Direction.DOWN){
                y = y + offset;
            }
        }

        public bool isHit(Block block){
            return block.x == this.x && block.y == this.y;
        }

        public void Draw(){
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
            Console.SetCursorPosition(0, 0);
            
        }

        public void Clear(){
            symbol = " ";
            Draw();
        }

        public override string ToString(){
            return x + ", " + y + ", " + symbol;
        }
    }
}
