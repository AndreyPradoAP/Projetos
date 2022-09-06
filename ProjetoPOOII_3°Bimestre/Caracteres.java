class Caracteres{
    Caracteres(Unidade uni){
        String[] unidade = {"um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove"};
        String[] dezena = {"dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa"};
        String[] dezenaDez = {"onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezesste", "dezoito", "dezenove"};
        String[] centena = {"cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos"};
        int algarismo = 0;
        int algarismoUnidade = 0;
        String extenso = "";

        algarismo = uni.getMilhar();

        if(algarismo != 0){
            extenso = criarExtenso(unidade, extenso, algarismo);
            extenso += " mil";
        }

        algarismo = uni.getCentena();

        if(algarismo != 0){
            if(extenso != "")
                extenso += " e ";

            extenso = criarExtenso(centena, extenso, algarismo);
        }

        algarismo = uni.getDezena();
        algarismoUnidade = uni.getUnidade();

        if(algarismo != 0){
            if(extenso != "")
                extenso += " e ";

            if(algarismo == 1 && algarismoUnidade != 0){
                extenso = criarExtenso(dezenaDez, extenso, algarismoUnidade);
            }
            else{
                extenso = criarExtenso(dezena, extenso, algarismo);

                if(algarismoUnidade != 0){
                    if(extenso != "")
                        extenso += " e ";

                    extenso = criarExtenso(unidade, extenso, algarismoUnidade);
                }
            }
        }
        else{
            if(algarismoUnidade != 0){
                if(extenso != "")
                    extenso += " e ";

                extenso = criarExtenso(unidade, extenso, algarismoUnidade);
            }
        }

        if(extenso == ""){
            extenso = "Zero";
        }

        System.out.println(extenso);
    }
        
    public String criarExtenso(String[] numerosExtenso, String extenso, int algarismo){      
        extenso += numerosExtenso[algarismo - 1];

        return extenso;
    }
}