using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KA1
{
    public partial class MainForm : Form
    {
        PolygonGUI polygon;
        long progress; //перестановок пройдено
        long total; //перестановок всего
        Thread th; //поток для выполнения задачи
        bool start; //флажок состояния (начало программы - true, выполнение и конец - false)
        public MainForm()
        {
            InitializeComponent();
            polygon = new PolygonGUI(pbMain);
            Application.Idle += OnIdle;
            start = true;
            progress = 0;
            total = 1;
        }

        private void OnIdle(object sender, EventArgs e)
        {
            if (start)
                prgbLoad.Value = 0;
            btnFind.Enabled = polygon.points.Count > 2 && start;
            btnClear.Enabled = !start;
            if (th != null && th.IsAlive)
            {
                prgbLoad.Value = (int)(((double)progress / total) * 100);
                btnAbort.Enabled = true;
            }
           if(!start && !th.IsAlive)
            {
                btnAbort.Enabled = false;
                prgbLoad.Value = 100;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            start = true;
            if (th != null) th.Abort();
            polygon.Clear();
        }

        private void pbMain_Click(object sender, EventArgs e)
        {
            if(start)
                polygon.AddPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            start = false;
            th = new Thread(() => polygon.CreatePolygonGUI(ref progress, ref total));
            th.Start();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            if (th != null) th.Abort();
        }
    }
}
