﻿namespace Gu.Wpf.UiAutomation
{
    public abstract class DragPatternBase<TNativePattern> : PatternBase<TNativePattern>, IDragPattern
    {
        private AutomationProperty<string> dropEffect;
        private AutomationProperty<string[]> dropEffects;
        private AutomationProperty<bool> isGrabbed;
        private AutomationProperty<AutomationElement[]> grabbedItems;

        protected DragPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }

        /// <inheritdoc/>
        public IDragPatternProperties Properties => this.Automation.PropertyLibrary.Drag;

        /// <inheritdoc/>
        public IDragPatternEvents Events => this.Automation.EventLibrary.Drag;

        /// <inheritdoc/>
        public AutomationProperty<string> DropEffect => this.GetOrCreate(ref this.dropEffect, this.Properties.DropEffect);

        /// <inheritdoc/>
        public AutomationProperty<string[]> DropEffects => this.GetOrCreate(ref this.dropEffects, this.Properties.DropEffects);

        /// <inheritdoc/>
        public AutomationProperty<bool> IsGrabbed => this.GetOrCreate(ref this.isGrabbed, this.Properties.IsGrabbed);

        /// <inheritdoc/>
        public AutomationProperty<AutomationElement[]> GrabbedItems => this.GetOrCreate(ref this.grabbedItems, this.Properties.GrabbedItems);
    }
}
