using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Braincase.GanttChart
{
    public partial class ExampleSimple : Form
    {
        ProjectManager _mProject;

        public ExampleSimple()
        {
            InitializeComponent();
            
            _mProject = new ProjectManager();
            _mProject.Add(new Task() { Name = "New Task" });
            Task K = new Task() { Name = "Arash " };
            
            _mProject.Add(K);
            _mProject.SetStart(K, 5);
            _mChart.Init(_mProject);
        }

        public ExampleSimple(List<Tasks> job)
        {
            InitializeComponent();

            _mProject = new ProjectManager();
           // _mProject.Add(new Task() { Name = "New Task" });
            foreach (var item in job)
            {
               Task K = new Task() { Name = item.St+"-"+item.Fn };

            _mProject.Add(K);
            _mProject.SetStart(K, item.Ct);
            _mProject.SetDuration(K, item.Dur); 
            }
            
            _mChart.Init(_mProject);
        }
        private void _mChart_Load(object sender, EventArgs e)
        {
            
        }
    }
}
