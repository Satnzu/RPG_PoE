using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PoE
{
    public class IntVector : IComparable<IntVector>
    {
        public int x;
        public int y;

        public IntVector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double Magnitude
        {
            get { return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)); }
            private set { }

        }

        public int CompareTo(IntVector intVector)
        {
            try
            {
                return Magnitude.CompareTo(intVector);
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public static bool operator >=(IntVector operand1, IntVector operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        public static bool operator <=(IntVector operand1, IntVector operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }

        public static bool operator ==(IntVector operand1, IntVector operand2)
        {
            return (operand1.x - operand2.x == 0 && operand1.y - operand2.y == 0);
        }

        public static bool operator !=(IntVector operand1, IntVector operand2)
        {
            return !(operand1.x - operand2.x == 0 && operand1.y - operand2.y == 0);
        }

        public static bool operator >(IntVector operand1, IntVector operand2)
        {
            return operand1.CompareTo(operand2) > 0;
        }

        public static bool operator <(IntVector operand1, IntVector operand2)
        {
            return operand1.CompareTo(operand2) < 0;
        }

        public static IntVector operator +(IntVector a, IntVector b)
        {
            IntVector vector = new IntVector(a.x + b.x, a.y + b.y);
            return vector;
        }

        public static IntVector operator -(IntVector a, IntVector b)
        {
            IntVector vector = new IntVector(a.x - b.x, a.y - b.y);
            return vector;
        }

        public static IntVector operator *(IntVector a, IntVector b)
        {
            IntVector vector = new IntVector(a.x * b.x, a.y * b.y);
            return vector;
        }

        public static IntVector operator /(IntVector a, IntVector b)
        {
            IntVector vector = new IntVector(a.x / b.x, a.y / b.y);
            return vector;
        }

        public static IntVector operator *(IntVector a, int b)
        {
            IntVector vector = new IntVector(a.x * b, a.y * b);
            return vector;
        }

        public static IntVector operator /(IntVector a, double b)
        {
            IntVector vector = new IntVector((int)Math.Round(a.x / b), (int)Math.Round(a.y / b));
            return vector;
        }
    }
}
