using System;

namespace PBL
{
    class Program
    {
        static void Main()
        {
            double g = 9.8; //gravidade em m/s²

            //solicitar a altura e distancia do alvo
            Console.Write("Digite a altura do alvo (em metros): ");
            double altura = double.Parse(Console.ReadLine());
            Console.Write("Digite a distância até o alvo (em metros): ");
            double distancia = double.Parse(Console.ReadLine());

            //calculo do angulo mínimo
            double thetaMin = Math.Atan((2 * altura) / distancia);
            double thetaMinGraus = thetaMin * (180 / Math.PI);

            Console.WriteLine($"Ângulo mínimo necessário para atingir o alvo: {thetaMinGraus:F2} graus");

            //solicitação do angulo desejado
            double thetaGraus;
            do
            {
                Console.Write("Digite um ângulo desejado (em graus), maior ou igual ao ângulo mínimo: ");
                thetaGraus = double.Parse(Console.ReadLine());
            } while (thetaGraus < thetaMinGraus);

            //converter angulo para rad
            double theta = thetaGraus * (Math.PI / 180);

            //calculo de velocidade inicial
            double v0 = Math.Sqrt((g * distancia * distancia) / (2 * (distancia * Math.Tan(theta) - altura) * Math.Cos(theta) * Math.Cos(theta)));

            //calcular de tempo de voo até o alvo
            double tempo = distancia / (v0 * Math.Cos(theta));

            //saber se o projetil está em asc ou desc
            double vt = v0 - g * tempo;


            //resultados
            Console.WriteLine($"Velocidade inicial mínima: {v0:F2} m/s");
            Console.WriteLine($"Tempo de voo: {tempo:F2} segundos");
            if (vt > 0)
            {
                Console.WriteLine("O projétil atinge o alvo em ascendência.");
            }
            else
            {
                Console.WriteLine("O projétil atinge o alvo em descendência.");
            }

            Console.ReadKey();
        }
    }
}
