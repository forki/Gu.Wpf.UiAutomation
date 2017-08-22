﻿using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
using Gu.Wpf.UiAutomation.Definitions;
using Gu.Wpf.UiAutomation.UITests.TestFramework;
using NUnit.Framework;

namespace Gu.Wpf.UiAutomation.UITests.Patterns
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class GridPatternTests : UITestBase
    {
        private AutomationElement _dataGrid;

        public GridPatternTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [OneTimeSetUp]
        public void SelectTab()
        {
            var mainWindow = App.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            var tabItem = tab.SelectTabItem(1);
            _dataGrid = tabItem.FindFirstDescendant(cf => cf.ByAutomationId("dataGrid1"));
        }

        [Test]
        public void GridTest()
        {
            var dataGrid = _dataGrid;
            Assert.That(dataGrid, Is.Not.Null);
            var gridPattern = dataGrid.Patterns.Grid.Pattern;
            Assert.That(gridPattern, Is.Not.Null);
            Assert.That(gridPattern.ColumnCount.Value, Is.EqualTo(2));
            Assert.That(gridPattern.RowCount.Value, Is.EqualTo(3));
            var item = gridPattern.GetItem(1, 1);
            Assert.That(item.Properties.Name.Value, Is.EqualTo("Patrick"));
        }
    }
}
