using System;
using System.Collections.Generic;
using System.Drawing;

namespace FreeFlowAI
{
    public class Board
    {
        #region Static


        #endregion

        #region Properties

        /// <summary>
        /// The current state of the board. integer values represent the different contents of a cell. 0 indicates an empty cell.
        /// </summary>
        public byte[][] board { get; private set; }

        /// <summary>
        /// The keys identifying the colors for the board.
        /// </summary>
        Dictionary<byte, Color> ColorKeys;

        /// <summary>
        /// Gets the width of the board.
        /// </summary>
        public int width
        {
            get
            {
                return board.Length;
            }
        }

        /// <summary>
        /// Gets the height of the board.
        /// </summary>
        public int height
        {
            get
            {
                return board[0].Length;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an w * h sized, empty board.
        /// </summary>
        /// <param name="w">The width of the board.</param>
        /// <param name="h">The height of the board.</param>
        private Board(int w, int h)
        {
            // Create a new board of empty spaces.
            board = new byte[w][];
            for (int i = 0; i < w; i++)
            {
                board[i] = new byte[h];
                for (int j = 0; j < h; j++)
                    board[i][j] = 0;
            }
        }

        /// <summary>
        /// Creates a solvable board with a specified number of unique pipes.
        /// </summary>
        /// <param name="w">The width of the board.</param>
        /// <param name="h">The height of the board.</param>
        /// <param name="numPipes">The number of unique pipes to create.</param>
        public Board(int w, int h, byte numPipes) : this(w, h)
        {
            System.Random rng = new System.Random();
            // Create color pieces.
            ColorKeys = new Dictionary<byte, Color>();
            for (byte i = 0; i < numPipes; i++)
                ColorKeys.Add(i, Color.FromArgb(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256)));

            // Construct the board.
            ConstructBoard(numPipes);
        }

        #endregion

        #region Methods

        private void ConstructBoard(int numColors)
        {
            System.Random rng = new System.Random();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    board[i][j] = (byte)rng.Next(1, numColors + 1);
                }
            }
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Converts a board to ascii representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retVal = "";
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    retVal += board[w][h];
                }
                retVal += "\n";
            }
            return retVal;
        }
        #endregion
    }
}
