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
        bool end;
        public MainForm()
        {
            InitializeComponent();
            polygon = new PolygonGUI(pbMain);
            Application.Idle += OnIdle;
            start = true;
            end = false;
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
            if(!start && !th.IsAlive && !end)
            {
                btnAbort.Enabled = false;
                prgbLoad.Value = 100;
                if(polygon.points.Count == 0)
                {
                    MessageBox.Show("Выпуклый многоугольник получить нельзя!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    end = true;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            start = true;
            end = false;
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
            th = new Thread(() => polygon.TryCreatePolygon(ref progress, ref total));
            th.Start();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            if (th != null) th.Abort();
        }
    }
}
