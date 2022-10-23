using System;
using System.Threading;

class Program
{
    static int[,] atribui(int [,]array)
    {
        Random rand = new Random();
        for (int i = 0; i < Math.Sqrt(array.Length) ; i++){
            for(int j = 0; j < Math.Sqrt(array.Length); j++){
                array[i,j] = rand.Next(1000);
            }
        }
        return array;
    }

    static void imprime(int [,]array)
    {
        Random rand = new Random();
        for (int i = 0; i < Math.Sqrt(array.Length ); i++){
            for(int j = 0; j < Math.Sqrt(array.Length); j++){
                System.Console.WriteLine(array[i,j]);
            }
        }
    }

    static int[,] soma(int [,]array1, int [,]array2,int tam){
        int [,]vet = new int[tam,tam];
        for (int i = 0; i < tam; i++){
            for (int j = 0; j < tam; j++){
                System.Console.WriteLine($"Somando os valores {array1[i,j]} e {array2[i,j]} tem como resultado: {array1[i,j]+array2[i,j]}");
                vet[i,j] = array1[i,j]+array2[i,j];
            }
        }
        return vet;
    }


    static int[,] multiplica(int [,]array1, int [,]array2){
        int l1 = array1.GetLength(0);
        int c1 = array1.GetLength(1);
        int l2 = array2.GetLength(0);
        int c2 = array2.GetLength(1);

        if(c1 != l2){
           Console.WriteLine("Não pode ser multiplicada");
           return null;
        }
        else{
        int res = 0;
        int[,] matriz = new int[l1,c2];

        for(int i = 0;i< l1;i++){
           for (int j = 0; j < c2; j++){
                res = 0;
                for(int m =0;m<c1; m++)
                {
                    res += array1[i,m] * array2[m, j];
                }
                matriz[i,j] = res;
           }
        }
        return matriz;
        }
        
    }
    
    static int[,] subtracao(int[,]array1, int [,]array2,int tam){
        int [,]vet = new int [tam,tam];
        for(int i = 0;i< tam;i++){
            for (int j = 0; j < tam; j++){
                System.Console.WriteLine($"Subtração os valores {array1[i,j]} e {array2[i,j]} tem como resultado: {array1[i,j]+array2[i,j]}");
                vet[i,j] = array1[i,j]-array2[i,j];
           }
        }
        return vet;
    }
    static void Main()
    {
        Console.WriteLine("Hello, World");
        //int num = rand.Next(1000)
        int[,] array10 = new int[10,10];
        int[,] array100 = new int[100,100];
        int[,] array1000 = new int[1000,1000];

        int[,] array10_2 = new int[10,10];
        int[,] array100_2 = new int[100,100];
        int[,] array1000_2 = new int[1000,1000];

        // Thread t = new Thread(new ThreadStart(ThreadProc));
        atribui(array10);
        atribui(array100);
        atribui(array1000);
        
        atribui(array10_2);
        atribui(array100_2);
        atribui(array1000_2);
        soma(array10,array10_2,10);
        // soma(array100,array100_2);
        // soma(array1000,array1000_2);

        // subtracao(array10,array10_2);
        // subtracao(array100,array100_2);
        // subtracao(array1000,array1000_2);

    }
}