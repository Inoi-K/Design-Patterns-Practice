using UnityEngine;

namespace SubclassSandbox {
    public class SkyLaunch : Superpower {
        Vector3 launchDirection = new Vector3(0, 0, 20); // these hard-coded values irritate me
        
        public override void Activate() {
            // reminds me of the state pattern...
            if (hero.transform.position.y < 1f) {
                PlaySound(AudioType.SFX_LAUNCH);
                SpawnParticles(ParticleType.DUST);
                Move(launchDirection); 
            } else if (hero.transform.position.y < 10f) {
                PlaySound(AudioType.SFX_SWOOP);
                Move(launchDirection);
            }
        }
    }
}
