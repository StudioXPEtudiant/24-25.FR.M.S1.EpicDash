using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace StudioXP.Scripts.Components.Objects
{
    public class TimerEvent : MonoBehaviour
    {
        [LabelText("Temps du timer")]
        [MinValue(0)]
        [SerializeField] private float time;

        [LabelText("Commence au lancement du jeu")]
        [SerializeField] private bool startOnGameStart;

        [LabelText("En boucle")]
        [SerializeField] private bool loop;

        [LabelText("A la fin du timer")]
        [SerializeField] private UnityEvent OnTimerEnd;

        private bool activated = false;

        private void Start()
        {
            if(startOnGameStart) { StartTimer(); }
        }

        private void EndTimer()
        {
            OnTimerEnd.Invoke();

            activated = false;

            if(loop) { StartTimer(); }
        }

        public void StopTimer()
        {
            StopAllCoroutines();
            activated = false;
        }

        public void StartTimer()
        {
            if (activated) {return;}

            activated = true;
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(time);
            EndTimer();
        }
    }
}
