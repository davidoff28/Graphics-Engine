using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenGL;

namespace Engine
{
    public class VertexBuffer
    {
        private uint _id;
        private BufferUsage _usage;
        private BufferTarget _target;

        public uint ID
        {
            get => _id;
        }

        public bool IsActive
        {
            get => _id != 0;
        }

        public VertexBuffer(BufferTarget target, BufferUsage usage)
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
        
        public void SetData(float[] data)
        {
            Gl.BufferData(_target, (uint)(4 * data.Length), data, _usage);
        }

        public void Delete()
        {
            Gl.DeleteBuffers(_id);
            _id = 0;
        }
    }
}
