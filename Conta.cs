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
        public void soma() {
            try
            {
                System.Console.WriteLine($"Thread: {Thread.CurrentThread.Name}");
                for (int i=0;i<this.array1.GetLength(0);i++) {
                    for (int j=0;j<this.array2.GetLength(1);j++) {
                        System.Console.WriteLine($"Resultado da soma da pos [{i}][{j}]: {this.array1[i,j]+this.array2[i,j]}");
                    }
                    Thread.Sleep(random.Next(1));   
                }                
            }
            catch (System.NullReferenceException e) 
            {
                System.Console.WriteLine(e.Message);
                throw;
            }

        }

        public void subtracao() {
            try
            {
                System.Console.WriteLine($"Thread: {Thread.CurrentThread.Name}");
                for (int i=0;i<this.array1.GetLength(0);i++) {
                    for (int j=0;j<this.array2.GetLength(1);j++) {
                        System.Console.WriteLine($"Resultado da subtração da pos [{i}][{j}]: {this.array1[i,j]-this.array2[i,j]}");
                    }
                    Thread.Sleep(random.Next(1));   
                }            
            }
            catch (System.NullReferenceException e)
            {
                System.Console.WriteLine(e.Message);
                throw;
            }    

        }

        public void multiplicacao() {
            try
            {
                System.Console.WriteLine($"Thread: {Thread.CurrentThread.Name}");
                for (int i=0;i<this.array1.GetLength(0);i++) {
                    for (int j=0;j<this.array2.GetLength(1);j++) {
                        System.Console.WriteLine($"Resultado da multiplicação da pos [{i}][{j}]: {this.array1[i,j]*this.array2[i,j]}");
                    }
                    Thread.Sleep(random.Next(1));   
                }            
            }
            catch (System.NullReferenceException e)
            {
                System.Console.WriteLine(e.Message);
                throw;
            }

        }                        

    }
}