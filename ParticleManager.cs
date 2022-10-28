using System;

namespace app
{
    internal class ParticleManager
    {
        static int MaxParticleCount { get { return 15; } }
        int ParticleCount {
            get
            {
                int count = 0;
                for (int i = 0; i < Particles.Count; i++)
                {
                    if (Particles[i] != null)
                        count++;
                }
                return count; 
            } 
        }
        readonly List<Particle> Particles = new List<Particle>();
        int randomSpawnerProbabiltyCounter = 6;

        public void Update()
        {
            Spawner();
            Renderer();
        }

        void Spawner()
        {
            if (ParticleCount < MaxParticleCount)
            {
                if (Program.random.Next() % randomSpawnerProbabiltyCounter == 0)
                {
                    Particles.Add(new());
                    randomSpawnerProbabiltyCounter = 6;
                }
                else
                {
                    randomSpawnerProbabiltyCounter--;
                }
            }
        }

        void Renderer()
        {
            for (int i = 0; i < Particles.Count; i++)
            {
                if (Particles[i].IsDead || Particles[i] == null)
                    Particles[i] = new();
                Particles[i].Render();
            }
        }
    }
}
