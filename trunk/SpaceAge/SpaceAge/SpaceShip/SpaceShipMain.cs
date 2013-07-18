using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using SpaceAge.Properties;

namespace SpaceAge
{
    partial class SpaceShip
    {
        public string SpaceShipName = "TODO:Name";
        SpaceShipConstant.SpaceShipClass SpaceShipClass = SpaceShipConstant.SpaceShipClass.Generic;
        SpaceShipConstant.SpaceShipSize SpaceShipSize = SpaceShipConstant.SpaceShipSize.Medium;

        static Bitmap SpaceShipImage;
        private int SpaceShipId = 0;
        private static int SpaceShipIdStatic = -1;

        //
        // User variables
        //
        public int fuelLevel = UserState.USER_MAX_FUEL_AMOUNT;  // Change to accessor function, so that we may have max and effective fuel level
        public int SpaceShipFunds = UserState.USER_STARTING_FUNDS;

        // Management threads
        public static Thread UserSpaceShipMovementThread = new Thread(new ThreadStart(UserSpaceShipMovement));
        public static Thread AiSpaceShipMovementThread = new Thread(new ThreadStart(AiSpaceShipMovement));

        static SpaceShip()
        {
            SpaceShipImage = new Bitmap(Resources.SpaceShip1);
        }

        public static void UserSpaceShipMovement()
        {
            
            while (UserState.ThreadsRunning)
            {
                UserState.PlayerShip.UpdateMovingShipsPosition();
                Thread.Sleep(10);
            }
        }

        public static void AiSpaceShipMovement()
        {
            while (UserState.ThreadsRunning)
            {
                foreach (MerchantSpaceShip mss in MerchantSpaceShip.AllMerchants)
                {
                    mss.UpdateMovingShipsPosition();
                }
                Thread.Sleep(2);
            }
        }

        public virtual Bitmap GetSpaceShipImage()
        {
            Bitmap RotatedImage = GraphicsLib.RotateBitmap(SpaceShipImage, DirectionVector.GetAngle());
            return RotatedImage;
        }

        // Better for atomic operations
        public virtual Bitmap GetSpaceShipImage(int Angle)
        {
            Bitmap RotatedImage = GraphicsLib.RotateBitmap(SpaceShipImage, Angle);
            return RotatedImage;
        }

        public bool Equals(SpaceShip obj)
        {
            if (obj.SpaceShipId == SpaceShipId)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return SpaceShipId;
        }
    }

    static class SpaceShipConstant
    {
        //
        // Commonly Associated with SpaceShip
        //
        public enum SpaceShipClass { Generic, Merchant };
        public static string[] SpaceShipClassString = { "Generic", "Merchant" };

        public static string[] SpaceShipSizeString = { "XS", "S", "M", "L", "XL", "N/A" };
        public enum SpaceShipSize { ExtraSmall, Small, Medium, Large, ExraLarge, NoSize };
        //public static int[] ItemSizeStatMultiplier = { 1, 3, 10, 25, 50, 1 };
        //public static int[] ItemSizeStatDivider = { 5, 4, 3, 2, 1, 1 };
    }
}
