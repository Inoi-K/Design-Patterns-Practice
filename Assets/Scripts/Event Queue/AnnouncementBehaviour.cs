using System;
using UnityEngine;

namespace EventQueue {
    public class AnnouncementBehaviour : MonoBehaviour {
        [SerializeField] string announcement;
        [SerializeField] float delay;

        public static event Action<string> OnNewAnnouncement;

        void Start() {
            Invoke(nameof(Announce), delay);
        }

        void Announce() {
            OnNewAnnouncement?.Invoke(announcement);
        }
    }
}
