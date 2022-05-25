using UnityEngine;

namespace SubclassSandbox {
    [CreateAssetMenu(fileName = "SkyLaunch", menuName = "Superpower/SkyLaunch")]
    public class SkyLaunch : Superpower {
        [SerializeField] Vector3 launchDirection;
        [SerializeField] float swoopHeight;
        
        public override void Activate() {
            // reminds me of the state pattern...
            if (hero.transform.position.y < swoopHeight / 2f) {
                PlaySound(AudioType.SFX_LAUNCH);
                SpawnParticles(ParticleType.DUST);
                Move(launchDirection); 
            } else if (hero.transform.position.y < swoopHeight) {
                PlaySound(AudioType.SFX_SWOOP);
                Move(launchDirection);
            }
        }
    }
}
