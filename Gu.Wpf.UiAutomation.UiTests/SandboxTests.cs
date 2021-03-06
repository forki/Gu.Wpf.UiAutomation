namespace Gu.Wpf.UiAutomation.UiTests
{
    using System;
    using System.Linq;
    using System.Windows.Automation;
    using NUnit.Framework;

    [Explicit("Script")]
    public class SandboxTests
    {
        private const string ExeFileName = "WpfApplication.exe";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(ExeFileName);
        }

        [Test]
        public void DumpTypes()
        {
            foreach (var type in typeof(UiElement).Assembly
                                                  .GetTypes()
                                                  .Where(x => typeof(UiElement).IsAssignableFrom(x)))
            {
                Console.WriteLine($"- {type.Name}");
            }
        }

        [Test]
        public void DumpButton()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "ButtonWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindButton().AutomationElement);
            }
        }

        [Test]
        public void DumpCalendar()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "CalendarWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindFirst(TreeScope.Descendants, Conditions.Calendar).AutomationElement);
            }
        }

        [Test]
        public void DumpComboBox()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "ComboBoxWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindComboBox().AutomationElement);
            }
        }

        [Test]
        public void DumpComboBoxExpanded()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "ComboBoxWindow"))
            {
                var window = app.MainWindow;
                var comboBox = window.FindComboBox();
                comboBox.Expand();
                DumpRecursive(comboBox.AutomationElement);
            }
        }

        [Test]
        public void DumpFrame()
        {
            using (var app = Application.Launch(ExeFileName, "FrameWindow"))
            {
                DumpRecursive(app.MainWindow.FindFrame().AutomationElement);
            }
        }

        [Test]
        public void DumpDataGrid()
        {
            using (var app = Application.Launch(ExeFileName, "SingleDataGridWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindDataGrid().AutomationElement);
            }
        }

        [Test]
        public void DumpDataGrid10()
        {
            using (var app = Application.Launch(ExeFileName, "DataGridWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindDataGrid("DataGrid10").AutomationElement);
            }
        }

        [Test]
        public void DumpDialog()
        {
            using (var app = Application.Launch(ExeFileName, "DialogWindow"))
            {
                var window = app.MainWindow;
                window.FindButton("Show Dialog").Click();
                var dialog = window.FindDialog();
                var element = dialog.AutomationElement;
                DumpRecursive(element);
                dialog.Close();
            }
        }

        [Test]
        public void DumpExpander()
        {
            using (var app = Application.Launch(ExeFileName, "ExpanderWindow"))
            {
                var window = app.MainWindow;
                var element = window.FindExpander().AutomationElement;
                DumpRecursive(element);
            }
        }

        [Test]
        public void DumpGridSplitterWindow()
        {
            using (var app = Application.Launch(ExeFileName, "GridSplitterWindow"))
            {
                DumpRecursive(app.MainWindow.AutomationElement);
            }
        }

        [Test]
        public void DumpOpenFileDialog()
        {
            using (var app = Application.Launch(ExeFileName, "DialogWindow"))
            {
                var window = app.MainWindow;
                window.FindButton("Show OpenFileDialog").Click();
                var dialog = window.FindOpenFileDialog();
                DumpRecursive(dialog.AutomationElement);
                dialog.AutomationElement.WindowPattern().Close();
            }
        }

        [Test]
        public void DumpSaveFileDialog()
        {
            using (var app = Application.Launch(ExeFileName, "DialogWindow"))
            {
                var window = app.MainWindow;
                window.FindButton("Show SaveFileDialog").Click();
                var dialog = window.FindSaveFileDialog();
                DumpRecursive(dialog.AutomationElement);
                dialog.AutomationElement.WindowPattern().Close();
            }
        }

        [Test]
        public void DumpMenu()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "MenuWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindMenu().AutomationElement);
            }
        }

        [Test]
        public void DumpTabControl()
        {
            using (var app = Application.Launch(ExeFileName, "TabControlWindow"))
            {
                var window = app.MainWindow;
                var element = window.FindTabControl().AutomationElement;
                DumpRecursive(element);
            }
        }

        [Test]
        public void DumpTabItem()
        {
            using (var app = Application.Launch(ExeFileName, "TabControlWindow"))
            {
                var window = app.MainWindow;
                var element = window.FindTabControl().Items[0].AutomationElement;
                DumpRecursive(element);
            }
        }

        [Test]
        public void DumpGroupBox()
        {
            using (var app = Application.Launch(ExeFileName, "GroupBoxWindow"))
            {
                var window = app.MainWindow;
                var element = window.FindGroupBox().AutomationElement;
                DumpRecursive(element);
            }
        }

        [Test]
        public void DumpRichTextBox()
        {
            using (var app = Application.Launch(ExeFileName, "RichTextBoxWindow"))
            {
                var window = app.MainWindow;
                var element = window.FindFirstDescendant(Conditions.ByClassName("RichTextBox")).AutomationElement;
                DumpRecursive(element);
            }
        }

        [Test]
        public void DumpPasswordBox()
        {
            using (var app = Application.Launch(ExeFileName, "PasswordBoxWindow"))
            {
                var window = app.MainWindow;
                var element = window.FindFirstDescendant(new PropertyCondition(AutomationElement.IsPasswordProperty, true)).AutomationElement;
                DumpRecursive(element);
            }
        }

        [Test]
        public void DumpSeparatorWindow()
        {
            using (var app = Application.Launch(ExeFileName, "SeparatorWindow"))
            {
                DumpRecursive(app.MainWindow.AutomationElement);
            }
        }

        [Test]
        public void DumpStatusBar()
        {
            using (var app = Application.Launch(ExeFileName, "StatusBarWindow"))
            {
                DumpRecursive(app.MainWindow.FindStatusBar().AutomationElement);
            }
        }

        [Test]
        public void DumpWindow()
        {
            using (var app = Application.Launch(ExeFileName, "EmptyWindow"))
            {
                var window = app.MainWindow;
                var element = window.AutomationElement;
                DumpRecursive(element);
            }
        }

        [Test]
        public void DumpDataGridItem()
        {
            using (var app = Application.Launch(ExeFileName, "DataGridWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindDataGrid()[0, 0].AutomationElement);
            }
        }

        [Test]
        public void DumpListBox()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "ListBoxWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindListBox().AutomationElement);
            }
        }

        [Test]
        public void DumpListBox10()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "ListBoxWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindListBox("ListBox10").AutomationElement);
            }
        }

        [Test]
        public void DumpListView()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "ListViewWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindListView().AutomationElement);
            }
        }

        [Test]
        public void DumpMessageBox()
        {
            using (var app = Application.Launch(ExeFileName, "DialogWindow"))
            {
                var window = app.MainWindow;
                window.FindButton("Show MessageBox OKCancel").Click();
                var messageBox = window.FindMessageBox();
                var element = messageBox.AutomationElement;
                DumpRecursive(element);
                messageBox.Close();
            }
        }

        [Test]
        public void DumpScrollViewer()
        {
            using (var app = Application.Launch(ExeFileName, "ScrollBarWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindScrollViewer().AutomationElement);
            }
        }

        [Test]
        public void DumpTextBox()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "TextBoxWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindTextBox().AutomationElement);
            }
        }

        [Test]
        public void DumpToggleButton()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "ToggleButtonWindow"))
            {
                var window = app.MainWindow;
                var toggleButton = window.FindToggleButton();
                DumpRecursive(toggleButton.AutomationElement, allPropertiesAndPatterns: true);
            }
        }

        [Test]
        public void DumpTreeView()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "TreeViewWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindTreeView().AutomationElement);
            }
        }

        private static void DumpRecursive(AutomationElement element, bool allPropertiesAndPatterns = false, string padding = "")
        {
            DumpPropertiesAndPatterns(element, allPropertiesAndPatterns, padding);
            foreach (var child in element.Children())
            {
                DumpRecursive(child, allPropertiesAndPatterns, padding + "  ");
            }
        }

        private static void DumpPropertiesAndPatterns(AutomationElement element, bool all = true, string padding = "")
        {
            if (all)
            {
                foreach (var pattern in element.GetSupportedPatterns())
                {
                    Console.WriteLine($"{padding}{pattern.ProgrammaticName}");
                    var currentPattern = element.GetCurrentPattern(pattern);
                    Console.WriteLine($"{padding}{currentPattern}");
                    var currentProperty = currentPattern.GetType().GetProperty("Current");
                    if (currentProperty != null)
                    {
                        var value = currentProperty.GetValue(currentPattern);
                        foreach (var property in value.GetType().GetProperties())
                        {
                            Console.WriteLine($"{padding}{property.Name} {property.GetValue(value)}");
                        }
                    }
                }

                foreach (var property in element.GetSupportedProperties().OrderBy(x => x.ProgrammaticName))
                {
                    Console.WriteLine($"{padding}{property.ProgrammaticName.TrimStart("AutomationElementIdentifiers.").TrimEnd("Property")} {element.GetCurrentPropertyValue(property)}");
                }

                Console.WriteLine();
            }
            else
            {
                var info = element.Current;
                Console.WriteLine($"{padding}ControlType: {info.ControlType.ProgrammaticName} (LocalizedControlType: {info.LocalizedControlType})");
                Console.WriteLine($"{padding}ClassName: {info.ClassName}");
                Console.WriteLine($"{padding}Name: {info.Name}");
                Console.WriteLine($"{padding}AutomationId: {info.AutomationId}");
                Console.WriteLine($"{padding}IsContentElement: {info.IsContentElement} IsControlElement: {info.IsControlElement}");
                Console.WriteLine($"{padding}Properties: {string.Join(", ", element.GetSupportedProperties().Select(x => x.ProgrammaticName.TrimStart("AutomationElementIdentifiers.").TrimEnd("Property")).OrderBy(x => x))}");
                Console.WriteLine($"{padding}Patterns: {string.Join(", ", element.GetSupportedPatterns().Select(x => x.ProgrammaticName.TrimEnd("Identifiers.Pattern").TrimEnd("Pattern")).OrderBy(x => x))}");
                Console.WriteLine();
            }
        }
    }
}
