using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceAge.Controls
{
    partial class PlanetViewer : UserControl
    {
        Planet thisPlanet;
        public bool NeedToRefresh = true;

        public PlanetViewer()
        {
            InitializeComponent();

            GraphicsLib.ApplyListviewProperties(listview_atmosphericGas);
            GraphicsLib.ApplyListviewProperties(listview_elementResources);
            GraphicsLib.ApplyListviewProperties(listview_naturalResources);

        }

        public void SetPlanet(Planet p)
        {
            thisPlanet = p;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            RefreshUi();
        }

        public void RefreshUi()
        {
            if (!NeedToRefresh)
                return;
            if (thisPlanet == null)
                return;

            ui_planetPosition.Text = ObjectCharactaristics.PositionString[(int)thisPlanet.PlanetPosition];
            ui_planetSize.Text = ObjectCharactaristics.PlanetSizeString[(int)thisPlanet.PlanetSize];
            String starColorText = "";
            if (thisPlanet.Parent.stars.Length == 1)
            {
                starColorText += ObjectCharactaristics.StarColorString[(int)thisPlanet.Parent.stars[0].StarColor];
            }
            else
            {
                // Only two stars for now...
                starColorText = ObjectCharactaristics.StarColorString[(int)thisPlanet.Parent.stars[0].StarColor] +
                    " and " + ObjectCharactaristics.StarColorString[(int)thisPlanet.Parent.stars[1].StarColor];
            }
            ui_lightSpectrum.Text = starColorText;

            listview_elementResources.Columns.Clear();
            listview_elementResources.Columns.Add("Name", 120);
            listview_elementResources.Columns.Add("Volume");
            listview_atmosphericGas.Columns.Clear();
            listview_atmosphericGas.Columns.Add("Name", 120);
            listview_atmosphericGas.Columns.Add("Percentage");
            listview_naturalResources.Columns.Clear();
            listview_naturalResources.Columns.Add("Name", 120);
            listview_naturalResources.Columns.Add("Productivity", 120);
            ListViewItem currentItem;

            List<ListViewItem> elementsList = new List<ListViewItem>(3);
            foreach (Commodity c in thisPlanet.Resources)
            {
                if (!c.IsResource)
                    throw new Exception();
                currentItem = new ListViewItem(c.ToString());
                //currentItem.SubItems.Add(c.Productivity.ToString());
                currentItem.SubItems.Add(thisPlanet.FindProductivityOfInternalResource(c).ToString());

                // *Pat myself on the back for the more elegant solution after refactoring resource commodities
                switch (c.ResourceCommodityType)
                {
                    case ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere:
                        listview_atmosphericGas.Items.Add(currentItem);
                        break;
                    case ObjectCharactaristics.ResourceCommodityType.RareAtmosphere:
                        listview_atmosphericGas.Items.Add(currentItem);
                        break;
                    case ObjectCharactaristics.ResourceCommodityType.CommonElement:
                        listview_elementResources.Items.Add(currentItem);
                        break;
                    case ObjectCharactaristics.ResourceCommodityType.RareElement:
                        listview_elementResources.Items.Add(currentItem);
                        break;
                    case ObjectCharactaristics.ResourceCommodityType.ResourceStatic:
                        listview_naturalResources.Items.Add(currentItem);
                        break;
                    default:
                        throw new Exception();
                }
            }

            DrawPlanet();

            NeedToRefresh = false;
        }

        private void DrawPlanet()
        {
        }
    }
}
