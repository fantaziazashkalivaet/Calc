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

        private IOperation lastOperation;
        private Button lastButton;

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

                if (lastButton != null)
                {
                    lastButton.BackColor = SystemColors.Control;
                }

                button.BackColor = SystemColors.ActiveCaption;

                var operation = button.Tag as IOperation;
                if (operation == null)
                    return;

                lastOperation = operation;
                lastButton = button;

                Calculate();
                
           
        }

        private void Calculate()
        {
            var inputs = textBox1.Text.Split(' ');
            var args = inputs.Select(str => Helper.Str2Db(str));

            lastOperation.Input = args.ToArray();

            try
            {
                var result = lastOperation.GetResult();

                var str = new StringBuilder();
                str.AppendFormat("{0} ( ", lastOperation.Name);
                foreach (var item in lastOperation.Input)
                {
                    str.Append(item.ToString() + ' ');
                }
                str.Append(") " + result.ToString());
                History.Items.Add(str);
                textBox1.SelectAll();

                label3.ForeColor = Color.Black;
                label3.Text = string.Format("{0}", result);

                var baseOper = lastOperation as Operation;

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


        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lastOperation != null)
                {
                    Calculate();
                }
                else
                {
                    label3.Text = "Select operation please";
                }
                textBox1.SelectAll();
            }
        }

     
    }
}
