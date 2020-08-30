using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor_obrázků
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.seznamEfektu.Items.Add("Otočit vodorovně");
            this.seznamEfektu.Items.Add("Otočit svisle");
        }
        Bitmap obrazek;
        //uchovává vybraný obrázek
        Color[,] barvy;
        //Array uchovává hodnoty jednotlivých pixelů 
        int maxVyska = 750;
        int maxSirka = 975;
        //maxVyska a sirka určují maximální rozměry nahraného obrázku - pokud budou větší, obrázek se zmenší

        private void otevriSoubor()
        {
            OpenFileDialog otevreniSouboru = new OpenFileDialog();
            //openfiledialog = otevření rozhraní pro výběr souborů
            otevreniSouboru.Filter = "Obrázky (*.bmp, *.jpg) | *.bmp;*.jpg;";
            //.filter filtruje možné soubory, které lze vybrat
            otevreniSouboru.ShowDialog();
            if (otevreniSouboru.FileName != "")
            {
                try
                {
                    using (Bitmap docasnyObrazek = (Bitmap)Bitmap.FromFile(otevreniSouboru.FileName))
                    {
                        //using je použité pro dočasnou proměnnou (docasnyobrazek) - jakmile using skončí tak zmizí.
                        if (obrazek != null)
                        {
                            //pokud už je použitý obrazek (tj. - byl předtím nahraný), tak se vymaže
                            obrazek.Dispose();
                            obrazek = null;
                        }
                        if (docasnyObrazek.Width > maxSirka || docasnyObrazek.Height > maxVyska)
                        {
                            //pokud je obrázek větší než rozměry, tak se přizpůsobí a naklonuje
                            using (Bitmap docasnyObrazek2 = (Bitmap)ScaleImage(docasnyObrazek))
                            {
                                obrazek = (Bitmap)docasnyObrazek2.Clone();
                            }
                        }
                        else
                        {
                            //pokud je obrázek menší než rozměry, tak se naklonuje a nemění se rozměry
                            obrazek = (Bitmap)docasnyObrazek.Clone();
                        }
                        barvy = new Color[obrazek.Width, obrazek.Height];
                        for (int sloupec = 0; sloupec < obrazek.Width; sloupec++)
                        {
                            for (int radek = 0; radek < obrazek.Height; radek++)
                            {
                                barvy[sloupec, radek] = obrazek.GetPixel(sloupec, radek);
                            }
                        }
                        //pole barvy se obsadí jednotlivými pixely dle barev
                    }
                    seznamEfektu.Enabled = true;
                    tlacitko_ulozit.Enabled = false;
                    this.Invalidate();
                    //invalidate = překreslení povrchu
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Obrázek má moc velkou velikost!");
                }

            }
        }

        private void tlacitko_otevrit_Click(object sender, EventArgs e)
        {
            otevriSoubor();
            //zavolání funkce při otevření souboru
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //zavolá se při invalidate - když se kreslí na formulář
            if (obrazek != null)
            {
                e.Graphics.DrawImage(obrazek, 10, 10);
            }

        }
        private Bitmap ScaleImage(Bitmap bmp)
        {
            //funkce se zavolá, když je obrázek větší než maximální rozměry a zmenší se v zachovaném poměru. Navrátí pozměněný obrázek.
            var ratioX = (double)maxSirka / bmp.Width;
            var ratioY = (double)maxVyska / bmp.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(bmp.Width * ratio);
            var newHeight = (int)(bmp.Height * ratio);

            var newImage = new Bitmap(bmp, newWidth, newHeight);

            return newImage;
        }
        private void InverzeBarev()
        {
            for (int sloupec = 0; sloupec < obrazek.Width; sloupec++)
            {

                for (int radek = 0; radek < obrazek.Height; radek++)
                {
                    Color docasnaBarva = barvy[sloupec, radek];
                    int NovaCervena = 255 - docasnaBarva.R;
                    int NovaZelena = 255 - docasnaBarva.G;
                    int NovaModra = 255 - docasnaBarva.B;
                    Color invertovanaBarva = Color.FromArgb(NovaCervena, NovaZelena, NovaModra);
                    obrazek.SetPixel(sloupec, radek, invertovanaBarva);
                    barvy[sloupec, radek] = invertovanaBarva;
                }
            }
            this.Invalidate();
        }
        private void Zesvetli(int hodnota)
        {
            for (int sloupec = 0; sloupec < obrazek.Width; sloupec++)
            {

                for (int radek = 0; radek < obrazek.Height; radek++)
                {
                    Color docasnaBarva = barvy[sloupec, radek];
                    int NovaCervena = Math.Min(docasnaBarva.R + hodnota, 255);
                    int NovaZelena = Math.Min(docasnaBarva.G + hodnota, 255);
                    int NovaModra = Math.Min(docasnaBarva.B + hodnota, 255);
                    Color zesvetlenaBarva = Color.FromArgb(NovaCervena, NovaZelena, NovaModra);
                    obrazek.SetPixel(sloupec, radek, zesvetlenaBarva);
                    barvy[sloupec, radek] = zesvetlenaBarva;
                }
            }
            this.Invalidate();
        }
        private void Ztmav(int hodnota)
        {
            for (int sloupec = 0; sloupec < obrazek.Width; sloupec++)
            {

                for (int radek = 0; radek < obrazek.Height; radek++)
                {
                    Color docasnaBarva = barvy[sloupec, radek];
                    int NovaCervena = Math.Max(docasnaBarva.R - hodnota, 0);
                    int NovaZelena = Math.Max(docasnaBarva.G - hodnota, 0);
                    int NovaModra = Math.Max(docasnaBarva.B - hodnota, 0);
                    Color ztmavenaBarva = Color.FromArgb(NovaCervena, NovaZelena, NovaModra);
                    obrazek.SetPixel(sloupec, radek, ztmavenaBarva);
                    barvy[sloupec, radek] = ztmavenaBarva;
                }
            }
            this.Invalidate();
        }
        private void Rozmaz()
        {
            for (int sloupec = 0; sloupec < obrazek.Width; sloupec++)
            {

                for (int radek = 0; radek < obrazek.Height; radek++)
                {
                    Color barva;
                    if (sloupec > 0)
                    {
                        barva = barvy[sloupec - 1, radek];
                    }
                    else
                    {
                        barva = barvy[sloupec, radek];
                    }
                    int predchoziCervena = barva.R;
                    int predchoziZelena = barva.G;
                    int predchoziModra = barva.B;
                    if (sloupec < obrazek.Width - 1)
                    {
                        barva = barvy[sloupec + 1, radek];
                    }
                    else
                    {
                        barva = barvy[sloupec, radek];
                    }
                    int nasledujiciCervena = barva.R;
                    int nasledujiciZelena = barva.G;
                    int nasledujiciModra = barva.B;
                    int novaCervena = (predchoziCervena + nasledujiciCervena) / 2;
                    int novaZelena = (predchoziZelena + nasledujiciZelena) / 2;
                    int novaModra = (predchoziModra + nasledujiciModra) / 2;

                    Color novaBarva = Color.FromArgb(novaCervena, novaZelena, novaModra);
                    obrazek.SetPixel(sloupec, radek, novaBarva);
                    barvy[sloupec, radek] = novaBarva;
                }
            }
            this.Invalidate();
        }
        private void OtocVodorovne()
        {
            Color[,] docasnePole = new Color[obrazek.Width, obrazek.Height];
            for (int sloupec = 0; sloupec < obrazek.Width; sloupec++)
            {

                for (int radek = 0; radek < obrazek.Height; radek++)
                {
                    obrazek.SetPixel(sloupec, radek, barvy[(obrazek.Width - 1) - sloupec, radek]);
                    docasnePole[sloupec,radek]= barvy[(obrazek.Width - 1) - sloupec, radek];
                }
            }
            barvy = docasnePole;
            this.Invalidate();
        }
        private void OtocSvisle()
        {
            Color[,] docasnePole = new Color[obrazek.Width, obrazek.Height];
            for (int sloupec = 0; sloupec < obrazek.Width; sloupec++)
            {

                for (int radek = 0; radek < obrazek.Height; radek++)
                {
                    obrazek.SetPixel(sloupec, radek, barvy[sloupec, (obrazek.Height - 1) - radek]);
                    docasnePole[sloupec, radek] = barvy[sloupec, (obrazek.Height - 1) - radek];
                }
            }
            barvy = docasnePole;
            this.Invalidate();
        }
        private void tlacitko_proved_Click(object sender, EventArgs e)
        {
            this.zvolenyEfekt();
            tlacitko_ulozit.Enabled = true;
        }

        private void seznamEfektu_SelectedIndexChanged(object sender, EventArgs e)
        {
            tlacitko_proved.Enabled = true;
            switch(seznamEfektu.SelectedIndex)
            {
                case 0:
                    zvolenyEfekt = this.InverzeBarev;
                    this.posuvnik.Visible = false;
                    break;
                case 1:
                    zvolenyEfekt = this.Rozmaz;
                    this.posuvnik.Visible = false;
                    break;
                case 2:
                    zvolenyEfekt = () => this.Zesvetli(posuvnik.Value);
                    this.posuvnik.Visible = true;
                    break;
                case 3:
                    zvolenyEfekt = () => this.Ztmav(posuvnik.Value);
                    this.posuvnik.Visible = true;
                    break;
                case 4:
                    zvolenyEfekt = this.OtocVodorovne;
                    break;
                case 5:
                    zvolenyEfekt = this.OtocSvisle;
                    break;
            }
        }
        delegate void DelegatZvolenyEfekt();
        DelegatZvolenyEfekt zvolenyEfekt;

        private void tlacitko_ulozit_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog ulozeni = new SaveFileDialog();
                ulozeni.DefaultExt = "jpg";
                ulozeni.Filter = "Obrázek JPEG .jpg, .jpeg | *.jpg; *.jpeg|Bitmap .bmp | *.bmp";
                ulozeni.AddExtension = true;
                ulozeni.FileName = "obrazek";
                ulozeni.ShowDialog();
                string cesta = ulozeni.FileName;
                if (cesta != "")
                {
                    obrazek.Save(cesta);
                }
            }
            catch
            {
                MessageBox.Show("Chyba při ukládání souboru!", "Chyba");
            }
        }
    }
}
