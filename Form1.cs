using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;


namespace Barcode_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
        private void button1_Click_1(object sender, EventArgs e)
        {


            SqlConnection conn = new SqlConnection("Data Source=GILSFDNGDSVR07;Initial Catalog=Nagda;User ID=sa;Password=Sa@12345");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into BarcodeGen (Name,Red,Yellow,White,Blue,Date,Time,BarcodeRed,BarcodeYellow,BarcodeWhite,BarcodeBlue) values ('" + txtName.Text + "','" + txtred.Text + "','" + txtyellow.Text + "','" + txtwhite.Text + "','" + txtblue.Text + "','" + datePicker.Text + "','" + timePicker.Text + "','" + txtName.Text + " " + txtred.Text + "','" + txtName.Text + " " + txtyellow.Text + "','" + txtName.Text + " " + txtwhite.Text + "','" + txtName.Text + " " + txtblue.Text + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Barcode generated successfully");
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Input Barcode", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtred.Text.Trim() == "")
            {
                MessageBox.Show("Input  Weight", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtyellow.Text.Trim() == "")
            {
                MessageBox.Show("Input  Weight", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtwhite.Text.Trim() == "")
            {
                MessageBox.Show("Input  Weight", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtblue.Text.Trim() == "")
            {
                MessageBox.Show("Input  Weight", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            errorProvider1.Clear();

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.CODE128;
           
            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {
                    barcode.IncludeLabel = true;
                    pictureBox1.Image = barcode.Encode(type, 
                        txtName.Text + " R-" + txtred.Text , Color.Black, Color.White);
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Barcode Data Saved....");
        }
        private void printDoc_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            using (Graphics graph = e.Graphics)
            {
                int rowY = 0;
                for (int n3 = 0; n3 < 5; n3++)
                {
                    int rowX = 0;
                    for (int nI = 0; nI < 8; nI++)
                    {
                        graph.DrawImage(pictureBox1.Image, rowY + 10, 5 + rowX);
                        rowX = rowX + pictureBox1.Height + 20;
                    }

                    rowY = rowY + pictureBox1.Width + 22;



                }
               

            }
        }
       
        private void cmdprint_Click_1(object sender, EventArgs e)
        {
            printDoc.Print();

        }


            
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

      
    }
    }

