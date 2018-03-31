using System.Collections.Generic;

using OpenGL;

namespace Engine
{
    public class ShaderProgram
    {
        private uint _id;
        private List<Shader> _shaders;        
        private Dictionary<string, int> _uniformNamesToLocations;

        public uint ID
        {
            get => _id;
        }

        public ShaderProgram(params Shader[] shaders)
            : this(null, shaders)
        {

        }

        public ShaderProgram(Dictionary<uint, string> attributeLocations = null, params Shader[] shaders)
        {
            _id = Gl.CreateProgram();

            _shaders = new List<Shader>(shaders.Length);            
            _uniformNamesToLocations = new Dictionary<string, int>();

            for (int i = 0; i < shaders.Length; i++)
            {
                _shaders.Add(shaders[i]);
                Gl.AttachShader(_id, shaders[i].ID);
            }

            if (attributeLocations != null)
            {
                foreach (var attribute in attributeLocations)
                {
                    Gl.BindAttribLocation(_id, attribute.Key, attribute.Value);
                }
            }


            Gl.LinkProgram(_id);
        }

        public void Bind()
        {
            Gl.UseProgram(_id);
        }

        public void Unbind()
        {
            Gl.UseProgram(0);
        }

        public void DetachShaders()
        {
            for (int i = 0; i < _shaders.Count; i++)
            {
                Gl.DetachShader(_id, _shaders[i].ID);
                _shaders[i].Delete();
            }
        }

        public void Delete()
        {
            if (_shaders != null)
                DetachShaders();

            Gl.DeleteProgram(_id);
            _id = 0;
        }

        public int GetAttributeLocation(string attributeName)
        {
            return Gl.GetAttribLocation(_id, attributeName);
        }

        public void BindAttributeLocation(uint location, string attribute)
        {
            Gl.BindAttribLocation(_id, location, attribute);
        }

        public void SetUniform1(string uniformName, float v1)
        {
            Gl.Uniform1(GetUniformLocation(uniformName), v1);
        }

        public void SetUniform3(string uniformName, float v1, float v2, float v3)
        {
            Gl.Uniform3(GetUniformLocation(uniformName), v1, v2, v3);
        }

        public void SetUniformMatrix3(string uniformName, float[] m)
        {
            Gl.UniformMatrix3(GetUniformLocation(uniformName), false, m);
        }

        public void SetUniformMatrix4(string uniformName, float[] m)
        {
            Gl.UniformMatrix3(GetUniformLocation(uniformName), false, m);
        }

        public int GetUniformLocation(string uniformName)
        {
            if (!_uniformNamesToLocations.ContainsKey(uniformName))
            {
                _uniformNamesToLocations[uniformName] = Gl.GetUniformLocation(_id, uniformName);
            }

            return _uniformNamesToLocations[uniformName];
        }
    }
}
