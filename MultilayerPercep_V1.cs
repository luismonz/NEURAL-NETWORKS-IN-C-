using System;
using System.Collections.Generic;

namespace PerceptronBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            //XNOR GATE
            bool sw = true;
            while (sw)
            {
                sw = false;
                //we have two layers, first one has two neurons and the second has only one
                //(see the circuit of this gate)
                Perceptron p = new Perceptron(2, new int[] { 2, 1 });
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("E1:1 E2:1 : " + p.Outputs(new float[] { 1, 1 })[0]);
                Console.WriteLine("E1:1 E2:0 : " + p.Outputs(new float[] { 1, 0 })[0]);
                Console.WriteLine("E1:0 E2:1 : " + p.Outputs(new float[] { 0, 1 })[0]);
                Console.WriteLine("E1:0 E2:0 : " + p.Outputs(new float[] { 0, 0 })[0]);
                //WEIGHT = PREVIOUS WEIGHT + MEAN OF LEARN * ERROR * ENTRY

                //LET'S TEACH   TO OUR NEURON AN AND
                if (p.Outputs(new float[] { 1, 1 })[0] != 1)
                {
                    sw = true;
                }
                if (p.Outputs(new float[] { 1, 0 })[0] != 0)
                {
                    sw = true;
                }
                if (p.Outputs(new float[] { 0, 1 })[0] != 0)
                {
                    sw = true;
                }
                if (p.Outputs(new float[] { 0, 0 })[0] != 1)
                {
                    sw = true;
                }

            }
            Console.ReadKey();
        }

    }

    class Perceptron
    {
        public List<Layer> Network = new List<Layer>();
        public int[] neuronsPerLayer;

        public Perceptron(int externalInputs, int[] NeuronsPerLayer)
        {
            Random r = new Random();
            neuronsPerLayer = NeuronsPerLayer;

            Network.Add(new Layer(externalInputs, NeuronsPerLayer[0], r));
            for(int i = 1; i < NeuronsPerLayer.Length; i++)
            {
                Network.Add(new Layer(NeuronsPerLayer[i-1], NeuronsPerLayer[i], r));
            }
        }

        public float[] Outputs(float[] externalInputs)
        {
            Network[0].Outputs(externalInputs);
            for (int i = 1; i < Network.Count; i++)
                Network[i].Outputs(Network[i - 1].Output);

            return Network[Network.Count - 1].Output;
        }

    }

    class Layer
    {
        public List<Neurona> layer = new List<Neurona>();
        public float[] Output;
        Random r;
        public Layer(int inputs, int numberofNeurons, Random R)
        {
            r = R;
            for (int i = 0; i < numberofNeurons; i++)
                layer.Add(new Neurona(inputs, r));
        }

        public void Outputs(float[] inputs)
        {
            float[] f = new float[layer.Count];
            for(int i = 0; i<layer.Count; i++)
            {
                f[i] = layer[i].Salida(inputs);
            }
            Output = f;            
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
        Random r;

        public Neurona(int NEntradas, Random R, float learnMean = 0.3f)
        {
            r = R;
            LearnMean = learnMean;
            previousweights = new float[NEntradas];
            w = new float[NEntradas];
            Aprender();
        }

        public void Aprender()
        {
            //Random r = new Random();
            //I DELETE THIS TO PREVENT FUTURE ERRORS, LIKE EACH NEURON WILL TAKE DIFFERENT NUMBER
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
