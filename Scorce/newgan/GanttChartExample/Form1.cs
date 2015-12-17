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
    public partial class Form1 : Form
    {
        public Form1()
        {
            Job = new List<Tasks>();
            InitializeComponent();
        }
     
       List<Tasks> Job;
        List<Days> cal;
        private void button1_Click(object sender, EventArgs e)
        {
            cal = new List<Days>();

            Tasks temp = new Tasks(int.Parse(textBox5.Text), int.Parse(textBox6.Text), int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            Job.Add(temp);
            //Job.Sort(Comparison<int> 
            Job = Job.OrderBy(order => order.Fn).ThenBy(order => order.St).ToList();
            listBox1.Items.Clear();
            listBox1.Items.Add("Act" + "     " + "Es" + "     " + "Ls" + "     " + "R");
            int projectd = 0;
            foreach (var item in Job)
            {
                listBox1.Items.Add(item.St + "-" + item.Fn + "     " + item.Es + "     " + item.Ls + "     " + item.R);
                if (projectd < (item.Ls + item.Dur))
                {
                    projectd = (item.Ls + item.Dur);

                }

            }
            int Z = 0;

            for (int i = 0; i < projectd; i++)
            {
                Days d = new Days();
                d.time = i;
                cal.Add(d);
            }
            for (int i = Job.Count - 1; i >= 0; i--)
            {
                Tasks t = Job[i];
                int ctmin = 0;
                int zmin = 1000000000;
                for (int j = t.Es; j <= t.Ls; j++)
                {
                    int z = 0;
                    t.Ct = j;
                    foreach (var item2 in cal)
                    {
                        item2.z = 0;
                        item2.z2 = 0;
                    }
                    for (int k = i; k < Job.Count; k++)
                    {
                        for (int stin = Job[k].Ct; stin < Job[k].Ct + Job[k].Dur; stin++)
                        {
                            cal[stin].z += Job[k].R;
                            cal[stin].z2 = cal[stin].z * cal[stin].z;
                        }
                    }
                    foreach (var item3 in cal)
                    {
                        z += item3.z2;
                    }
                    if (z <= zmin)
                    {
                        zmin = z;

                        ctmin = t.Ct;
                    }

                }
                t.Ct = ctmin;
                Z = zmin;
            }



            bool flag = true;
            while (flag)
            {
                flag = false;

                for (int i = Job.Count - 1; i >= 0; i--)
                {
                    Tasks t = Job[i];
                    int ctmin = t.Ct;
                    int zmin = Z;
                    for (int j = t.Es; j <= t.Ls; j++)
                    {
                        int z = 0;
                        t.Ct = j;
                        foreach (var item2 in cal)
                        {
                            item2.z = 0;
                            item2.z2 = 0;
                        }
                        for (int k = 0; k < Job.Count; k++)
                        {
                            for (int stin = Job[k].Ct; stin < Job[k].Ct + Job[k].Dur; stin++)
                            {
                                cal[stin].z += Job[k].R;
                                cal[stin].z2 = cal[stin].z * cal[stin].z;
                            }
                        }
                        foreach (var item3 in cal)
                        {
                            z += item3.z2;
                        }
                        if (z < zmin)
                        {
                            flag = true;
                            zmin = z;

                            ctmin = t.Ct;
                        }


                    }
                    t.Ct = ctmin;
                    Z = zmin;
                }

            }
            foreach (var item2 in cal)
            {
                item2.z = 0;
                item2.z2 = 0;
            }
            for (int k = 0; k < Job.Count; k++)
            {
                for (int stin = Job[k].Ct; stin < Job[k].Ct + Job[k].Dur; stin++)
                {
                    cal[stin].z += Job[k].R;
                    cal[stin].z2 = cal[stin].z * cal[stin].z;
                }
            }
            listBox2.Items.Clear();
            listBox2.Items.Add("Time" + "   R   " + "R2   ");
            foreach (var item3 in cal)
            {
                listBox2.Items.Add(item3.time + "   |   " + item3.z + " |  " + item3.z2);
            }

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Job.Any())
            {
               // ExampleFull ex = new ExampleFull(Job);
                ExampleSimple ex = new ExampleSimple(Job);
                ex.Show();
            }
        }
    }
}
