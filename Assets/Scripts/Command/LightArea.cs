using UnityEngine;

namespace Command {
    public class LightArea : MonoBehaviour {
        [SerializeField] Vector2 minMaxIntensity;
        [SerializeField] Light[] lightSources;
    
        float intensityRange;

        void Start() {
            intensityRange = minMaxIntensity.y - minMaxIntensity.x;
        }

        public void SetIntensityRatio(float percent) {
            float newIntensity = minMaxIntensity.x + intensityRange * percent;
            foreach (Light lightSource in lightSources)
                lightSource.intensity = newIntensity;
        }

        public float GetIntensityRatio() {
            return (lightSources[0].intensity - minMaxIntensity.x) / intensityRange;
        }

        public void SetColor(Color newColor) {
            foreach (Light lightSource in lightSources)
                lightSource.color = newColor;
        }

        public Color GetColor() {
            return lightSources[0].color;
        }
    }
}
