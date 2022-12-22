using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Mixer
{
    public partial class Form1 : Form
    {
        private List<Musica> listaMusicas1 = new List<Musica>();
        private List<Musica> listaMusicas2 = new List<Musica>();
        private List<Musica> listaMusicas3 = new List<Musica>();
        private List<Musica> listaMusicas4 = new List<Musica>();
        private string play1, play2;
        private int volume = 60;

        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            Player1.uiMode = "none";
            Player1.Ctlenabled = false;
            Player2.uiMode = "none";
            Player2.Ctlenabled = false;
            Player1.settings.volume = volume;
            Player2.settings.volume = volume;
            WriteVol();
        }
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    listaMusicas1.Add(new Musica(file));
                }
                listBox1.Items.Clear();
                foreach (var item in listaMusicas1)
                {
                    listBox1.Items.Add(Path.GetFileName(item.Arquivo).Split('.')[0]);
                }
            }
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    listaMusicas3.Add(new Musica(file));
                }
                listBox3.Items.Clear();
                foreach (var item in listaMusicas3)
                {
                    listBox3.Items.Add(Path.GetFileName(item.Arquivo).Split('.')[0]);
                }
            }
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    listaMusicas2.Add(new Musica(file));
                }
                listBox2.Items.Clear();
                foreach (var item in listaMusicas2)
                {
                    listBox2.Items.Add(Path.GetFileName(item.Arquivo).Split('.')[0]);
                }
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    listaMusicas4.Add(new Musica(file));
                }
                listBox4.Items.Clear();
                foreach (var item in listaMusicas4)
                {
                    listBox4.Items.Add(Path.GetFileName(item.Arquivo).Split('.')[0]);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Player1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar1.Maximum = (int)Player1.Ctlcontrols.currentItem.duration;
                progressBar1.Value = (int)Player1.Ctlcontrols.currentPosition;

                lbl1Cur.Text = Player1.Ctlcontrols.currentPositionString;
                lbl1Dur.Text = Player1.Ctlcontrols.currentItem.durationString.ToString();
            }
            else if (Player1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                progressBar1.Value = 0;
                lbl1Cur.Text = "00:00";
                lbl1Dur.Text = "00:00";
            }

            if (Player2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar2.Maximum = (int)Player2.Ctlcontrols.currentItem.duration;
                progressBar2.Value = (int)Player2.Ctlcontrols.currentPosition;

                lbl2Cur.Text = Player2.Ctlcontrols.currentPositionString;
                lbl2Dur.Text = Player2.Ctlcontrols.currentItem.durationString.ToString();
            }
            else if (Player2.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                progressBar2.Value = 0;
                lbl2Cur.Text = "00:00";
                lbl2Dur.Text = "00:00";
            }
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Player1.URL = listaMusicas1[listBox1.SelectedIndex].Arquivo;
            Player1.Ctlcontrols.play();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            play1 = listaMusicas1[listBox1.SelectedIndex].Arquivo;
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            play1 = listaMusicas3[listBox3.SelectedIndex].Arquivo;
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            play2 = listaMusicas2[listBox2.SelectedIndex].Arquivo;
        }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            play2 = listaMusicas4[listBox4.SelectedIndex].Arquivo;
        }
        private void btnPlay1_Click(object sender, EventArgs e)
        {
            Player1.URL = play1;
            Player1.Ctlcontrols.play();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Player1.Ctlcontrols.stop();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Player2.URL = play2;
            Player2.Ctlcontrols.play();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Player2.Ctlcontrols.stop();
        }
        private void listBox1_Enter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Blue;
        }
        private void listBox1_Leave(object sender, EventArgs e)
        {
            label1.BackColor = Color.DarkGray;
        }
        private void listBox2_Enter(object sender, EventArgs e)
        {
            label2.BackColor = Color.Blue;
        }
        private void listBox2_Leave(object sender, EventArgs e)
        {
            label2.BackColor = Color.DarkGray;
        }
        private void listBox3_Enter(object sender, EventArgs e)
        {
            label3.BackColor = Color.Blue;
        }
        private void listBox3_Leave(object sender, EventArgs e)
        {
            label3.BackColor = Color.DarkGray;
        }
        private void listBox4_Enter(object sender, EventArgs e)
        {
            label4.BackColor = Color.Blue;
        }
        private void listBox4_Leave(object sender, EventArgs e)
        {
            label4.BackColor = Color.DarkGray;
        }
        private void progressBar1_MouseDown(object sender, MouseEventArgs e)
        {
            Player1.Ctlcontrols.currentPosition = Player1.currentMedia.duration * e.X / progressBar1.Width;
        }
        private void progressBar2_MouseDown(object sender, MouseEventArgs e)
        {
            Player2.Ctlcontrols.currentPosition = Player2.currentMedia.duration * e.X / progressBar2.Width;
        }

        private void Player1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e)
        {

        }

        private void Player1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            if (Player1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                Player1.fullScreen = true;
        }


        private void Player2_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            if (Player2.playState == WMPLib.WMPPlayState.wmppsPlaying)
                Player2.fullScreen = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            Mix();
        }

        private void Mix()
        {
            if (trackBar3.Value < 0)
            {
                Player2.settings.volume = trackBar3.Value + volume;
            }
            else if (trackBar3.Value > 0)
            {
                Player1.settings.volume = -trackBar3.Value + volume;
            }
            else if (trackBar3.Value == 0)
            {
                Player1.settings.volume = volume;
                Player2.settings.volume = volume;
            }
            WriteVol();
        }

        private void WriteVol()
        {
            int vol1 = (int) Player1.settings.volume * 100 / volume;
            int vol2 = (int) Player2.settings.volume * 100 / volume;
            label5.Text = "Volume " + vol1 + "%";
            label6.Text = "Volume " + vol2 + "%";
        }
    }
}
