using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_OOP {
    class Figure {
        protected List<Block> blockList;

        public void Draw(){
            foreach(Block block in blockList){
                block.Draw();
            }
        }

        internal bool isHit(Figure figure){
            foreach(var block in blockList){
                if(figure.isHit(block)){
                    return true;
                }
            }
            return false;
        }

        private bool isHit(Block block){
            foreach(var b in blockList){
                if (b.isHit(block)){
                    return true;
                }
            }
            return false;
        }
    }
}
