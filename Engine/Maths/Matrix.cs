using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Maths
{
    public struct Matrix
    {
        private static readonly Matrix identity = new Matrix(1f, 0f, 0f, 0f,
                                                            0f, 1f, 0f, 0f,
                                                            0f, 0f, 1f, 0f,
                                                            0f, 0f, 0f, 1f);

        public float m11, m12, m13, m14;
        public float m21, m22, m23, m24;
        public float m31, m32, m33, m34;
        public float m41, m42, m43, m44;

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return m11;
                    case 1: return m12;
                    case 2: return m13;
                    case 3: return m14;

                    case 4: return m21;
                    case 5: return m22;
                    case 6: return m23;
                    case 7: return m24;

                    case 8: return m31;
                    case 9: return m32;
                    case 10: return m33;
                    case 11: return m34;

                    case 12: return m41;
                    case 13: return m42;
                    case 14: return m43;
                    case 15: return m44;                    
                    default: throw new IndexOutOfRangeException("Invalid Matrix Index!");                        
                }
            }
            set
            {
                switch (index)
                {
                    case 0: m11 = value; break;
                    case 1: m12 = value; break;
                    case 2: m13 = value; break;
                    case 3: m14 = value; break;

                    case 4: m21 = value; break;
                    case 5: m22 = value; break;
                    case 6: m23 = value; break;
                    case 7: m24 = value; break;

                    case 8:  m31 = value; break;
                    case 9:  m32 = value; break;
                    case 10: m33 = value; break;
                    case 11: m34 = value; break;

                    case 12: m41 = value; break;
                    case 13: m42 = value; break;
                    case 14: m43 = value; break;
                    case 15: m44 = value; break;
                    default: throw new IndexOutOfRangeException("Invalid Matrix Index!");
                }
            }
        }

        public float this[int row, int column]
        {
            get => this[(row * 4) + column];
            set => this[(row * 4) + column] = value;
        }

        public Vector3 Right
        {
            get => new Vector3(m11, m12, m13);
            set { m11 = value.x; m12 = value.y; m13 = value.z; }
        }

        public Vector3 Up
        {
            get => new Vector3(m21, m22, m23);
            set { m21 = value.x; m22 = value.y; m23 = value.z; }
        }

        public Vector3 Backward
        {
            get => new Vector3(m31, m32, m33);
            set { m31 = value.x; m32 = value.y; m33 = value.z; }
        }

        public Vector3 Translation
        {
            get => new Vector3(m41, m42, m43);
            set { m41 = value.x; m42 = value.y; m43 = value.z; }
        }

        public Vector3 Left
        {
            get => new Vector3(m11, m12, m13);
            set { m11 = -value.x; m12 = -value.y; m13 = -value.z; }
        }

        public Vector3 Down
        {
            get => new Vector3(-m21, -m22, -m23);
            set { m21 = -value.x; m22 = -value.y; m23 = -value.z; }
        }

        public Vector3 Forward
        {
            get => new Vector3(-m31, -m32, -m33);
            set { m31 = -value.x; m32 = -value.y; m33 = -value.z; }
        }

        public static Matrix Identity
        {
            get => identity;
        }

        public Matrix(
            float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m14 = m14;
            this.m21 = m21;
            this.m22 = m22;
            this.m23 = m23;
            this.m24 = m24;
            this.m31 = m31;
            this.m32 = m32;
            this.m33 = m33;
            this.m34 = m34;
            this.m41 = m41;
            this.m42 = m42;
            this.m43 = m43;
            this.m44 = m44;
        }

        public Matrix(Vector4 row1, Vector4 row2, Vector4 row3, Vector4 row4)
            : this(row1.x, row1.y, row1.z, row1.w,
                  row2.x, row2.y, row2.z, row2.w,
                  row3.x, row3.y, row3.z, row3.w,
                  row4.x, row4.y, row4.z, row4.w)
        {

        }

        public static Matrix operator -(Matrix m)
        {
            return new Matrix(
                -m.m11, -m.m12, -m.m13, -m.m14,
                -m.m21, -m.m22, -m.m23, -m.m24,
                -m.m31, -m.m32, -m.m33, -m.m34,
                -m.m41, -m.m42, -m.m43, -m.m44);
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            float m11 = a.m11 + b.m11;
            float m12 = a.m12 + b.m12;
            float m13 = a.m13 + b.m13;
            float m14 = a.m14 + b.m14;
            float m21 = a.m21 + b.m21;
            float m22 = a.m22 + b.m22;
            float m23 = a.m23 + b.m23;
            float m24 = a.m24 + b.m24;
            float m31 = a.m31 + b.m31;
            float m32 = a.m32 + b.m32;
            float m33 = a.m33 + b.m33;
            float m34 = a.m34 + b.m34;
            float m41 = a.m41 + b.m41;
            float m42 = a.m42 + b.m42;
            float m43 = a.m43 + b.m43;
            float m44 = a.m44 + b.m44;

            return new Matrix(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            float m11 = a.m11 - b.m11;
            float m12 = a.m12 - b.m12;
            float m13 = a.m13 - b.m13;
            float m14 = a.m14 - b.m14;
            float m21 = a.m21 - b.m21;
            float m22 = a.m22 - b.m22;
            float m23 = a.m23 - b.m23;
            float m24 = a.m24 - b.m24;
            float m31 = a.m31 - b.m31;
            float m32 = a.m32 - b.m32;
            float m33 = a.m33 - b.m33;
            float m34 = a.m34 - b.m34;
            float m41 = a.m41 - b.m41;
            float m42 = a.m42 - b.m42;
            float m43 = a.m43 - b.m43;
            float m44 = a.m44 - b.m44;

            return new Matrix(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            float m11 = (((a.m11 * b.m11) + (a.m12 * b.m21)) + (a.m13 * b.m31)) + (a.m14 * b.m41);
            float m12 = (((a.m11 * b.m12) + (a.m12 * b.m22)) + (a.m13 * b.m32)) + (a.m14 * b.m42);
            float m13 = (((a.m11 * b.m13) + (a.m12 * b.m23)) + (a.m13 * b.m33)) + (a.m14 * b.m43);
            float m14 = (((a.m11 * b.m14) + (a.m12 * b.m24)) + (a.m13 * b.m34)) + (a.m14 * b.m44);
            float m21 = (((a.m21 * b.m11) + (a.m22 * b.m21)) + (a.m23 * b.m31)) + (a.m24 * b.m41);
            float m22 = (((a.m21 * b.m12) + (a.m22 * b.m22)) + (a.m23 * b.m32)) + (a.m24 * b.m42);
            float m23 = (((a.m21 * b.m13) + (a.m22 * b.m23)) + (a.m23 * b.m33)) + (a.m24 * b.m43);
            float m24 = (((a.m21 * b.m14) + (a.m22 * b.m24)) + (a.m23 * b.m34)) + (a.m24 * b.m44);
            float m31 = (((a.m31 * b.m11) + (a.m32 * b.m21)) + (a.m33 * b.m31)) + (a.m34 * b.m41);
            float m32 = (((a.m31 * b.m12) + (a.m32 * b.m22)) + (a.m33 * b.m32)) + (a.m34 * b.m42);
            float m33 = (((a.m31 * b.m13) + (a.m32 * b.m23)) + (a.m33 * b.m33)) + (a.m34 * b.m43);
            float m34 = (((a.m31 * b.m14) + (a.m32 * b.m24)) + (a.m33 * b.m34)) + (a.m34 * b.m44);
            float m41 = (((a.m41 * b.m11) + (a.m42 * b.m21)) + (a.m43 * b.m31)) + (a.m44 * b.m41);
            float m42 = (((a.m41 * b.m12) + (a.m42 * b.m22)) + (a.m43 * b.m32)) + (a.m44 * b.m42);
            float m43 = (((a.m41 * b.m13) + (a.m42 * b.m23)) + (a.m43 * b.m33)) + (a.m44 * b.m43);
            float m44 = (((a.m41 * b.m14) + (a.m42 * b.m24)) + (a.m43 * b.m34)) + (a.m44 * b.m44);
            
            return new Matrix(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
        }

        public static Matrix operator /(Matrix a, Matrix b)
        {
            float m11 = a.m11 / b.m11;
            float m12 = a.m12 / b.m12;
            float m13 = a.m13 / b.m13;
            float m14 = a.m14 / b.m14;
            float m21 = a.m21 / b.m21;
            float m22 = a.m22 / b.m22;
            float m23 = a.m23 / b.m23;
            float m24 = a.m24 / b.m24;
            float m31 = a.m31 / b.m31;
            float m32 = a.m32 / b.m32;
            float m33 = a.m33 / b.m33;
            float m34 = a.m34 / b.m34;
            float m41 = a.m41 / b.m41;
            float m42 = a.m42 / b.m42;
            float m43 = a.m43 / b.m43;
            float m44 = a.m44 / b.m44;

            return new Matrix(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
        }

        public static Matrix operator *(Matrix a, float b)
        {
            float m11 = a.m11 * b;
            float m12 = a.m12 * b;
            float m13 = a.m13 * b;
            float m14 = a.m14 * b;
            float m21 = a.m21 * b;
            float m22 = a.m22 * b;
            float m23 = a.m23 * b;
            float m24 = a.m24 * b;
            float m31 = a.m31 * b;
            float m32 = a.m32 * b;
            float m33 = a.m33 * b;
            float m34 = a.m34 * b;
            float m41 = a.m41 * b;
            float m42 = a.m42 * b;
            float m43 = a.m43 * b;
            float m44 = a.m44 * b;

            return new Matrix(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
        }

        public static Matrix operator /(Matrix a, float b)
        {
            float m11 = a.m11 / b;
            float m12 = a.m12 / b;
            float m13 = a.m13 / b;
            float m14 = a.m14 / b;
            float m21 = a.m21 / b;
            float m22 = a.m22 / b;
            float m23 = a.m23 / b;
            float m24 = a.m24 / b;
            float m31 = a.m31 / b;
            float m32 = a.m32 / b;
            float m33 = a.m33 / b;
            float m34 = a.m34 / b;
            float m41 = a.m41 / b;
            float m42 = a.m42 / b;
            float m43 = a.m43 / b;
            float m44 = a.m44 / b;

            return new Matrix(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            return 
                a.m11 == b.m11 && a.m12 == b.m12 && a.m13 == b.m13 && a.m14 == b.m14 &&
                a.m21 == b.m21 && a.m22 == b.m22 && a.m23 == b.m23 && a.m24 == b.m24 &&
                a.m31 == b.m31 && a.m32 == b.m32 && a.m33 == b.m33 && a.m34 == b.m34 &&
                a.m41 == b.m41 && a.m42 == b.m42 && a.m43 == b.m43 && a.m44 == b.m44;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            return 
                a.m11 != b.m11 || a.m12 != b.m12 || a.m13 != b.m13 || a.m14 != b.m14 ||
                a.m21 != b.m21 || a.m22 != b.m22 || a.m23 != b.m23 || a.m24 != b.m24 ||
                a.m31 != b.m31 || a.m32 != b.m32 || a.m33 != b.m33 || a.m34 != b.m34 ||
                a.m41 != b.m41 || a.m42 != b.m42 || a.m43 != b.m43 || a.m44 != b.m44;
        }

        public static Matrix CreateLookAt(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
        {
            var v1 = cameraPosition - cameraTarget;
            v1.Normalize();

            var v2 = Vector3.Cross(cameraUpVector, v1);
            v2.Normalize();

            var v3 = Vector3.Cross(v1, v2);

            Matrix result = identity;
            result.m11 = v2.x;
            result.m12 = v3.x;
            result.m13 = v1.x;

            result.m21 = v2.y;
            result.m22 = v3.y;
            result.m23 = v1.y;

            result.m31 = v2.y;
            result.m32 = v3.y;
            result.m33 = v1.y;

            result.m41 = -Vector3.Dot(v2, cameraPosition);
            result.m42 = -Vector3.Dot(v3, cameraPosition);
            result.m43 = -Vector3.Dot(v1, cameraPosition);

            return result;
        }

        public static Matrix CreateOrthographic(float width, float height, float zNearPlane, float zFarPlane)
        {
            Matrix result = identity;

            result.m11 = 2f / width;
            result.m22 = 2f / height;
            result.m33 = 1f / (zNearPlane - zFarPlane);
            result.m43 = zNearPlane / (zNearPlane - zFarPlane);

            return result;
        }

        public static Matrix CreatePerspective(float width, float height, float nearPlaneDistance, float farPlaneDistance)
        {
            if (nearPlaneDistance <= 0f) throw new ArgumentException("nearPlaneDistance <= 0");
            if (farPlaneDistance <= 0f) throw new ArgumentException("farPlaneDistance <= 0");
            if (nearPlaneDistance >= farPlaneDistance) throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");

            Matrix result = new Matrix();

            result.m11 = (2f * nearPlaneDistance) / width;
            result.m22 = (2f * nearPlaneDistance) / height;
            result.m33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.m34 = -1f;
            result.m43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);

            return result;
        }

        public static Matrix CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            if (fieldOfView <= 0f || fieldOfView >= 3.141593f) throw new ArgumentException("fieldOfView <= 0 or >= PI");
            if (nearPlaneDistance <= 0f) throw new ArgumentException("nearPlaneDistance <= 0");
            if (farPlaneDistance <= 0f) throw new ArgumentException("farPlaneDistance <= 0");
            if (nearPlaneDistance >= farPlaneDistance) throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");

            Matrix result = new Matrix();

            float numA = 1f / MathsX.Tan(fieldOfView * 0.5f);
            float numB = numA / aspectRatio;

            result.m11 = numB;
            result.m22 = numA;
            result.m33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.m34 = -1;
            result.m43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);

            return result;
        }

        public static Matrix CreateRotationX(float degrees)
        {
            Matrix result = identity;

            var val1 = MathsX.Cos(MathsX.ToRadians(degrees));
            var val2 = MathsX.Sin(MathsX.ToRadians(degrees));

            result.m22 = val1;
            result.m23 = val2;
            result.m32 = -val2;
            result.m33 = val1;

            return result;
        }

        public static Matrix CreateRotationY(float degrees)
        {
            Matrix result = identity;

            var val1 = MathsX.Cos(MathsX.ToRadians(degrees));
            var val2 = MathsX.Sin(MathsX.ToRadians(degrees));

            result.m11 = val1;
            result.m13 = -val2;
            result.m31 = val2;
            result.m33 = val1;

            return result;
        }

        public static Matrix CreateRotationZ(float degrees)
        {
            Matrix result = identity;

            var val1 = MathsX.Cos(MathsX.ToRadians(degrees));
            var val2 = MathsX.Sin(MathsX.ToRadians(degrees));

            result.m11 = val1;
            result.m12 = val2;
            result.m21 = -val2;
            result.m22 = val1;

            return result;
        }

        public static Matrix CreateScale(float scaleX, float scaleY, float scaleZ)
        {
            Matrix result = identity;

            result.m11 = scaleX;
            result.m22 = scaleY;
            result.m33 = scaleZ;

            return result;
        }

        public static Matrix CreateScale(Vector3 scaleXYZ)
        {
            Matrix result = identity;

            result.m11 = scaleXYZ.x;
            result.m22 = scaleXYZ.y;
            result.m33 = scaleXYZ.z;

            return result;
        }

        public static Matrix CreateTranslation(Vector3 position)
        {
            Matrix result = identity;
            result.Translation = position;
            return result;
        }

        public static Matrix CreateWorld(Vector3 position, Vector3 forward, Vector3 up)
        {
            Vector3 z = forward;
            z.Normalize();
            Vector3 x = Vector3.Cross(forward, up);
            Vector3 y = Vector3.Cross(x, forward);
            x.Normalize();
            y.Normalize();

            Matrix result = new Matrix
            {
                Right = x,
                Up = y,
                Forward = z,
                Translation = position,
                m44 = 1f
            };

            return result;
        }

        public float[] ToArray()
        {
            return new float[16]
            {
                m11, m12, m13, m14,
                m21, m22, m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44
            };
        }

        public override bool Equals(object obj)
        {
            return (obj is Matrix) ? this == (Matrix)obj : false;
        }

        public override int GetHashCode()
        {
            var hashCode = 0;
            for (int i = 0; i < 16; i++)
            {
                hashCode += this[i].GetHashCode();
            }

            return hashCode;
        }

        public override string ToString()
        {
            return "Mat({M11:" + m11 + " M12:" + m12 + " M13:" + m13 + " M14:" + m14 + "},"
                + " {M21:" + m21 + " M22:" + m22 + " M23:" + m23 + " M24:" + m24 + "},"
                + " {M31:" + m31 + " M32:" + m32 + " M33:" + m33 + " M34:" + m34 + "},"
                + " {M41:" + m41 + " M42:" + m42 + " M43:" + m43 + " M44:" + m44 + "})";
        }
    }
}
