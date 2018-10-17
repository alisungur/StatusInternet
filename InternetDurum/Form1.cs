using InternetDurum.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetDurum
{
    public partial class Form1 : Form
    {
        DurumContext db = new DurumContext();

        public Form1()
        {
            InitializeComponent();

            timer1.Start();
            timer2.Start();

            var query = db.InternetDrm.ToList();

            dataGridView1.DataSource = query;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public bool InternetKontrol()
        {
            try
            {
                System.Net.Sockets.TcpClient kontrol_client = new System.Net.Sockets.TcpClient("www.google.com.tr", 80);
                kontrol_client.Close();
                return true;
            }
            catch (Exception)
            {


                return false;
            }


        }


        public bool flagInternetService = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var newResult = InternetKontrol();
                var warn = false;


                if (flagInternetService != newResult)
                {
                    if (newResult == false) warn = true;

                    flagInternetService = newResult;

                }

                if (warn)
                {
                    InternetDrm drm = new InternetDrm();
                    drm.GidenNet= "Net Gitti " + DateTime.Now.ToString();
                    drm.GelenNet = "";

                    db.InternetDrm.Add(drm);
                    db.SaveChanges();                  

                                  
                    
                    notifyIcon1.Icon = SystemIcons.Information;
                    notifyIcon1.ShowBalloonTip(3000, "Net Durum", "Net Gitti " + DateTime.Now.ToLongTimeString().ToString(), ToolTipIcon.Info);
                    notifyIcon1.Visible = true;

                    BindCollection();

                }
            }
            catch (Exception)
            {


            }


        }

        private void BindCollection()
        {
            var query = db.InternetDrm.ToList();

            dataGridView1.DataSource = query;
        }


        public bool flagInternetSer = false;

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                var newResult = InternetKontrol();
                var warn = false;

                if (flagInternetSer != newResult)
                {
                    if (newResult == true) warn = true;

                    flagInternetSer = newResult;

                }

                if (warn)
                {
                    InternetDrm drm = new InternetDrm();
                    drm.GidenNet = "";
                    drm.GelenNet= "Net Geldi " + DateTime.Now.ToString();

                    db.InternetDrm.Add(drm);
                    db.SaveChanges();                



                    notifyIcon1.Icon = SystemIcons.Information;
                    notifyIcon1.ShowBalloonTip(3000, "Net Durum", "Net Geldi " + DateTime.Now.ToLongTimeString().ToString(), ToolTipIcon.Info);
                    notifyIcon1.Visible = true;

                    BindCollection();

                }


            }
            catch (Exception)
            {


            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.MouseDoubleClick += new MouseEventHandler(MyIcon_MouseDoubleClick);

            }
        }
        void MyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;

        }
    }
}
