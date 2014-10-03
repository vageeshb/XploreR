using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DSOD_Assignment2
{
    class MultiCellBuffer
    {
        private int numOfCells;
        public int index = -1;
        public string[] bufferArray;
        public delegate void orderPlaced(int index);
        public event orderPlaced orderPlacedEvent;
        // Constructor to initialize the number of cells and the buffer array
        public MultiCellBuffer(int numOfCells)
        {
            this.numOfCells = numOfCells;
            bufferArray = new string[numOfCells];
        }

        public string getOneCell(int index)
        {
            string cell = null;
            // Block the cell buffer
            lock (this)
            {
                // Wait if there is nothing in the buffer
                while (isEmpty())
                {
                    Monitor.Wait(this);
                }

                // Cell was filled, fetch the cell value and reduce the index value
                cell = bufferArray[index];
                index--;

                // Let all other blocked threads know that this one has finished locking
                Monitor.PulseAll(this);
            }

            return cell;
        }

        public void setOneCell(string cell)
        {
            // Block the cell buffer
            lock (this)
            {
                // Wait if the buffer is full
                while (isFull())
                {
                    Monitor.Wait(this);
                }

                // Cell space was empty, increase the index value and fill the cell
                index++;
                bufferArray[index] = cell;

                orderPlacedEvent(index);

                // Let all other blocked threads know that this one has finished locking
                Monitor.PulseAll(this);
            }
        }

        public bool isEmpty()
        {
            return index == -1;
        }
        public bool isFull()
        {
            return index == numOfCells - 1;
        }
    }
}
