using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GbSet
{

    public partial class GbSetView : Form
    {
        String screenX;
        String screenY;




        public GbSetView()
        {
            var Settings = new IniFile("Config.ini");
            var winMode = Settings.Read("winMode");
            var sndEffect = Settings.Read("Effects");
            var sndMusic = Settings.Read("BGM");
            var VSync = Settings.Read("VSync");
            var wndResBox = Settings.Read("wndRes");

            try
            {
                // Ultima Configuração por arquivo INI

                // Setta os campos

                //Modo da tela
                comboBox2.SelectedIndex = int.Parse(winMode);
                //Resolução da Tela
                comboBox1.SelectedIndex = int.Parse(wndResBox);

                //Musicas
                if (bool.Parse(sndMusic) == true)
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
                //Efeitos Sonoros
                if (bool.Parse(sndEffect) == true)
                {
                    checkBox3.Checked = true;
                }
                else
                {
                    checkBox3.Checked = false;
                }
            }
            catch
            {

            }
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            else if (checkBox1.Checked == false)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 5)
            {
                label7.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            else
            {
                label7.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
        }
        //Cria o DWX
        private void genDXW()
        {
            string path = @"dxwnd.dxw";
            try
            {
                File.Delete("dxwnd.lock");
            }
            catch (System.IO.FileNotFoundException)
            {

            }
            // Cria o Arquivo DWX
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("[target]");
                sw.WriteLine("title0=Reload GunBound!");
                sw.WriteLine("C:\\Program Files(x86)\\Reload\\GunboundWC\\GWCL.exe");
                sw.WriteLine("startfolder0 = ");
                sw.WriteLine("C:\\Program Files(x86)\\Reload\\GunboundWC\\GWCL.exe");
                sw.WriteLine("icon0 = 0000010001002020100000000000E802000016000000280000002000000040000000010004000000000080020000000000000000000000000000000000000000000000008000008000000080800080000000800080008080000080808000C0C0C0000000FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
                sw.WriteLine("module0 = ");
                sw.WriteLine("opengllib0 = ");
                sw.WriteLine("notes0 = ");
                sw.WriteLine("registry0 = ");
                sw.WriteLine("ver0 = 0");
                sw.WriteLine("monitorid0 =-1");
                sw.WriteLine("filterid0 =0");
                sw.WriteLine("renderer0 =1");
                sw.WriteLine("coord0 =1");
                sw.WriteLine("flag0 =673186353");
                sw.WriteLine("flagg0 =1275346944");
                sw.WriteLine("flagh0 =22");
                sw.WriteLine("flagi0 =4194308");
                sw.WriteLine("flagj0 =4224");
                sw.WriteLine("flagk0 =268500992");
                sw.WriteLine("flagl0 =1048576");
                sw.WriteLine("flagm0 =0");
                sw.WriteLine("flagn0 =17825793");
                sw.WriteLine("flago0 =536870912");
                sw.WriteLine("tflag0 =0");
                sw.WriteLine("dflag0 =0");
                sw.WriteLine("posx0 =0");
                sw.WriteLine("posy0 =0");
                sw.WriteLine("sizx0 =" + screenX + "");
                sw.WriteLine("sizy0 =" + screenY + "");
                sw.WriteLine("maxfps0 =60");
                sw.WriteLine("initts0 =0");
                sw.WriteLine("winver0 =0");
                sw.WriteLine("maxres0 =-1");
                sw.WriteLine("swapeffect0 =0");
                sw.WriteLine("maxddinterface0 =9");
                sw.WriteLine("slowratio0 =2");
                sw.WriteLine("scanline0 =0");
                sw.WriteLine("initresw0 =800");
                sw.WriteLine("initresh0 =600");
                sw.WriteLine("fakehddrive0 =C:");
                sw.WriteLine("fakecddrive0 =D:");
                sw.WriteLine("cdvol0 =100");
            }

            // Abre o Arquivo
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            var Settings = new IniFile("Config.ini");
            Settings.Write("winMode", "" + comboBox2.SelectedIndex + "", "ScreenMode");
            Settings.Write("Effects", "" + checkBox2.Checked + "", "Audio");
            Settings.Write("BGM", "" + checkBox3.Checked + "", "Audio");
            //Settings.Write("VSync");
            Settings.Write("wndRes", "" + comboBox1.SelectedIndex + "", "ScreenMode");
        }
        private void button1_Click(object sender, EventArgs e)
        { // TELA CHEIA
            if (comboBox2.SelectedIndex == 0 || comboBox2.Text == "Tela Cheia")
            {
                comboBox2.SelectedIndex = 0;
                comboBox1.SelectedIndex = 0;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                try
                {
                    File.Delete("dxwnd.dxw");
                    try
                    {
                        File.Move("dxwnd.dll", "dxwnd.lock");
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível salvar as alterações, favor reinstalar o jogo", "Gunbound Configuration");
                    }
                    try
                    {
                        File.Move("ddraw.dll", "ddraw_wnd.dll");
                        File.Move("ddraw_fullscreen.dll", "ddraw.dll");
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível salvar as alterações, favor reinstalar o jogo", "Gunbound Configuration");
                    }

                }
                catch (System.IO.FileNotFoundException)
                {
                }
            }
            else
            {
                if (comboBox1.SelectedIndex != 5)
                { //RESOLUÇÕES
                    switch (this.comboBox1.SelectedIndex)
                    {
                        case 0:
                            this.screenX = "800";
                            this.screenY = "600";
                            break;
                        case 1:
                            this.screenX = "1024";
                            this.screenY = "768";
                            break;
                        case 2:
                            this.screenX = "1336";
                            this.screenY = "768";
                            break;
                        case 3:
                            this.screenX = "1600";
                            this.screenY = "1400";
                            break;
                        case 4:
                            this.screenX = "1920";
                            this.screenY = "1080";
                            break;
                        default:

                            break;
                    }
                }
                else
                {
                    this.screenX = textBox1.Text;
                    this.screenY = textBox2.Text;
                }
                try
                { // CORREÇÃO DO DDRAW / DXWND
                    try
                    {
                        File.Delete("dxwnd.dxw");
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível salvar as alterações, favor reinstalar o jogo", "Gunbound Configuration");
                    }
                    try
                    {
                        File.Move("dxwnd.lock", "dxwnd.dll");
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível salvar as alterações, favor reinstalar o jogo", "Gunbound Configuration");
                    }
                    try
                    {
                        File.Move("ddraw.dll", "ddraw_fullscreen.dll");
                        File.Move("ddraw_wnd.dll", "ddraw.dll");
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível salvar as alterações, favor reinstalar o jogo", "Gunbound Configuration");
                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                }
                genDXW();
                MessageBox.Show("As configurações foram gravadas.", "Gunbound Configuration");
                Close();
            }
        }

        //Gera o arquivo DXW e Renomeia o DDraw necessário para Janela.
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            try
            {
                try
                {
                    File.Delete("dxwnd.dxw");
                }
                catch
                {
                    MessageBox.Show("Não foi possível salvar as alterações, favor reinstalar o jogo", "Gunbound Configuration");
                }
                try
                {
                    File.Move("dxwnd.dll", "dxwnd.lock");
                }
                catch
                {
                    MessageBox.Show("Não foi possível salvar as alterações, favor reinstalar o jogo", "Gunbound Configuration");
                }
                try
                {
                    File.Move("ddraw_fullscreen.dll", "ddraw.dll");
                }
                catch
                {
                    MessageBox.Show("Não foi possível salvar as alterações, favor reinstalar o jogo", "Gunbound Configuration");
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("As configurações foram redefinidas.", "Gunbound Configuration");
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 1)
            {
                label1.Enabled = true;
                comboBox1.Enabled = true;
            }
            else
            {
                label1.Enabled = false;
                comboBox1.Enabled = false;
            }
        }
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
