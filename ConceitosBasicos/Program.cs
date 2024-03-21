// crie um programa para calcular o IMC de uma pessoa e informar o status de acordo com o imc calculado

// modifique o programa para que possua um menu de opções para suas funcionalidades

using System.Globalization;

int opcao = 0;

do
{
    Console.WriteLine("Informe o que deseja fazer:");
    Console.WriteLine("(1) Calcular IMC");
    Console.WriteLine("(2) Peso Ideal");
    Console.WriteLine("(3) Jogo de adivinhação");
    Console.WriteLine("(4) Exibir 5 valores fornecidos pelo usuário em ordem decrescente");
    Console.WriteLine("(0) Encerrar");
    opcao = Convert.ToInt32(Console.ReadLine());
    switch (opcao)
    {
        case 1:
            CalcularIMC();
            break;
        case 2:
            PesoIdeal();
            break;
        case 3:
            JogoAdivinhacao();
            break;
        case 4:
            OrdenarValores();
            break;
    }
    /*
    if (opcao == 1)
        CalcularIMC();
    else if (opcao == 2)
        PesoIdeal();
    else if (opcao == 3)
        JogoAdivinhacao();
    */
} while (opcao != 0);
Console.WriteLine("Obrigado por sua participação!");
Console.WriteLine("Programa Finalizado");

static void CalcularIMC()
{
    Console.WriteLine("Informe seu peso:");
    int peso = int.Parse(Console.ReadLine());

    Console.WriteLine("Informe sua altura:");
    float altura = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    float imc = peso / (altura * altura);

    Console.WriteLine($"Para o peso {peso} e a altura {altura} o imc calculado foi {imc:f1}");

    string status = string.Empty;
    if (imc <= 16.9)
        status = "muito abaixo do peso";
    else if (imc <= 18.4)
        status = "magreza";
    else if (imc <= 24.9)
        status = "normal";
    else if (imc <= 29.9)
        status = "Sobrepeso";
    else if (imc <= 39.9)
        status = "Obesidade";
    else
        status = "Obesidade Grave";

    // crie a mensagem: O IMC x indica a classificação y
    // $ -> caractere de interpolação
    Console.WriteLine($"O IMC {imc} indica a classificação {status}");
}

static void PesoIdeal()
{
    Console.WriteLine("Informe sua altura:");
    float altura = float.Parse (Console.ReadLine(), CultureInfo.InvariantCulture);
    float minIdeal = (float)(Math.Pow(altura, 2) * 18.5);
    float maxIdeal = (float)(Math.Pow(altura, 2) * 24.9);
    Console.WriteLine($"Pelo IMC o peso ideal de uma pessoa com altura {altura}");
    Console.WriteLine($" fica entre {minIdeal:f1} e {maxIdeal:f1}");
}

static void JogoAdivinhacao()
{
    Console.WriteLine("você tem 10 tentativas para adivinhar um número entre 1 e 100!");
    Random random = new Random();
    int valorSorteado = random.Next(1,100);
    int tentativa;
    for(int i = 0; i < 10; i++)
    {
        Console.WriteLine($"{i+1}a. tentativa:");
        tentativa = Convert.ToInt32(Console.ReadLine());
        if(tentativa == valorSorteado)
        {
            Console.WriteLine($"Parabéns!! Você adivinhou o número em {i} tentativas!!!");
            break;
        }
        if(i < 9)
        {
            if (tentativa < valorSorteado)
                Console.WriteLine("O valor sorteado é maior que o número informado. Tente novamente!");
            else if (tentativa > valorSorteado)
                Console.WriteLine("O valor sorteado é menor que o número informado. Tente novamente!");
        }
        else
        {
            Console.WriteLine("Você não possui mais tentativas!");
        }
            
    }
    Console.WriteLine("Fim de Jogo!");
}
static void OrdenarValores()
{
    int tamanho = 5;
    int[] valores = new int[tamanho];

    for(int i = 0;i < valores.Length;i++)
    {
        Console.WriteLine("Informe o ${0}o. valor: ", i+1);
        valores[i] = Convert.ToInt32(Console.ReadLine());
    }

    Console.WriteLine("Valores Informados:");
    foreach (var valor in valores)
    {
        Console.WriteLine(valor + " ");
    }
}