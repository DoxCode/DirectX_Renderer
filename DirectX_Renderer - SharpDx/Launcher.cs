// Copyright (c) 2016-2017 DirectX_Renderer - DoxCode - https://github.com/DoxCode

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectX_Renderer
{
    public partial class Launcher : Form
    {
        private Overlay_SharpDX overlayWindow = null;

        public Launcher()
        {
            InitializeComponent();
        }

        private void overlay_launcher_Click(object sender, EventArgs e)
        {
            if (overlayWindow != null)
            {
                overlayWindow.Close();
                overlayWindow = null;
            }
            else
            {
                overlayWindow = new Overlay_SharpDX();
                overlayWindow.Show();
            }

        }
    }
}
