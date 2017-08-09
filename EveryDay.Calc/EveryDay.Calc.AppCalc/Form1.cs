using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EveryDay.Calc.Calculation.Interfaces;
using EveryDay.Calc.Calculation.Models;

namespace EveryDay.Calc.AppCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOper_Click(object sender, EventArgs e)
        {
            
                var button = sender as Button;
                if (button == null)
                    return;



                var operation = button.Tag as IOperation;
                if (operation == null)
                    return;

                var inputs = textBox1.Text.Split(' ');
                var args = inputs.Select(str => Helper.Str2Db(str));

                operation.Input = args.ToArray();

                try
                {
                    var result = operation.GetResult();

                    var str = new StringBuilder();
                    str.Append(operation.Name + " ( ");
                    foreach (var item in operation.Input)
                    {
                        str.Append(item.ToString() + ' ');
                    }
                    str.Append(") " + result.ToString());
                    History.Items.Add(str);
                    textBox1.Clear();

                    label3.ForeColor = Color.Black;
                    label3.Text = string.Format("{0}", result);

                    var baseOper = operation as Operation;

                    if (baseOper != null && !string.IsNullOrWhiteSpace(baseOper.Error))
                    {
                        label3.ForeColor = Color.DarkGoldenrod;
                        label3.Text = baseOper.Error;
                    }
                }
                catch (Exception ex)
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = ex.Message;
                }

                textBox1.Tag = operation;
                textBox1.Enter += new System.EventHandler(buttonOper_Click);

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var operations = Helper.LoadOperations().ToList();

            this.fOperations.SuspendLayout();
            var count = 0;
            foreach (var operation in operations)
            {
                var button = new System.Windows.Forms.Button();

                var y = 0;

                button.Location = new System.Drawing.Point(14 + count * 81, 30 + y * 42);
                if (fOperations.Size.Width < (button.Location.X + 81))
                {
                    y++;
                    count = 0;
                }
                button.Location = new System.Drawing.Point(14 + count * 81, 30 + y * 42);
                button.Name = string.Format("button_oper_{0}", count);
                button.Size = new System.Drawing.Size(75, 36);
                button.TabIndex = 5 + count;
                button.Text = operation.Name;
                button.UseVisualStyleBackColor = true;

                button.Tag = operation;

                button.Click += new System.EventHandler(this.buttonOper_Click);
                

                var baseOper = operation as Operation;
                if (baseOper != null)
                {
                    this.toolTip.SetToolTip(button, baseOper.GetDescription());
                }

                this.fOperations.Controls.Add(button);

                count++;
            }
            

            this.fOperations.ResumeLayout(false);
        }

        private void history_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;
            var operation = button.Tag as IOperation;
            if (operation == null)
                return;

            var inputs = textBox1.Text.Split(' ');
            var args = inputs.Select(str => Helper.Str2Db(str));

            operation.Input = args.ToArray();

            try
            {
                var result = operation.GetResult();

                var str = new StringBuilder();
                str.Append(operation.Name + " ( ");
                foreach (var item in operation.Input)
                {
                    str.Append(item.ToString() + ' ');
                }
                str.Append(") " + result.ToString());
                History.Items.Add(str);
                textBox1.Clear();

                label3.ForeColor = Color.Black;
                label3.Text = string.Format("{0}", result);

                var baseOper = operation as Operation;

                if (baseOper != null && !string.IsNullOrWhiteSpace(baseOper.Error))
                {
                    label3.ForeColor = Color.DarkGoldenrod;
                    label3.Text = baseOper.Error;
                }
            }
            catch (Exception ex)
            {
                label3.ForeColor = Color.Red;
                label3.Text = ex.Message;
            }
        }

     
    }
}
