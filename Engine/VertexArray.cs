using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenGL;

namespace Engine
{
    public class VertexArray
    {
        private uint _id;

        public VertexArray()
        {
            _id = Gl.GenVertexArray();
        }

        public void Bind()
        {
            Gl.BindVertexArray(_id);
        }

        public void Unbind()
        {
            Gl.BindVertexArray(0);            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">Specifies the index of the attribute.</param>
        /// <param name="size">Specifies the number of components per vertex attribute. Must be 1, 2, 3, or 4.</param>
        /// <param name="normalized">Specifies whether the data should be normalized (clamped to the range -1 to 1 for signed values and 0 to 1 for unsigned values).</param>
        /// <param name="stride">Specifies the byte offset between consecutive vertex attributes. If stride is 0, the generic vertex attributes are understood to be tightly packed in the array.</param>
        /// <param name="offset">Specifies the offset of the first component of the first vertex attribute in the array.</param>
        public void AttributePointer(uint index, int size, VertexAttribType type, bool normalized, int stride, int offset)
        {
            Gl.EnableVertexAttribArray(index);
            Gl.VertexAttribPointer(index, size, type, normalized, stride * 4, (IntPtr)(offset * 4));
        }

        public void Delete()
        {
            Gl.DeleteVertexArrays(_id);
            _id = 0;
        }
    }
}
