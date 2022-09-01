import java.util.Scanner;

class NumeroExtenso{
    public static void main(String args[]){
        int algarismoDecimal = 0;
        int numero = -1;
        int flag = 0;
        Scanner scan = new Scanner(System.in);
        Unidade uni = new Unidade();

        while(numero < 0 || numero > 9999){
            if(flag == 0){
                System.out.println("Digite um número de 0 a 9999");
                numero = Integer.parseInt(scan.nextLine());
                flag++;
            }
            else{
                System.out.println("Número digitado inválido! Digite novamente um número de 0 a 9999");
                numero = Integer.parseInt(scan.nextLine());
            }
        }

        for(int c = 1000; c >= 1 ; c /= 10){
            algarismoDecimal = numero / c;
            numero -= algarismoDecimal * c;

            if(c == 1)
                uni.setUnidade(algarismoDecimal);
            else if(c == 10)
                uni.setDezena(algarismoDecimal);
            else if(c == 100)
                uni.setCentena(algarismoDecimal);
            else
                uni.setMilhar(algarismoDecimal);
        }

        Caracteres caracter = new Caracteres(uni);
    }
}