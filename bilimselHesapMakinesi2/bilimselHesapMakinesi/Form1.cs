using System.Data;

namespace bilimselHesapMakinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //deðiþkenleri sýfýrlama kodu
        public void sifirla()
        {
            sonuc=0;
            sonuclandirildi = true;
            aktif2nd = false;
            lblSil = false;

            expBasildi = false;
            xUzeriYBasildi = false;
            logBasildi = false;

            esittirBasildi = false;
            dortIslem = false;
            strSonuc = "";
        }
        //deðiþkenleri sýfýrlama kodu



        //
        //----------------------------------------deðiþkenler----------------------------------------
        double sonuc;
        bool sonuclandirildi = true;
        bool aktif2nd = false;
        bool lblSil = false;

        bool expBasildi = false;
        bool xUzeriYBasildi = false;
        bool logBasildi = false;

        //(4+1) iþlemler için
        bool esittirBasildi = false;
        bool dortIslem = false;
        string strSonuc = "";
        //----------------------------------------deðiþkenler----------------------------------------
        //

        //
        //----------------------------------------text deðiþtiðinde----------------------------------------
        private void txtbox_TextChanged(object sender, EventArgs e)
        {
            if (txtbox.Text == "")
            {//textboxun texti boþ kalmak yerine 0 oluyor
                txtbox.Text = "0";
                btn_C.Text = "C";
            }
            else
            {
                btn_C.Text = "CE";
                if (txtbox.Text.Length == 2)
                {
                    if (txtbox.Text.Substring(0, 1) == "0")
                    {// textboxda 00 yazýyorsa onu 0 olarak güncelliyor
                        txtbox.Text = txtbox.Text.Substring(1, txtbox.Text.Length - 1);
                    }
                }
            }
            if (lblSil==true)
            {
                lbl.Text = "";
            }
        }
        //----------------------------------------text deðiþtiðinde----------------------------------------
        //

        //
        //----------------------------------------EÞÝTTÝR----------------------------------------
        private void btn_esittir_Click(object sender, EventArgs e)
        {
            //
            //2nd ile çalýþanlar
            if (aktif2nd == false)
            {//1. fonksiyonlarý

                //x^y butonu
                if (xUzeriYBasildi == true)
                {
                    xUzeriYBasildi = false;
                    sonuc = Math.Pow(sonuc, Convert.ToInt16(txtbox.Text));
                    sonuc = 0;
                }
                //x^y butonu
            }
            else
            {//2. fonksiyonlarý

                //x^y
                if (xUzeriYBasildi == true)
                {
                    xUzeriYBasildi = false;
                    lbl.Text += txtbox.Text + " =";
                    sonuc = Math.Pow(sonuc, 1 / Convert.ToDouble(txtbox.Text));
                    sonuc = 0;
                }
                //x^y

                //log butonu
                if (logBasildi == true)
                {
                    logBasildi = false;
                    lbl.Text += txtbox.Text + " =";
                    sonuc = Math.Log(sonuc, Convert.ToDouble(txtbox.Text));
                    sonuc = 0;
                }
                //log butonu

            }
            //2nd ile çalýþanlar
            //

            //exp butonu
            if (expBasildi == true)
            {
                expBasildi = false;
                int sifirSayisi = Convert.ToInt16(txtbox.Text);

                for (int i = 0; i < sifirSayisi; i++)
                {
                    sonuc *= 10;
                    lbl.Text = txtbox.Text = sonuc.ToString();
                }
                sonuc = 0;
            }
            //exp butonu


            //
            // 4+1 temel iþlemler
            if (dortIslem == true)
            {
                lbl.Text += txtbox.Text;

                //parantez açma sayýsý ile parantez kapama sayýsý eþit mi kontrolu
                int acikParantezSay = 0;
                for (int i = 0; i < lbl.Text.Length; i++)
                {
                    lbl.Text.Substring(i,1);
                    if (lbl.Text.Substring(i, 1)=="(")
                    {
                        acikParantezSay++;
                    }
                    else if (lbl.Text.Substring(i, 1) == ")")
                    {
                        acikParantezSay--;
                    }
                }
                if (acikParantezSay > 0)
                {
                    for (int i = 0; i < acikParantezSay; i++)
                    {
                        lbl.Text =  lbl.Text+")";
                    }
                }
                else if (acikParantezSay < 0)
                {
                    for (int i = 0; i < acikParantezSay; i++)
                    {
                        lbl.Text = "("+lbl.Text;
                    }
                }
                //parantez açma sayýsý ile parantez kapama sayýsý eþit mi kontrolu

                dortIslem = false;
                string math = lbl.Text;
                strSonuc = new DataTable().Compute(math, null).ToString();
                sonuc=Convert.ToDouble(strSonuc);
            }
            // 4+1 temel iþlemler
            //

            txtbox.Text = sonuc.ToString();
            sifirla();
            lblSil = true;
        }
        //----------------------------------------EÞÝTTÝR----------------------------------------
        //


        //
        //----------------------------------------sayýlar----------------------------------------
        private void btn_0_Click(object sender, EventArgs e)
        {
            if (sonuclandirildi == true)
            {
                if (esittirBasildi==true)
                {
                    lbl.Text = "";
                }
                txtbox.Text = "0";
                sonuclandirildi = false;
            }
            else
            {
                if (txtbox.Text!="0")
                {
                    txtbox.Text += "0";
                }
            }
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            if (sonuclandirildi==true)
            {
                txtbox.Text = "1";
                sonuclandirildi = false;
            }
            else
            {
                txtbox.Text += "1";
            }
        }
        private void btn_2_Click(object sender, EventArgs e)
        {
            if (sonuclandirildi == true)
            {
                txtbox.Text = "2";
                sonuclandirildi = false;
            }
            else
            {
                txtbox.Text += "2";
            }
        }
        private void btn_3_Click(object sender, EventArgs e)
        {
            if (sonuclandirildi == true)
            {
                txtbox.Text = "3";
                sonuclandirildi = false;
            }
            else
            {
                txtbox.Text += "3";
            }
        }
        private void btn_4_Click(object sender, EventArgs e)
        {
            if (sonuclandirildi == true)
            {
                txtbox.Text = "4";
                sonuclandirildi = false;
            }
            else
            {
                txtbox.Text += "4";
            }
        }
        private void btn_5_Click(object sender, EventArgs e)
        {
            if (sonuclandirildi == true)
            {
                txtbox.Text = "5";
                sonuclandirildi = false;
            }
            else
            {
                txtbox.Text += "5";
            }
        }
        private void btn_6_Click(object sender, EventArgs e)
        {
            if (sonuclandirildi == true)
            {
                txtbox.Text = "6";
                sonuclandirildi = false;
            }
            else
            {
                txtbox.Text += "6";
            }
        }
        private void btn_7_Click(object sender, EventArgs e)
        {
            if (sonuclandirildi == true)
            {
                txtbox.Text = "7";
                sonuclandirildi = false;
            }
            else
            {
                txtbox.Text += "7";
            }
        }
        private void btn_8_Click(object sender, EventArgs e)
        {
            if (sonuclandirildi == true)
            {
                txtbox.Text = "8";
                sonuclandirildi = false;
            }
            else
            {
                txtbox.Text += "8";
            }
        }
        private void btn_9_Click(object sender, EventArgs e)
        {
            if (sonuclandirildi == true)
            {
                txtbox.Text = "9";
                sonuclandirildi = false;
            }
            else
            {
                txtbox.Text += "9";
            }
        }
        //----------------------------------------sayýlar----------------------------------------
        //


        //
        //----------------------------------------kolay olanlar----------------------------------------
        private void btn_virgul_Click(object sender, EventArgs e)
        {
            bool virgulYaz = true;
            for (int i = 0; i < txtbox.Text.Length; i++)
            {//textte virgül var mýd iye kontrol
                if (txtbox.Text.Substring(i, 1) == ",")
                {
                    virgulYaz = false;
                }
            }
            if (virgulYaz==true)
            {//textte herhangi biyerde virgül yoksa virgül koy
                txtbox.Text += ",";
            }
        }
        private void btn_isaretDegistir_Click(object sender, EventArgs e)
        {
            sonuc = (Convert.ToDouble(txtbox.Text)*(-1));
            txtbox.Text = sonuc.ToString();
        }
        private void btn_sil_Click(object sender, EventArgs e)
        {
            txtbox.Text = txtbox.Text.Substring(0,txtbox.Text.Length-1);
        }
        private void btn_pi_Click(object sender, EventArgs e)
        {
            txtbox.Text =  Math.PI.ToString();
            sifirla();
        }
        private void btn_e_Click(object sender, EventArgs e)
        {
            txtbox.Text = Math.E.ToString();
            sifirla();
        }
        private void btn_mutlakDeger_Click(object sender, EventArgs e)
        {
            sonuc = (Convert.ToDouble(txtbox.Text));
            if (sonuc<0)
            {
                sonuc = (Convert.ToDouble(txtbox.Text) * (-1));
            }
            txtbox.Text = sonuc.ToString();
        }
        private void btn_1boluX_Click(object sender, EventArgs e)
        {
            sonuc = Convert.ToDouble(txtbox.Text);
            lbl.Text = "1/"+sonuc;
            sonuc = 1 / sonuc;
            txtbox.Text = sonuc.ToString();
            sifirla();
        }
        private void btn_C_Click(object sender, EventArgs e)
        {
            if (btn_C.Text=="CE")
            {
                txtbox.Text = "";
            }
            else if (btn_C.Text == "C")
            {
                lbl.Text = "";
            }
            sifirla();
        }
        private void btn_parantezAc_Click(object sender, EventArgs e)
        {
            lbl.Text +=  "(";
        }
        private void btn_parantezKapa_Click(object sender, EventArgs e)
        {
            lbl.Text += ")";
        }
        private void btn_faktoriyel_Click(object sender, EventArgs e)
        {
            int fact = 1;
            sonuc = Convert.ToDouble(txtbox.Text);
            lbl.Text = "fact(" + sonuc + ")";
            for (int i = 2; i <= sonuc; i++)
            {
                fact *= i;
            }
            txtbox.Text = fact.ToString();
            sonuclandirildi = true;
            sifirla();
        }
        //----------------------------------------kolay olanlar----------------------------------------
        //

        //
        //----------------------------------------2. iþlev butonu----------------------------------------
        private void btn_2nd_Click(object sender, EventArgs e)
        {
            if (btn_2nd.BackColor == System.Drawing.SystemColors.MenuHighlight)
            {
                btn_2nd.BackColor = System.Drawing.SystemColors.ScrollBar;
                aktif2nd = false;
                btn_xKare.Text = "x^2";
                btn_kareKok.Text = "kare kök";
                btn_xUzeriY.Text = "x^y";
                btn_10uzeriX.Text = "10^x";
                btn_log.Text = "log";
                btn_ln.Text = "ln";
            }
            else if (btn_2nd.BackColor == System.Drawing.SystemColors.ScrollBar)
            {
                btn_2nd.BackColor = System.Drawing.SystemColors.MenuHighlight;
                aktif2nd = true;
                btn_xKare.Text = "x^3";
                btn_kareKok.Text = "küp kök";
                btn_xUzeriY.Text = "y kök x";
                btn_10uzeriX.Text = "2^x";
                btn_log.Text = "logvY X";
                btn_ln.Text = "e^x";
            }
        }
        //----------------------------------------2. iþlev butonu----------------------------------------
        //

        //
        //----------------------------------------2. iþlev kullanýlan yerler----------------------------------------
        private void btn_xKare_Click(object sender, EventArgs e)
        {
            sonuc = Convert.ToDouble(txtbox.Text);

            if (aktif2nd == false)
            {
                lbl.Text = "sqr(" + sonuc + ")";

                sonuc = sonuc * sonuc;
            }
            else
            {
                lbl.Text = "cube(" + sonuc + ")";

                sonuc = sonuc * sonuc * sonuc;
            }
            txtbox.Text = sonuc.ToString();
            sonuclandirildi = true;
        }
        private void btn_kareKok_Click(object sender, EventArgs e)
        {
            sonuc = Convert.ToDouble(txtbox.Text);
            if (aktif2nd==false)
            {
                lbl.Text = "kare_kök(" +sonuc+")";
                sonuc =Math.Sqrt(sonuc);
            }
            else
            {
                lbl.Text = "küp_kök(" + sonuc + ")";
                sonuc = Math.Cbrt(sonuc);
            }
            txtbox.Text = sonuc.ToString();
            sonuclandirildi = true;
        }
        private void btn_xUzeriY_Click(object sender, EventArgs e)
        {
            sonuc = Convert.ToDouble(txtbox.Text);
            if (aktif2nd == false)
            {
                if (xUzeriYBasildi == false)
                {
                    lbl.Text = sonuc + "^";
                    xUzeriYBasildi = true;
                }
            }
            else
            {
                if (xUzeriYBasildi == false)
                {//y kuvvetinde kök x (x ^ 1/y)
                    lbl.Text = sonuc + " ykök ";
                    xUzeriYBasildi = true;
                }
            }
            sonuclandirildi = true;
            txtbox.Text = sonuc.ToString();
        }
        private void btn_10uzeriX_Click(object sender, EventArgs e)
        {
            sonuc = Convert.ToDouble(txtbox.Text);
            if (aktif2nd == false)
            {
                lbl.Text = "10^("+sonuc+")";
                sonuc=Math.Pow(10,sonuc);
            }
            else
            {
                lbl.Text = "2^(" + sonuc + ")";
                sonuc = Math.Pow(2, sonuc);
            }
            sonuclandirildi = true;
            txtbox.Text = sonuc.ToString();
        }
        private void btn_log_Click(object sender, EventArgs e)
        {
            sonuc = Convert.ToDouble(txtbox.Text);
            if (aktif2nd == false)
            {
                lbl.Text = "log(" + sonuc + ")";
                sonuc = Math.Log10(sonuc);
            }
            else
            {
                if (logBasildi==false)
                {
                    lbl.Text = sonuc + "log base";
                    logBasildi=true;
                }
            }
            sonuclandirildi = true;
            txtbox.Text = sonuc.ToString();
        }
        private void btn_ln_Click(object sender, EventArgs e)
        {
            sonuc = Convert.ToDouble(txtbox.Text);
            if (aktif2nd == false)
            {
                lbl.Text = "ln(" + sonuc + ")";
                sonuc = Math.Log(sonuc);
            }
            else
            {
                int s=Convert.ToInt16(sonuc);
                lbl.Text = "e^(" + s + ")";
                sonuc = 1;
                if (s>0)
                {
                    for (int i = 1; i <= s; i++)
                    {
                        sonuc *= Math.E;
                    }
                }
                else
                {
                    s *= -1;
                    for (int i = 1; i <= s; i++)
                    {
                        sonuc /= Math.E;
                    }
                }

            }
            sonuclandirildi = true;
            txtbox.Text = sonuc.ToString();
        }
        //----------------------------------------2. iþlev kullanýlan yerler----------------------------------------
        //

        //exp butonu
        private void btn_exp_Click(object sender, EventArgs e)
        {
            if (expBasildi == false)
            {
                expBasildi = true;
                sonuc = Convert.ToDouble(txtbox.Text);
                lbl.Text = sonuc + ",e+";
                txtbox.Text = "0";
                sonuclandirildi = true;
            }
        }
        //exp butonu

        //
        //---------------------------------------- 4 temel iþlem + 1 (+,-,/,*,(%)) ----------------------------------------
        private void btn_topla_Click(object sender, EventArgs e)
        {
            lbl.Text += txtbox.Text + "+";
            sonuclandirildi = true;
            dortIslem = true;
        }
        private void btn_cikar_Click(object sender, EventArgs e)
        {
            lbl.Text += txtbox.Text + "-";
            sonuclandirildi = true;
            dortIslem = true;
        }
        private void btn_carp_Click(object sender, EventArgs e)
        {
            lbl.Text += txtbox.Text + "*";
            sonuclandirildi = true;
            dortIslem = true;
        }
        private void btn_bol_Click(object sender, EventArgs e)
        {
            lbl.Text += txtbox.Text + "/";
            sonuclandirildi = true;
            dortIslem = true;
        }
        private void btn_mod_Click(object sender, EventArgs e)
        {
            lbl.Text += txtbox.Text + "%";
            sonuclandirildi = true;
            dortIslem = true;
        }
        //---------------------------------------- 4 temel iþlem + 1 (+,-,/,*,(%)) ----------------------------------------
        //

        //
        //---------------------------------------- tuþa basma ----------------------------------------
        private void keyDown_tusaBasma(object sender, KeyEventArgs e)
        {
            string basilanTus = e.KeyCode.ToString();
            basilanTus = basilanTus.Substring(basilanTus.Length-1,1);
            switch (basilanTus)
            {
                case "0":
                    btn_0_Click(new Button(), new EventArgs());
                    break;

                case "1":
                    btn_1_Click(new Button(), new EventArgs());
                    break;

                case "2":
                    btn_2_Click(new Button(), new EventArgs());
                    break;

                case "3":
                    btn_3_Click(new Button(), new EventArgs());
                    break;

                case "4":
                    btn_4_Click(new Button(), new EventArgs());
                    break;

                case "5":
                    btn_5_Click(new Button(), new EventArgs());
                    break;

                case "6":
                    btn_6_Click(new Button(), new EventArgs());
                    break;

                case "7":
                    btn_7_Click(new Button(), new EventArgs());
                    break;

                case "8":
                    btn_8_Click(new Button(), new EventArgs());
                    break;

                case "9":
                    btn_9_Click(new Button(), new EventArgs());
                    break;
            }

        }
        //---------------------------------------- tuþa basma ----------------------------------------
        //

    }
}