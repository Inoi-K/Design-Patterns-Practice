using UnityEngine;

namespace SubclassSandbox {
    public class Thrust : Superpower {
        float shockWaveForce = 50f;
        float shockWaveRadius = 7f;
        
        public override void Activate() {
            PlaySound(AudioType.SFX_EXPLOSION);
            SpawnParticles(ParticleType.SHOCK_WAVE);
            
            Collider[] objects = Physics.OverlapSphere(hero.transform.position, shockWaveRadius);
            foreach (var obj in objects) {
                obj.GetComponent<Rigidbody>()?.AddExplosionForce(shockWaveForce, hero.transform.position, shockWaveRadius);
            }
        }
    }
}
