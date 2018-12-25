using System;
using NSubstitute;
using NUnit.Framework;

namespace LogAn
{
    public class EventRelatedTests
    {
        [Test]
        public void ctor_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = Substitute.For<IView>();

            var p = new Presenter(mockView);
            bool loadFired = false;
            mockView.Loaded += () => 
            {
                loadFired = true;
            };
            mockView.Loaded += Raise.Event<Action>();

            mockView.Received()
                .Render(Arg.Is<string>(s => s.Contains("Hello world")));
            Assert.IsTrue(loadFired);
        }
    }
}