using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenGL;

namespace Engine
{
    public class Texture
    {
        private uint _id;
        private int _width;
        private int _height;

        public uint ID
        {
            get => _id;
        }

        public int Width
        {
            get => _width;
        }

        public int Height
        {
            get => _height;
        }

        public Texture(string filename)
        {
            Bitmap bitmap = new Bitmap(filename);
            _width = bitmap.Width;
            _height = bitmap.Height;

            //bool flipY = true;

            //if (flipY)
            //{
            //    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            //}

            Rectangle rec = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rec, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            _id = Gl.GenTexture();
            //Gl.PixelStore(PixelStoreParameter.UnpackAlignment, 1);
            Gl.BindTexture(TextureTarget.Texture2d, _id);
           
            Gl.TexImage2D(TextureTarget.Texture2d, 0, InternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);

            Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureWrapS, Gl.REPEAT);
            Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureWrapT, Gl.REPEAT);

            Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureMinFilter, Gl.LINEAR);
            Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureMagFilter, Gl.LINEAR);

            bitmap.UnlockBits(bitmapData);
            bitmap.Dispose();
        }

        public void Unbind()
        {
            Gl.BindTexture(TextureTarget.Texture1dArray, 0);

        }
    }
}
