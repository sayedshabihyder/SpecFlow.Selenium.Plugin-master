﻿Feature: F1

#@Browser:RemoteChrome
#@Browser:Cbt_Win10_Chrome
#@GoogleTranslate:DEe
@Browser:BrowserStack_Win10_Chrome
#@Browser:TestingBot_ElCapitan_Safari
#@Browser:SauceLabs_Win7_Firefox
#@GoogleTranslate:FR
#@GoogleTranslate:DE
@
@Browser:ChromeDebug
@GoogleTranslate:UK
@Authoer:QWE
Scenario Outline: Check website title
	Given I have opened <URL>
	Then the title should contain '<string>'
Examples: 
| URL							| string |
| https://translate.google.com/ | Google |
#| https://translate.google.com | Google |
