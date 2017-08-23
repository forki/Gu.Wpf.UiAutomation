﻿namespace Gu.Wpf.UiAutomation.UITests.EventHandlers
{
    using System.Collections.Generic;
    using System.Threading;
    using Gu.Wpf.UiAutomation.UIA3;
    using Gu.Wpf.UiAutomation.WindowsAPI;
    using NUnit.Framework;

    [TestFixture]
    public class FocusChangedTests
    {
        [Test]
        public void FocusChangedWithPaintTest()
        {
            var app = Application.Launch("mspaint");
            var focusChangedElements = new List<string>();
            using (var automation = new UIA3Automation())
            {
                var mainWindow = app.GetMainWindow(automation);
                var x = automation.RegisterFocusChangedEvent(element => { focusChangedElements.Add(element.ToString()); });
                Thread.Sleep(100);
                var button1 = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Button).And(cf.ByText(this.GetResizeText())));
                button1.AsButton().Invoke();
                Thread.Sleep(100);
                var radio2 = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.RadioButton).And(cf.ByText(this.GetPixelsText())));
                Mouse.Click(MouseButton.Left, radio2.GetClickablePoint());
                Thread.Sleep(100);
                Keyboard.Press(VirtualKeyShort.ESCAPE);
                Thread.Sleep(100);
                automation.UnRegisterFocusChangedEvent(x);
                mainWindow.Close();
            }

            app.Dispose();
            Assert.That(focusChangedElements.Count, Is.GreaterThan(0));
        }

        private string GetResizeText()
        {
            switch (SystemLanguageRetreiver.GetCurrentOsCulture().TwoLetterISOLanguageName)
            {
                case "de":
                    return "Größe ändern";
                default:
                    return "Resize";
            }
        }

        private string GetPixelsText()
        {
            switch (SystemLanguageRetreiver.GetCurrentOsCulture().TwoLetterISOLanguageName)
            {
                case "de":
                    return "Pixel";
                default:
                    return "Pixels";
            }
        }
    }
}
