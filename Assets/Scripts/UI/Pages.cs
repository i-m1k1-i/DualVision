using UnityEngine;

namespace Assets.Scripts.UI
{
    public class Pages : MonoBehaviour
    {
        [SerializeField] private Canvas[] _pages;
        [SerializeField] private TurnPageButton _prevButton;
        [SerializeField] private TurnPageButton _nextButton;


        private int _currentPage;

        private void Start()
        {
            _currentPage = 1;
            OpenPage(_currentPage);
        }

        private void OpenNext()
        {
            if (_currentPage < _pages.Length)
            {
                OpenPage(++_currentPage);
            }
        }

        private void OpenPrev()
        {
            if (_currentPage > 1)
            {
                OpenPage(--_currentPage);
            }
        }

        private  void OpenPage(int page)
        {
            CloseAll();
            _currentPage = page;
            int pageIndex = page - 1;
            _pages[pageIndex].gameObject.SetActive(true);

            if (page == 1)
            {
                _prevButton.gameObject.SetActive(false);
                _nextButton.gameObject.SetActive(true);
            }
            else if (page == _pages.Length)
            {
                _nextButton.gameObject.SetActive(false);
                _prevButton.gameObject.SetActive(true);
            }
            else
            {
                _nextButton.gameObject.SetActive(true);
                _prevButton.gameObject.SetActive(true);
            }
        }

        private void CloseAll()
        {
            for (int i = 0; i < _pages.Length; i++)
            {
                _pages[i].gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            _prevButton.PageTurnedPrev += OpenPrev;
            _nextButton.PageTurnedNext += OpenNext;
        }
    }
}