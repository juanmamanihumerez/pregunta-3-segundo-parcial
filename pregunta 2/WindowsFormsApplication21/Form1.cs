using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace WindowsFormsApplication21
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(10,10);
            textBox1.Text = c.R.ToString();
            //textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            /*Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
            cR = c.R;
            cG = c.G;
            cB = c.B;*/
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int x, y, mR=0, mG=0, mB=0;
            x = e.X; y = e.Y;
            for (int i = x; i < x + 10;i++)
                for (int j = y; j < y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            cR = mR;
            cG = mG;
            cB = mB;
            textBox1.Text = cR.ToString();
            textBox2.Text = cG.ToString();
            textBox3.Text = cB.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, c);
                }
            pictureBox2.Image = cpoa;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, Color.FromArgb(c.R, 0 , 0) );
                }
            pictureBox2.Image = cpoa;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, Color.FromArgb(0, c.G, 0));
                }
            pictureBox2.Image = cpoa;
        }

        public void guardaregion(string cod, string reg, string color, int cordx, int cordy)
        {
            SqlConnection con = new SqlConnection("server=(local);user=usuario324;pwd=123456;database=juanmamanihumerez");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into region values(@cod, @reg, @color,@cordx,@cordy)", con);
            cmd.Parameters.AddWithValue("@cod", cod);
            cmd.Parameters.AddWithValue("@reg", reg);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.Parameters.AddWithValue("@cordx", cordx);
            cmd.Parameters.AddWithValue("@cordy", cordy);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void recuperaDatos()
        {
            SqlConnection con = new SqlConnection("server=(local);user=usuario324;pwd=123456;database=juanmamanihumerez");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM region WHERE cod=@cod", con);
            cmd.Parameters.AddWithValue("@cod", "R1");

            SqlDataReader registro = cmd.ExecuteReader();

        }
        private void button8_Click(object sender, EventArgs e)
        {
            //int meR, meG, meB;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            string cod = textBox5.Text;
            string color = comboBox1.Text;
            
            SqlConnection con = new SqlConnection("server=(local);user=usuario324;pwd=123456;database=juanmamanihumerez");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM region WHERE cod=@cod", con);
            cmd.Parameters.AddWithValue("@cod",cod);
            
            SqlDataReader registro = cmd.ExecuteReader();
         

            while (registro.Read())
            {   
                if(registro["reg"].ToString().Equals("z1"))
                {
                    cpoa.SetPixel((int)registro["datosx"], (int)registro["datosy"], ColorTranslator.FromHtml(color));
                }
                else
                { 
                    c = bmp.GetPixel((int)registro["datosx"], (int)registro["datosy"]);
                    cpoa.SetPixel((int)registro["datosx"], (int)registro["datosy"], c);
                }
            }
            pictureBox2.Image = cpoa;
            con.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (((cR - 10) < c.R) && (c.R < (cR + 10)) && ((cG - 10) < c.G) && (c.G < (cG + 10)) && ((cB - 10) < c.B) && (c.B < (cB + 10)))
                        cpoa.SetPixel(i, j, Color.Black);
                    else 
                       cpoa.SetPixel(i, j, c);
                }
            pictureBox2.Image = cpoa;
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int meR, meG, meB;
            
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width - 10; i += 10)
                for (int j = 0; j < bmp.Height - 10; j += 10)
                {
                    meR = 0;
                    meG = 0;
                    meB = 0;

                    for (int k = i; k < i + 10; k++)
                    
                        for (int l = j; l < j + 10; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            meR = meR + c.R;
                            meG = meG + c.G;
                            meB = meB + c.B;
                        }
                        meR = meR / 100;
                        meG = meG / 100;
                        meB = meB / 100;


                    /*string strx = "0";
                    string stry = "0";
                    string totalx = "0";
                    string totaly = "0";*/


                    List<int> lrx = new List<int>();
                    List<int> lry = new List<int>();

                    List<int> lcx = new List<int>();
                    List<int> lcy = new List<int>();
                    

                    if (((cR - 10) < meR) && (meR < (cR + 10)) && ((cG - 10) < meG) && (meG < (cG + 10)) && ((cB - 10) < meB) && (meB < (cB + 10)))
                        
                            for (int k = i; k < i + 10; k++)
                            
                                for (int l = j; l < j + 10; l++)
                                {
                                //strx = strx + "," + k;
                                //stry = stry + "," + l;
                                cpoa.SetPixel(k, l, Color.Orange);
                                string reg="z1";
                                    
                                //lrx.Add(k);
                                //lry.Add(l);
                                guardaregion(textBox4.Text,reg, textBox5.Text, k, l);
                            }
                            
                            /*strx = strx.Remove(0, 2);
                            stry = stry.Remove(0, 2);
                            */
                            //guardaregion(textBox4.Text, textBox5.Text, strx, stry);

                            /*string[] valoresx = strx.Split(',');
                            string[] valoresy = stry.Split(',');

                            int[] arregloIntx = new int[valoresx.Length];
                            int[] arregloInty = new int[valoresy.Length];

                            for (int px = 0; px < valoresx.Length; px++)
                            {
                                arregloIntx[px] = Int32.Parse(valoresx[px]);
                            }

                            for (int py = 0; py < valoresy.Length; py++)
                            {
                                arregloInty[py] = Int32.Parse(valoresy[py]);
                            }

                            for (int x = 0; x < arregloIntx.Length; x++)
                            {
                                for (int y = 0; y < arregloInty.Length; y++)
                                {
                                    cpoa.SetPixel(arregloIntx[x], arregloInty[y], Color.Orange);
                                }
                            }*/

                        
                        else
                        
                            for (int k = i; k < i + 10; k++)
                            
                                for (int l = j; l < j + 10; l++)
                                {
                                c = bmp.GetPixel(k, l);
                                cpoa.SetPixel(k, l, c);

                                //totalx = totalx + "," + k;
                                //totaly = totaly + "," + l;
                                string reg = "z2";
                                //lcx.Add(k);
                                //lcy.Add(l);
                                guardaregion(textBox4.Text, reg, textBox5.Text, k, l);

                            }

                    /*
                    totalx = totalx.Remove(0, 2);
                    totaly = totaly.Remove(0, 2);

                    Console.WriteLine(totalx);
                    //guardaregion(textBox4.Text, textBox5.Text, strx, stry);

                    string[] valx = totalx.Split(',');
                    string[] valy = totaly.Split(',');

                    int[] tarregloIntx = new int[valx.Length];
                    int[] tarregloInty = new int[valy.Length];

                    for (int px = 0; px < valx.Length; px++)
                    {
                        tarregloIntx[px] = Int32.Parse(valx[px]);

                    }

                    for (int py = 0; py < valy.Length; py++)
                    {
                        tarregloInty[py] = Int32.Parse(valy[py]);

                    }

                    for (int x = 0; x < tarregloIntx.Length; x++)
                    {
                        for (int y = 0; y < tarregloInty.Length; y++)
                        {

                            c = bmp.GetPixel(tarregloIntx[x], tarregloInty[y]);
                            cpoa.SetPixel(tarregloIntx[x], tarregloInty[y], c);
                        }
                    }*/
                    
                    for (int x = 0; x < lrx.Count; x++)

                        for (int y = 0; y < lry.Count; y++)
                        {
                            //c = bmp.GetPixel(lrx[x], lry[y]);
                            //cpoa.SetPixel(lrx[x], lry[y], c);
                            cpoa.SetPixel(lrx[x], lry[y], Color.Orange);
                        }

                    for (int x = 0; x < lcx.Count; x++)

                        for (int y = 0; y < lcy.Count; y++)
                        {
                            c = bmp.GetPixel(lcx[x], lcy[y]);
                            cpoa.SetPixel(lcx[x], lcy[y], c);
                        }
                    
                }
            pictureBox2.Image = cpoa;
        }
    }
}
