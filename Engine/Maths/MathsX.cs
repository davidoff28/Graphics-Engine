using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Maths
{
    public static class MathsX
    {
        public const float Pi = (float)Math.PI;
        public const float PiOver2 = (float)(Math.PI / 2.0);
        public const float PiOver4 = (float)(Math.PI / 4.0);
        public const float TwoPi = (float)(Math.PI * 2.0);

        public static float Sin(float x) => (float)Math.Sin(x);
        public static float Cos(float x) => (float)Math.Cos(x);
        public static float Tan(float x) => (float)Math.Tan(x);
        public static float Tanh(float x) => (float)Math.Tanh(x);

        public static float Asin(float x) => (float)Math.Asin(x);
        public static float Acos(float x) => (float)Math.Acos(x);
        public static float Atan(float x) => (float)Math.Atan(x);
        public static float Atan2(float y, float x) => (float)Math.Atan2(y, x);

        public static float Abs(float x) => Math.Abs(x);
        public static float Ceil(float x) => (float)Math.Ceiling(x);
        public static float Floor(float x) => (float)Math.Floor(x);

        public static float Log(float x) => (float)Math.Log(x);
        public static float Log(float x, int logBase) => (float)(Math.Log(x, logBase));
        public static float Log2(float x) => (float)Math.Log(x, 2);
        public static float Log10(float x) => (float)Math.Log10(x);
        
        public static float Sqrt(float x) => (float)Math.Sqrt(x);

        public static float Distance(float a, float b) => Math.Abs(a - b);

        public static int Clamp(int value, int min, int max) => (value > max) ? max : (value < min) ? min : value;
        public static float Clamp(float value, float min, float max) => (value > max) ? max : (value < min) ? min : value;

        public static int Lerp(int a, int b, int amount) => a + (b - a) * amount;
        public static float Lerp(float a, float b, float amount) => a + (b - a) * amount;

        public static float Min(float a, float b) => a < b ? a : b;
        public static float Max(float a, float b) => a > b ? a : b;

        public static int Min(int a, int b) => a < b ? a : b;
        public static int Max(int a, int b) => a > b ? a : b;

        public static float ToDegrees(float radians) => (float)(radians * 57.295779513082320876798154814105);
        public static float ToRadians(float degrees) => (float)(degrees * 0.017453292519943295769236907684886);

        public static bool IsPowerOfTwo(int value) => (value > 0) && ((value & (value - 1)) == 0);
    }
}
