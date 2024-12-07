using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    public class Guard
    {
        private readonly int _startRow;
        private readonly int _startCol;
        private readonly int _startDirection;
        private readonly char[,] _startRoom;

        public  int PosRow = 0;
        public int PosCol = 0;
        public char[,] Room = new char[130, 130];
        public int Direction = 0;
        public int NumberOFMoves = 0;
        


        public Guard(int StartPositionRoom, int StartPositionCol, char[,] StartRoom, int StartDirection = 0)
        {
            PosRow = _startRow = StartPositionRoom;
            PosCol = _startCol = StartPositionCol;
            Room =  _startRoom= StartRoom;
            Direction = _startDirection = StartDirection;
            DrawGrid();
        }

        public void Run()
        {

            try
            {
                UpdateCell('X');
                Move();
                FindDirection();
                UpdateCell(DirectionSymbol());
                Run();
            }
            catch (Exception ex)
            {
                Exit();
            }
        }
        
        void Move()
        {
            PosCol = getNextPos()[0];
            PosRow = getNextPos()[1];
        }
        
        void FindDirection()
        {
             if (Room[getNextPos()[1], getNextPos()[0]] == '#') { 
                Direction++; };
        
        }

       char DirectionSymbol()
        {
            switch (Direction){
                case 0:
                    return '^';
                case 1:
                    return '>';
                case 2:
                    return 'v';
                    case 3:
                    return '<';
                default:
                    return 'o';
            }
        }

        void Exit()
        {
            UpdateCell('X');
            Console.SetCursorPosition(0, 131);
            Console.WriteLine("Exited Room at position " + PosCol + " " + PosRow);
            Console.WriteLine("Distinct Places: " + FindDistinctPositions());

        }

        int FindDistinctPositions()
        {
            int count = 0;
            for (int i = 0; i < 130; i++)
            {
                for (int j = 0; j < 130; j++) {
                    if (Room[i, j] == 'X') count++;    
                }
            }
            return count;   
        }
        int[] getNextPos()
        {

             //checking direction 
            if (Direction % 4 == 0)
            {
                return [PosCol, PosRow - 1];
            }
            if (Direction % 4 == 1)
            {
                return [PosCol + 1, PosRow];
            }
            if (Direction % 4 == 2)
            {
                return [PosCol, PosRow + 1];
            }
            else 
            {
                return [PosCol - 1, PosRow];
            }
        }

         public void DrawGrid()
        {
            Console.Clear(); // Fjerner tidligere innhold
            for (int i = 0; i < Room.GetLength(0); i++)
            {
                for (int j = 0; j < Room.GetLength(1); j++)
                {
                    Console.Write(Room[i, j] + "");
                }
                Console.WriteLine();
            }
        }

        void UpdateCell(char newValue)
        {
            // Oppdater rutenettet i minnet
            Room[PosRow, PosCol] = newValue;

            // Tegn cellen direkte i konsollen
            Console.SetCursorPosition(PosCol, PosRow); // * 2 for mellomrom mellom kolonner
            Console.Write(newValue);
        }
       
    }

    public class Turn
    {
        public int PositionCol { get; set; }
        public int PositionRow { get; set; }
        public int Direction { get; set; }

        public override bool Equals(object obj)
        {
            // Sjekk om `obj` er null eller av feil type
            if (obj == null || obj.GetType() != typeof(Turn))
                return false;

            // Kast til Turn og sammenlign verdier
            Turn t = (Turn)obj;
            return t.PositionCol == PositionCol &&
                   t.PositionRow == PositionRow &&
                   t.Direction == Direction;
        }

        public override int GetHashCode()
        {
            // Generer en hashkode basert på felt
            return HashCode.Combine(PositionCol, PositionRow, Direction);
        }
    }

    public class LoopingException : Exception
    {
        public LoopingException(string message) : base(message) { }
    }
}
