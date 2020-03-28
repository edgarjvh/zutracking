using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET.WindowsForms;


namespace ZUControls
{
    public class ZUMapa : GMapControl
    {
        public ZUMapa()
        {
            this.DoubleBuffered = true;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            this.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            this.ShowCenter = false;
            this.SetPositionByKeywords("Cabimas, Venezuela");
            this.VerticalScroll.Visible = false;
            this.DragButton = System.Windows.Forms.MouseButtons.Left;
            this.MinZoom = 3;
            this.MaxZoom = 19;
            this.Zoom = 12;
            this.DisableFocusOnMouseEnter = true;
            this.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
        }
    }
}
