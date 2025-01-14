using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(AudioSource))]
    public abstract class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float _scaleMultiplier;

        protected Button _button;
        private AudioSource _audioSource;
        private Vector3 _defaultScale;

        protected virtual void Start()
        {
            _defaultScale = transform.localScale;
            _button = GetComponent<Button>();
            _audioSource = GetComponent<AudioSource>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Vector3 targetScale = transform.localScale * _scaleMultiplier;
            StartCoroutine(ScaleButton(targetScale));
            _audioSource.Play();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Vector3 targetScale = _defaultScale;
            StartCoroutine(ScaleButton(targetScale));
        }

        private IEnumerator ScaleButton(Vector3 targetScale)
        {
            Vector3 startScale = transform.localScale;
            float elapsedTime = 0;
            float duration = 0.1f;
            float currentStep;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.unscaledDeltaTime;
                currentStep = elapsedTime / duration;
                transform.localScale = Vector3.Lerp(startScale, targetScale, currentStep);
                yield return null;
            }

            transform.localScale = targetScale;
        }
    }
}