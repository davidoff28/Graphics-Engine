using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Maths
{
    public struct Vector2
    {
        public float x;
        public float y;

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;                    
                    default: throw new IndexOutOfRangeException("Invalid Vector Index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;                    
                    default: throw new IndexOutOfRangeException("Invalid Vector Index!");
                }
            }
        }

        public float Length
        {
            get => MathsX.Sqrt(x * x + y * y);
        }

        public float SqrLength
        {
            get => x * x + y * y;
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(float value)
        {
            this.x = value;
            this.y = value;
        }

        public static Vector2 operator -(Vector2 v) => new Vector2(-v.x, -v.y);

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.x / b.x, a.y / b.y);

        public static Vector2 operator +(Vector2 a, float b) => new Vector2(a.x + b, a.y + b);
        public static Vector2 operator -(Vector2 a, float b) => new Vector2(a.x - b, a.y - b);
        public static Vector2 operator *(Vector2 a, float b) => new Vector2(a.x * b, a.y * b);
        public static Vector2 operator *(float a, Vector2 b) => new Vector2(a * b.x, a * b.y);
        public static Vector2 operator /(Vector2 a, float b) => new Vector2(a.x / b, a.y / b);

        public static bool operator ==(Vector2 a, Vector2 b) => a.x == b.x && a.y == b.y;
        public static bool operator !=(Vector2 a, Vector2 b) => a.x != b.x || a.y != b.y;

        public static float Distance(Vector2 a, Vector2 b) => (a - b).Length;
        public static float DistanceSqrd(Vector2 a, Vector2 b) => (a - b).SqrLength;

        public static float Dot(Vector2 a, Vector2 b) => a.x * b.x + a.y * b.y;

        public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max) => new Vector2(
            MathsX.Clamp(value.x, min.x, max.x),
            MathsX.Clamp(value.y, min.y, max.y));

        public static Vector2 Lerp(Vector2 a, Vector2 b, float amount) => new Vector2(
            MathsX.Lerp(a.x, b.x, amount),
            MathsX.Lerp(a.y, b.y, amount));

        public static Vector2 Min(Vector2 a, Vector2 b) => new Vector2(
            MathsX.Min(a.x, b.x),
            MathsX.Min(a.y, b.y));

        public static Vector2 Max(Vector2 a, Vector2 b) => new Vector2(
            MathsX.Max(a.x, b.x),
            MathsX.Max(a.y, b.y));            

        // http://www.3dkingdoms.com/weekly/weekly.php?a=2
        public static Vector2 Reflect(Vector2 vector, Vector2 normal) => -2f * Dot(vector, normal) * normal + vector;        

        public void Normalize() => this *= (1f / Length);

        public float[] ToArray() => new float[2] { x, y };

        public override bool Equals(object obj) => (obj is Vector2) ? this == (Vector2)obj : false;

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = x.GetHashCode();
                hashCode = (hashCode * 397) ^ y.GetHashCode();                
                return hashCode;
            }
        }

        public override string ToString() => string.Format("Vec2(X:{0}, Y:{1})", x, y);
    }
}
