using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Engine.Maths;

using OpenGL;

namespace Engine
{
    public class BufferObject<T> where T : struct
    {
        private uint _id;
        private BufferTarget _target;
        private BufferUsage _usage;

        private int _size;
        private VertexAttribType _type;
        private int _count;

        public uint ID
        {
            get => _id;
        }

        public int Size
        {
            get => _size;
        }

        public VertexAttribType Type
        {
            get => _type;
        }

        public int Count
        {
            get => _count;            
        }        

        public BufferObject(BufferTarget target, BufferUsage usage)
        {
            _id = Gl.CreateBuffer();
            _target = target;
            _usage = usage;
        }

        public void Bind()
        {
            Gl.BindBuffer(_target, _id);
        }

        public void Unbind()
        {
            Gl.BindBuffer(_target, 0);
        }

        public void SetData(T[] data)
        {
            uint size = (uint)(data.Length * Marshal.SizeOf(typeof(T)));

            BufferData(size, data);
        }

        public void SetData(List<T> data)
        {
            SetData(data.ToArray());
        }

        private void BufferData(uint size, T[] data)
        {
            _size = (data is uint[] ? 1 : (data is Vector2[] ? 2 : (data is Vector3[] ? 3 : (data is Vector4[] ? 4 : 0))));
            _type = (data is uint[] ? VertexAttribType.UnsignedInt : VertexAttribType.Float);
            _count = data.Length;

            Gl.BufferData(_target, size, data, _usage);
        }

        public void Delete()
        {
            Gl.BindBuffer(_target, 0);
            _id = 0;
        }
    }
}
