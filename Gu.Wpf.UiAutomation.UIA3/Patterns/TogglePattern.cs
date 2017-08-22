﻿using Gu.Wpf.UiAutomation;
using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.Patterns;
using Gu.Wpf.UiAutomation.Tools;
using Gu.Wpf.UiAutomation.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    public class TogglePattern : TogglePatternBase<UIA.IUIAutomationTogglePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TogglePatternId, "Toggle", AutomationObjectIds.IsTogglePatternAvailableProperty);
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ToggleToggleStatePropertyId, "ToggleState");

        public TogglePattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTogglePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public override void Toggle()
        {
            ComCallWrapper.Call(() => NativePattern.Toggle());
        }
    }

    public class TogglePatternProperties : ITogglePatternProperties
    {
        public PropertyId ToggleState => TogglePattern.ToggleStateProperty;
    }
}
