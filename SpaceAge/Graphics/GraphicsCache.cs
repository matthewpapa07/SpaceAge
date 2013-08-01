using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class GraphicsCache
    {
        Dictionary<SpaceShip, GraphicsCacheElement> SpaceShipLookUpTable;
        Dictionary<ISectorMember, GraphicsCacheElement> ISectorMemberLookupTable;

        public static GraphicsCache GraphicsCacheSpaceShip()
        {
            GraphicsCache gc = new GraphicsCache();
            gc.SpaceShipLookUpTable = new Dictionary<SpaceShip, GraphicsCacheElement>(100);

            return gc;
        }

        public static GraphicsCache GraphicsCacheISectorMember()
        {
            // TODO: Need a special IEqualityComparer for performance and precision
                //int IEqualityComparer<ISectorMember>.GetHashCode(Village obj)
                //{
                //    return obj.AllianceName.GetHashCode();
                //}
            GraphicsCache gc = new GraphicsCache();
            gc.ISectorMemberLookupTable = new Dictionary<ISectorMember, GraphicsCacheElement>(100);

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

        public Bitmap GetImage(ISectorMember s, int Size)
        {
            GraphicsCacheElement OutElement;

            if (ISectorMemberLookupTable.TryGetValue(s, out OutElement))
            {
                return OutElement.GetImage(Size);

            }
            else
                return null;
        }

        public void SetImage(ISectorMember s, Bitmap inImage, int Size)
        {
            GraphicsCacheElement OutElement;

            if (s == null || inImage == null)
                return;

            if (ISectorMemberLookupTable.TryGetValue(s, out OutElement))
            {
                OutElement.SetImage(Size, inImage);
            }
            else
            {
                ISectorMemberLookupTable.Add(s, new GraphicsCacheElement());
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
