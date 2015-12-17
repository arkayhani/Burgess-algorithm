using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Braincase.GanttChart
{
    public class Tasks
    {
        public int Ct = -1;
        public int St;
        public int Fn;
        public int Es;
        public int Ls;
        public int R;
        public int Dur;
        public Tasks(int St, int Fn, int Es, int Ls, int R, int Dur)
        {
            this.St = St;
            this.Fn = Fn;
            this.Es = Es;
            this.Ls = Ls;
            this.R = R;
            this.Dur = Dur;
        }
    }
  public  class Days
    {
        public int time;
        public int z = 0;
        public int z2 = 0;

    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ExampleFull());
          //  Application.Run(new ExampleSimple());
            Application.Run(new Form1());
            //Application.Run(new ExampleGanttTreeView());
        }
    }
}
