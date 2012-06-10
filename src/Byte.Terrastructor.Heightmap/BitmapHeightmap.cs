using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Byte.Terrastructor.Heightmap
{
    /// <summary>
    /// This class is capable of generating heightmaps from any of image formats supported by System.Drawing.Bitmap
    /// It utilizes the red channel of the image once it has been converted into a 24-bit format internally.
    /// </summary>
    public class BitmapHeightmap : IHeightmap
    {
        private const int BytesPerPixel = 3;

        private readonly Bitmap _heightmapBitmap;
        private byte[,] _heightPoints;

        public int Width
        {
            get
            {
                return _heightPoints.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return _heightPoints.GetLength(1);
            }
        }

        public BitmapHeightmap(string filename)
        {
            //NOTE: The second parameter is false in order to turn off "color correction" which is used by default.
            _heightmapBitmap = new Bitmap(filename, false);

            ProcessHeightmap();
        }

        private void ProcessHeightmap()
        {
            _heightPoints = new byte[_heightmapBitmap.Width, _heightmapBitmap.Height];

            BitmapData data = _heightmapBitmap.LockBits(new Rectangle(0,
                                                                      0,
                                                                      _heightmapBitmap.Width,
                                                                      _heightmapBitmap.Height),
                                                        ImageLockMode.ReadOnly,
                                                        PixelFormat.Format24bppRgb);

            IntPtr startPointer = data.Scan0;

            var width = data.Width*BytesPerPixel;

            for(int yPosition = 0; yPosition < _heightmapBitmap.Height; ++yPosition)
            {
                var linePointer = startPointer + (yPosition*data.Stride);
                var rgbData = new byte[width];
                Marshal.Copy(linePointer, rgbData, 0, rgbData.Length);

                for(int index = 0; index < rgbData.Length; index += BytesPerPixel)
                {
                    var xPosition = index/BytesPerPixel;

                    _heightPoints[xPosition, yPosition] = rgbData[index];
                }
            }

            _heightmapBitmap.UnlockBits(data);
        }

        public int this[int x, int y]
        {
            get
            {
                if(x < 0 || y < 0 || x >= Width || y >= Height)
                {
                    return 0;
                }

                return _heightPoints[x, y];
            }
        }

        public Image Image
        {
            get { return _heightmapBitmap; }
        }
    }
}
