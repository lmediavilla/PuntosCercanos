using System;

namespace LuisMediavilla_DAA
{

    public class punto : IComparable
    {
        public double x { get; set; }
        public double y { get; set; }
 
        public int CompareTo(object obj)
        {
            if (obj is punto)
            {
                return this.x.CompareTo((obj as punto).x);
            }
            throw new ArgumentException("no estamos comparando puntos");
        }
    }
    class Program
    {
        public static punto c1 = new punto();
        public static punto c2 = new punto();
        static double mindist = Double.MaxValue;
        public static double distancia;
        static void busca(punto[] p)
        {
            double d;
            int desde, hasta, a, b;
            int num = p.Length;
            if (num <= 1) 
            {
                   return;
            }
            //subvecotr izquierdo
            punto[] pI = new punto[(num / 2)];
        
            for (int i = 0; i < pI.Length; i++)
            {
                pI[i] = p[i];
            }
            busca(pI);
            //subvector derecho
            punto[] pD = new punto[p.Length - pI.Length-1];
            for (int i = 0; i < pD.Length; i++)
            {
                pD[i] = p[p.Length - i - 1];
            }
            busca(pD);
       
            // Hallar los límites del conjunto central.
          // for (desde = num / 2; desde > 0 && p[num / 2].x - p[desde].x < mindist; desde--) ;
           // Console.WriteLine("p[num / 2].x: " + p[num / 2].x);
          //  Console.WriteLine("p[desde].x" + p[num/2].x);
           desde = num / 2;
            while(desde > 0 && p[num / 2].x - p[desde].x < mindist)
            {
               desde--;

            }
          //  for (hasta = num / 2; hasta < num - 1 && p[hasta].x - p[num / 2].x < mindist; hasta++) ;
            hasta = num / 2;
            while (hasta < num - 1 && p[hasta].x - p[num / 2].x < mindist)
            {
                    hasta++;
 
            }
            // Búsqueda minimos en el conjunto central
            for (a = desde; a <= hasta; a++)
            {
                for (b = a + 1; b <= hasta; b++)
                {
                    d = pitagoras(p[a], p[b]);
                    if (d < mindist)
                    {
                        mindist = d;
                        c1.x = p[a].x;
                        c1.y = p[a].y;
                        c2.x = p[b].x;
                        c2.y = p[b].y;
                    }
                }
            }
            distancia = pitagoras(c1,c2);
        }
        public static double pitagoras(punto p1, punto p2)
        {
            return Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y));
        }
        public static void imprimematriz(punto[] vector)
        {
            int max;
            if(vector[vector.Length - 1].x> vector[vector.Length - 1].y)
            {
                max = Convert.ToInt32(vector[vector.Length - 1].x);
            }
            else
            {
                max = Convert.ToInt32(vector[vector.Length - 1].y);
            }
            
            bool pintado = false;
            for (int x = 0; x <= max; x++)
            {
                for (int y = 0; y <= max; y++)
                {
                    for (int contador = 0; contador < vector.Length; contador++)
                    {
                        pintado = false;
                        if (vector[contador] == null) break;
                        if ((vector[contador].x == x) && (vector[contador].y == y))
                        {
                            Console.Write("|");
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(+x + "," + y + "");
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
        public static void dividevector(punto[] p)
        {
            int num = p.Length;
            if (num <= 1) // Si no hay pares de puntos:
            {
                Console.WriteLine("fin");
                return; // salir.
            }
            Console.WriteLine("Vector P");
            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine("p[i].x: " + p[i].x + "  " + "p[i].y: " + p[i].y);
            }
            Console.WriteLine("----------------------------------");
            punto[] pI = new punto[(num / 2)];
            punto[] pD = new punto[p.Length-(num/2)];
            for (int i = 0; i < num / 2 ; i++)
            {
                pI[i] = p[i];
            }
            Console.WriteLine("Vector izquierdo: ");
            for (int i = 0; i < pI.Length; i++)
            {
                Console.WriteLine("pI[i].x: " + pI[i].x + "  " + "pI[i].y: " + pI[i].y);
            }
            Console.WriteLine("----------------------------------");
            // Mirar en el subconjunto de la derecha.

            for (int i = 0; i < pD.Length; i++)
            {
                pD[i] = p[p.Length - i-1];
            }
            Console.WriteLine("Vector derecho: ");
            for (int i = 0; i < pD.Length; i++)
            {
                Console.WriteLine("pD[i].x: " + pD[i].x + "  " + "pD[i].y: " + pD[i].y);
            }
            Console.WriteLine("----------------------------------");
            dividevector(pI);
            dividevector(pD);


        }
        static void Main(string[] args)
        {
           //int a, num;

            /*   punto[] vector = new punto[6];
               vector[0] = new punto { x = 2d, y = 3d };
               vector[1] = new punto { x = 12d, y = 30d };
               vector[2] = new punto { x = 40d, y = 50d };
               vector[3] = new punto { x = 5d, y = 1d };
               vector[4] = new punto { x = 13d, y = 10d };
               vector[5] = new punto { x = 3d, y = 4d };*/
            //primero ordenamos el vector por su valor de X

            //dividevector(vector);
            punto[] vector;
            int contador = 0;
             int   npuntos = 0;
             //introducimos los puntos en el vector de puntos
              
            Console.WriteLine("Introduce el número de puntos a tratar (minimo 2): ");
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
            }
            
            while (contador < npuntos)
            {
                try
                {
                    Console.WriteLine("Coordenada X punto " + contador + ": ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    if (x < 0) throw new Exception("numero muy pequeño");
                    Console.WriteLine("Coordenada Y punto " + contador + ": ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    if (y < 0) throw new Exception("numero muy pequeño");
                    vector[contador] = new punto { x = x, y = y };
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("error");
                    Console.ReadKey();
                    return;
                }
                contador++;
            }
            
            Array.Sort(vector);
            imprimematriz(vector);
            busca(vector);
           Console.WriteLine("Soluicon x1:" + c1.x + " y1:" + c1.y + " x2:" + c2.x + " y2:" + c2.y);
            Console.WriteLine("Con distancia: " + distancia);
            Console.ReadLine();
        }
    }
}
