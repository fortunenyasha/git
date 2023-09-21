using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace tetris
{
    class BlockQueue
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new Lblock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };
        private readonly Random random = new Random();
        public Block NextBlock { get; private set; }

        public BlockQueue()
        {
            NextBlock = RandomBock();
        }

        private Block RandomBlock()
        {
            return blocks[Random.Next(blocks.length)];

        }
        public Block GetAndUpdate()
        {
            Block block = NextBlock;
            do
            {
                NextBlock = RandomBlock ();
            }
            while (block.Id == NextBlock.Id);
            return block;
        }

    }
}
