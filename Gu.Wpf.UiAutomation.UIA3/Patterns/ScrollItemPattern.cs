﻿namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    using Gu.Wpf.UiAutomation.UIA3.Identifiers;
    using UIA = Interop.UIAutomationClient;

    public class ScrollItemPattern : PatternBase<UIA.IUIAutomationScrollItemPattern>, IScrollItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_ScrollItemPatternId, "ScrollItem", AutomationObjectIds.IsScrollItemPatternAvailableProperty);

        public ScrollItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationScrollItemPattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }

        public void ScrollIntoView()
        {
            ComCallWrapper.Call(() => this.NativePattern.ScrollIntoView());
        }
    }
}
