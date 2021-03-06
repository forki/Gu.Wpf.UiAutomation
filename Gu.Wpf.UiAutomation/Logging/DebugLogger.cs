﻿namespace Gu.Wpf.UiAutomation.Logging
{
    public class DebugLogger : LoggerBase
    {
        /// <inheritdoc/>
        protected override void GatedDebug(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        /// <inheritdoc/>
        protected override void GatedError(string message)
        {
            System.Diagnostics.Debug.Fail(message);
        }

        /// <inheritdoc/>
        protected override void GatedFatal(string message)
        {
            System.Diagnostics.Debug.Fail(message);
        }

        /// <inheritdoc/>
        protected override void GatedInfo(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        /// <inheritdoc/>
        protected override void GatedTrace(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        /// <inheritdoc/>
        protected override void GatedWarn(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
