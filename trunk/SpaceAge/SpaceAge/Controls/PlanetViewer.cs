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

            ui_planetPosition.Text = ObjectCharactaristics.PositionString[(int)thisPlanet.planetPosition];
            ui_planetSize.Text = ObjectCharactaristics.PlanetSizeString[(int)thisPlanet.planetSize];
            String starColorText = "";
            if (thisPlanet.parent.stars.Length == 1)
            {
                starColorText += ObjectCharactaristics.StarColorString[(int)thisPlanet.parent.stars[0].StarColor];
            }
            else
            {
                // Only two stars for now...
                starColorText = ObjectCharactaristics.StarColorString[(int)thisPlanet.parent.stars[0].StarColor] +
                    " and " + ObjectCharactaristics.StarColorString[(int)thisPlanet.parent.stars[1].StarColor];
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
            for (int i = 0; i < thisPlanet.CommonElements.Length; i++)
            {
                ObjectCharactaristics.CommonElements ce = thisPlanet.CommonElements[i];
                currentItem = new ListViewItem(ObjectCharactaristics.CommonElementsString[(int)ce]);
                currentItem.SubItems.Add(thisPlanet.CommonElementsQuantity[i].ToString());
                elementsList.Add(currentItem);
            }
            for (int i = 0; i < thisPlanet.RareElements.Length; i++)
            {
                ObjectCharactaristics.RareElements re = thisPlanet.RareElements[0];
                currentItem = new ListViewItem(ObjectCharactaristics.RareElementsString[(int)re]);
                currentItem.SubItems.Add(thisPlanet.RareElementsQuantity[i].ToString());
                elementsList.Add(currentItem);
            }
            listview_elementResources.Items.AddRange(elementsList.ToArray());

            List<ListViewItem> atmosphereList = new List<ListViewItem>(3);
            for (int i = 0; i < thisPlanet.CommonAtmosphere.Length; i++)
            {
                ObjectCharactaristics.CommonAtmosphere ca = thisPlanet.CommonAtmosphere[i];
                currentItem = new ListViewItem(ObjectCharactaristics.CommonAtmosphereString[(int)ca]);
                currentItem.SubItems.Add(thisPlanet.CommonAtmosphereQuantity[i] + "%");
                atmosphereList.Add(currentItem);
            }
            for (int i = 0; i < thisPlanet.RareAtmosphere.Length ; i++)
            {
                ObjectCharactaristics.RareAtmosphere ra = thisPlanet.RareAtmosphere[i];
                currentItem = new ListViewItem(ObjectCharactaristics.RareAtmosphereString[(int)ra]);
                currentItem.SubItems.Add(thisPlanet.RareAtmosphereQuantity[i] + "1%");
                atmosphereList.Add(currentItem);
            }
            listview_atmosphericGas.Items.AddRange(atmosphereList.ToArray());

            List<ListViewItem> resourcesList = new List<ListViewItem>(3);
            for (int i = 0; i < thisPlanet.ResourcesStatic.Length; i++)
            {
                ObjectCharactaristics.ResourcesStatic rs = thisPlanet.ResourcesStatic[i];
                currentItem = new ListViewItem(ObjectCharactaristics.ResourcesStaticString[(int)rs]);
                currentItem.SubItems.Add(thisPlanet.ResourcesStaticQuantity[i].ToString());
                resourcesList.Add(currentItem);
            }
            listview_naturalResources.Items.AddRange(resourcesList.ToArray());

            DrawPlanet();

            NeedToRefresh = false;
        }

        -private void DrawPlanet()
        {
        }
    }
}
