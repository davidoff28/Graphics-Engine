using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Maths
{
    public struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    case 3: return w;
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
                    case 3: w = value; break;
                    default: throw new IndexOutOfRangeException("Invalid Vector Index!");
                }
            }
        }

        public float Length
        {
            get => MathsX.Sqrt(x * x + y * y + z * z + w * w);
        }

        public float SqrLength
        {
            get => x * x + y * y + z * z + w * w;
        }

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4(Vector2 vec2, float z, float w)
        {
            this.x = vec2.x;
            this.y = vec2.y;
            this.z = z;
            this.w = w;
        }

        public Vector4(Vector3 vec3, float w)
        {
            this.x = vec3.x;
            this.y = vec3.y;
            this.z = vec3.z;
            this.w = w;
        }

        public Vector4(float value)
        {
            this.x = value;
            this.y = value;
            this.z = value;
            this.w = value;
        }

        public static Vector4 operator -(Vector4 v) => new Vector4(-v.x, -v.y, -v.z, -v.w);

        public static Vector4 operator +(Vector4 a, Vector4 b) => new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        public static Vector4 operator -(Vector4 a, Vector4 b) => new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        public static Vector4 operator *(Vector4 a, Vector4 b) => new Vector4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        public static Vector4 operator /(Vector4 a, Vector4 b) => new Vector4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);

        public static Vector4 operator +(Vector4 a, float b) => new Vector4(a.x + b, a.y + b, a.z + b, a.w + b);
        public static Vector4 operator -(Vector4 a, float b) => new Vector4(a.x - b, a.y - b, a.z - b, a.w - b);
        public static Vector4 operator *(Vector4 a, float b) => new Vector4(a.x * b, a.y * b, a.z * b, a.w * b);
        public static Vector4 operator /(Vector4 a, float b) => new Vector4(a.x / b, a.y / b, a.z / b, a.w / b);

        public static bool operator ==(Vector4 a, Vector4 b) => a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
        public static bool operator !=(Vector4 a, Vector4 b) => a.x != b.x || a.y != b.y || a.z != b.z || a.w != b.w;

        public static float Distance(Vector4 a, Vector4 b) => (a - b).Length;
        public static float DistanceSqrd(Vector4 a, Vector4 b) => (a - b).SqrLength;

        public static float Dot(Vector4 a, Vector4 b) => a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;

        public static Vector4 Clamp(Vector4 value, Vector4 min, Vector4 max) => new Vector4(
            MathsX.Clamp(value.x, min.x, max.x),
            MathsX.Clamp(value.y, min.y, max.y),
            MathsX.Clamp(value.z, min.z, max.z),
            MathsX.Clamp(value.w, min.w, max.w));

        public static Vector4 Lerp(Vector4 a, Vector4 b, float amount) => new Vector4(
            MathsX.Lerp(a.x, b.x, amount),
            MathsX.Lerp(a.y, b.y, amount),
            MathsX.Lerp(a.z, b.z, amount),
            MathsX.Lerp(a.w, b.w, amount));

        public static Vector4 Min(Vector4 a, Vector4 b) => new Vector4(
            MathsX.Min(a.x, b.x),
            MathsX.Min(a.y, b.y),
            MathsX.Min(a.z, b.z),
            MathsX.Min(a.w, b.w));

        public static Vector4 Max(Vector4 a, Vector4 b) => new Vector4(
            MathsX.Max(a.x, b.x),
            MathsX.Max(a.y, b.y),
            MathsX.Max(a.z, b.z),
            MathsX.Max(a.w, b.w));

        public void Normalize() => this *= (1f / Length);

        public float[] ToArray() => new float[4] { x, y, z, w };

        public override bool Equals(object obj) => (obj is Vector4) ? this == (Vector4)obj : false;

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = w.GetHashCode();
                hashCode = (hashCode * 397) ^ x.GetHashCode();
                hashCode = (hashCode * 397) ^ y.GetHashCode();
                hashCode = (hashCode * 397) ^ z.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString() => string.Format("Vec4(X:{0}, Y:{1}, Z:{2}, W:{3})", x, y, z, w);
    }
}
