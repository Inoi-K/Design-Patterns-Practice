using UnityEngine;

namespace SubclassSandbox {
    [CreateAssetMenu(fileName = "Thrust", menuName = "Superpower/Thrust")]
    public class Thrust : Superpower {
        [SerializeField] float shockWaveForce;
        [SerializeField] float shockWaveRadius;
        [SerializeField] LayerMask ignoreMask;
        
        public override void Activate() {
            PlaySound(AudioType.SFX_EXPLOSION);
            SpawnParticles(ParticleType.SHOCK_WAVE);
            
            Collider[] objects = Physics.OverlapSphere(hero.transform.position, shockWaveRadius, ~ignoreMask);
            Debug.LogWarning(objects.Length);
            foreach (var obj in objects) {
                Rigidbody objRb = obj.GetComponent<Rigidbody>();
                if (objRb != null)
                    objRb.AddExplosionForce(shockWaveForce, hero.transform.position, shockWaveRadius);
                //obj.GetComponent<Rigidbody>()?.AddExplosionForce(shockWaveForce, hero.transform.position, shockWaveRadius);
            }
        }
    }
}
