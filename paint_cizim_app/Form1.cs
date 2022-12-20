using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint_cizim_app
{
    public partial class Form1 : Form
    {

        Boolean b_dikdortgen = false;
        Boolean b_daire = false;
        Boolean b_ucgen = false;
        Boolean b_altıgen = false;
        Boolean b_sec = false;
        Boolean b_isMove_dik = false;
        Boolean b_isMove_altıgen = false;
        Boolean b_isMove_daire = false;
        Boolean b_isMove_ucgen = false;

        bool isDrow = false;
        int ilkX, ilkY, sonY, sonX, mesafeX, mesafeY = 0;
        int cAlani_panel_x;
        int cAlani_panel_y;
        int Sekil_sirasiDaire;
        int Sekil_sirasiDikdorgen;
        int Sekil_sirasiucgen;
        int Sekil_sirasiAltigen;



        Pen kalem = new Pen(Color.Black);
        Graphics cAlanı_panel;

        Islemler Islemler = new Islemler();

        List<Dikdortgen> dikdortgenler = new List<Dikdortgen>();
        List<Ucgen> ucgenler = new List<Ucgen>();
        List<Daire> daireler = new List<Daire>();
        List<Altigen> altigenler = new List<Altigen>();

        Dikdortgen dikdortgen = new Dikdortgen();
        Daire daire = new Daire();
        Ucgen ucgen = new Ucgen();
        Altigen altigen = new Altigen();



        Brush firca = new SolidBrush(Color.Black);
        int dikdorgenSayisi = 0;
        public Form1()
        {
            InitializeComponent();

            dikdortgen.FircaRenk = firca;
            daire.FircaRenk = firca;
            ucgen.FircaRenk = firca;
            altigen.FircaRenk = firca;

            for (int i = 0; i < 100; i++)
            {
                //dikdortgenler[i] = new Dikdortgen();

            }


        }
        protected override CreateParams CreateParams
        {                                               //titremeyi önlemek (daha hızlı çizim) için.
            get                                         // bütün form elemanları için double bufferring yapar.
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {


        }
        private void diktortgen_button_Click(object sender, EventArgs e)
        {
            dikdortgen = new Dikdortgen();

            diktortgen_button.FlatStyle = FlatStyle.Flat;
            diktortgen_button.FlatAppearance.BorderSize = 3;
            diktortgen_button.FlatAppearance.BorderColor = Color.DarkGray;

            daire_button.FlatAppearance.BorderColor = Color.Gray;
            daire_button.FlatAppearance.BorderSize = 2;

            altıgen_button.FlatAppearance.BorderColor = Color.Gray;
            altıgen_button.FlatAppearance.BorderSize = 2;

            ucgen_button.FlatAppearance.BorderColor = Color.Gray;
            ucgen_button.FlatAppearance.BorderSize = 2;


            b_altıgen = false;
            b_dikdortgen = true;
            b_daire = false;
            b_ucgen = false;
            b_sec = false;
        }
        private void daire_button_Click(object sender, EventArgs e)
        {
            daire = new Daire();

            daire_button.FlatStyle = FlatStyle.Flat;
            daire_button.FlatAppearance.BorderSize = 3;
            daire_button.FlatAppearance.BorderColor = Color.DarkGray;

            diktortgen_button.FlatAppearance.BorderColor = Color.Gray;
            diktortgen_button.FlatAppearance.BorderSize = 2;

            altıgen_button.FlatAppearance.BorderColor = Color.Gray;
            altıgen_button.FlatAppearance.BorderSize = 2;

            ucgen_button.FlatAppearance.BorderColor = Color.Gray;
            ucgen_button.FlatAppearance.BorderSize = 2;


            b_altıgen = false;
            b_dikdortgen = false;
            b_daire = true;
            b_ucgen = false;
            b_sec = false;
        }
        private void cizimAlanı_panel_MouseDown(object sender, MouseEventArgs e)
        {

            isDrow = true;
            ilkX = e.X;
            ilkY = e.Y;
            Vector2 p;
            Vector2[] shape = new Vector2[6];
            p.X = e.X; p.Y = e.Y;


            if (b_dikdortgen)
            {
                dikdortgen.X = ilkX;
                dikdortgen.Y = ilkY;
                cizimAlanı_panel.Refresh();
            }
            if (b_daire)
            {
                daire.X = ilkX;
                daire.Y = ilkY;
                daire.merkez_nokta.X = ilkX;
                daire.merkez_nokta.Y = ilkY;
            }
            if (b_ucgen)
            {
                ucgen.X = ilkX;
                ucgen.Y = ilkY;
                Invalidate();
            }
            if (b_altıgen)
            {
                for (int i = 0; i < 6; i++)
                {
                    shape[i].X = altigen.shape[i].X;
                    shape[i].Y = altigen.shape[i].Y;
                }
                altigen.X = ilkX;
                altigen.Y = ilkY;

                Invalidate();
            }
            if (b_sec)
            {
                for (int i = 0; i < dikdortgenler.Count; i++)
                {
                    Dikdortgen temp = dikdortgenler[i];
                    if (temp.dahil_mi(ilkX, ilkY))
                    {
                        dikdortgen = temp;
                        Sekil_sirasiDikdorgen = i;
                        Sekil_sirasiDaire = -1;
                        Sekil_sirasiucgen = -1;
                        Sekil_sirasiAltigen = -1;
                        Islemler.Sekil_onceki_X = dikdortgen.X;
                        Islemler.Sekil_onceki_Y = dikdortgen.Y;
                        
                        b_isMove_altıgen = false;
                        b_isMove_daire = false;
                        b_isMove_ucgen = false;
                        b_isMove_dik = true;

                        diktortgen_button.FlatStyle = FlatStyle.Flat;
                        diktortgen_button.FlatAppearance.BorderSize = 3;
                        diktortgen_button.FlatAppearance.BorderColor = Color.DarkGray;

                        daire_button.FlatAppearance.BorderColor = Color.Gray;
                        daire_button.FlatAppearance.BorderSize = 2;

                        altıgen_button.FlatAppearance.BorderColor = Color.Gray;
                        altıgen_button.FlatAppearance.BorderSize = 2;

                        ucgen_button.FlatAppearance.BorderColor = Color.Gray;
                        ucgen_button.FlatAppearance.BorderSize = 2;

                        sekilRenk_bul(dikdortgen.FircaRenk);
                        
                        Console.WriteLine("dikdörtgen içinde");
                    }
                }
                for (int i = 0;i<altigenler.Count;i++)
                {
                    Altigen altigen_sekil = altigenler[i];
                    if (altigen_sekil.PointInPolygon(p, altigen_sekil.shape))
                    {

                        altigen = altigen_sekil;
                        Sekil_sirasiDikdorgen = -1;
                        Sekil_sirasiDaire = -1;
                        Sekil_sirasiucgen = -1;
                        Sekil_sirasiAltigen = i;
                        Islemler.Sekil_onceki_X = altigen.X;
                        Islemler.Sekil_onceki_Y = altigen.Y;

                        b_isMove_altıgen = true;
                        b_isMove_daire = false;
                        b_isMove_ucgen = false;
                        b_isMove_dik = false;
                        sekilRenk_bul(altigen.FircaRenk);

                        altıgen_button.FlatStyle = FlatStyle.Flat;
                        altıgen_button.FlatAppearance.BorderSize = 3;
                        altıgen_button.FlatAppearance.BorderColor = Color.DarkGray;

                        diktortgen_button.FlatAppearance.BorderColor = Color.Gray;
                        diktortgen_button.FlatAppearance.BorderSize = 2;

                        daire_button.FlatAppearance.BorderColor = Color.Gray;
                        daire_button.FlatAppearance.BorderSize = 2;

                        ucgen_button.FlatAppearance.BorderColor = Color.Gray;
                        ucgen_button.FlatAppearance.BorderSize = 2;
                        Console.WriteLine("altıgen içinde");
                    }
                }
                for (int i = 0; i < daireler.Count; i++)
                {
                    Daire temp = (Daire)daireler[i];
                    if (temp.dahil_mi(ilkX, ilkY))
                    {
                        Sekil_sirasiDaire = i;
                        Sekil_sirasiDikdorgen = -1;
                        Sekil_sirasiucgen = -1;
                        Sekil_sirasiAltigen = -1;
                        daire = temp;
                        Islemler.Sekil_onceki_X = daire.X;
                        Islemler.Sekil_onceki_Y = daire.Y;
                        b_isMove_daire = true;
                        b_isMove_ucgen = false;
                        b_isMove_altıgen = false;
                        b_isMove_dik = false;

                        sekilRenk_bul(daire.FircaRenk);

                        daire_button.FlatStyle = FlatStyle.Flat;
                        daire_button.FlatAppearance.BorderSize = 3;
                        daire_button.FlatAppearance.BorderColor = Color.DarkGray;

                        diktortgen_button.FlatAppearance.BorderColor = Color.Gray;
                        diktortgen_button.FlatAppearance.BorderSize = 2;

                        altıgen_button.FlatAppearance.BorderColor = Color.Gray;
                        altıgen_button.FlatAppearance.BorderSize = 2;

                        ucgen_button.FlatAppearance.BorderColor = Color.Gray;
                        ucgen_button.FlatAppearance.BorderSize = 2;
                        Console.WriteLine("daire içinde");
                    }
                }
                for (int i = 0; i < ucgenler.Count; i++)
                {
                    Ucgen temp = (Ucgen)ucgenler[i];
                    if (temp.Dahil_mi(ilkX, ilkY))
                    {
                        Sekil_sirasiDaire = -1;
                        Sekil_sirasiDikdorgen = -1;
                        Sekil_sirasiucgen = i;
                        Sekil_sirasiAltigen = -1;
                        ucgen = temp;
                        Islemler.Sekil_onceki_X = ucgen.X;
                        Islemler.Sekil_onceki_Y = ucgen.Y;

                        b_isMove_ucgen = true;
                        b_isMove_daire = false;
                        b_isMove_altıgen = false;
                        b_isMove_dik = false;

                        sekilRenk_bul(ucgen.FircaRenk);

                        ucgen_button.FlatStyle = FlatStyle.Flat;
                        ucgen_button.FlatAppearance.BorderSize = 3;
                        ucgen_button.FlatAppearance.BorderColor = Color.DarkGray;

                        diktortgen_button.FlatAppearance.BorderColor = Color.Gray;
                        diktortgen_button.FlatAppearance.BorderSize = 2;

                        daire_button.FlatAppearance.BorderColor = Color.Gray;
                        daire_button.FlatAppearance.BorderSize = 2;

                        altıgen_button.FlatAppearance.BorderColor = Color.Gray;
                        altıgen_button.FlatAppearance.BorderSize = 2;
                        Console.WriteLine("ucgen içinde");
                    }
                }
            }
        }
        
        private void cizimAlanı_panel_MouseMove(object sender, MouseEventArgs e)
        {

            //Point p = e.Location;
            label1.Text = "Mouse Location (X Y):" + e.X.ToString() + " " + e.Y.ToString();//mouse lokasyonunu belirtir.
            mesafeX = e.X - ilkX;
            mesafeY = e.Y - ilkY;
            if (isDrow && b_dikdortgen)
            {
                if (dikdortgen.X > 0 && dikdortgen.Y > 0 && (dikdortgen.X + dikdortgen.Width) < cizimAlanı_panel.Size.Width
                                                         && (dikdortgen.Y + dikdortgen.Height) < cizimAlanı_panel.Size.Height)
                {

                    dikdortgen.X = ilkX - mesafeX;
                    dikdortgen.Y = ilkY - mesafeY;
                    dikdortgen.Width = 2 * mesafeX + mesafeX * (7 / 8);//karenin sol üsttende genişlemesini absorbe edebilmek için 2 ile çarp. 
                    dikdortgen.Height = 2 * mesafeY;

                }

                else if ((dikdortgen.X + dikdortgen.Width) >= cizimAlanı_panel.Size.Width)
                {
                    //-------  soldan ve yukaridan asim olursa  -------//

                    if (dikdortgen.X < 0)
                    {
                        dikdortgen.X = 0;
                        sonX = mesafeX; sonY = mesafeY;
                        dikdortgen.Width = sonX;
                        dikdortgen.Height = sonY;
                    }

                    if (dikdortgen.Y < 0)
                    {
                        dikdortgen.Y = 0;
                        sonX = mesafeX; sonY = mesafeY;
                        dikdortgen.Width = sonX;
                        dikdortgen.Height = sonY;
                    }
                    // -------sagdan ve asagıdan asim olursa  -------//
                    if ((dikdortgen.X + dikdortgen.Width) >= cizimAlanı_panel.Size.Width)
                    {
                        dikdortgen.X = cizimAlanı_panel.Size.Width - dikdortgen.Width;

                    }
                    if ((dikdortgen.Y + dikdortgen.Height) >= cizimAlanı_panel.Height)
                    {
                        dikdortgen.Y = cizimAlanı_panel.Size.Height - dikdortgen.Height;
                    }

                }

                cizimAlanı_panel.Refresh();
            }
            if (isDrow && b_daire)
            {
                if ((mesafeX > 0) && (mesafeY > 0) && (ilkX + daire.Yaricap +2 < cizimAlanı_panel.Size.Width) && (daire.Yaricap + ilkY < cizimAlanı_panel.Size.Height) 
                    && (daire.X != 0) && (daire.Y != 0) && ilkX+mesafeX< cizimAlanı_panel.Size.Width && ilkY + mesafeY < cizimAlanı_panel.Size.Height)
                {
                    daire.X = ilkX - mesafeX;
                    daire.Y = ilkY - mesafeY;
                }
                if (ilkX - daire.Yaricap < 0 && daire.Y != 0 && daire.Yaricap + ilkX < cizimAlanı_panel.Size.Width && mesafeY + ilkY < cizimAlanı_panel.Size.Height)
                {
                    daire.X = 0;
                }
                if (ilkY - daire.Yaricap < 0 && daire.X != 0 && daire.Yaricap + ilkX < cizimAlanı_panel.Size.Width && mesafeY + ilkY < cizimAlanı_panel.Size.Height)
                {
                    daire.Y = 0;
                }
                if (daire.Yaricap + ilkX >= cizimAlanı_panel.Size.Width || daire.Yaricap + ilkY >= cizimAlanı_panel.Size.Height)
                {
                    if (daire.Yaricap + ilkX >= cizimAlanı_panel.Size.Width)
                    {
                        mesafeX  = cizimAlanı_panel.Size.Width - ilkX;
                    }
                    if (daire.Yaricap + ilkY >= cizimAlanı_panel.Size.Height)
                    {
                        mesafeY = cizimAlanı_panel.Size.Height - ilkY;
                    }
                }
                else
                {
                    if (mesafeY >= 0 && mesafeX >= 0 && daire.Yaricap + ilkX < cizimAlanı_panel.Size.Width && daire.Yaricap + ilkY < cizimAlanı_panel.Size.Height && daire.X != 0 && daire.Y != 0)
                    {
                        daire.Yaricap = (mesafeY + mesafeX) / 2 + 2;
                    }
                }

                cizimAlanı_panel.Refresh();
            }
            if (isDrow && b_ucgen)
            {
                /*if (ilkX + mesafeX > cizimAlanı_panel.Size.Width)
                {
                    mesafeX = cizimAlanı_panel.Size.Width - ilkX;
                }
                if (ilkY + mesafeY > cizimAlanı_panel.Size.Height)
                {
                    mesafeY = cizimAlanı_panel.Size.Height - ilkY;
                }*/
                ucgen.CIZIM_ALANIWIDTH = cizimAlanı_panel.Size.Width;
                ucgen.CIZIM_ALANIHEIGHT = cizimAlanı_panel.Size.Height;
                ucgen.MESAFEX = mesafeX;
                ucgen.MESAFEY = mesafeY;
                cizimAlanı_panel.Refresh();
            }
            if (isDrow && b_altıgen)
            {
                if (altigen.shape[3].X >= 0 && altigen.shape[4].Y >= 0 && altigen.shape[0].X <= cizimAlanı_panel.Width && altigen.shape[1].Y <= cizimAlanı_panel.Height)
                {
                    altigen.MESAFEX = mesafeX;
                    altigen.MESAFEY = mesafeY;
                }
                
                cizimAlanı_panel.Refresh();
            }
            if (b_sec && isDrow)
            {
                if (b_isMove_dik)
                {

                    Islemler.tasima(dikdortgen.X, dikdortgen.Y, mesafeX, mesafeY);

                    dikdortgen.X = Islemler.X;
                    dikdortgen.Y = Islemler.Y;
                    if (dikdortgen.X < 0)
                    {
                        dikdortgen.X = 0;
                    }
                    if (dikdortgen.Y < 0)
                    {
                        dikdortgen.Y = 0;
                    }
                    if (dikdortgen.X + dikdortgen.Width >= cizimAlanı_panel.Size.Width)
                    {
                        dikdortgen.X = cizimAlanı_panel.Size.Width - dikdortgen.Width;
                    }
                    if (dikdortgen.Y + dikdortgen.Height >= cizimAlanı_panel.Size.Height)
                    {
                        dikdortgen.Y = cizimAlanı_panel.Size.Height - dikdortgen.Height;
                    }
                    //dikdortgenler[i].Ciz(cAlanı_panel);
                    Console.WriteLine("Dikdortgenimiz-X : " + Islemler.Sekil_onceki_X);
                    cizimAlanı_panel.Refresh();
                }

                if (b_isMove_altıgen)
                {
                    Islemler.tasima(altigen.X, altigen.Y, mesafeX, mesafeY);

                    altigen.X = Islemler.X;
                    altigen.Y = Islemler.Y;
                    var altigenYaricap = (altigen.MESAFEX + altigen.MESAFEY) / 2;
                    if (altigen.X - (altigenYaricap) < 0)
                    {
                        altigen.X = altigenYaricap;
                    }
                    if (altigen.Y - (altigenYaricap) < 0)
                    {
                        altigen.Y =(int) (altigenYaricap * Math.Sin(1 * 60 * Math.PI / 180f));
                    }
                    if (altigen.X + altigenYaricap >= cizimAlanı_panel.Size.Width)
                    {
                        altigen.X = cizimAlanı_panel.Size.Width - altigenYaricap;
                    }
                    if (altigen.Y + (altigenYaricap) >= cizimAlanı_panel.Size.Height)
                    {
                        altigen.Y = cizimAlanı_panel.Size.Height - (int)(altigenYaricap * Math.Sin(2 * 60 * Math.PI / 180f));
                    }
                    cizimAlanı_panel.Refresh();
                }

                if (b_isMove_daire)
                {
                    Islemler.tasima(daire.X, daire.Y, mesafeX, mesafeY);

                    daire.X = Islemler.X;
                    daire.Y = Islemler.Y;
                    if (daire.X <= 0)
                    {
                        daire.X = 0;
                    }

                    if (daire.Y <= 0)
                    {
                        daire.Y = 0;
                    }
                    if (daire.Y + 2 * (daire.Yaricap) >= cizimAlanı_panel.Size.Height)
                    {
                        daire.Y = cizimAlanı_panel.Size.Height - 2 * (int)(daire.Yaricap);
                    }
                    if (daire.X + 2 * (daire.Yaricap) >= cizimAlanı_panel.Size.Width)
                    {
                        daire.X = cizimAlanı_panel.Size.Width - 2 * (int)(daire.Yaricap); ;
                    }
                    cizimAlanı_panel.Refresh();
                }
                if (b_isMove_ucgen)
                {
                    Islemler.tasima(ucgen.X, ucgen.Y, mesafeX, mesafeY);

                    ucgen.X = Islemler.X;
                    ucgen.Y = Islemler.Y;
                    if (ucgen.X - ucgen.MESAFEX <= 0)
                    {
                        ucgen.X = ucgen.MESAFEX;
                    }

                    if (ucgen.Y - 2 * ucgen.MESAFEY <= 0)
                    {
                        ucgen.Y = 2 * ucgen.MESAFEY;
                    }
                    if (ucgen.Y + ucgen.MESAFEY > cizimAlanı_panel.Size.Height)
                    {
                        ucgen.Y = cizimAlanı_panel.Size.Height - ucgen.MESAFEY;
                    }
                    if (ucgen.X + ucgen.MESAFEX > cizimAlanı_panel.Size.Width)
                    {
                        ucgen.X = cizimAlanı_panel.Size.Width - ucgen.MESAFEX - 3;
                    }
                    cizimAlanı_panel.Refresh();
                }
            }

        }
        private void cizimAlanı_panel_Paint(object sender, PaintEventArgs e)
        {
            cAlani_panel_x = cizimAlanı_panel.Size.Width;
            cAlani_panel_y = cizimAlanı_panel.Size.Height;
            label2.Text = "X :" + cAlani_panel_x + "  Y :" + cAlani_panel_y + " daire x:" + daire.X.ToString() + " daire y:" + daire.Y.ToString() + " mesafeX: " + mesafeX + " mesafeY: " + mesafeY + "ilkx :" + ilkX.ToString()+"ilkY :"+ilkY.ToString();

            if (b_dikdortgen)
            {
                dikdortgen.FircaRenk = firca;
            }
            else if (b_daire)
            {
                daire.FircaRenk = firca;
            }
            else if (b_altıgen)
            {
                altigen.FircaRenk = firca;
            }
            else if (b_ucgen)
            {
                ucgen.FircaRenk = firca;
            }

            //cAlanı_panel = cizimAlanı_panel.CreateGraphics(); //Graphics for panel
            cAlanı_panel = e.Graphics;
            /* if (dikdorgenSayisi >= 0)
             {
                 /*for (int i = 0; i < dikdorgenSayisi; i++)
                 {
                     dikdortgenler[i].Ciz(cAlanı_panel);
                     /*if (Which_color == 1)
                     {
                         //sekiller[i].firca_renk = firca1;
                         //sekiller[i].Ciz(cAlanı_panel, sekiller[i].firca_renk);
                         dikdortgenler[i].Ciz(cAlanı_panel);
                         //dikdortgenler[i].Firca_Renk = firca1;

                     }
                     else if (Which_color == 2)
                     {
                         // sekiller[i].firca_renk = firca2;
                         //sekiller[i].Ciz(cAlanı_panel, sekiller[i].firca_renk);
                         //dikdortgenler[i].Firca_Renk = firca2;
                         dikdortgenler[i].Ciz(cAlanı_panel);
                     }
                     else if (Which_color == 3)
                     {
                         //dikdortgenler[i].Firca_Renk = firca3;
                         dikdortgenler[i].Ciz(cAlanı_panel);
                     }

                 }
             }*/
            foreach (Dikdortgen dik_dortgen in dikdortgenler)
            {
                dik_dortgen.Ciz(cAlanı_panel);
            }
            foreach (Ucgen ucgen in ucgenler)
            {
                ucgen.Ciz(cAlanı_panel);
            }


            if (b_dikdortgen && isDrow)
            {
                dikdortgen.Ciz(cAlanı_panel);
                /*for (int i = 0; i < dikdorgenSayisi; i++)
                {
                    if (Which_color == 1)
                    {
                        //sekiller[i].firca_renk = firca1;
                        //sekiller[i].Ciz(cAlanı_panel, sekiller[i].firca_renk);
                        dikdortgenler[i].Ciz(cAlanı_panel);
                        //dikdortgenler[i].Firca_Renk = firca1;

                    }
                    else if (Which_color == 2)
                    {
                        // sekiller[i].firca_renk = firca2;
                        //sekiller[i].Ciz(cAlanı_panel, sekiller[i].firca_renk);
                        //dikdortgenler[i].Firca_Renk = firca2;
                        dikdortgenler[i].Ciz(cAlanı_panel);
                    }
                    else if (Which_color == 3)
                    {
                        //dikdortgenler[i].Firca_Renk = firca3;
                        dikdortgenler[i].Ciz(cAlanı_panel);
                    }
                    //dikdortgenler[i].Ciz(cAlanı_panel,firca1);
                }*/
            }

            if (b_daire && isDrow)
            {
                daire.Ciz(cAlanı_panel);

            }
            foreach (Sekil sekil in daireler)
            {
                sekil.Ciz(cAlanı_panel);
            }
            if (b_ucgen && isDrow)
            {
                ucgen.Ciz(cAlanı_panel);

            }
            if (b_altıgen && isDrow)
            {
                altigen.Ciz(cAlanı_panel);

            }
            foreach (Sekil altigen_sekil in altigenler)
            {
                altigen_sekil.Ciz(cAlanı_panel);
            }


        }
        private void kırmızıRenk_button_Click(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Red);
            Renk_sec("kirmizi");
            Renk_ver();
        }
        private void maviRenk_button_Click(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Blue);
            Renk_sec("mavi");
            Renk_ver();
        }
        private void yesilRenk_button_Click(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Green);
            Renk_sec("yesil");
            Renk_ver();
        }
        private void secim_button_Click(object sender, EventArgs e)
        {
            b_sec = true;
            b_dikdortgen = false;
            b_daire = false;
            b_ucgen = false;
            b_altıgen = false;

            secim_button.FlatStyle = FlatStyle.Flat;
            secim_button.FlatAppearance.BorderSize = 3;
            secim_button.FlatAppearance.BorderColor = Color.DarkGray;

            sil_button.FlatAppearance.BorderColor = Color.Gray;
            sil_button.FlatAppearance.BorderSize = 2;

            temizSayfa_button.FlatAppearance.BorderColor = Color.Gray;
            temizSayfa_button.FlatAppearance.BorderSize = 2;
        }
        private void sil_button_Click(object sender, EventArgs e)
        {
            if (b_sec)
            {
                altigenler.Remove(altigen);
                daireler.Remove(daire);
                dikdortgenler.Remove(dikdortgen);
                ucgenler.Remove(ucgen);
                if (true)
                {

                    /*for (int i = 0; i < sekiller.Count; i++)
                    {
                        Daire temp = (Daire)sekiller[i];
                        if (temp.dahil_mi(sonX, sonY))
                        {
                            sekiller.Remove(temp);
                            temp.X = 0;
                            temp.Y = 0;
                            temp.Yaricap = 0;
                            cizimAlanı_panel.Refresh();
                        }
                    }*/
                }
            }

            sil_button.FlatStyle = FlatStyle.Flat;
            sil_button.FlatAppearance.BorderSize = 3;
            sil_button.FlatAppearance.BorderColor = Color.DarkGray;

            secim_button.FlatAppearance.BorderColor = Color.Gray;
            secim_button.FlatAppearance.BorderSize = 2;

            temizSayfa_button.FlatAppearance.BorderColor = Color.Gray;
            temizSayfa_button.FlatAppearance.BorderSize = 2;
            b_sec = false;
            b_dikdortgen = false;
            b_daire = false;
            b_ucgen = false;
            b_altıgen = false;
            cizimAlanı_panel.Refresh();
        }
        private void temizSayfa_button_Click(object sender, EventArgs e)
        {

            dikdorgenSayisi = 0;
            cizimAlanı_panel.Refresh();

            dikdortgenler.Clear();
            daireler.Clear();
            ucgenler.Clear();
            altigenler.Clear();

            b_sec = false;
            b_dikdortgen = false;
            b_daire = false;
            b_ucgen = false;
            b_altıgen = false;
            cizimAlanı_panel.Refresh();

            temizSayfa_button.FlatStyle = FlatStyle.Flat;
            temizSayfa_button.FlatAppearance.BorderSize = 3;
            temizSayfa_button.FlatAppearance.BorderColor = Color.DarkGray;

            secim_button.FlatAppearance.BorderColor = Color.Gray;
            secim_button.FlatAppearance.BorderSize = 2;

            sil_button.FlatAppearance.BorderColor = Color.Gray;
            sil_button.FlatAppearance.BorderSize = 2;
        }
        private void dosyaAc_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = @"Metin dosyaları (*.txt)|*.txt|Tüm dosyalar (*.*)|*.*";
            DialogResult result = dialog.ShowDialog();
            IEnumerable<String> objeler = new List<String>();
            if (result == DialogResult.OK)
                objeler = File.ReadLines(dialog.FileName);
            foreach (String obje in objeler)
            {
                string[] temp = obje.Split(' ');
                if (temp[0] == "Daire")
                {
                    daire = new Daire();
                    daire.X = Convert.ToInt32(temp[1]);
                    daire.Y = Convert.ToInt32(temp[2]);
                    daire.Yaricap = Convert.ToInt32(temp[3]);
                    daire.merkez_nokta = new Point(Convert.ToInt32(temp[4]), Convert.ToInt32(temp[5]));
                    daire.FircaRenk = new SolidBrush(Color.FromArgb(Convert.ToInt32(temp[6])));
                    daireler.Add(daire);
                    daire = new Daire();
                }
                else if (temp[0] == "Dikdortgen")
                {
                    dikdortgen = new Dikdortgen();
                    dikdortgen.X = Convert.ToInt32(temp[1]);
                    dikdortgen.Y = Convert.ToInt32(temp[2]);
                    dikdortgen.Width = Convert.ToInt32(temp[3]);
                    dikdortgen.Height = Convert.ToInt32(temp[4]);
                    dikdortgen.FircaRenk = new SolidBrush(Color.FromArgb(Convert.ToInt32(temp[5])));
                    dikdortgenler.Add(dikdortgen);
                    dikdortgen = new Dikdortgen();
                }
                else if (temp[0] == "Ucgen")
                {
                    ucgen = new Ucgen();
                    ucgen.X = Convert.ToInt32(temp[1]);
                    ucgen.Y = Convert.ToInt32(temp[2]);
                    ucgen.MESAFEX = Convert.ToInt32(temp[3]);
                    ucgen.MESAFEY = Convert.ToInt32(temp[4]);
                    ucgen.CIZIM_ALANIWIDTH = Convert.ToInt32(temp[5]);
                    ucgen.CIZIM_ALANIHEIGHT = Convert.ToInt32(temp[6]);
                    ucgen.FircaRenk = new SolidBrush(Color.FromArgb(Convert.ToInt32(temp[7])));
                    ucgenler.Add(ucgen);
                    ucgen = new Ucgen();
                }
                else if (temp[0] == "Altigen")
                {
                    altigen = new Altigen();
                    altigen.X = Convert.ToInt32(temp[1]);
                    altigen.Y = Convert.ToInt32(temp[2]);
                    altigen.MESAFEX = Convert.ToInt32(temp[3]);
                    altigen.MESAFEY = Convert.ToInt32(temp[4]);
                    altigen.FircaRenk = new SolidBrush(Color.FromArgb(Convert.ToInt32(temp[5])));
                    altigenler.Add(altigen);
                    altigen = new Altigen();
                }
                cizimAlanı_panel.Refresh();
            }
        }
        private void turuncuRenkbutton_Click(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Orange);
            Renk_sec("turuncu");
            Renk_ver();

        }
        private void siyahRenk_button_Click(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Black);
            Renk_sec("Black");
            Renk_ver();

        }
        private void sarıRenk_button_Click(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Yellow);
            Renk_sec("sari");
            Renk_ver();
        }
        private void morRenk_button_Click(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Purple);
            Renk_sec("mor");
            Renk_ver();
        }
        private void kahveRenk_button_Click(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Brown);
            Renk_sec("kahve");
            Renk_ver();
        }
        private void beyazRenk_button_Click(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.White);
            Renk_sec("beyaz");
            Renk_ver();
        }
        private void Kaydet_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Filter = @"Metin dosyaları (*.txt)|*.txt|Tüm dosyalar (*.*)|*.*";
            kaydet.InitialDirectory = "D://";
            if (kaydet.ShowDialog() == DialogResult.OK)
            {
                StreamWriter dosya = new StreamWriter(kaydet.FileName);
                foreach (Sekil item in daireler)
                {
                    dosya.WriteLine(item);
                }
                foreach (Sekil item in dikdortgenler)
                {
                    dosya.WriteLine(item);
                }
                foreach (Sekil item in ucgenler)
                {
                    dosya.WriteLine(item);
                }
                foreach (Sekil item in altigenler)
                {
                    dosya.WriteLine(item);
                }
                dosya.Flush();
                dosya.Close();
            }
        }
        private void cizimAlanı_panel_MouseUp(object sender, MouseEventArgs e)
        {
            sonX = e.X;
            sonY = e.Y;
            mesafeX = e.X - ilkX;
            mesafeY = e.Y - ilkY;
            if (b_daire)
            {
                daireler.Add(daire);
                daire = new Daire();
                daire.FircaRenk = firca;
            }
            if (b_isMove_daire)
            {
                daire.merkez_nokta.X = (int)(daire.X + daire.Yaricap);
                daire.merkez_nokta.Y = (int)(daire.Y + daire.Yaricap);
                daireler[Sekil_sirasiDaire] = daire;
            }
            if (b_dikdortgen)
            {
                dikdortgenler.Add(dikdortgen);
                dikdortgen = new Dikdortgen();
                dikdortgen.FircaRenk = firca;
            }
            if (b_ucgen)
            {
                ucgenler.Add(ucgen);
                ucgen = new Ucgen();
            }
            if (b_altıgen)
            {
                altigenler.Add(altigen);
                altigen = new Altigen();
            }

            b_isMove_dik = false;
            b_isMove_daire = false;
            b_isMove_altıgen = false;
            isDrow = false;
            cizimAlanı_panel.Refresh();
        }
        private void ucgen_button_Click(object sender, EventArgs e)
        {
            ucgen = new Ucgen();

            ucgen_button.FlatStyle = FlatStyle.Flat;
            ucgen_button.FlatAppearance.BorderSize = 3;
            ucgen_button.FlatAppearance.BorderColor = Color.DarkGray;
            diktortgen_button.FlatAppearance.BorderColor = Color.Gray;
            diktortgen_button.FlatAppearance.BorderSize = 2;
            daire_button.FlatAppearance.BorderColor = Color.Gray;
            daire_button.FlatAppearance.BorderSize = 2;
            altıgen_button.FlatAppearance.BorderColor = Color.Gray;
            altıgen_button.FlatAppearance.BorderSize = 2;


            b_altıgen = false;
            b_dikdortgen = false;
            b_daire = false;
            b_ucgen = true;
            b_sec = false;
        }
        private void altıgen_button_Click(object sender, EventArgs e)
        {
            altigen = new Altigen();

            altıgen_button.FlatStyle = FlatStyle.Flat;
            altıgen_button.FlatAppearance.BorderSize = 3;
            altıgen_button.FlatAppearance.BorderColor = Color.DarkGray;
            diktortgen_button.FlatAppearance.BorderColor = Color.Gray;
            diktortgen_button.FlatAppearance.BorderSize = 2;
            daire_button.FlatAppearance.BorderColor = Color.Gray;
            daire_button.FlatAppearance.BorderSize = 2;
            ucgen_button.FlatAppearance.BorderColor = Color.Gray;
            ucgen_button.FlatAppearance.BorderSize = 2;


            b_altıgen = true;
            b_dikdortgen = false;
            b_daire = false;
            b_ucgen = false;
            b_sec = false;
        }
        public void Renk_sec(string renk)
        {
            if (renk == "Black")
            {
                siyahRenk_button.FlatStyle = FlatStyle.Flat;
                siyahRenk_button.FlatAppearance.BorderSize = 3;
                siyahRenk_button.FlatAppearance.BorderColor = Color.DarkGray;

                turuncuRenkbutton.FlatAppearance.BorderColor = Color.Gray;
                turuncuRenkbutton.FlatAppearance.BorderSize = 1;

                sarıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                sarıRenk_button.FlatAppearance.BorderSize = 1;

                morRenk_button.FlatAppearance.BorderColor = Color.Gray;
                morRenk_button.FlatAppearance.BorderSize = 1;

                kahveRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kahveRenk_button.FlatAppearance.BorderSize = 1;

                beyazRenk_button.FlatAppearance.BorderColor = Color.Gray;
                beyazRenk_button.FlatAppearance.BorderSize = 1;

                kırmızıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kırmızıRenk_button.FlatAppearance.BorderSize = 1;

                maviRenk_button.FlatAppearance.BorderColor = Color.Gray;
                maviRenk_button.FlatAppearance.BorderSize = 1;

                yesilRenk_button.FlatAppearance.BorderColor = Color.Gray;
                yesilRenk_button.FlatAppearance.BorderSize = 1;
            }
            else if (renk == "kirmizi")
            {
                kırmızıRenk_button.FlatStyle = FlatStyle.Flat;
                kırmızıRenk_button.FlatAppearance.BorderSize = 3;
                kırmızıRenk_button.FlatAppearance.BorderColor = Color.DarkGray;

                turuncuRenkbutton.FlatAppearance.BorderColor = Color.Gray;
                turuncuRenkbutton.FlatAppearance.BorderSize = 2;

                siyahRenk_button.FlatAppearance.BorderColor = Color.Gray;
                siyahRenk_button.FlatAppearance.BorderSize = 2;

                sarıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                sarıRenk_button.FlatAppearance.BorderSize = 2;

                morRenk_button.FlatAppearance.BorderColor = Color.Gray;
                morRenk_button.FlatAppearance.BorderSize = 2;

                kahveRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kahveRenk_button.FlatAppearance.BorderSize = 2;

                beyazRenk_button.FlatAppearance.BorderColor = Color.Gray;
                beyazRenk_button.FlatAppearance.BorderSize = 2;

                maviRenk_button.FlatAppearance.BorderColor = Color.Gray;
                maviRenk_button.FlatAppearance.BorderSize = 2;

                yesilRenk_button.FlatAppearance.BorderColor = Color.Gray;
                yesilRenk_button.FlatAppearance.BorderSize = 2;
            }
            else if (renk == "mavi")
            {
                maviRenk_button.FlatStyle = FlatStyle.Flat;
                maviRenk_button.FlatAppearance.BorderSize = 3;
                maviRenk_button.FlatAppearance.BorderColor = Color.DarkGray;

                turuncuRenkbutton.FlatAppearance.BorderColor = Color.Gray;
                turuncuRenkbutton.FlatAppearance.BorderSize = 2;

                siyahRenk_button.FlatAppearance.BorderColor = Color.Gray;
                siyahRenk_button.FlatAppearance.BorderSize = 2;

                sarıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                sarıRenk_button.FlatAppearance.BorderSize = 2;

                morRenk_button.FlatAppearance.BorderColor = Color.Gray;
                morRenk_button.FlatAppearance.BorderSize = 2;

                kahveRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kahveRenk_button.FlatAppearance.BorderSize = 2;

                beyazRenk_button.FlatAppearance.BorderColor = Color.Gray;
                beyazRenk_button.FlatAppearance.BorderSize = 2;

                kırmızıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kırmızıRenk_button.FlatAppearance.BorderSize = 2;

                yesilRenk_button.FlatAppearance.BorderColor = Color.Gray;
                yesilRenk_button.FlatAppearance.BorderSize = 2;
            }
            else if (renk == "yesil")
            {
                yesilRenk_button.FlatStyle = FlatStyle.Flat;
                yesilRenk_button.FlatAppearance.BorderSize = 3;
                yesilRenk_button.FlatAppearance.BorderColor = Color.DarkGray;

                turuncuRenkbutton.FlatAppearance.BorderColor = Color.Gray;
                turuncuRenkbutton.FlatAppearance.BorderSize = 2;

                siyahRenk_button.FlatAppearance.BorderColor = Color.Gray;
                siyahRenk_button.FlatAppearance.BorderSize = 2;

                sarıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                sarıRenk_button.FlatAppearance.BorderSize = 2;

                morRenk_button.FlatAppearance.BorderColor = Color.Gray;
                morRenk_button.FlatAppearance.BorderSize = 2;

                kahveRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kahveRenk_button.FlatAppearance.BorderSize = 2;

                beyazRenk_button.FlatAppearance.BorderColor = Color.Gray;
                beyazRenk_button.FlatAppearance.BorderSize = 2;

                kırmızıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kırmızıRenk_button.FlatAppearance.BorderSize = 2;

                maviRenk_button.FlatAppearance.BorderColor = Color.Gray;
                maviRenk_button.FlatAppearance.BorderSize = 2;
            }
            
            else if (renk == "turuncu")
            {
                turuncuRenkbutton.FlatStyle = FlatStyle.Flat;
                turuncuRenkbutton.FlatAppearance.BorderSize = 3;
                turuncuRenkbutton.FlatAppearance.BorderColor = Color.DarkGray;

                siyahRenk_button.FlatAppearance.BorderColor = Color.Gray;
                siyahRenk_button.FlatAppearance.BorderSize = 2;

                sarıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                sarıRenk_button.FlatAppearance.BorderSize = 2;

                morRenk_button.FlatAppearance.BorderColor = Color.Gray;
                morRenk_button.FlatAppearance.BorderSize = 2;

                kahveRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kahveRenk_button.FlatAppearance.BorderSize = 2;

                beyazRenk_button.FlatAppearance.BorderColor = Color.Gray;
                beyazRenk_button.FlatAppearance.BorderSize = 2;

                kırmızıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kırmızıRenk_button.FlatAppearance.BorderSize = 2;

                maviRenk_button.FlatAppearance.BorderColor = Color.Gray;
                maviRenk_button.FlatAppearance.BorderSize = 2;

                yesilRenk_button.FlatAppearance.BorderColor = Color.Gray;
                yesilRenk_button.FlatAppearance.BorderSize = 2;
            }
            else if (renk == "sari")
            {
                sarıRenk_button.FlatStyle = FlatStyle.Flat;
                sarıRenk_button.FlatAppearance.BorderSize = 3;
                sarıRenk_button.FlatAppearance.BorderColor = Color.DarkGray;

                turuncuRenkbutton.FlatAppearance.BorderColor = Color.Gray;
                turuncuRenkbutton.FlatAppearance.BorderSize = 2;

                siyahRenk_button.FlatAppearance.BorderColor = Color.Gray;
                siyahRenk_button.FlatAppearance.BorderSize = 2;

                morRenk_button.FlatAppearance.BorderColor = Color.Gray;
                morRenk_button.FlatAppearance.BorderSize = 2;

                kahveRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kahveRenk_button.FlatAppearance.BorderSize = 2;

                beyazRenk_button.FlatAppearance.BorderColor = Color.Gray;
                beyazRenk_button.FlatAppearance.BorderSize = 2;

                kırmızıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kırmızıRenk_button.FlatAppearance.BorderSize = 2;

                maviRenk_button.FlatAppearance.BorderColor = Color.Gray;
                maviRenk_button.FlatAppearance.BorderSize = 2;

                yesilRenk_button.FlatAppearance.BorderColor = Color.Gray;
                yesilRenk_button.FlatAppearance.BorderSize = 2;
            }
            else if (renk == "mor")
            {
                morRenk_button.FlatStyle = FlatStyle.Flat;
                morRenk_button.FlatAppearance.BorderSize = 3;
                morRenk_button.FlatAppearance.BorderColor = Color.DarkGray;

                turuncuRenkbutton.FlatAppearance.BorderColor = Color.Gray;
                turuncuRenkbutton.FlatAppearance.BorderSize = 2;

                siyahRenk_button.FlatAppearance.BorderColor = Color.Gray;
                siyahRenk_button.FlatAppearance.BorderSize = 2;

                sarıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                sarıRenk_button.FlatAppearance.BorderSize = 2;

                kahveRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kahveRenk_button.FlatAppearance.BorderSize = 2;

                beyazRenk_button.FlatAppearance.BorderColor = Color.Gray;
                beyazRenk_button.FlatAppearance.BorderSize = 2;

                kırmızıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kırmızıRenk_button.FlatAppearance.BorderSize = 2;

                maviRenk_button.FlatAppearance.BorderColor = Color.Gray;
                maviRenk_button.FlatAppearance.BorderSize = 2;

                yesilRenk_button.FlatAppearance.BorderColor = Color.Gray;
                yesilRenk_button.FlatAppearance.BorderSize = 2;
            }
            else if (renk == "kahve")
            {
                kahveRenk_button.FlatStyle = FlatStyle.Flat;
                kahveRenk_button.FlatAppearance.BorderSize = 3;
                kahveRenk_button.FlatAppearance.BorderColor = Color.DarkGray;

                turuncuRenkbutton.FlatAppearance.BorderColor = Color.Gray;
                turuncuRenkbutton.FlatAppearance.BorderSize = 2;

                siyahRenk_button.FlatAppearance.BorderColor = Color.Gray;
                siyahRenk_button.FlatAppearance.BorderSize = 2;

                sarıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                sarıRenk_button.FlatAppearance.BorderSize = 2;

                morRenk_button.FlatAppearance.BorderColor = Color.Gray;
                morRenk_button.FlatAppearance.BorderSize = 2;

                beyazRenk_button.FlatAppearance.BorderColor = Color.Gray;
                beyazRenk_button.FlatAppearance.BorderSize = 2;

                kırmızıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kırmızıRenk_button.FlatAppearance.BorderSize = 2;

                maviRenk_button.FlatAppearance.BorderColor = Color.Gray;
                maviRenk_button.FlatAppearance.BorderSize = 2;

                yesilRenk_button.FlatAppearance.BorderColor = Color.Gray;
                yesilRenk_button.FlatAppearance.BorderSize = 2;
            }
            else if (renk == "beyaz")
            {
                beyazRenk_button.FlatStyle = FlatStyle.Flat;
                beyazRenk_button.FlatAppearance.BorderSize = 3;
                beyazRenk_button.FlatAppearance.BorderColor = Color.DarkGray;

                turuncuRenkbutton.FlatAppearance.BorderColor = Color.Gray;
                turuncuRenkbutton.FlatAppearance.BorderSize = 2;

                siyahRenk_button.FlatAppearance.BorderColor = Color.Gray;
                siyahRenk_button.FlatAppearance.BorderSize = 2;

                sarıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                sarıRenk_button.FlatAppearance.BorderSize = 2;

                morRenk_button.FlatAppearance.BorderColor = Color.Gray;
                morRenk_button.FlatAppearance.BorderSize = 2;

                kahveRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kahveRenk_button.FlatAppearance.BorderSize = 2;

                kırmızıRenk_button.FlatAppearance.BorderColor = Color.Gray;
                kırmızıRenk_button.FlatAppearance.BorderSize = 2;

                maviRenk_button.FlatAppearance.BorderColor = Color.Gray;
                maviRenk_button.FlatAppearance.BorderSize = 2;

                yesilRenk_button.FlatAppearance.BorderColor = Color.Gray;
                yesilRenk_button.FlatAppearance.BorderSize = 2;
            }
        }
        public void Renk_ver()
        {
            if (b_sec && Sekil_sirasiDikdorgen!=-1)
            {

                dikdortgenler[Sekil_sirasiDikdorgen].FircaRenk = firca;
            }
            else if (b_sec && Sekil_sirasiDaire!=-1)
            {
                daireler[Sekil_sirasiDaire].FircaRenk = firca;
            }
            else if (b_sec && Sekil_sirasiucgen!=-1)
            {
                ucgenler[Sekil_sirasiucgen].FircaRenk = firca;
            }
            else if (b_sec && Sekil_sirasiAltigen!=-1)
            {
                altigenler[Sekil_sirasiAltigen].FircaRenk = firca;
            }
            if (true)
            {

            }
            cizimAlanı_panel.Refresh();
        }
        public void sekilRenk_bul(Brush sekil)
        {

            if (((SolidBrush)sekil).Color.Name == "Black")
            {
                siyahRenk_button.PerformClick();
                Console.WriteLine(((SolidBrush)dikdortgen.FircaRenk).Color.Name);
            }
            
            if (((SolidBrush)sekil).Color.Name == "Red")
            {
                kırmızıRenk_button.PerformClick();
            }
            if (((SolidBrush)sekil).Color.Name == "Yellow")
            {
                sarıRenk_button.PerformClick();
            }
            if (((SolidBrush)sekil).Color.Name == "Orange")
            {
                turuncuRenkbutton.PerformClick();
            }
            if (((SolidBrush)sekil).Color.Name == "White")
            {
                beyazRenk_button.PerformClick();
            }
            if (((SolidBrush)sekil).Color.Name == "Green")
            {
                yesilRenk_button.PerformClick();
            }
            if (((SolidBrush)sekil).Color.Name == "Blue")
            {
                maviRenk_button.PerformClick();
            }
            if (((SolidBrush)sekil).Color.Name == "Brown")
            {
                kahveRenk_button.PerformClick();
            }
            if (((SolidBrush)sekil).Color.Name == "Purple")
            {
                morRenk_button.PerformClick();
            }
        }
    }
}
