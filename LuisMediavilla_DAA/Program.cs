using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisMediavilla_DAA
{
 
    public class punto
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
    }
    class Program
    {
        public static float distancia(punto p1, punto p2)
        {
            return (float)Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y));
        }
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
        public static float fuerzabruta(punto[] vector, int num)
        {
            //este codigo se ejecuta cuando solo quedan 3 puntos o menos
            float min = float.MaxValue;
            for(int i=0;i<num;i++)
            {
                for(int j=i+1;j<num;j++)
                {
                    min = distancia(vector[i], vector[j]);
                }
            }
            return min;
        }
        public static float min(float x, float y)
        {
            if(x<y)
            {
                return x;
            }
            else
            {
                return y;
            }
        }
        static float stripClosest(punto[] vector, int tamano, float d)
        {
            float min = d;
            for (int i = 0; i < tamano; ++i)
            {
                for (int j = i + 1; j < tamano && (vector[j].y - vector[i].y) < min; ++j)
                {
                    if (distancia(vector[i], vector[j]) < min)
                    {
                        min = distancia(vector[i], vector[j]);
                    }
                }
             }
            return min;
        }
        public static float busca(punto[] vectorX, punto[] vectorY, int num)
        {
            if(num<=3)
            {
                fuerzabruta(vectorX, num);
            }
            //buscamos el punto medio
            int medio = num / 2;
            punto pmedio = vectorX[medio];
            //dividimos por una linea vertical

            punto[] vectorYizq = new punto[medio+1];
            punto[] vectorYdcha = new punto[num - medio - 1];
            Console.WriteLine("long Num:" + num);
            Console.WriteLine("long Total:" + vectorY.Length);
            Console.WriteLine("long Yizq:" + vectorYizq.Length);
            Console.WriteLine("long Ydcha:" + vectorYdcha.Length);
            int li = 0;
            int ri = 0;
            for(int i=0;i<num;i++)
            {
                if(vectorY[i].x<=pmedio.x)
                {
                    
                    vectorYizq[li] = vectorY[i];
                    li++;
                    Console.WriteLine("Izquierda i: " + i);
                }
                else
                {
                  
                    vectorYdcha[ri] = vectorY[i];
                    ri++;
                    Console.WriteLine("Derecha i: " + i);
                }
            }

            float DL = busca(vectorX, vectorYizq, medio);
            punto[] vectorXdcha = new punto[num/2];
            for(int i=0;i<vectorX.Length;i++)
            {
                vectorXdcha[i] = vectorX[i];
            }
            float DR = busca(vectorXdcha,vectorYdcha, num-medio);
            //distancia minima total Dl Dr
            float Dlr = min(DL,DR);
            //creamos un vector con los puntos de metor distancia de Dlr
            punto[] strip = new punto[num];
            int x = 0;
            for(int i=0;i< num; i++)
            {
                if(Math.Abs(vectorY[i].x - pmedio.x)<Dlr)
                {
                    strip[x] = vectorY[i];
                    x++;
                }
            }
            return min(Dlr, stripClosest(strip, x, Dlr));
        }
        static float cercano(punto[] vector, int num)
        {
            punto[] vectorX = new punto[num];
            punto[] vectorY = new punto[num];
            for (int i=0;i<vector.Length;i++)
            {
                vectorX[i] = vector[i];
                vectorY[i] = vector[i];
            }
            Array.Sort(vectorX, (f1, f2) => f1.x.CompareTo(f2.x));
            Array.Sort(vectorY, (P1, P2) => P1.y.CompareTo(P2.y));
            Console.WriteLine("Ordenados por X");
            for (int contador = 0; contador < vector.Length; contador++)
            {
                Console.Write("|");
                Console.Write(+vectorX[contador].x + "," + vectorX[contador].y + "");
            }
            Console.WriteLine("|");
            Console.WriteLine("Ordenados por Y");
            for (int contador = 0; contador < vector.Length; contador++)
            {
                Console.Write("|");
                Console.Write(+vectorY[contador].x + "," + vectorY[contador].y + "");
            }
            Console.WriteLine("|");
            return busca(vectorX, vectorY, num);
        }
        static void Main(string[] args)
        {
            int npuntos;
            punto[] vector;
            //comenta las siguietnes lineas 
            npuntos = 6;
            vector = new punto[npuntos];
            vector[0] = new punto { x = 2, y = 3 };
            vector[1] = new punto { x = 12, y = 30 };
            vector[2] = new punto { x = 40, y = 50 };
            vector[3] = new punto { x = 5, y = 1 };
            vector[4] = new punto { x = 12, y = 10 };
            vector[5] = new punto { x = 3, y = 4 };
            //comenta las siguientes lineas si quieres introducir los parametros manualmente
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
           // imprimematriz(vector);
            Console.WriteLine("la respuesta es: "+ cercano(vector, npuntos));
            Console.WriteLine("fin");
            Console.ReadLine();
        }
     
    }
}
