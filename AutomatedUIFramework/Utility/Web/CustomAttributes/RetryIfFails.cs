using System;
using System.Configuration;
using NUnit.Framework;

namespace AutomatedUIFramework.Utility.Web.CustomAttributes
{
    /// <summary>
    /// RetryIfFailsAttribute may be applied to test case in order
    /// to run it multiple times based on app setting.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class RetryIfFailsAttribute : RetryAttribute
    {

        private const int DEFAULT_TRIES = 1;
        static Lazy<int> numberOfRetries = new Lazy<int>(() => {
            int count = 0;
            return int.TryParse(ConfigurationManager.AppSettings["retryTest"], out count) ? count : DEFAULT_TRIES;
        });

        public RetryIfFailsAttribute() : base(numberOfRetries.Value)
        {
        }
    }
}
