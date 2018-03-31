using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine.Maths;

using Glfw3;
using OpenGL;

namespace Engine
{
    class Program
    {
        static Glfw.Window window;
        static string vertexShaderSource = "vertex.txt";
        static string fragmentShaderSource = "fragment.txt";

        static float[] vertices =
        {
            // positions          // colors           // texture coords
             0.5f,  0.5f, 0.0f,   1.0f, 0.0f, 0.0f,   1.0f, 1.0f, // top right
             0.5f, -0.5f, 0.0f,   0.0f, 1.0f, 0.0f,   1.0f, 0.0f, // bottom right
            -0.5f, -0.5f, 0.0f,   0.0f, 0.0f, 1.0f,   0.0f, 0.0f, // bottom left
            -0.5f,  0.5f, 0.0f,   1.0f, 1.0f, 0.0f,   0.0f, 1.0f  // top left 
        };

        static uint[] indices = 
        {
            0, 1, 3,  // first Triangle
            1, 2, 3   // second Triangle
        };

        static void Main(string[] args)
        {
            Gl.Initialize();
            Glfw.ConfigureNativesDirectory("../../../libs/");
            Glfw.Init();            


            window = Glfw.CreateWindow(800, 600, "Window");

            if (!window)
            {
                Glfw.Terminate();
                Environment.Exit(-1);
            }

            Glfw.WindowHint(Glfw.Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Glfw.Hint.ContextVersionMinor, 2);
            Glfw.WindowHint(Glfw.Hint.OpenglProfile, Glfw.OpenGLProfile.Core);

            Glfw.SetWindowCloseCallback(window, WindowCloseCallback);
            Glfw.SetFramebufferSizeCallback(window, FramebufferResizeCallback);
            Glfw.SetKeyCallback(window, KeyCallback);

            Glfw.MakeContextCurrent(window);

            string shaderFolder = "../../../Media/Shaders/";

            Shader vertex = new Shader(ShaderType.VertexShader, System.IO.File.ReadAllText(shaderFolder + vertexShaderSource));
            Shader fragment = new Shader(ShaderType.FragmentShader, System.IO.File.ReadAllText(shaderFolder + fragmentShaderSource));

            ShaderProgram shaderProgram = new ShaderProgram(vertex, fragment);
            shaderProgram.DetachShaders();

            VertexArray vertexArray = new VertexArray();
            BufferObject<uint> indexBuffer = new BufferObject<uint>(BufferTarget.ElementArrayBuffer, BufferUsage.StaticDraw);
            BufferObject<float> vertexBuffer = new BufferObject<float>(BufferTarget.ArrayBuffer, BufferUsage.StaticDraw);

            vertexArray.Bind();

            vertexBuffer.Bind();
            vertexBuffer.SetData(vertices);

            indexBuffer.Bind();
            indexBuffer.SetData(indices);

            vertexArray.AttributePointer(0, 3, VertexAttribType.Float, false, 8, 0);
            vertexArray.AttributePointer(1, 3, VertexAttribType.Float, false, 8, 3);
            vertexArray.AttributePointer(2, 2, VertexAttribType.Float, false, 8, 6);

            vertexBuffer.Unbind();

            string textureFolder = "../../../Media/Textures/crate.jpg";
            Texture texture = new Texture(textureFolder);

            while (!Glfw.WindowShouldClose(window))
            {
                Gl.ClearColor(0.6f, 0.6f, 0.6f, 1.0f);
                Gl.Clear(ClearBufferMask.ColorBufferBit);

                shaderProgram.Bind();
                vertexArray.Bind();
                Gl.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, (IntPtr)0);

                Glfw.SwapBuffers(window);
                Glfw.PollEvents();
            }

            shaderProgram.Delete();
            vertexArray.Delete();
            vertexBuffer.Delete();
            indexBuffer.Delete();

            Glfw.Terminate();
        }

        static void WindowCloseCallback(Glfw.Window window)
        {
            Glfw.SetWindowShouldClose(window, true);
        }

        static void FramebufferResizeCallback(Glfw.Window window, int width, int height)
        {
            Gl.Viewport(0, 0, width, height);
        }

        static void KeyCallback(Glfw.Window window, Glfw.KeyCode key, int scancode, Glfw.InputState state, Glfw.KeyMods mods)
        {
            if (key == Glfw.KeyCode.Escape && state == Glfw.InputState.Press)
            {
                Glfw.SetWindowShouldClose(window, true);
            }
        }

        static void ErrorCallback(Glfw.ErrorCode error, string description)
        {
            Console.WriteLine("Error({0})", error);
        }
    }
}
