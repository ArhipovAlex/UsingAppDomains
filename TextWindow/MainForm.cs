using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace TextWindow
{
	public partial class MainForm : Form
	{
		Module drawerModule;
		object drawer;
		public MainForm()
		{
			InitializeComponent();
		}
		public MainForm(Module drawer, object targetWindow) : this()
		{
			this.drawerModule= drawer;
			this.drawer=targetWindow;
		}
		private void textBox_TextChanged(object sender, EventArgs e)
		{
			drawerModule.GetType("TextDrawer.MainForm").GetMethod("SetText").Invoke(drawer, new object[] { textBox.Text });
		}
		private void MainForm_LocationChanged(object sender, EventArgs e)
		{
			drawerModule.GetType("TextDrawer.MainForm").GetMethod("Move").Invoke(drawer,new object[] { new Point(this.Location.X, this.Location.Y + this.Height), this.Width});
		}
	}
}
