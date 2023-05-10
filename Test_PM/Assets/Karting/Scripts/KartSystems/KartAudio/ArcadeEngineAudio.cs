using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace KartGame.KartSystems
{
    /// <summary>
    /// This class produces audio for various states of the vehicle's movement.
    /// </summary>
    public class ArcadeEngineAudio : MonoBehaviour
    {
        public float minRPM = 0;
        public float maxRPM = 1;
        ArcadeKart arcadeKart;

        void Awake()
        {
            arcadeKart = GetComponentInParent<ArcadeKart>();
        }

        void Update()
        {
            float kartSpeed     = arcadeKart != null ? arcadeKart.LocalSpeed() : 0;
            // set RPM value for the FMOD event
            float effectiveRPM = Mathf.Lerp(minRPM, maxRPM, kartSpeed);
            var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
            emitter.SetParameter("RPM", effectiveRPM);
        }
        
    }
}
