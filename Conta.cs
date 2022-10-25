namespace Arq2_Thread
{
    public class Conta
    {   
        public int[,] array1 { get; set; }
        public int[,] array2 { get; set; }

        public Conta(int [,] array1, int[,] array2) {
            this.array1 = array1; 
            this.array2 = array2;
        }
        public void soma() {
            for (int i=0;i<this.array1.GetLength(0);i++) {
                for (int j=0;j<this.array2.GetLength(1);j++) {
                    System.Console.WriteLine($"Resultado da soma da pos [{i}][{j}]: {this.array1[i,j]+this.array2[i,j]}");
                }
            }
        }
    }// da uma zoiada no programs-> q é a mains !
}