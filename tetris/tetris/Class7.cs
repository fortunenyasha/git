﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public class GameState 
    {
        private Block CurrentBlock;
        public Block currentBlock
        {
            get => CurrentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }
        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public  bool GameOver { get; private set; }
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }
        private bool Blockfits()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
                return true;
            }
        }
        //method to rotate block clockwise
        private void rotateBlockCW () {
            CurrentBlock.RotateCW();
            if(!Blockfits())
            {
                CurrentBlock.RotateCW();
            }
        }
        public void RotateBlockCCW()
        {
            currentBlock .RotateCCW();
            if(!Blockfits()) {
                currentBlock.RotateCCW();
            }
        }
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);
            if (!Blockfits())
            {
                CurrentBlock.Move(0, 1);
            }
        }
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);
            if (!Blockfits())
            {
                CurrentBlock.Move(0, -1);
            }
        }
        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }
        private void PlaceBlock()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;

            }
            GameGrid.ClearFullRows();
            if (IsGameOver() )
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }
        public void MoveBlockDown ()
        {
            CurrentBlock.Move(-1, 0);
            PlaceBlock();
        }
    }

}
