using System;

namespace PerceptronBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            Neurona p = new Neurona();
            Random r = new Random();

            p.w = new float[2];
            p.umbral = 0f;

            //ERROR = IS WHAT WE NEED - ALL WE HAVE
            //MEAN OF LEARN = 0.3F
            //WEIGHT = PREVIOUS WEIGHT + MEAN OF LEARN * ERROR * ENTRY
            float[] previousweights = new float[0];
            float previousUmbral = -10;

            bool sw = false;
            while (!sw)
            {
                sw = true;
                p.w[0] = Convert.ToSingle(r.NextDouble() - r.NextDouble());
                p.w[1] = Convert.ToSingle(r.NextDouble() - r.NextDouble());
                p.umbral = Convert.ToSingle(r.NextDouble() - r.NextDouble());

                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("W1: " + p.w[0]);
                Console.WriteLine("W2: " + p.w[1]);
                Console.WriteLine("UMBRAL: " + p.umbral);
                Console.WriteLine("E1:1 E2:1 : " + p.Salida(new float[2] { 1f, 1f }));
                Console.WriteLine("E1:1 E2:0 : " + p.Salida(new float[2] { 1f, 0f }));
                Console.WriteLine("E1:0 E2:1 : " + p.Salida(new float[2] { 0f, 1f }));
                Console.WriteLine("E1:0 E2:0 : " + p.Salida(new float[2] { 0f, 0f }));
                //WEIGHT = PREVIOUS WEIGHT + MEAN OF LEARN * ERROR * ENTRY

                //LET'S TEACJ TO OUR NEURON AN AND
                if (p.Salida(new float[2] { 1f, 1f }) != 1)
                {
                    sw = false;
                }
                if (p.Salida(new float[2] { 1f, 0f }) != 0)
                {
                    sw = false;
                }
                if (p.Salida(new float[2] { 0f, 1f }) != 0)
                {
                    sw = false;
                }
                if (p.Salida(new float[2] { 0f, 0f }) != 0)
                {
                    sw = false;
                }
            }
            Console.ReadKey();
        }

    }

    public class Neurona
    {
        public float[] w; //weights
        public float umbral;

        public float Salida(float[] ent)
        {
            return Sigmoid(neurona(ent));
        }

        float neurona(float[] ent)
        {
            float sum = 0;

            for (int i = 0; i < w.Length; i++)
                sum += ent[i] * w[i];

            sum += umbral;

            return sum;
        }

        float Sigmoid(float d)
        {
            //AN APPROX. TO THE SIGMOID
            return d > 0 ? 1 : 0;
        }

    }

}
