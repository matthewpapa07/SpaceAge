 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SpaceAge
{
    partial class SpaceShip
    {
        public CargoItemList SpaceShipCargo;

        public bool ShipInitialized = false;

        private int BaseArmor = 35;
        private int BaseStructure = 35;
        private int BaseAgility = 1;
        private int BaseCargoSpace = 50;
        private int BaseWarpSpeed = 1;
        private int BaseScanStrength = 2;

        private int EffectiveArmor = 0;
        private int EffectiveStructure = 0;
        private int EffectiveAgility = 0;
        private int EffectiveCargoSpace = 0;
        private int EffectiveWarpSpeed = 0;
        private int EffectiveScanStrength = 0;

        private int NumWeaponMounts;
        private int NumDefensiveMounts;
        private int NumEngineMounts;
        private int NumSpecialMounts;

        public List<ShipComponents.ShipWeapon> WeaponMounts = new List<ShipComponents.ShipWeapon>();
        public List<ShipComponents.ShipDefense> DefensiveMounts = new List<ShipComponents.ShipDefense>();
        public List<ShipComponents.ShipEngines> EngineMounts = new List<ShipComponents.ShipEngines>();
        public List<Item> SpecialMounts = new List<Item>();

        /// <summary>
        /// Effective instance data. Much of this still needs to be implemented
        /// </summary>
        /// 
        public int SpaceShipHpPercentage = 100; // Change this to accessor method
        public ListViewItem SpaceShipListViewItem;

        public SpaceShip(int inWeaponMounts, int inDefensiveMounts, int inEngineMounts, int inSpecialMounts)
        {
            SpaceShipCargo = new CargoItemList(100000, this); // Hard code large cargo list size for now...

            NumWeaponMounts = inWeaponMounts;
            NumDefensiveMounts = inDefensiveMounts;
            NumEngineMounts = inEngineMounts;
            NumSpecialMounts = inSpecialMounts;

            SectorFineGridLocation = new PointD(Sector.MAX_DISTANCE_FROM_AXIS / 2, Sector.MAX_DISTANCE_FROM_AXIS / 2);
        }

        public void IntializeStats(int inBaseArmor, int inBaseStructure, int inBaseAgility, int inBaseCargoSpace, int inBaseWarpSpeed, int inBaseScanStrength)
        {
            BaseArmor = inBaseArmor;
            BaseStructure = inBaseStructure;
            BaseAgility = inBaseAgility;
            BaseCargoSpace = inBaseCargoSpace;
            BaseWarpSpeed = inBaseWarpSpeed;
            BaseScanStrength = inBaseScanStrength;

            SpaceShipCargo.ChangeVolume(BaseCargoSpace);
            RefreshSpaceShipStats();

            ShipInitialized = true;

            RefreshSpaceShipListViewItem();
            SpaceShipId = ++SpaceShipIdStatic;
        }

        /// <summary>
        /// Equips an item to the ship
        /// </summary>
        /// <param name="itemToEquip"></param>
        /// <returns></returns>
        public bool EquipItem(Item itemToEquip)
        {
            if (itemToEquip is ShipComponents.ShipDefense)
            {
                if ((DefensiveMounts.Count < NumDefensiveMounts) && (!DefensiveMounts.Contains(itemToEquip)))
                {
                    DefensiveMounts.Add(itemToEquip as ShipComponents.ShipDefense);
                    RefreshSpaceShipStats();
                    return true;
                }
                else
                    return false;
            }
            if (itemToEquip is ShipComponents.ShipWeapon)
            {
                if ((WeaponMounts.Count < NumWeaponMounts) && (!WeaponMounts.Contains(itemToEquip)))
                {
                    WeaponMounts.Add(itemToEquip as ShipComponents.ShipWeapon);
                    RefreshSpaceShipStats();
                    return true;
                }
                else
                    return false;
            }
            if (itemToEquip is ShipComponents.ShipEngines)
            {
                if ((EngineMounts.Count < NumEngineMounts) && (!EngineMounts.Contains(itemToEquip)))
                {
                    EngineMounts.Add(itemToEquip as ShipComponents.ShipEngines);
                    RefreshSpaceShipStats();
                    return true;
                }
                else
                    return false;
            }
            //
            // If we get to here item is special mount
            //
            if ((SpecialMounts.Count < NumSpecialMounts) && (!SpecialMounts.Contains(itemToEquip)))
            {
                SpecialMounts.Add(itemToEquip);
                RefreshSpaceShipStats();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Un equips an item from the ship
        /// </summary>
        /// <param name="itemToEquip"></param>
        /// <returns></returns>
        public bool UnEquipItem(Item itemToEquip)
        {
            if (itemToEquip is ShipComponents.ShipDefense)
            {
                if ((DefensiveMounts.Count > 0) && (DefensiveMounts.Contains(itemToEquip)))
                {
                    DefensiveMounts.Remove(itemToEquip as ShipComponents.ShipDefense);
                    RefreshSpaceShipStats();
                    return true;
                }
                else
                    return false;
            }
            if (itemToEquip is ShipComponents.ShipWeapon)
            {
                if ((WeaponMounts.Count > 0) && (WeaponMounts.Contains(itemToEquip)))
                {
                    WeaponMounts.Remove(itemToEquip as ShipComponents.ShipWeapon);
                    RefreshSpaceShipStats();
                    return true;
                }
                else
                    return false;
            }
            if (itemToEquip is ShipComponents.ShipEngines)
            {
                if ((EngineMounts.Count > 0) && (EngineMounts.Contains(itemToEquip)))
                {
                    EngineMounts.Remove(itemToEquip as ShipComponents.ShipEngines);
                    RefreshSpaceShipStats();
                    return true;
                }
                else
                    return false;
            }
            //
            // If we get to here item is special mount
            //
            if ((SpecialMounts.Count > 0) && (SpecialMounts.Contains(itemToEquip)))
            {
                SpecialMounts.Remove(itemToEquip);
                RefreshSpaceShipStats();
                return true;
            }
            else
                return false;
        }

        public void RefreshSpaceShipStats()
        {
            EffectiveArmor = BaseArmor;
            EffectiveStructure = BaseStructure;
            EffectiveAgility = BaseAgility;
            EffectiveCargoSpace = BaseCargoSpace;
            EffectiveWarpSpeed = BaseWarpSpeed;
            EffectiveScanStrength = BaseScanStrength;

            foreach (ShipComponents.ShipDefense sd in DefensiveMounts)
            {
                EffectiveArmor += sd.GetAverageDefense();
            }
            foreach (ShipComponents.ShipWeapon sw in WeaponMounts)
            {
                EffectiveArmor += sw.GetAverageDamage();
            }
            foreach (ShipComponents.ShipEngines se in EngineMounts)
            {
                EffectiveAgility += se.DrivePower;
                EffectiveWarpSpeed += se.WarpPower;
            }
            //
            // Now calculate the random odds and ends
            //
            foreach (Item i in SpecialMounts)
            {
                if (i is ShipComponents.ShipScanner)
                {
                    EffectiveScanStrength += (i as ShipComponents.ShipScanner).ScannerStrength;
                }
            }
        }

        public static void SpaceShipObjectListViewItemsMini(ListView ui_SpaceShipList)
        {
            ui_SpaceShipList.Columns.Clear();
            //
            // Add columns
            //
            double BoxLength = ui_SpaceShipList.Width;
            ui_SpaceShipList.Columns.Add("Name", (int) (BoxLength * .30));
            ui_SpaceShipList.Columns.Add("HP %", (int)(BoxLength * .20));
            ui_SpaceShipList.Columns.Add("Class", (int)(BoxLength * .25));
            ui_SpaceShipList.Columns.Add("Size", (int)(BoxLength * .20));
        }

        void RefreshSpaceShipListViewItem()
        {
            if (SpaceShipListViewItem == null)
            {
                SpaceShipListViewItem = new ListViewItem(SpaceShipName);
                SpaceShipListViewItem.SubItems.Add("100%"); // TODO once combat implemented
                SpaceShipListViewItem.SubItems.Add(SpaceShipConstant.SpaceShipClassString[(int)SpaceShipClass]);
                SpaceShipListViewItem.SubItems.Add(SpaceShipConstant.SpaceShipSizeString[(int)SpaceShipSize]);
            }
            else
            {
                // TODO: Refresh these values after they might have changed
            }
        }
    }

}
