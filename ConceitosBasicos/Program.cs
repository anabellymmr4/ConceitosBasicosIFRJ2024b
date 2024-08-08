
using System.Globalization;

int opcao = 0;

do
{
    Console.WriteLine("Informe o que deseja fazer:");
    Console.WriteLine("(1) Calcular IMC");
    Console.WriteLine("(2) Peso Ideal");
    Console.WriteLine("(3) Jogo de adivinhação");
    Console.WriteLine("(4) Exibir 5 valores fornecidos pelo usuário em ordem decrescente");
    Console.WriteLine("(5) Fatorial");
    Console.WriteLine("(6) Verifica Primo");
    Console.WriteLine("(7) Calcular a área do retangulo");
    Console.WriteLine("(8) Calcular área da circunferência");
    Console.WriteLine("(9) Calcular área e verificar a validade do triângulo");
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
        case 5:
            Fatorial();
            break;
        case 6:
            Console.WriteLine("Informe um número inteiro:");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(VerificaPrimo(numero));
            break;
        case 7:
            ÁreaRetangulo();
            break;
        case 8:
            ÁreaCircunferência();
            break;
        case 9:
            ÁreaTriângulo();
            break;
    }

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
    Console.WriteLine($"O IMC {imc} indica a classificação {status}");
}

static void PesoIdeal()
{
    Console.WriteLine("Informe sua altura:");
    float altura = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    float minIdeal = (float)(Math.Pow(altura, 2) * 18.5);
    float maxIdeal = (float)(Math.Pow(altura, 2) * 24.9);
    Console.WriteLine($"Pelo IMC o peso ideal de uma pessoa com altura {altura}");
    Console.WriteLine($" fica entre {minIdeal:f1} e {maxIdeal:f1}");
}

static void JogoAdivinhacao()
{
    Console.WriteLine("você tem 10 tentativas para adivinhar um número entre 1 e 100!");
    Random random = new Random();
    int valorSorteado = random.Next(1, 100);
    int tentativa;
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"{i + 1}a. tentativa:");
        tentativa = Convert.ToInt32(Console.ReadLine());
        if (tentativa == valorSorteado)
        {
            Console.WriteLine($"Parabéns!! Você adivinhou o número em {i} tentativas!!!");
            break;
        }
        if (i < 9)
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

    for (int i = 0; i < valores.Length; i++)
    {
        Console.WriteLine("Informe o {0}o. valor: ", i + 1);
        valores[i] = Convert.ToInt32(Console.ReadLine());
    }

    Console.WriteLine("Valores Informados:");
    foreach (var valor in valores)
    {
        Console.WriteLine(valor + " ");
    }

    for (int i = 0; i < valores.Length; i++)
    {
        for (int j = i + 1; j < valores.Length; j++)
        {
            if (valores[i] < valores[j])
            {
                var temp = valores[i];
                valores[i] = valores[j];
                valores[j] = temp;
            }
        }
    }

    Console.WriteLine("Valores ordenados:");
    foreach (var valor in valores)
    {
        Console.WriteLine(valor + " ");
    }
}

static void Fatorial()
{
    int i, numero, fatorial;
    Console.WriteLine("Informe o número");
    numero = int.Parse(Console.ReadLine());
    fatorial = numero;
    for (i = numero - 1; i >= 1; i--)
    {
        fatorial = fatorial * 1;
    }
    Console.WriteLine($"\nFatorial de {numero} é {fatorial} ");
    Console.ReadLine();
}

static string VerificaPrimo(int numero)
{
    int cont = numero / 2;

    for (int divisor = 2; divisor <= cont; divisor++)
    {
        if ((numero % divisor) == 0)
            return "não é primo";
    }
    return "é primo";

}


static void ÁreaRetangulo()
{
    Console.WriteLine("Informe a base:");
    int Base = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a altura:");
    int Altura = int.Parse(Console.ReadLine());
    int area = Base * Altura;
    Console.WriteLine($"A área é igual a:{area}");
}

static void ÁreaCircunferência()
{
    Console.WriteLine("Informe o raio:");
    float raio = float.Parse(Console.ReadLine());
    float pi = 3.14f;
    float area = pi * (raio * raio);
    Console.WriteLine($"A área é igual a: {area}");
}

static void ÁreaTriângulo()
{
    Console.WriteLine("Digite o valor do lado A do triângulo:");
    double ladoA = double.Parse(Console.ReadLine());
    Console.WriteLine("Digite o valor do lado B do triângulo:");
    double ladoB = double.Parse(Console.ReadLine());
    Console.WriteLine("Digite o valor da base do triângulo:");
    double ladoC = double.Parse(Console.ReadLine());
    Console.WriteLine("Digite o valor da altura do triângulo:");
    double alturaT = double.Parse(Console.ReadLine());
    if (ladoA < ladoB + ladoC && ladoB < ladoA + ladoC && ladoC < ladoA + ladoB)
    {
        Console.WriteLine("O triângulo é válido");
        double areaT = (alturaT * ladoC) / 2;
        Console.WriteLine($"A área do triângulo é {areaT:f2}");
    }

    else
    {
        Console.WriteLine("O triângulo não é fisicamente possível");
    }
}







