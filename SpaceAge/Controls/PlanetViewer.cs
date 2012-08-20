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

            listview_elementResources.Columns.Clear();
            listview_elementResources.Columns.Add("Name", 120);
            listview_elementResources.Columns.Add("Volume");
            listview_atmosphericGas.Columns.Clear();
            listview_atmosphericGas.Columns.Add("Name", 120);
            listview_atmosphericGas.Columns.Add("Percentage");
            ListViewItem currentItem;

            List<ListViewItem> elementsList = new List<ListViewItem>(3);
            foreach (ObjectCharactaristics.CommonElements ce in thisPlanet.CommonElements)
            {
                currentItem = new ListViewItem(ObjectCharactaristics.CommonElementsString[(int)ce]);
                currentItem.SubItems.Add("1%");
                elementsList.Add(currentItem);
            }
            foreach (ObjectCharactaristics.RareElements re in thisPlanet.RareElements)
            {
                currentItem = new ListViewItem(ObjectCharactaristics.RareElementsString[(int)re]);
                currentItem.SubItems.Add("1%");
                elementsList.Add(currentItem);
            }
            listview_elementResources.Items.AddRange(elementsList.ToArray());

            List<ListViewItem> atmosphereList = new List<ListViewItem>(3);
            foreach(ObjectCharactaristics.CommonAtmosphere ca in thisPlanet.CommonAtmosphere)
            {
                currentItem = new ListViewItem(ObjectCharactaristics.CommonAtmosphereString[(int)ca]);
                currentItem.SubItems.Add("1%");
                atmosphereList.Add(currentItem);
            }
            foreach(ObjectCharactaristics.RareAtmosphere ra in thisPlanet.RareAtmosphere)
            {
                currentItem = new ListViewItem(ObjectCharactaristics.RareAtmosphereString[(int)ra]);
                currentItem.SubItems.Add("1%");
                atmosphereList.Add(currentItem);
            }
            listview_atmosphericGas.Items.AddRange(atmosphereList.ToArray());

            NeedToRefresh = false;
        }
    }
}
