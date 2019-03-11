﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Allure.Commons;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace Unickq.SpecFlow.Selenium.Allure
{
    public static class PluginHelper
    {
//        static ScenarioInfo emptyScenarioInfo = new ScenarioInfo().;

        private static FeatureInfo emptyFeatureInfo = new FeatureInfo(
            CultureInfo.CurrentCulture, string.Empty, string.Empty);

        public static PluginConfiguration PluginConfiguration =
            GetConfiguration(AllureLifecycle.Instance.JsonConfiguration);

        private static PluginConfiguration GetConfiguration(string allureConfiguration)
        {
            var config = new PluginConfiguration();
            var specflowSection = JObject.Parse(allureConfiguration)["specflow"];
            if (specflowSection != null)
                config = specflowSection.ToObject<PluginConfiguration>();
            return config;
        }

        internal static StatusDetails GetStatusDetails(Exception ex)
        {
            return new StatusDetails
            {
                message = ex.GetType().Name,
                trace = ex.Message
            };
        }

        public static Tuple<List<Label>, List<Link>> GetTags(FeatureInfo featureInfo, ScenarioInfo scenarioInfo)
        {
            var result = Tuple.Create(new List<Label>(), new List<Link>());

            var tags = scenarioInfo.Tags
                .Union(featureInfo.Tags)
                .Distinct(StringComparer.CurrentCultureIgnoreCase);

            foreach (var tag in tags)
            {
                var tagValue = tag;
                // link
                if (TryUpdateValueByMatch(PluginConfiguration.links.link, ref tagValue))
                {
                    result.Item2.Add(new Link {name = tagValue, url = tagValue});
                    continue;
                }

                // issue
                if (TryUpdateValueByMatch(PluginConfiguration.links.issue, ref tagValue))
                {
                    result.Item2.Add(Link.Issue(tagValue, tagValue));
                    continue;
                }

                // tms
                if (TryUpdateValueByMatch(PluginConfiguration.links.tms, ref tagValue))
                {
                    result.Item2.Add(Link.Tms(tagValue, tagValue));
                    continue;
                }

                // parent suite
                if (TryUpdateValueByMatch(PluginConfiguration.grouping.suites.parentSuite, ref tagValue))
                {
                    result.Item1.Add(Label.ParentSuite(tagValue));
                    continue;
                }

                // suite
                if (TryUpdateValueByMatch(PluginConfiguration.grouping.suites.suite, ref tagValue))
                {
                    result.Item1.Add(Label.Suite(tagValue));
                    continue;
                }

                // sub suite
                if (TryUpdateValueByMatch(PluginConfiguration.grouping.suites.subSuite, ref tagValue))
                {
                    result.Item1.Add(Label.SubSuite(tagValue));
                    continue;
                }

                // epic
                if (TryUpdateValueByMatch(PluginConfiguration.grouping.behaviors.epic, ref tagValue))
                {
                    result.Item1.Add(Label.Epic(tagValue));
                    continue;
                }

                // story
                if (TryUpdateValueByMatch(PluginConfiguration.grouping.behaviors.story, ref tagValue))
                {
                    result.Item1.Add(Label.Story(tagValue));
                    continue;
                }

                // package
                if (TryUpdateValueByMatch(PluginConfiguration.grouping.packages.package, ref tagValue))
                {
                    result.Item1.Add(Label.Package(tagValue));
                    continue;
                }

                // test class
                if (TryUpdateValueByMatch(PluginConfiguration.grouping.packages.testClass, ref tagValue))
                {
                    result.Item1.Add(Label.TestClass(tagValue));
                    continue;
                }

                // test method
                if (TryUpdateValueByMatch(PluginConfiguration.grouping.packages.testMethod, ref tagValue))
                {
                    result.Item1.Add(Label.TestMethod(tagValue));
                    continue;
                }

                // owner
                if (TryUpdateValueByMatch(PluginConfiguration.labels.owner, ref tagValue))
                {
                    result.Item1.Add(Label.Owner(tagValue));
                    continue;
                }

                // severity
                if (TryUpdateValueByMatch(PluginConfiguration.labels.severity, ref tagValue) &&
                    Enum.TryParse(tagValue, out SeverityLevel level))
                {
                    result.Item1.Add(Label.Severity(level));
                    continue;
                }

                // tag
                if (!tagValue.Contains("Browser"))
                    result.Item1.Add(Label.Tag(tagValue));
            }

            return result;
        }

        private static bool TryUpdateValueByMatch(string expression, ref string value)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(expression))
                return false;

            Regex regex = null;
            try
            {
                regex = new Regex(expression,
                    RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                return false;
            }

            if (regex == null)
                return false;

            if (regex.IsMatch(value))
            {
                var groups = regex.Match(value).Groups;
                if (groups?.Count == 1)
                    value = groups[0].Value;
                else
                    value = groups[1].Value;

                return true;
            }

            return false;
        }

        public static void WrapInStep(this AllureLifecycle allureInstance, Action action, string stepName = "")
        {
            var id = Guid.NewGuid().ToString();
            var stepResult = new StepResult {name = stepName};
            try
            {
                allureInstance.StartStep(id, stepResult);
                action.Invoke();
                allureInstance.StopStep(step => stepResult.status = Status.passed);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($" > WARN - You can't use step {stepName} here. Allure hasn't been initialized");
                action.Invoke();
            }
            catch (Exception ex)
            {
                allureInstance.StopStep(step =>
                {
                    step.stage = Stage.finished;
                    step.status = Status.failed;
                    step.statusDetails = GetStatusDetails(ex);
                });
                throw;
            }
        }
    }
}