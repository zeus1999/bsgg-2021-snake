using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_OOP {
    class Snake : Figure {
        Direction dir;

        public int baseSpeed = 100;
        public int speed = 100;
        public int counter = 0;

        public Snake(Block tail, int lenght, Direction direction){
            dir = direction;

            blockList = new List<Block>();
            for(int i = 0; i < lenght; i++){
                Block block = new Block(tail);
                block.Move(i, direction);
                blockList.Add(block);
            }
        }

        internal void Move(){
            Block tail = blockList.First();
            blockList.Remove(tail);

            Block head = GetNextPoint();
            blockList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Block GetNextPoint(){
            Block head = blockList.Last();
            Block nextPoint = new Block(head);
            nextPoint.Move(1, dir);
            return nextPoint;
        }

        internal bool isHitTail(){
            var head = blockList.Last();
            for(int i = 0; i < blockList.Count -2; i++){
                if(head.isHit(blockList[i])){
                    return true;
                }
            }
            return false;
        }

        public void HandleKey(ConsoleKey key){
            if(key == ConsoleKey.LeftArrow && dir != Direction.RIGHT){
                dir = Direction.LEFT;
                speed = baseSpeed;
            } else if(key == ConsoleKey.RightArrow && dir != Direction.LEFT){
                dir = Direction.RIGHT;
                speed = baseSpeed;
            }
            else if(key == ConsoleKey.DownArrow && dir != Direction.UP){
                dir = Direction.DOWN;
                speed = Convert.ToInt16(baseSpeed * 1.5);
            }
            else if(key == ConsoleKey.UpArrow && dir != Direction.DOWN){
                dir = Direction.UP;
                speed = Convert.ToInt16(baseSpeed * 1.5);
            }
        }

        internal bool Eat(Block block){
            Block head = GetNextPoint();
            if(head.isHit(block)){
                blockList.Add(block);
                baseSpeed -= 10;
                counter++;
                return true;
            } else {
                return false;
            }
        }
    }
}
