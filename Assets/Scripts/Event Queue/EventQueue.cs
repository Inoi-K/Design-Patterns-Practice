using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace EventQueue {
    public class EventQueue : MonoBehaviour {
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] Animator textAnimator;

        bool isDisplaying;
        
        Queue<string> announcements = new();
        static readonly int Display = Animator.StringToHash("Display");

        void OnEnable() {
            AnnouncementBehaviour.OnNewAnnouncement += OnNewAnnouncement;
            
        }

        void OnDisable() {
            AnnouncementBehaviour.OnNewAnnouncement -= OnNewAnnouncement;
        }

        void Update() {
            CheckQueue();
        }

        void OnNewAnnouncement(string announcement) {
            announcements.Enqueue(announcement);
            Debug.Log($"CURRENT QUEUE LENGTH: {announcements.Count}");
        }
        
        // Unity animations... :\
        void CheckQueue() {
            if (announcements.Count > 0 && !isDisplaying) {
                StartCoroutine(DisplayAnnouncement(announcements.Dequeue()));
            }
        }

        IEnumerator DisplayAnnouncement(string textToDisplay, float triggerDelay = .5f) {
            isDisplaying = true;
            
            text.text = textToDisplay;
            textAnimator.SetTrigger(Display);

            // It takes some time to trigger :\
            yield return new WaitForSeconds(triggerDelay);
            yield return new WaitForSeconds(Mathf.Max(0, textAnimator.GetCurrentAnimatorStateInfo(0).length - triggerDelay));
            
            isDisplaying = false;
        }
    }
}
