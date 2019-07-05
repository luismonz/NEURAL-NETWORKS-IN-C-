using System;

namespace PerceptronBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            Neurona p = new Neurona(2, 100f); //two inputs
            //TRY THE LEARN MEAN 0, 0.5f, 1f
            Random r = new Random();

            //ERROR = IS WHAT WE NEED - WHAT WE HAVE
            //MEAN OF LEARN = 0.3F
            //WEIGHT = PREVIOUS WEIGHT + MEAN OF LEARN * ERROR * ENTRY

            bool sw = false;
            while (!sw)
            {
                sw = true;

                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("W1: " + p.w[0]);
                Console.WriteLine("W2: " + p.w[1]);
                Console.WriteLine("UMBRAL: " + p.Umbral);
                Console.WriteLine("E1:1 E2:1 : " + p.Salida(new float[2] { 1f, 1f }));
                Console.WriteLine("E1:1 E2:0 : " + p.Salida(new float[2] { 1f, 0f }));
                Console.WriteLine("E1:0 E2:1 : " + p.Salida(new float[2] { 0f, 1f }));
                Console.WriteLine("E1:0 E2:0 : " + p.Salida(new float[2] { 0f, 0f }));
                //WEIGHT = PREVIOUS WEIGHT + MEAN OF LEARN * ERROR * ENTRY

                //LET'S TEACH   TO OUR NEURON AN AND
                if (p.Salida(new float[2] { 1f, 1f }) != 1)
                {
                    p.Aprender(new float[2] { 1f, 1f }, 1);
                    sw = false;
                }
                if (p.Salida(new float[2] { 1f, 0f }) != 0)
                {
                    p.Aprender(new float[2] { 1f, 0f }, 0);
                    sw = false;
                }
                if (p.Salida(new float[2] { 0f, 1f }) != 0)
                {
                    p.Aprender(new float[2] { 0f, 1f }, 0);
                    sw = false;
                }
                if (p.Salida(new float[2] { 0f, 0f }) != 0)
                {
                    p.Aprender(new float[2] { 0f, 0f }, 0);
                    sw = false;
                }

            }
            Console.ReadKey();
        }

    }

    public class Neurona
    {
        float[] previousweights;
        float previousumbral;
        //WEIGHT = PREVIOUSWEIGHT + MEAN LEARN * ERROR * INPUT
        public float[] w; //weights
        public float Umbral; //UMBRAL
        public float LearnMean = 0.3f;

        public Neurona(int NEntradas, float learnMean = 0.3f)
        {
            LearnMean = learnMean;
            previousweights = new float[NEntradas];
            w = new float[NEntradas];
            Aprender();
        }

        public void Aprender()
        {
            Random r = new Random();
            for(int i = 0; i < previousweights.Length; i++)
                previousweights[i] = Convert.ToSingle(r.NextDouble() - r.NextDouble());
            previousumbral = Convert.ToSingle(r.NextDouble() - r.NextDouble());
            w = previousweights;
            Umbral = previousumbral;
        }

        public void Aprender(float[] inputs, float expectInput)
        {
            float error = expectInput - Salida(inputs);
            for (int i = 0; i < w.Length; i++)
            {
                w[i] = previousweights[i] + LearnMean * error * inputs[i];
            }
            Umbral = previousumbral + LearnMean * error;

            previousweights = w;
            previousumbral = Umbral;
        }

        public float Salida(float[] ent)
        {
            return Sigmoid(neurona(ent));
        }

        float neurona(float[] ent)
        {
            float sum = 0;

            for (int i = 0; i < w.Length; i++)
                sum += ent[i] * w[i];

            sum += Umbral;

            return sum;
        }

        float Sigmoid(float d)
        {
            //AN APPROX. TO THE SIGMOID
            return d > 0 ? 1 : 0;
        }

    }

}
