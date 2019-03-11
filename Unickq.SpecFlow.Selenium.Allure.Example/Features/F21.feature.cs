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
    [NUnit.Framework.DescriptionAttribute("f2")]
    [NUnit.Framework.ParallelizableAttribute()]
    public partial class F2Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private UnickqSpecFlowSeleniumGeneratorHelper helper;
        
        private ConcurrentDictionary<string, string> tagsDict;
        
        [NUnit.Framework.OneTimeSetUp()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "f2", "As Dasdsadsa\r\nsadas\r\nasd\r\nsad\r\nsa\r\ndas\r\nd\r\nas", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
            helper = new UnickqSpecFlowSeleniumAllureGeneratorHelper(testRunner);
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
            helper.ClearScenarioContext(testRunner.ScenarioContext, "GoogleTranslate");
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
        
        [NUnit.Framework.TestCaseAttribute("ChromeDebug", "DE", "Gwoogle", null, Category="ChromeDebug,DE", TestName="CheckWebsiteTitle with ChromeDebug,DE and \"Gwoogle\"")]
        [NUnit.Framework.TestCaseAttribute("ChromeDebug", "UA", "Gwoogle", null, Category="ChromeDebug,UA", TestName="CheckWebsiteTitle with ChromeDebug,UA and \"Gwoogle\"")]
        public virtual void CheckWebsiteTitle(string browser, string googletranslate, string @string, string[] exampleTags)
        {
            tagsDict.TryAdd("GoogleTranslate", googletranslate);
            string[] @__tags = new string[] {
                    "Browser:ChromeDebug",
                    "GoogleTranslate:DE",
                    "GoogleTranslate:UA"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check website title", null, @__tags);
            this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
            testRunner.Given("I have opened https://translate.google.com/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            testRunner.Then(string.Format("the title should contain \'{0}\'", @string), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion