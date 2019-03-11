﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Unickq.SpecFlow.Selenium.Example.Features
{
    using TechTalk.SpecFlow;
    using Unickq.SpecFlow.Selenium;
    using System.Collections.Concurrent;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("F1")]
    [NUnit.Framework.ParallelizableAttribute()]
    public partial class F1Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private UnickqSpecFlowSeleniumGeneratorHelper helper;
        
        private System.Collections.Concurrent.ConcurrentDictionary<string, string> tagsDict;
        
        [NUnit.Framework.OneTimeSetUp()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "F1", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
            helper = new UnickqSpecFlowSeleniumGeneratorHelper(testRunner);
            helper.FeatureSetup();
        }
        
        [NUnit.Framework.OneTimeTearDown()]
        public virtual void FeatureTearDown()
        {
            helper.FeatureTearDown();
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
            tagsDict = new ConcurrentDictionary<string, string>();
            helper.SetUp();
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            helper.TearDown();
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.Add("Driver", helper.Driver);
            foreach (var tag in tagsDict) testRunner.ScenarioContext.Add(tag.Key, tag.Value);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestCaseAttribute("BrowserStack_Win10_Chrome", "https://translate.google.com/", "Google", null, Category="BrowserStack_Win10_Chrome", TestName="CheckWebsiteTitle with BrowserStack_Win10_Chrome and \"https://translate_google_co" +
            "m/\" ,\"Google\"")]
        [NUnit.Framework.TestCaseAttribute("BrowserStack_Win10_Firefox", "https://translate.google.com/", "Google", null, Category="BrowserStack_Win10_Firefox", TestName="CheckWebsiteTitle with BrowserStack_Win10_Firefox and \"https://translate_google_c" +
            "om/\" ,\"Google\"")]
        public virtual void CheckWebsiteTitle(string browser, string uRL, string @string, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Browser:BrowserStack_Win10_Chrome",
                    "Browser:BrowserStack_Win10_Firefox"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check website title", null, @__tags);
            this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
            testRunner.Given(string.Format("I have opened {0}", uRL), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            testRunner.Then(string.Format("the title should contain \'{0}\'", @string), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check website title manual")]
        [NUnit.Framework.CategoryAttribute("Manual")]
        public virtual void CheckWebsiteTitleManual()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check website title manual", null, new string[] {
                        "Manual"});
            this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
            testRunner.Given("I have opened <URL>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            testRunner.Then("the title should contain \'<string>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion