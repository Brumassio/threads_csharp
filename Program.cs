using System;
using Arq2_Thread;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
  //public Object locker = new Object();

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
    
    static void Main()
    {


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
        Object locker = new Object();
        //Quantidade de Threads a ser escolhida pelo usuário
        int qtd;
        System.Console.WriteLine("Digite a quantidade de threads: ");
        int.TryParse(Console.ReadLine(),out qtd); 
        Thread[] threads = new Thread[qtd];
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "mainThread";
        // para testar as outras matrizes
        Conta con = new Conta(array100,array100_2);
        int op =1;
        Console.WriteLine("\n\nEscolha uma operação:\n");
        Console.WriteLine("1--Soma");
        Console.WriteLine("2--Subtração"); 
        Console.WriteLine("3--Multiplicação");
        Console.WriteLine("4--Transposta");
        Console.WriteLine("0--Sair");
        int.TryParse(Console.ReadLine(),out op); 
        switch(op){
            case 1:
            System.Console.WriteLine("\nSEQUENCIAL");
            DateTime beginsom = DateTime.Now;
            con.somaSeq();
            DateTime endsom = DateTime.Now;
            System.Console.WriteLine(endsom.Subtract(beginsom));
            System.Console.WriteLine("\nMULTITHREAD");
            //guardando o tempo para calcular o tempo de execução
            DateTime begin = DateTime.Now;
            System.Console.WriteLine("Soma:");
            for(int i=0;i<qtd;i++){
                threads[i] = new Thread(con.soma1);
            }

            foreach (var item in threads)
            {
                //inicializando as threads guardadas anteriormente
                item.Start();
            }

            DateTime end = DateTime.Now;
            //printando o tempo de execução
            System.Console.WriteLine($"Tempo de execução: {end.Subtract(begin)} ");  
            break;  

            case 2:
            System.Console.WriteLine("\nSEQUENCIAL");
            DateTime beginsub = DateTime.Now;
            con.subtracaoSeq();
            DateTime endsub = DateTime.Now;
            System.Console.WriteLine(endsub.Subtract(beginsub));

            System.Console.WriteLine("\nMULTITHREAD");
            //guardando o tempo para calcular o tempo de execução
            DateTime beginSub = DateTime.Now;
            System.Console.WriteLine("Subtracao:");

            for(int i=0;i<qtd;i++){
                threads[i] = new Thread(con.subtracao1);
            }

            foreach (var item in threads)
            {
                //inicializando as threads guardadas anteriormente
                item.Start();
            }

            DateTime endSub = DateTime.Now;
            //printando o tempo de execução
            System.Console.WriteLine($"Tempo de execução: {endSub.Subtract(beginSub)} ");  
            break;
        
            case 3:
            System.Console.WriteLine("\nSEQUENCIAL");
            DateTime beginmul = DateTime.Now;
            con.multiplicaSeq();
            DateTime endmul = DateTime.Now;
            System.Console.WriteLine(endmul.Subtract(beginmul));

            System.Console.WriteLine("\nMULTITHREAD");
            //guardando o tempo para calcular o tempo de execução
            DateTime beginMul = DateTime.Now;
            System.Console.WriteLine("Multiplicação:");

            for(int i=0;i<qtd;i++){
                threads[i] = new Thread(con.multiplicacao1);
            }

            foreach (var item in threads)
            {
                //inicializando as threads guardadas anteriormente
                item.Start();
            }

            DateTime endMul = DateTime.Now;
            //printando o tempo de execução
            System.Console.WriteLine($"Tempo de execução: {endMul.Subtract(beginMul)} "); 
            break;

            case 4:
            System.Console.WriteLine("\nSEQUENCIAL");
            DateTime begintr = DateTime.Now;
            con.transpostaSeq();
            DateTime endtr = DateTime.Now;
            System.Console.WriteLine(endtr.Subtract(begintr));

            System.Console.WriteLine("\nMULTITHREAD");
            //guardando o tempo para calcular o tempo de execução
            DateTime beginTr = DateTime.Now;
            System.Console.WriteLine("Matriz Transposta:");

            for(int i=0;i<qtd;i++){
                threads[i] = new Thread(con.transposta1);
            }

            foreach (var item in threads)
            {
                //inicializando as threads guardadas anteriormente
                item.Start();
            }

            DateTime endTr = DateTime.Now;
            //printando o tempo de execução
            System.Console.WriteLine($"Tempo de execução: {endTr.Subtract(beginTr)} ");  
            break;                           
                                
            default:
            System.Console.WriteLine("\nDigite uma opção válida ! :D , Volte Sempre !!!");
            break;
            }
        }
    }           

        
            

