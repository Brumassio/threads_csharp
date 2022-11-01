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
        int op2 = 2;
        while(op!=0)
        {   
            Console.WriteLine("\n\nEscolha uma das opções a seguir:\n");
            Console.WriteLine("1--Sequencial");
            Console.WriteLine("2--Multithread (duas threads)");
            int.TryParse(Console.ReadLine(),out op); 
            switch(op){
                case 0:
                System.Console.WriteLine("Volte sempre !");
                break;
                case 1:
                Console.WriteLine("\n\nEscolha uma das opções a seguir (Multithread):\n");
                Console.WriteLine("1--Soma");
                Console.WriteLine("2--Subtração"); 
                Console.WriteLine("3--Multiplicação");
                Console.WriteLine("0--Sair");
                int.TryParse(Console.ReadLine(),out op2); 
                switch(op2){
                    case 1:
                    DateTime beginsom = DateTime.Now;
                    con.somaSeq();
                    DateTime endsom = DateTime.Now;
                    System.Console.WriteLine(endsom.Subtract(beginsom));
                    break;
                    case 2:
                    DateTime beginsub = DateTime.Now;
                    con.subtracaoSeq();
                    DateTime endsub = DateTime.Now;
                    System.Console.WriteLine(endsub.Subtract(beginsub));
                    break;
                    case 3:
                    DateTime beginmul = DateTime.Now;
                    con.multiplicaSeq();
                    DateTime endmul = DateTime.Now;
                    System.Console.WriteLine(endmul.Subtract(beginmul));
                    break;
                    default:
                    System.Console.WriteLine("Opção errada !");
                    break;
                }               

                break;
                case 2:
                Console.WriteLine("\n\nEscolha uma das opções a seguir (Multithread):\n");
                Console.WriteLine("1--Soma");
                Console.WriteLine("2--Subtração"); 
                Console.WriteLine("3--Multiplicação");
                Console.WriteLine("0--Sair");
                int.TryParse(Console.ReadLine(),out op2);
                switch (op2)
                {   
                    case 0:
                        break;
                    case 1:
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
                        // pode variar o tempo de sleep para todas as operações (pode ser por causa do break do switch)-> matriz[10][10]: 1 ,
                        // matriz[100][100]:2400, matriz[1000][1000]: um valor maior  
                        // Thread.Sleep(0);
                        DateTime end = DateTime.Now;
                        //printando o tempo de execução
                        System.Console.WriteLine($"Tempo de execução: {end.Subtract(begin)} ");  
                        break;

                    case 2:
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
                        foreach (var item in threads)
                        {
                            //inicializando as threads guardadas anteriormente
                            item.Join();
                        }
                        // pode variar o tempo de sleep para todas as operações (pode ser por causa do break do switch)-> matriz[10][10]: 1 ,
                        // matriz[100][100]:3000, matriz[1000][1000]: um valor maior  
                        // Thread.Sleep(10000);
                        DateTime endSub = DateTime.Now;
                        //printando o tempo de execução
                        System.Console.WriteLine($"Tempo de execução: {endSub.Subtract(beginSub)} ");                  
                        break;

                    case 3:
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
                        foreach (var item in threads)
                        {
                            //inicializando as threads guardadas anteriormente
                            item.Join();
                        }         
                        // pode variar o tempo de sleep para todas as operações (pode ser por causa do break do switch)-> matriz[10][10]: 1 ,
                        // matriz[100][100]:3000, matriz[1000][1000]: um valor maior ai !  
                        // Thread.Sleep(10000);
                        DateTime endMul = DateTime.Now;
                        //printando o tempo de execução
                        System.Console.WriteLine($"Tempo de execução: {endMul.Subtract(beginMul)} "); 
                        break;
                    
                    default:
                        System.Console.WriteLine("\nDigite uma opção válida ! :D");
                        break;
                }
                break;

                default:
                System.Console.WriteLine("\nDigite uma opção valida !");
                break;
            }


            
        }
            
    }
}
