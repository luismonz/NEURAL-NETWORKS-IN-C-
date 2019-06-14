using System;

namespace PerceptronBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            float w1, w2, umbral;

            Random r = new Random();
            bool sw = false;
            while (!sw)
            {
                sw = true;

                //FOR TRUE 
                w1 = Convert.ToSingle(r.NextDouble() - r.NextDouble());
                w2 = Convert.ToSingle(r.NextDouble() - r.NextDouble());
                umbral = Convert.ToSingle(r.NextDouble() - r.NextDouble());
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("W1: " + w1);
                Console.WriteLine("W2: " + w2);
                Console.WriteLine("UMBRAL: " + umbral);
                Console.WriteLine("E1:1 E2:1 : " + p.funcion(p.Neurona(1f, 1f, w1, w2, umbral)));
                Console.WriteLine("E1:1 E2:0 : " + p.funcion(p.Neurona(1f, 0f, w1, w2, umbral)));
                Console.WriteLine("E1:0 E2:1 : " + p.funcion(p.Neurona(0f, 1f, w1, w2, umbral)));
                Console.WriteLine("E1:0 E2:0 : " + p.funcion(p.Neurona(0f, 0f, w1, w2, umbral)));

                if (p.funcion(p.Neurona(1f, 1f, w1, w2, umbral)) != 1)
                {
                    sw = false;
                }
                if (p.funcion(p.Neurona(1f, 0f, w1, w2, umbral)) != 1)
                {
                    sw = false;
                }
                if (p.funcion(p.Neurona(0f, 1f, w1, w2, umbral)) != 1)
                {
                    sw = false;
                }
                if (p.funcion(p.Neurona(0f, 0f, w1, w2, umbral)) != 0)
                {
                    sw = false;
                }

            }

            Console.ReadKey();
        }

        float Neurona(float e1, float e2, float w1, float w2, float umbral)
        {
            return umbral + e1 * w1 + e2 * w2;
        }


        public float funcion(float d)
        {
            return d > 0 ? 1 : 0;
        }

    }
}
