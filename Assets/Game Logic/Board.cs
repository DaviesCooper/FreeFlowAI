namespace FreeFlowAI
{
    public class Board
    {

        /// <summary>
        /// The current state of the board. integer values represent the different contents of a cell. 0 indicates an empty cell.
        /// </summary>
        public byte[][] board { get; private set; }

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

        /// <summary>
        /// Creates an w * h sized board
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public Board(int w, int h)
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
    }
}
