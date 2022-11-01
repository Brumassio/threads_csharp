namespace Arq2_Thread
{
    public class Conta
    {   
        public int[,] array1 { get; set; }
        public int[,] array2 { get; set; }
        public Object locker = new Object();
        Random random = new Random();

        public Conta(int [,] array1, int[,] array2) {
            this.array1 = array1; 
            this.array2 = array2;
        }

        //Função multiplicação para execução sequencial
        public int[,]? multiplicaSeq(){
            int l1 = this.array1.GetLength(0); //linha do array1
            int c1 = this.array1.GetLength(1); //coluna do array1
            int l2 = this.array2.GetLength(0); //linha do array2
            int c2 = this.array2.GetLength(1); //coluna do array2

            int res = 0;
            int[,] matriz = new int[l1,c2];

            for(int i = 0;i< l1;i++){
                for (int j = 0; j < c2; j++){
                    res = 0;
                    for(int m =0;m<c1; m++)
                    {
                        res += this.array1[i,m] * this.array2[m, j];
                    }
                    // System.Console.WriteLine($"Multiplicação resulta em : {res}");
                    matriz[i,j] = res;
                }
            }
            return matriz;
        }

        //Função Tranposta (exemplo adicional que o professor pediu) para execução sequencial
        public int[,] transpostaSeq(){
            int l1 = this.array1.GetLength(0);
            int c1 = this.array1.GetLength(1); 
            // int[,] matriz = new int[l1,c1];
            int[,] res = new int[c1,l1];

           // System.Console.WriteLine($"Matriz: {array1[i,j]}");

            for(int i = 0;i<l1;i++)
            {
                for(int j = 0; j<c1;j++)
                {
                    res[j,i] =  this.array1[i,j];
                    // System.Console.WriteLine(res[i,j] + " ");
                    //System.Console.WriteLine($"Matriz Transposta : {res}");
                }
            }
            return res;
            
        }

        //Função Subtração para execução sequencial
        public int[,] subtracaoSeq(){
            int [,]vet = new int [this.array1.GetLength(0),this.array1.GetLength(1)];
            for(int i = 0;i< array1.GetLength(0);i++){
                for (int j = 0; j < array1.GetLength(0); j++){
                    // System.Console.WriteLine($"Subtração os valores {this.array1[i,j]} e {this.array2[i,j]} tem como resultado: {this.array1[i,j]-this.array2[i,j]}");
                    vet[i,j] = this.array1[i,j]-this.array2[i,j];
                }
            }
            return vet;
        }

        //Função Soma para execução sequencial
        public int[,] somaSeq(){
            int [,]vet = new int[this.array1.GetLength(0),this.array1.GetLength(1)];
            for (int i = 0; i < array1.GetLength(0); i++){
                for (int j = 0; j < array1.GetLength(1); j++){
                    // System.Console.WriteLine($"Somando os valores {array1[i,j]} e {array2[i,j]} tem como resultado: {array1[i,j]+array2[i,j]}");
                    vet[i,j] = array1[i,j]+array2[i,j];
                }
            }
            return vet;
        }

        // A seguir ficam as funções utlizando Threads.

        //Função Soma para execução utilizando Threads.
        public void soma1() {
            int[,] matriz = new int[this.array1.GetLength(0),this.array1.GetLength(1)];
            for (int i=0;i<this.array1.GetLength(0)/2;i++) {
                for (int j=0;j<this.array2.GetLength(1);j++) {
                    matriz[i,j] = this.array1[i,j] + this.array2[i,j];
                }
            }
        }
        
        //Função Subtração para execução utilizando Threads.
        public void subtracao1() {   
            int[,] matriz = new int[this.array1.GetLength(0),this.array1.GetLength(1)];         
            for (int i=0;i<this.array1.GetLength(0);i++) {
                for (int j=0;j<this.array2.GetLength(1);j++) {
                    matriz[i,j] = this.array1[i,j] - this.array1[i,j];
                }
            }
        }

        //Função Multiplicação para execução utilizando Threads.
        public void multiplicacao1() {
            int l1 = this.array1.GetLength(0) ;//linha do array1
            int c1 = this.array1.GetLength(1); //coluna do array1
            int l2 = this.array2.GetLength(0); //linha do array2
            int c2 = this.array2.GetLength(1); //coluna do array2

            int res = 0;
            int[,] matriz = new int[l1,c2];

            for(int i = 0;i< l1;i++){
                for (int j = 0; j < c2; j++){
                    res = 0;
                    for(int m =0;m<c1; m++)
                    {
                        res += this.array1[i,m] * this.array2[m, j];
                    }
                    matriz[i,j] = res;
                }
            }

        }

        public void transposta1(){
            int l1 = this.array1.GetLength(0);
            int c1 = this.array1.GetLength(1); 
            int[,] res = new int[c1,l1];


            for(int i = 0;i<l1;i++)
            {
                for(int j = 0; j<c1;j++)
                {
                    res[j,i] =  this.array1[i,j];
                }
            }
        }
    }
}