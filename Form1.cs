using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace OpenRobotVision
{
    public partial class FrmMain : Form
    {
        private Capture capture;
        private Timer TmrCapture = new Timer();
        private Image<Bgr, Byte> Img;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //Initialize capture device
            capture = new Capture();

            //Set timer defualts
            this.TmrCapture.Enabled = true;
            this.TmrCapture.Interval = 100;
            this.TmrCapture.Tick+=new EventHandler(TmrCapture_Tick);
        }

        /// <summary>
        /// Method occurs once every 100ms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrCapture_Tick(object sender, EventArgs e)
        {
            Img = capture.QueryFrame();

            this.PicImg.Image = Img.ToBitmap();
        }
    }
}