using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLEDNYA_LBA.MatrixElements
{
    public class Hero : Cell
    {
        Teleport teleport = new Teleport(-1, -1);

        public bool Safe { get; set; }
        public Hero(int X, int Y)
        {
            Icon = Resource.Hero;
            this.X = X;
            this.Y = Y;
        }

        public int Coin { get; set; } = 0;

        public List<Cell> inventoty = new List<Cell>();

        public void Inventory(Field field, Hero hero)
        {
            try
            {
                Cell backpack = inventoty.ElementAt(0);            
                if (!(field.gameField[hero.Y + 1, hero.X] is Wall) && backpack is Lom)
                {
                    field.gameField[hero.Y + 1, hero.X] = new Empty(hero.X, hero.Y + 1);
                    inventoty.RemoveAt(0);
                }
                else if(!(field.gameField[hero.Y, hero.X - 1] is Wall) && backpack is TrapRope)
                {
                    field.gameField[hero.Y, hero.X - 1] = new TrapRope(hero.X - 1, hero.Y);
                    inventoty.RemoveAt(0);
                }
            }
            catch (IndexOutOfRangeException)
            {
                X = hero.X;
                Y = hero.Y;
            }
        }

        public void HeroPutsMein(Field field, Hero hero)
        {
            field.gameField[hero.Y, hero.X - 1] = new Mine(hero.X - 1, hero.Y);
        }

        public void Insert_In_Matrix(int x, int y, Field field, Hero player, Cell tl)
        {
            if (x < Field.size_x && x >= 0 && y < Field.size_y && y >= 0)
            {
                try
                {
                    if (field.gameField[y, x] is TrapRope)
                    {
                        X = x;
                        Y = y;
                        inventoty.Add(field.gameField[y, x]);
                        field.gameField[y, x] = new Empty(y, x);
                    }
                    else if ((field.gameField[y + 1, x] is Empty) && (field.gameField[y, x] is Empty))
                    {
                        for (; !(field.gameField[y, x] is Wall) && !(field.gameField[y, x] is Sand);)
                        {
                            X = x;
                            Y = y++;
                        }
                    }
                    else if (field.gameField[y, x] is Teleport)
                    {
                        teleport.TeleportHero(field, player, tl);
                    }
                    else if (field.gameField[y + 1, x] is Sand && (field.gameField[y + 2, x] is Empty))
                    {
                        X = x;
                        Y = y;
                        field.gameField[y + 1, x] = new Empty(y + 1, x);
                        field.gameField[y + 2, x] = new Sand(y + 2, x);
                    }
                    else if (field.gameField[y, x] is Empty || field.gameField[y, x] is Ladder)
                    {
                        X = x;
                        Y = y;
                    }
                    else if (field.gameField[y, x] is Gold)
                    {
                        X = x;
                        Y = y;
                        field.gameField[y, x] = new Empty(y, x);
                        field.NumberOfGold--;
                        Coin++;
                    }
                    else if(field.gameField[y, x] is Lom)
                    {
                        X = x;
                        Y = y;
                        inventoty.Add(field.gameField[y, x]);
                        field.gameField[y, x] = new Empty(y, x);
                    }
                }
                catch
                {
                    X = X;
                    Y = Y;
                }
            }
        }
    }
}

