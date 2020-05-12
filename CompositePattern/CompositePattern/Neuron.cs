using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CompositePattern
{
    public static class ExtensionMethod
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if(ReferenceEquals(self,other))
                return;
            foreach (Neuron from in self)
            {
                foreach (Neuron to in other)
                {
                    from.Out.Add(to);
                    to.In.Add(from);
                }
            }
        }
    }
    public class Neuron : IEnumerable<Neuron>
    {
        public float Value;
        public List<Neuron> In, Out;

        public void ConnectTo(Neuron other)
        {
            Out.Add(other);
            other.In.Add(this);
        }

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public class NeuronLayer:Collection<Neuron>
    {
       
    }
}
