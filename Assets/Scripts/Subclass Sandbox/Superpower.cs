using UnityEngine;
using Singleton;

namespace SubclassSandbox {
    public abstract class Superpower : ScriptableObject {
        protected HeroController hero;
        
        public void Init(HeroController hero) {
            this.hero = hero;
        }
        
        public abstract void Activate();

        protected void Move(Vector3 direction) {
            hero.Move(direction);
        }

        protected void PlaySound(AudioType soundType) {
            Game.Instance.AudioManager.PlaySound(soundType);
        }

        protected void SpawnParticles(ParticleType particleType) {
            //Game.Instance.ParticleManager.PlayParticle(particleType);
        }
    }
}
