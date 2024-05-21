using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDrawer
{
	public partial class MainForm : Form
	{
		string text = "Hello";
		Font font;
		public MainForm()
		{
			InitializeComponent();
			font = new Font("Arial", 45);
			panel.Paint += panel_Paint;
			this.Paint += MainForm_Paint;
		}
		private void panel_Paint(object sender, PaintEventArgs e)
		{
			if(text.Length > 0)
			{
				Image img =new Bitmap(panel.ClientRectangle.Width, panel.ClientRectangle.Height);
				Graphics imgDC = Graphics.FromImage(img);
				imgDC.Clear(BackColor);
				imgDC.DrawString(text,font,Brushes.LightBlue,ClientRectangle,new StringFormat(StringFormatFlags.NoFontFallback));
				e.Graphics.DrawImage(img,0,0);
			}
		}
		private void MainForm_Paint(object sender, PaintEventArgs e)
		{
			panel_Paint(panel, new PaintEventArgs(panel.CreateGraphics(),panel.ClientRectangle));
		}
	}
}
