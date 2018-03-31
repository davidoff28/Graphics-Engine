using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenGL;

namespace Engine
{
    public class Shader
    {       
        private uint _id;
        private ShaderType _type;        

        public uint ID
        {
            get => _id;
        }

        public Shader(ShaderType type, string source)
        {           
            _type = type;
            _id = Gl.CreateShader(type);
            Gl.ShaderSource(_id, new string[1] { source });
            Gl.CompileShader(_id);
        }

        public void Delete()
        {
            Gl.DeleteShader(_id);
            _id = 0;
        }
    }
}
