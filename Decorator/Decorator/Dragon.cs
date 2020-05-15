using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public class Dragon:ILizard,IBird
    {
        private Bird bird;
        private Lizard lizard;

        public Dragon()
        {
            this.bird = new Bird();
            this.lizard = new Lizard();
        }

        public void Fly ()
        {
            bird.Fly();
        }

        public void Crawl ()
        {
            lizard.Crawl();
        }

        public int Weight
        {
            get => this.Weight;
            set
            {
                lizard.Weight = value;
                bird.Weight = value;
            }
        }
    }
}
