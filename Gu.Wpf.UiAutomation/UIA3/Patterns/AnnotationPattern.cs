﻿namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    using Gu.Wpf.UiAutomation.UIA3.Converters;
    using Gu.Wpf.UiAutomation.UIA3.Identifiers;
    using UIA = Interop.UIAutomationClient;

    public class AnnotationPattern : AnnotationPatternBase<UIA.IUIAutomationAnnotationPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_AnnotationPatternId, "Annotation", AutomationObjectIds.IsAnnotationPatternAvailableProperty);
        public static readonly PropertyId AnnotationTypeIdProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_AnnotationAnnotationTypeIdPropertyId, "AnnotationTypeId");
        public static readonly PropertyId AnnotationTypeNameProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_AnnotationAnnotationTypeNamePropertyId, "AnnotationTypeName");
        public static readonly PropertyId AuthorProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_AnnotationAuthorPropertyId, "Author");
        public static readonly PropertyId DateTimeProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_AnnotationDateTimePropertyId, "DateTime");
        public static readonly PropertyId TargetProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_AnnotationTargetPropertyId, "Target").SetConverter(AutomationElementConverter.NativeToManaged);

        public AnnotationPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationAnnotationPattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }
    }
}