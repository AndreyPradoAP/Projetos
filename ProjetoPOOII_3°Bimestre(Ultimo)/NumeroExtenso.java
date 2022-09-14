import java.util.Scanner;

class NumeroExtenso{
    public static void main(String args[]){
        Scanner scan = new Scanner(System.in);
        Numero num = new Numero();

        int numero = Integer.parseInt(scan.nextLine());                

        for(int c = 1000; c >= 1; c /= 10){
            int algarismoDecimal = numero / c;
            numero -= algarismoDecimal * c;

            if(c == 1)
                num.setUnidade(algarismoDecimal);
            else if(c == 10)
                num.setDezena(algarismoDecimal);
            else if(c == 100)
                num.setCentena(algarismoDecimal);
            else
                num.setMilhar(algarismoDecimal);
        }

        ManipulaCaracteres caracter = new ManipulaCaracteres(num);
    }
}