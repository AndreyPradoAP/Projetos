using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoICG_3_Bimestre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int calco = 100;

            Bitmap imagemPanela = carregarImagem("C:\\Imagens\\Panela.jpg");
            Bitmap imagemCozinha = carregarImagem("C:\\Imagens\\Imagem_A.jpg");

            int[] tamanhoPanela = tamanhoImagem(imagemPanela);
            int[] tamanhoCozinha = tamanhoImagem(imagemCozinha);

            //MessageBox.Show("Tamanho panela = " + tamanhoPanela[0] + " por " + tamanhoPanela[1]);
            //MessageBox.Show("Tamanho panela = " + tamanhoCozinha[0] + " por " + tamanhoCozinha[1]);

            Bitmap imagemColagem = new Bitmap(tamanhoCozinha[0], tamanhoCozinha[1]);

            for (int c = 0; c < tamanhoCozinha[0]; c++)
            {
                for (int i = 0; i < tamanhoCozinha[1]; i++)
                {
                    if (c < tamanhoPanela[0] && i < tamanhoPanela[1])
                    {
                        int[] RGBPanela = corPixelRGB(imagemPanela, c, i);

                        if (RGBPanela[0] > 210 && RGBPanela[1] > 210 && RGBPanela[2] < 150)
                        {
                            Color corCozinha = corPixelColor(imagemCozinha, c, i);
                            imagemColagem = mudarCorImagem(imagemColagem, corCozinha, c, i);
                        }
                        else
                        {
                            Color corPanela = corPixelColor(imagemPanela, c, i);
                            imagemColagem = mudarCorImagem(imagemColagem, corPanela, c + calco, i);
                        }

                        //MessageBox.Show("Plotar Panela: " + c + ", " + i);
                    }
                    else
                    {
                        Color corCozinha = corPixelColor(imagemCozinha, c, i);
                        imagemColagem = mudarCorImagem(imagemColagem, corCozinha, c, i);

                        //MessageBox.Show("Plotar Cozinha: " + c + ", " + i);
                    }
                }
            }

            imagemColagem.Save("C:\\Imagens\\imagemColagem.jpg");
        }

        public Bitmap carregarImagem(String caminhoImagem)
        {
            Bitmap imagem = new Bitmap(caminhoImagem);

            return imagem;
        }

        public int[] tamanhoImagem(Bitmap imagem)
        {
            int X = imagem.Width;
            int Y = imagem.Height;

            int[] medidaimagem = { X, Y };

            return medidaimagem;
        }

        public Color corPixelColor(Bitmap imagem, int X, int Y)
        {
            int r = imagem.GetPixel(X, Y).R;
            int g = imagem.GetPixel(X, Y).G;
            int b = imagem.GetPixel(X, Y).B;

            Color cor = new Color();
            cor = Color.FromArgb(r, g, b);

            return cor;
        }

        public int[] corPixelRGB(Bitmap imagem, int X, int Y)
        {
            int r = imagem.GetPixel(X, Y).R;
            int g = imagem.GetPixel(X, Y).G;
            int b = imagem.GetPixel(X, Y).B;

            int[] RGB = { r, g, b };

            return RGB;
        }

        public Color corRGB(byte r, byte g, byte b)
        {
            Color cor = new Color();
            cor = Color.FromArgb(r, g, b);
            return cor;
        }

        public Bitmap mudarCorImagem(Bitmap Imagem, Color cor, int X, int Y)
        {
            Imagem.SetPixel(X, Y, cor);

            return Imagem;
        }

        public void juntarImagens()
        {

        }
    }
}
