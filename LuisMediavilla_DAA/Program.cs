using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisMediavilla_DAA
{
    public class punto : IComparable
    {
        public int x { get; set; }
        public int y { get; set; }
      public punto()
        {
            
        }
        public punto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int CompareTo(object obj)
        {
            if (obj is punto)
            {
                return this.x.CompareTo((obj as punto).x);
            }
            throw new ArgumentException("no estamos comparando puntos");
        }
        public double distancia(punto p1, punto p2)
        {
            return Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y));
        }
    }
    class Program
    {
        public static void imprimematriz(punto[] vector)
        {
            bool pintado = false;
            for (int x=0;x<10;x++)
            {
                for(int y=0;y<10;y++)
                {
                    for(int contador =0;contador<vector.Length;contador++)
                    {
                       pintado = false;
                       if (vector[contador] == null) break;
                       if ((vector[contador].x == x)&&(vector[contador].y == y))
                       {
                            Console.Write("|");
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(+ x + "," + y + "");
                            Console.ResetColor();
                            pintado = true;
                            break;
                        }
                    }
                    if (pintado == false)
                    {
                        Console.Write("|" + x + "," + y + "");
                    }
                }
                Console.WriteLine("|");
            }
        }





        public static void busca(punto[] vector, int num)
        {
            double d;
            int desde, hast, a, b;
            //ordenamos los puntos por la coordenada x
           
            Array.Sort(vector);
            Console.WriteLine("primera ordenacion");
            for (int contador = 0; contador < vector.Length; contador++)
            {
                
                    Console.Write("|");
                    Console.Write(+vector[contador].x + "," + vector[contador].y + "");
                             
             }
            Console.WriteLine();
             //miramos en el subconjunto de la izquierda
            //busca(vector, num / 2);
            //miramos en el subconjunto de la derecha
         //   busca(vector + num / 2, (num + 1) / 2);

        }
        static void Main(string[] args)
        {
            int npuntos;
            punto[] vector;
            //introducimos el numero de puntos a tratar
            /*  Console.WriteLine("Introduce el número de puntos a tratar (minimo 2): ");
              try
              {
                  npuntos = Convert.ToInt32(Console.ReadLine());
                  if (npuntos < 2) throw new Exception("¡¡¡minimo 2 puntos!!!");
                  Console.WriteLine("puntos: " + npuntos);
                  vector = new punto[npuntos];
              }
              catch (Exception e)
              {
                  Console.WriteLine(e);
                  Console.WriteLine("error");
                  Console.ReadKey();
                  return;
              }*/
            npuntos = 10;
            vector = new punto[npuntos];
         
           vector[0] = new punto { x = 9, y = 9 };
           vector[1] = new punto { x = 2, y = 5 };
           vector[2] = new punto { x = 5, y = 5 };
           vector[3] = new punto { x = 7, y = 1 };
           vector[4] = new punto { x = 8, y = 3 };
           vector[5] = new punto { x = 3, y = 5 };
           vector[6] = new punto { x = 4, y = 1 };
           vector[7] = new punto { x = 2, y = 9 };
           vector[8] = new punto { x = 1, y = 7 };
           vector[9] = new punto { x = 6, y = 2 };
            //introducimos los puntos en el vector de puntos
          /*  int contador = 0;
            while (contador < npuntos)
            {
                try
                {
                    Console.WriteLine("Coordenada X punto " + contador + ": ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    if (x > 9) throw new Exception("numero muy grande");
                    Console.WriteLine("Coordenada Y punto " + contador + ": ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    if (y > 9) throw new Exception("numero muy grande");
                    vector[contador] = new punto(x, y);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("error");
                    Console.ReadKey();
                    return;
                }
                contador++;
            }*/
            
            
            imprimematriz(vector);
            busca(vector, npuntos);
            Console.WriteLine("fin");
            Console.ReadLine();
        }
     
    }
}
