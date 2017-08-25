﻿namespace Gu.Wpf.UiAutomation.UITests.Elements
{
    using Gu.Wpf.UiAutomation.UITests.TestFramework;
    using NUnit.Framework;

    public class PopupTests : UITestBase
    {
        public PopupTests()
            : base(TestApplicationType.Wpf)
        {
        }

        [Test]
        public void CheckBoxInPopupTest()
        {
            var window = this.App.MainWindow();
            var btn = window.FindFirstDescendant(cf => cf.ByAutomationId("PopupToggleButton1")).AsToggleButton();
            btn.Click();
            Wait.UntilInputIsProcessed();
            var popup = window.Popup;
            Assert.That(popup, Is.Not.Null);
            var popupChildren = popup.FindAllChildren();
            Assert.That(popupChildren, Has.Length.EqualTo(1));
            var check = popupChildren[0].AsCheckBox();
            Assert.That(check.Text, Is.EqualTo("This is a popup"));
        }

        [Test]
        public void MenuInPopupTest()
        {
            var window = this.App.MainWindow();
            var btn = window.FindFirstDescendant(cf => cf.ByAutomationId("PopupToggleButton2")).AsToggleButton();
            btn.Click();
            Wait.UntilInputIsProcessed();
            var popup = window.Popup;
            Assert.That(popup, Is.Not.Null);
            var popupChildren = popup.FindAllChildren();
            Assert.That(popupChildren, Has.Length.EqualTo(1));
            var menu = popupChildren[0].AsMenu();
            Assert.AreEqual(1, menu.Items.Count);
            var menuItem = menu.Items[0];
            Assert.That(menuItem.Text, Is.EqualTo("Some MenuItem"));
        }
    }
}
