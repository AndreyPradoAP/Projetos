using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoICG_3oBimestre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap imagemPanela = carregarImagem("C:\\Imagens\\Panela.jpg");
            Bitmap imagemCozinha = carregarImagem("C:\\Imagens\\Imagem_A.jpg");

            int[] tamanhoPanela = tamanhoImagem(imagemPanela);
            int[] tamanhoCozinha = tamanhoImagem(imagemCozinha);

            Bitmap imagemColagem = new Bitmap(tamanhoCozinha[0], tamanhoCozinha[1]);

            for (int c = 1; c <= tamanhoCozinha[0]; c++)
            {
                for (int i = 1; i <= tamanhoCozinha[1]; i++)
                {
                    if (c < tamanhoPanela[0] || i < tamanhoPanela[1])
                    {
                        Color corPanela = corPixel(imagemPanela, c, i);

                        imagemColagem = mudarCorImagem(imagemColagem, corPanela, c, i);
                    }
                    else
                    {
                        Color corCozinha = corPixel(imagemCozinha, c, i);

                        imagemColagem = mudarCorImagem(imagemColagem, corCozinha, c, i);
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

        public Color corPixel(Bitmap imagem, int X, int Y)
        {
            int r = imagem.GetPixel(X, Y).R;
            int g = imagem.GetPixel(X, Y).G;
            int b = imagem.GetPixel(X, Y).B;

            Color cor = new Color();
            cor = Color.FromArgb(r, g, b);

            return cor;
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