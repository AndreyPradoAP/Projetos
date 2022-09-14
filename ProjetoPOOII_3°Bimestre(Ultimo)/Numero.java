class Numero{
    private int centena;
    private int dezena;
    private int milhar;
    private int unidade;

    public void setCentena(int newCentena){
        this.centena = newCentena;
    }

    public int getCentena(){
        return this.centena;
    }
    
    public void setDezena(int newDezena){
        this.dezena = newDezena;
    }

    public int getDezena(){
        return this.dezena;
    }

    public void setMilhar(int newMilhar){
        this.milhar = newMilhar;
    }

    public int getMilhar(){
        return this.milhar;
    }

    public void setUnidade(int newUnidade){
        this.unidade = newUnidade;
    }

    public int getUnidade(){
        return this.unidade;
    }
}