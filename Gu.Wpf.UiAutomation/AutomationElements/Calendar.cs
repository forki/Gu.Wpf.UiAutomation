namespace Gu.Wpf.UiAutomation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows.Automation;

    public class Calendar : MultiSelector<CalendarDayButton>
    {
        public Calendar(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        public override IReadOnlyList<CalendarDayButton> Items =>
            this.FindAllChildren(Conditions.CalendarDayButton, x => new CalendarDayButton(x));

        public TablePattern TablePattern => this.AutomationElement.TablePattern();

        public GridPattern GridPattern => this.AutomationElement.GridPattern();

        public MultipleViewPattern MultipleViewPattern => this.AutomationElement.MultipleViewPattern();

        public void Select(DateTime dateTime)
        {
            this.Select(dateTime.ToString(CultureInfo.InstalledUICulture));
        }
    }
}
