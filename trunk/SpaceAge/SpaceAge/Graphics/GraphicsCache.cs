using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    // We can generic-fy this class later for other types of data if we need to
    // The GetSpaceShipImage can be abstracted into an interface and used in other objects
    class GraphicsCache
    {
        Dictionary<SpaceShip, GraphicsCacheElement> SpaceShipLookUpTable;
        Dictionary<Star, GraphicsCacheElement> StarLookupTable;

        public static GraphicsCache GraphicsCacheSpaceShip()
        {
            GraphicsCache gc = new GraphicsCache();
            gc.SpaceShipLookUpTable = new Dictionary<SpaceShip, GraphicsCacheElement>(10);

            return gc;
        }

        public static GraphicsCache GraphicsCacheStar()
        {
            GraphicsCache gc = new GraphicsCache();
            gc.StarLookupTable = new Dictionary<Star, GraphicsCacheElement>(10);

            return gc;
        }

        private GraphicsCache()
        {
            
        }

        public Bitmap GetImage(SpaceShip ss, int AngleValue)
        {
            GraphicsCacheElement OutElement;

            if (SpaceShipLookUpTable.TryGetValue(ss, out OutElement))
            {
                return OutElement.GetImage(AngleValue);
                
            }
            else
                return null;
        }

        public void SetImage(SpaceShip ss, Bitmap inImage, int AngleValue)
        {
            GraphicsCacheElement OutElement;

            if (ss == null || inImage == null)
                return;

            if (SpaceShipLookUpTable.TryGetValue(ss, out OutElement))
            {
                OutElement.SetImage(AngleValue, inImage);
            }
            else
            {
                SpaceShipLookUpTable.Add(ss, new GraphicsCacheElement());
                SetImage(ss, inImage, AngleValue);
            }
        }

        public Bitmap GetImage(Star s, int Size)
        {
            GraphicsCacheElement OutElement;

            if (StarLookupTable.TryGetValue(s, out OutElement))
            {
                return OutElement.GetImage(Size);

            }
            else
                return null;
        }

        public void SetImage(Star s, Bitmap inImage, int Size)
        {
            GraphicsCacheElement OutElement;

            if (s == null || inImage == null)
                return;

            if (StarLookupTable.TryGetValue(s, out OutElement))
            {
                OutElement.SetImage(Size, inImage);
            }
            else
            {
                StarLookupTable.Add(s, new GraphicsCacheElement());
                SetImage(s, inImage, Size);
            }
        }

        public void Kill()
        {
            GraphicsCacheElement[] AllElements = SpaceShipLookUpTable.Values.ToArray<GraphicsCacheElement>();

            for (int i = 0; i < AllElements.Length; i++)
            {
                if (AllElements[i] != null)
                {
                    AllElements[i].Kill();
                }
            }
        }

        private class GraphicsCacheElement
        {
            public Dictionary<int, Bitmap> BitmapLookUpTable;

            public GraphicsCacheElement()
            {
                BitmapLookUpTable = new Dictionary<int, Bitmap>(180);
            }

            public Bitmap GetImage(int Angle)
            {
                Bitmap OutBitmap;

                if (BitmapLookUpTable.TryGetValue(Angle, out OutBitmap))
                {
                    return OutBitmap;
                }
                else
                    return null;
            }

            public void SetImage(int Angle, Bitmap bm)
            {
                if (bm == null)
                    return;

                BitmapLookUpTable.Add(Angle, bm);
            }

            public void Kill()
            {
                Bitmap[] bmstofree = BitmapLookUpTable.Values.ToArray<Bitmap>();

                for (int i = 0; i < bmstofree.Length; i++)
                {
                    if (bmstofree[i] != null)
                    {
                        bmstofree[i].Dispose();
                    }
                }
            }
        }
    }

}
