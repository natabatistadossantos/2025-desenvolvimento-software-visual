﻿//Passos para resolver o bubble sort
//1 - Criar um vetor para receber 100 posições
//2 - Criar um laço de repetição para percorrer
//o vetor
//3 - Preencher cada posição com um valor 
//aleatório
//4 - Imprimir o vetor com valores aleatórios

int tamanho = 100;
int[] vetor = new int[tamanho];

Random random = new Random();
for (int i = 0; i < tamanho; i++)
{
    vetor[i] = random.Next(1000);
}

for (int i = 0; i < tamanho; i++)
{
    Console.Write(vetor[i] + " ");
}

//5 - Percorrer o vetor com valores aleatórios
//6 - Comparar a posição atual com a próxima
//7 - Se a posição atual for maior, inverte 
//os valores
//8 - Imprimir o vetor com valores ordenados

for (int a = 0; a < tamanho - 1; a++)
{
    for (int i = 0; i < vetor.Length - 1; i++)
    {
        int atual = vetor[i];
        int proximo = vetor[i + 1];
        if (atual > proximo)
        {
            int aux = atual;
            vetor[i] = proximo;
            vetor[i + 1] = aux;
        }
    }
}

Console.WriteLine("\n");

    for (int i = 0; i < tamanho-1; i++)
    {
        Console.WriteLine(vetor[i]);
    }
