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
        private int index = -1;
        private string[] bufferArray;
        
        // Constructor to initialize the number of cells and the buffer array
        public MultiCellBuffer(int numOfCells)
        {
            this.numOfCells = numOfCells;
            bufferArray = new string[numOfCells];
        }

        // Getter function to get one cell
        public string getOneCell()
        {
            string cell = null;
            lock (this)
            {
                // Wait if the cells are empty
                while (isEmpty())
                {
                    Monitor.Wait(this);
                }
                
                // Cell was filled, fetch the cell value
                cell = bufferArray[index];
                Monitor.PulseAll(this);
            }
            return cell;
        }

        public void setOneCell(string cell)
        {
            // Wait if the buffer is full
            lock (this)
            {
                while (isFull())
                {
                    Monitor.Wait(this);
                }

                // Cell space was empty, increase the index value and fill the cell
                index++;
                bufferArray[index] = cell;
                Monitor.PulseAll(this);
            }
            
        }

        // Utility function to delete cell
        public void deleteCell()
        {
            lock (this)
            {
                index--;
            }
        }

        // Utility function to see if cells are empty
        public bool isEmpty()
        {
            return index == -1;
        }

        // Utility function to see if cells are full
        public bool isFull()
        {
            return index == numOfCells - 1;
        }
    }
}

