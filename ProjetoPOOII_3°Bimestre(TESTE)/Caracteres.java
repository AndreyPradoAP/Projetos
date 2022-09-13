class Caracteres{
    Caracteres(Numero num){
        Unidade numString[] = new Unidade[9];

        numString[0].setUnidade("um");
        numString[0].setDezena("dez");
        numString[0].setDezenaDez("onze");
        numString[0].setCentena("cem");
        numString[0].setMilhar("mil");

        numString[1].setUnidade("dois");
        numString[1].setDezena("vinte");
        numString[0].setDezenaDez("doze");
        numString[1].setCentena("duzentos");
        numString[1].setMilhar("dois mil");

        numString[2].setUnidade("três");
        numString[2].setDezena("trinta");
        numString[0].setDezenaDez("treze");
        numString[2].setCentena("trezentos");
        numString[2].setMilhar("três mil");

        numString[3].setUnidade("quatro");
        numString[3].setDezena("quarenta");
        numString[0].setDezenaDez("quatorze");
        numString[3].setCentena("quatrocentos");
        numString[3].setMilhar("quatro mil");

        numString[4].setUnidade("cinco");
        numString[4].setDezena("cinquenta");
        numString[0].setDezenaDez("quinze");
        numString[4].setCentena("quinhentos");
        numString[4].setMilhar("cinco mil");

        numString[5].setUnidade("seis");
        numString[5].setDezena("sessenta");
        numString[0].setDezenaDez("dezesseis");
        numString[5].setCentena("seisentos");
        numString[5].setMilhar("seis mil");

        numString[6].setUnidade("sete");
        numString[6].setDezena("setenta");
        numString[0].setDezenaDez("dezessete");
        numString[6].setCentena("setessentos");
        numString[6].setMilhar("sete mil");

        numString[7].setUnidade("oito");
        numString[7].setDezena("oitenta");
        numString[0].setDezenaDez("dezoito");
        numString[7].setCentena("oitocentos");
        numString[7].setMilhar("oito mil");

        numString[8].setUnidade("nove");
        numString[8].setDezena("noventa");
        numString[0].setDezenaDez("dezenove");
        numString[8].setCentena("novecentos");
        numString[8].setMilhar("nove mil");

        int algarismo = 0;
        int algarismoUnidade = 0;
        String extenso = "";

        algarismo = num.getMilhar();

        if(algarismo != 0){
            extenso += numString[algarismo - 1].getMilhar();
        }

        algarismo = num.getCentena();

        if(algarismo != 0){
            if(extenso != "")
                extenso += " e ";

            extenso += numString[algarismo - 1].getCentena();
        }

        algarismo = num.getDezena();
        algarismoUnidade = num.getUnidade();

        if(algarismo != 0){
            if(extenso != "")
                extenso += " e ";

            if(algarismo == 1 && algarismoUnidade != 0){
                extenso += numString[algarismo - 1].getDezenaDez();
            }
            else{
                extenso += numString[algarismo - 1].getDezena();

                if(algarismoUnidade != 0){
                    if(extenso != "")
                        extenso += " e ";

                    extenso += numString[algarismo - 1].getUnidade();
                }
            }
        }
        else{
            if(algarismoUnidade != 0){
                if(extenso != "")
                    extenso += " e ";

                extenso += numString[algarismo - 1].getUnidade();
            }
        }

        if(extenso == ""){
            extenso = "Zero";
        }

        System.out.println(extenso);
    }
}