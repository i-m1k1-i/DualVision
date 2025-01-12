using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float _scaleMultiplier;

        private Vector3 _defaultScale;

        protected virtual void Start()
        {
            _defaultScale = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Vector3 targetScale = transform.localScale * _scaleMultiplier;
            StartCoroutine(ScaleButton(targetScale));
            Debug.Log("Pointer targetScale = " + targetScale);
            Debug.Log("scale multiplier " +  _scaleMultiplier);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Vector3 targetScale = _defaultScale;
            StartCoroutine(ScaleButton(targetScale));
            Debug.Log("Pointer exit, targetScale = " + targetScale);
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