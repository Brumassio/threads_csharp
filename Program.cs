using System;
using Arq2_Thread;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
  public Object locker = new Object();

    public static int[,] atribui(int[,] array)// é 
    {
        Random rand = new Random(); //  
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i,j] = rand.Next(1000);
            }
        }
        return array;
    }

    public static void imprime(int[,] array)
    {
        foreach (int i in array) {
            Console.WriteLine(i);
        }
    }


    // Vo pro trampo flw
    public static int[,]? multiplica(int[,] array1, int[,] array2){
        int l1 = array1.GetLength(0);
        int c1 = array1.GetLength(1);
        int l2 = array2.GetLength(0);
        int c2 = array2.GetLength(1);

        if(c1 != l2){
            Console.WriteLine("Não pode ser multiplicada");
            return null;
        }

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
    
    public static int[,] subtracao(int[,]array1, int [,]array2,int tam){
        int [,]vet = new int [tam,tam];
        for(int i = 0;i< tam;i++){
            for (int j = 0; j < tam; j++){
                System.Console.WriteLine($"Subtração os valores {array1[i,j]} e {array2[i,j]} tem como resultado: {array1[i,j]+array2[i,j]}");
                vet[i,j] = array1[i,j]-array2[i,j];
            }
        }
        return vet;
    }

    public static int[,] soma(int [,]array1, int [,]array2,int tam){
        int [,]vet = new int[tam,tam];
                for (int i = 0; i < tam; i++){
                for (int j = 0; j < tam; j++){
                    System.Console.WriteLine($"Somando os valores {array1[i,j]} e {array2[i,j]} tem como resultado: {array1[i,j]+array2[i,j]}");
                    vet[i,j] = array1[i,j]+array2[i,j];
            }
        }
        return vet;
    }



    // public static void Threadson() {
    //     for (int i = 0; i < 10; i++) {
    //         Console.WriteLine("ThreadProc: {0}", i);
    //         // Yield the rest of the time slice.
    //         Thread.Sleep(0);
    //     }
    // }
    

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


        atribui(array10);
        atribui(array100);
        atribui(array1000);
        
        atribui(array10_2);
        atribui(array100_2);
        atribui(array1000_2);
        Program pro = new Program();

        Thread[] threads = new Thread[4];
        Conta con10 = new Conta(array100,array100_2);
        
        try
        {
            lock (pro.locker)
           { 
                for (int i = 0; i < threads.GetLength(0); i++)
                {
                    Thread thread = new Thread(con10.soma);
                    thread.Name = "Thread" + i;
                    threads[i] = thread;
                
                    foreach (var item in threads)
                    {
                        item.Start();
                    }      
                }
            }
        }
        catch (NullReferenceException e)
        {
            if (e.Source != null)
                Console.WriteLine("IOException source: {0}", e.Source);
            throw;
        }
            
    }
}
