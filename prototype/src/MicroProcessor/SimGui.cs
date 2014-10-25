using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace armsim
{
    public partial class SimGui : Form
    {
        // use me to intialize all the things you dont want the user touching :D
        public SimGui()
        {
            InitializeComponent();
            output.Text = Computer.HashSet();
            for (uint x = 0; x < 16; x++)
            {
                string rnum = "r" + x.ToString();
                string[] row = new string[] { rnum, BitConverter.ToUInt32(Computer.regRead(x), 0).ToString("X8") };
                regGrid.Rows.Add(row);
            }

            uint address = 0;
            byte[] beta = Computer.memOut(address);
            uint y = 0;
            for (uint x = 0; x < 7; x++)
            {
                string[] row = new string[] { (address + y).ToString("x2"), beta[y].ToString("x2"), beta[y + 1].ToString("x2"), beta[y + 2].ToString("x2"), beta[y + 3].ToString("x2"), beta[y + 4].ToString("x2"), beta[y + 5].ToString("x2"), beta[y + 6].ToString("x2"), beta[y + 7].ToString("x2"), beta[y + 8].ToString("x2"), beta[y + 9].ToString("x2"), beta[y + 10].ToString("x2"), beta[y + 11].ToString("x2"), beta[y + 12].ToString("x2"), beta[y + 13].ToString("x2"), beta[y + 14].ToString("x2"), beta[y + 15].ToString("x2") };
                memGrid.Rows.Add(row);
                y = y + 16;
            }

            uint p = 0;
            for (uint x = 0; x < 4; x++)
            {
                string[] row = new string[] {(Computer.stackPointerGet() + p).ToString("x8"), Computer.grabWord(Computer.stackPointerGet()).ToString("x8") };
                stackView.Rows.Add(row);
                p += 4;
            }

        }
        public void update()
        {
            regGrid.Rows.Clear();
            for (uint x = 0; x < 16; x++)
            {
                string rnum = "r" + x.ToString();
                string[] row = new string[] { rnum, BitConverter.ToUInt32(Computer.regRead(x), 0).ToString("X8") };
                regGrid.Rows.Add(row);
            }
        }

        //reset button that sets all the things back to 0
        private void button1_Click(object sender, EventArgs e)
        {
            Computer.clobber();
            output.Text = Computer.HashSet();
            regGrid.Rows.Clear();
            for (uint x = 0; x < 16; x++)
            {
                string rnum = "r" + x.ToString();
                string[] row = new string[] { rnum, BitConverter.ToUInt32(Computer.regRead(x), 0).ToString("X8") };
                regGrid.Rows.Add(row);
            }
            memGrid.Rows.Clear();
            uint address = 0;
            byte[] beta = Computer.memOut(address);
            uint y = 0;
            for (uint x = 0; x < 7; x++)
            {
                string[] row = new string[] { (address + y).ToString("x2"), beta[y].ToString("x2"), beta[y + 1].ToString("x2"), beta[y + 2].ToString("x2"), beta[y + 3].ToString("x2"), beta[y + 4].ToString("x2"), beta[y + 5].ToString("x2"), beta[y + 6].ToString("x2"), beta[y + 7].ToString("x2"), beta[y + 8].ToString("x2"), beta[y + 9].ToString("x2"), beta[y + 10].ToString("x2"), beta[y + 11].ToString("x2"), beta[y + 12].ToString("x2"), beta[y + 13].ToString("x2"), beta[y + 14].ToString("x2"), beta[y + 15].ToString("x2") };
                memGrid.Rows.Add(row);
                y = y + 16;
            }
            stackView.Rows.Clear();
            uint p = 0;
            for (uint x = 0; x < 4; x++)
            {
                string[] row = new string[] {(Computer.stackPointerGet() + p).ToString("x8"), Computer.grabWord(Computer.stackPointerGet()).ToString("x8") };
                stackView.Rows.Add(row);
                p += 4;
            }

        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //load file button
        //loads a file into ram clobbers all the things when it does it.
        private void button1_Click_1(object sender, EventArgs e)
        {
            bool update = false;
            try
            {
                openFileDialog1.Filter = "ELF|*.exe|All File Types|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string ext = Path.GetExtension(openFileDialog1.FileName);
                    if (ext == ".exe")
                    {

                        fileLbl.Text = Path.GetFileName(openFileDialog1.FileName);
                        Computer.clobber();
                        Computer.readFile(Path.GetFileName(openFileDialog1.FileName));
                        output.Text = Computer.HashSet();
                        update = true;

                    }
                }
                else
                {
                    Computer.log.WriteLine("Prototype: error reading from the selcted file");
                }
            }
            catch
            {
                Computer.log.WriteLine("Prototype: error reading from the selcted file");
               
            }
            if (update)
            {
                memGrid.Rows.Clear();
                uint address = 0;
                byte[] beta = Computer.memOut(address);
                uint y = 0;
                for (uint x = 0; x < 7; x++)
                {
                    string[] row = new string[] { (address + y).ToString("x2"), beta[y].ToString("x2"), beta[y + 1].ToString("x2"), beta[y + 2].ToString("x2"), beta[y + 3].ToString("x2"), beta[y + 4].ToString("x2"), beta[y + 5].ToString("x2"), beta[y + 6].ToString("x2"), beta[y + 7].ToString("x2"), beta[y + 8].ToString("x2"), beta[y + 9].ToString("x2"), beta[y + 10].ToString("x2"), beta[y + 11].ToString("x2"), beta[y + 12].ToString("x2"), beta[y + 13].ToString("x2"), beta[y + 14].ToString("x2"), beta[y + 15].ToString("x2") };
                    memGrid.Rows.Add(row);
                    y = y + 16;
                }
                regGrid.Rows.Clear();
                for (uint x = 0; x < 16; x++)
                {
                    string rnum = "r" + x.ToString();
                    string[] row = new string[] { rnum, BitConverter.ToUInt32(Computer.regRead(x), 0).ToString("X8") };
                    Computer.log.WriteLine(row);
                    regGrid.Rows.Add(row);
                }
                stackView.Rows.Clear();
                uint p = 0;
                for (uint x = 0; x < 4; x++)
                {
                    string[] row = new string[] { (Computer.stackPointerGet() + p).ToString("x8"), Computer.grabWord(Computer.stackPointerGet()).ToString("x8") };
                    stackView.Rows.Add(row);
                    p += 4;
                }
            }


        }

        private void regGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void inputTxt_TextChanged(object sender, EventArgs e)
        {

        }
        //terminal stuff that puts stuff from input text into textbox
        private void enterBtn_Click(object sender, EventArgs e)
        {
            termTxt.Text = termTxt.Text +  "\r\n" + inputTxt.Text;
        }

       
        //calls the step button
        private void stepBtn_Click(object sender, EventArgs e)
        {
            new Thread(Computer.step).Start();
            regGrid.Rows.Clear();
            for (uint x = 0; x < 16; x++)
            {
                string rnum = "r" + x.ToString();
                string[] row = new string[] { rnum, BitConverter.ToUInt32(Computer.regRead(x), 0).ToString("X8") };
                regGrid.Rows.Add(row);
            }
        
        }

        //calls the run fuction
        private void runBtn_Click(object sender, EventArgs e)
        {

            new Thread(Computer.run).Start();
            regGrid.Rows.Clear();
            for (uint x = 0; x < 16; x++)
            {
                string rnum = "r" + x.ToString();
                string[] row = new string[] { rnum, BitConverter.ToUInt32(Computer.regRead(x), 0).ToString("X8") };
                regGrid.Rows.Add(row);
            }
        }
        //sets the stop variable that stops the thread of run
        private void stopBtn_Click(object sender, EventArgs e)
        {
            Computer.setStop();
        }

        private void dissBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SimGui_Load(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click_1(null, null);
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runBtn_Click(null, null);
        }

        private void stepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stepBtn_Click(null, null);
        }

        private void breakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopBtn_Click(null, null);
        }

        private void toggleTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Computer.getTrace())
            {
                Computer.setTrace(true);
            }
            else
            {
                Computer.setTrace(false);
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        //allows user to set the memory panels view to a different address.
        private void memGo_Click(object sender, EventArgs e)
        {
            try
            {
                memGrid.Rows.Clear();
                uint address = Convert.ToUInt32(memTxt.Text);
                byte[] beta = Computer.memOut(address);
                uint y = 0;
                for (uint x = 0; x < 7; x++)
                {
                    string[] row = new string[] { (address + y).ToString("x2"), beta[y].ToString("x2"), beta[y + 1].ToString("x2"), beta[y + 2].ToString("x2"), beta[y + 3].ToString("x2"), beta[y + 4].ToString("x2"), beta[y + 5].ToString("x2"), beta[y + 6].ToString("x2"), beta[y + 7].ToString("x2"), beta[y + 8].ToString("x2"), beta[y + 9].ToString("x2"), beta[y + 10].ToString("x2"), beta[y + 11].ToString("x2"), beta[y + 12].ToString("x2"), beta[y + 13].ToString("x2"), beta[y + 14].ToString("x2"), beta[y + 15].ToString("x2") };
                    memGrid.Rows.Add(row);
                    y = y + 16;
                }
            }
            catch 
            {
                Computer.log.WriteLine("Prototype: Error reading in the address the user provided");
                  memGrid.Rows.Clear();
                uint address = 0;
                byte[] beta = Computer.memOut(address);
                uint y = 0;
                for (uint x = 0; x < 7; x++)
                {
                    string[] row = new string[] { (address + y).ToString("x2"), beta[y].ToString("x2"), beta[y + 1].ToString("x2"), beta[y + 2].ToString("x2"), beta[y + 3].ToString("x2"), beta[y + 4].ToString("x2"), beta[y + 5].ToString("x2"), beta[y + 6].ToString("x2"), beta[y + 7].ToString("x2"), beta[y + 8].ToString("x2"), beta[y + 9].ToString("x2"), beta[y + 10].ToString("x2"), beta[y + 11].ToString("x2"), beta[y + 12].ToString("x2"), beta[y + 13].ToString("x2"), beta[y + 14].ToString("x2"), beta[y + 15].ToString("x2") };
                    memGrid.Rows.Add(row);
                    y = y + 16;
                }
            }

            
        }
    }
}

