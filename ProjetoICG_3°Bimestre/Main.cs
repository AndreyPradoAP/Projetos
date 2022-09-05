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
            int calco = 140;

            Bitmap imagemPanela = carregarImagem("c:\\Imagens\\Panela.jpg");
            Bitmap imagemCozinha = carregarImagem("c:\\Imagens\\Imagem_A.jpg");

            int[] tamanhoPanela = calcularTamanhoImagem(imagemPanela);
            int[] tamanhoCozinha = calcularTamanhoImagem(imagemCozinha);

            Bitmap imagemColagem = new Bitmap(tamanhoCozinha[0], tamanhoCozinha[1]);

            for (int x = 0; x < tamanhoCozinha[0]; x++)
            {
                for (int y = 0; y < tamanhoCozinha[1]; y++)
                {
                    if (x >= calco && x - calco < tamanhoPanela[0] && y < tamanhoPanela[1])
                    {
                        byte[] RGBPanela = corPixelRGB(imagemPanela, x - calco, y);

                        if (RGBPanela[0] > 210 && RGBPanela[1] > 210 && RGBPanela[2] < 150)
                        {
                            byte[] corCozinhaRGB = corPixelRGB(imagemCozinha, x, y);
                            Color corCozinhaColor = corRGB(corCozinhaRGB[0], corCozinhaRGB[1], corCozinhaRGB[2]);

                            imagemColagem = mudarCorImagem(imagemColagem, corCozinhaColor, x, y);
                        }
                        else
                        {
                            byte[] corPanelaRGB = corPixelRGB(imagemPanela, x - calco, y);
                            Color corPanelaColor = corRGB(corPanelaRGB[0], corPanelaRGB[1], corPanelaRGB[2]);

                            imagemColagem = mudarCorImagem(imagemColagem, corPanelaColor, x, y);
                        }
                    }
                    else
                    {
                        byte[] corCozinhaRGB = corPixelRGB(imagemCozinha, x, y);
                        Color corCozinhaColor = corRGB(corCozinhaRGB[0], corCozinhaRGB[1], corCozinhaRGB[2]);

                        imagemColagem = mudarCorImagem(imagemColagem, corCozinhaColor, x, y);
                    }
                }
            }

            imagemColagem.Save("c:\\Imagens\\imagemColagem.jpg");

            imagemColagem = filtroMonocromatico(imagemColagem);
            imagemColagem.Save("c:\\Imagens\\imagemColagem_Monocromatico.jpg");

            imagemColagem = filtroBinario(imagemColagem);
            imagemColagem.Save("c:\\Imagens\\imagemColagem_Binario.jpg");
        }

        public Bitmap carregarImagem(String caminhoImagem)
        {
            Bitmap imagem = new Bitmap(caminhoImagem);

            return imagem;
        }

        public int[] calcularTamanhoImagem(Bitmap imagem)
        {
            int X = imagem.Width;
            int Y = imagem.Height;

            int[] medidaImagem = { X, Y };

            return medidaImagem;
        }

        public byte[] corPixelRGB(Bitmap imagem, int X, int Y)
        {
            byte r = imagem.GetPixel(X, Y).R;
            byte g = imagem.GetPixel(X, Y).G;
            byte b = imagem.GetPixel(X, Y).B;

            byte[] RGB = { r, g, b };

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

        public Bitmap filtroMonocromatico(Bitmap imagem)
        {
            int[] tamanhoImagem = calcularTamanhoImagem(imagem);

            for (int x = 0; x < tamanhoImagem[0]; x++)
            {
                for (int y = 0; y < tamanhoImagem[1]; y++)
                {
                    byte[] rgbPixel = corPixelRGB(imagem, x, y);

                    byte tomCinza = (byte) (rgbPixel[0] * 0.3 + rgbPixel[1] * 0.59 + rgbPixel[2] * 0.11);

                    Color corPixel = corRGB(tomCinza, tomCinza, tomCinza);

                    mudarCorImagem(imagem, corPixel, x, y);
                }
            }

            return imagem;
        }

        public Bitmap filtroBinario(Bitmap imagem)
        {
            int[] tamanhoImagem = calcularTamanhoImagem(imagem);

            for (int x = 0; x < tamanhoImagem[0]; x++)
            {
                for (int y = 0; y < tamanhoImagem[1]; y++)
                {
                    byte[] rgbPixel = corPixelRGB(imagem, x, y);

                    if (rgbPixel[0] >= 126)
                    {
                        Color corPixel = corRGB(255, 255, 255);

                        mudarCorImagem(imagem, corPixel, x, y);
                    }
                    else
                    {
                        Color corPixel = corRGB(0, 0, 0);

                        mudarCorImagem(imagem, corPixel, x, y);
                    }
                }
            }

            return imagem;
        }
    }
}
