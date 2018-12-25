using System;

namespace LogAn
{
    public class Presenter
    {
        private readonly IView _view;

        public Presenter(IView view)
        {
            _view = view;
            _view.Loaded += OnLoaded;
        }

        private void OnLoaded()
        {
            _view.Render("Hello world");
        }
    }
}