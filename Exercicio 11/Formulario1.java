import java.awt.*;

class Formulario1 extends Frame{
    private Panel containerNorte;
    private Panel containerSul;
    private Button botao;
    private TextField inputText;
    private TextField printText;
    private Label label1;

    Formulario1(){
        containerNorte = new Panel();
        containerSul = new Panel();
        botao = new Button(" OK ");
        inputText = new TextField("Digite o numero aqui!", 15);
        printText = new TextField(30);
        
        setLayout(new BorderLayout());
        add("North", containerNorte);
        add("South", containerSul);

        containerNorte.add(inputText);
        containerNorte.add(printText);
        containerSul.add(botao);

        reshape(700, 200, 500, 200);
        show();
    }

    public boolean action(Event evt, Object arg){
        if(" OK ".equals(arg)){
            String numero = this.inputText.getText();
            NumeroExtenso numEx = new NumeroExtenso();
            String extenso = numEx.quebrarNumero(numero);

            printText.setText(extenso);
        }
        
        return true;
    }

    public static void main(String[] args){
        new Formulario1();
    }
}