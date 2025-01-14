using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.UI
{
    public class TurnPageButton : UIButton
    {
        [SerializeField] private bool _isNext;

        public event UnityAction PageTurnedNext;
        public event UnityAction PageTurnedPrev;

        protected override void Start()
        {
            base.Start();

            _button.onClick.AddListener(TurnPage);
        }

        private void TurnPage()
        {
            if (_isNext)
            {
                PageTurnedNext?.Invoke();
            }
            else
            {
                PageTurnedPrev?.Invoke();
            }
        }

    }
}