using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using POSLEDNYA_LBA.MatrixElements;
using Newtonsoft.Json;
using System.IO;

namespace POSLEDNYA_LBA
{
    public class Field
    {
        public Field()
        {

        }

        public int NumberOfGold { get; set; }

        public const int size_y = 9;

        public const int size_x = 9;

        public Cell[,] gameField = new Cell[size_y, size_x];

        

        char[,] Example =
        { 
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', },
        {'#', ' ', 'R', 'G', 'R', ' ', ' ', 'T', '#' },
        {'#', '|', '#', '#', '#', 'S', 'S', '#', '#' },
        {'#', '|', ' ', 'L', 'L', ' ', ' ', ' ', '#' },
        {'#', '#', '|', '#', '#', '#', '#', '#', '#' },
        {'#', ' ', '|', ' ', ' ', ' ', ' ', ' ', '#' },
        {'#', '#', '#', '#', '#', '#', '|', '#', '#' },
        {'#', ' ', ' ', ' ', ' ', 'G', '|', 'T', '#' },
        {'#', '#', '#', '#', '#', '#', '#', '#', '#' },
        };

        public void Searialize()
        {
            File.WriteAllText("Field.json", JsonConvert.SerializeObject(Example));
        }

        public Field BuildField(Teleport teleport, string name)
        {
            Field newField = new Field();
            Example = JsonConvert.DeserializeObject<char[,]>(File.ReadAllText(name));
            for (int i = 0; i < size_y; i++)
            {
                for (int j = 0; j < size_x; j++)
                {
                    if (Example[i, j] == 'R')
                    {
                        newField.gameField[i, j] = new TrapRope(i, j);
                    }
                    if (Example[i, j] == 'T')
                    {
                        newField.gameField[i, j] = teleport;
                        teleport.X = i;
                        teleport.Y = j;
                    }
                    if (Example[i, j] == 'S')
                    {
                        newField.gameField[i, j] = new Sand(i, j);
                    }
                    if (Example[i, j] == 'L')
                    {
                        newField.gameField[i, j] = new Lom(i, j);
                    }
                    if (Example[i, j] == ' ')
                    {
                        newField.gameField[i, j] = new Empty(i, j);
                    }
                    if (Example[i, j] == '#')
                    {
                        newField.gameField[i, j] = new Wall(i, j);
                    }
                    if (Example[i, j] == 'G')
                    {
                        newField.NumberOfGold++;
                        newField.gameField[i, j] = new Gold(i, j);
                    }
                    if (Example[i, j] == '|')
                    {
                        newField.gameField[i, j] = new Ladder(i, j);
                    }
                }
            }
            return newField;
        }

        Cell this[int x, int y]
        {
            get => gameField[x, y];
            set => gameField[x, y] = value;
        }
    }
}
