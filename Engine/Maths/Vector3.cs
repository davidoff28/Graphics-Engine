using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Maths
{
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;                    
                    default: throw new IndexOutOfRangeException("Invalid Vector Index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;                    
                    default: throw new IndexOutOfRangeException("Invalid Vector Index!");
                }
            }
        }

        public float Length
        {
            get => MathsX.Sqrt(x * x + y * y + z * z);
        }

        public float SqrLength
        {
            get => x * x + y * y + z * z;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(Vector2 value, float z)
        {
            this.x = value.x;
            this.y = value.y;
            this.z = z;
        }

        public Vector3(float value)
        {
            this.x = value;
            this.y = value;
            this.z = value;
        }

        public static Vector3 operator -(Vector3 v) => new Vector3(-v.x, -v.y, -v.z);

        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3 operator *(Vector3 a, Vector3 b) => new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vector3 operator /(Vector3 a, Vector3 b) => new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);

        public static Vector3 operator +(Vector3 a, float b) => new Vector3(a.x + b, a.y + b, a.z + b);
        public static Vector3 operator -(Vector3 a, float b) => new Vector3(a.x - b, a.y - b, a.z - b);
        public static Vector3 operator *(Vector3 a, float b) => new Vector3(a.x * b, a.y * b, a.z * b);
        public static Vector3 operator *(float a, Vector3 b) => new Vector3(a * b.x, a * b.y, a * b.z);
        public static Vector3 operator /(Vector3 a, float b) => new Vector3(a.x / b, a.y / b, a.z / b);

        public static bool operator ==(Vector3 a, Vector3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
        public static bool operator !=(Vector3 a, Vector3 b) => a.x != b.x || a.y != b.y || a.z != b.z;

        public static float Distance(Vector3 a, Vector3 b) => (a - b).Length;
        public static float DistanceSqrd(Vector3 a, Vector3 b) => (a - b).SqrLength;

        public static float Dot(Vector3 a, Vector3 b) => a.x * b.x + a.y * b.y + a.z * b.z;

        public static Vector3 Cross(Vector3 a, Vector3 b) => new Vector3(
            a.y * b.z - a.z * b.y,
            a.z * b.x - a.x * b.z,
            a.x * b.y - a.y * b.x);

        public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max) => new Vector3(
            MathsX.Clamp(value.x, min.x, max.x),
            MathsX.Clamp(value.y, min.y, max.y),
            MathsX.Clamp(value.z, min.z, max.z));

        public static Vector3 Lerp(Vector3 a, Vector3 b, float amount) => new Vector3(
            MathsX.Lerp(a.x, b.x, amount),
            MathsX.Lerp(a.y, b.y, amount),
            MathsX.Lerp(a.z, b.z, amount));

        public static Vector3 Min(Vector3 a, Vector3 b) => new Vector3(
            MathsX.Min(a.x, b.x),
            MathsX.Min(a.y, b.y),
            MathsX.Min(a.z, b.z));

        public static Vector3 Max(Vector3 a, Vector3 b) => new Vector3(
            MathsX.Max(a.x, b.x),
            MathsX.Max(a.y, b.y),
            MathsX.Max(a.z, b.z));

        // http://www.3dkingdoms.com/weekly/weekly.php?a=2
        public static Vector3 Reflect(Vector3 vector, Vector3 normal) => -2f * Dot(vector, normal) * normal + vector;

        // https://math.oregonstate.edu/home/programs/undergrad/CalculusQuestStudyGuides/vcalc/dotprod/dotprod.html
        public static Vector3 Project(Vector3 vector, Vector3 normal) => normal * Dot(vector, normal) / Dot(normal, normal);

        public void Normalize() => this *= (1f / Length);

        public float[] ToArray() => new float[3] { x, y, z };

        public override bool Equals(object obj) => (obj is Vector3) ? this == (Vector3)obj : false;

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = x.GetHashCode();                
                hashCode = (hashCode * 397) ^ y.GetHashCode();
                hashCode = (hashCode * 397) ^ z.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString() => string.Format("Vec3(X:{0}, Y:{1}, Z:{2})", x, y, z);
    }
}
