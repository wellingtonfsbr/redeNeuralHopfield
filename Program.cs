using System;
using System.Collections.Generic;

namespace CalculadoraPesosHopfield
{
    // Calculadora de Pesos da Rede Hopfield
    public class CalculadoraPesosHopfield
    {
        // Método para calcular os pesos da rede Hopfield
                    //int[,] é um tipo que representa uma matriz de inteiros. Os colchetes [,] indicam que a matriz é bidimensional
        public static int[,] CalcularPesos(int[][] padroesTreinamento)//Este é um método público e estático chamado CalcularPeoss. Ele aceita como entrada um array de arrays de inteiros chamado padroesTreinamento, que representa os padrões de treinamento. O método retorna uma matriz de inteiros int[,] que representa os pesos da rede de Hopfield.
        {
            //A propriedade Length de um array em C# retorna o número de elementos no array. Neste contexto, padroesTreinamento[0].Length
            //nos dá o número de neurônios no primeiro padrão de treinamento.
            int tamanho = padroesTreinamento[0].Length; // Tamanho da rede
            //estamos declarando uma variável chamada pesos e inicializando-a como uma matriz bidimensional de inteiros (int[,]
            int[,] pesos = new int[tamanho, tamanho]; // Matriz de pesos 


            //Os loops for iteram sobre todos os pares de neurônios na rede, representados por i e j.
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    if (i != j)////garante que não estamos calculando o peso de um neurônio para si mesmo, pois esses pesos são geralmente definidos como 0
                    {
                        foreach (int[] padrao in padroesTreinamento)
                        {
                            ////Para cada padrão de treinamento, calculamos a contribuição do neurônio j para o neurônio i multiplicando os valores dos
                            ///neurônios nos padrões correspondentes

                            pesos[i, j] += padrao[i] * padrao[j];
                            //A soma dos produtos dos estados dos neurônios em cada padrão de treinamento
                            //é realizada para calcular os pesos da conexão entre esses neurônios na matriz
                            //"pesos". Esse processo é repetido para todos os pares de neurônios na rede,
                            //exceto quando i é igual a j, nesse caso, o peso é definido como zero, pois não
                            //há conexão de um neurônio para si mesmo em uma rede de Hopfield típica

                        }

                    }
                }
            }
            //O código acumula os produtos dos estados dos neurônios em cada padrão de treinamento e
            //armazena esses valores na matriz"pesos"
            return pesos;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[][] padroesTreinamento =
            {
                // aqui possuimos 3 padroes, cada padrao tem 3 neuronios 
                new int[] { 1, 0, 1 },
                new int[] { 1, 1, 0 },
                new int[] { 0, 0, 1 }
            };

            //Aqui estamos criando uma matriz chamada pesosIniciais que será usada para armazenar os pesos iniciais.
            //Esta linha está reservando espaço na memória para a matriz de pesos iniciais, mas ainda não estamos calculando os pesos aqui.
            int[,] pesosIniciais = new int[padroesTreinamento[0].Length, padroesTreinamento[0].Length];


            //Aqui estamos chamando o método  CalcularPesosda classe CalculadoraPesosHopfield para calcular os pesos finais com base nos padrões de treinamento fornecidos.
            int[,] pesosFinais = CalculadoraPesosHopfield.CalcularPesos(padroesTreinamento);//  //Os pesos calculados são armazenados na matriz pesosFinais

            Console.WriteLine("\nMatriz de Pesos Final:");
            ImprimirPesos(pesosFinais);
            Console.ReadKey();
        }

        // Método para imprimir os pesos na matriz
        static void ImprimirPesos(int[,] pesos)
        {
            int tamanho = pesos.GetLength(0);
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    Console.Write(pesos[i, j] + "\t");
                }
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
}
