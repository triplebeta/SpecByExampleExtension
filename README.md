# Extension for testing web applications using Selenium and SpecFlow.

This Visual Studio extension was created to simplify using Selenium with SpecFlow and to get a working setup in under 5 minutes.

The extension containing a Project and Items templates to get started testing websites with Specflow and Selenium in under 5 minutes.

Your will have your first Selenium-based SpecFlow test running in under 5 minutes if you follow just the quick tutorial - no coding required.

It contains a number of components to get you started quickly:

## Getting started

### Prerequisites
Make sure you installed the [SpecFlow extension](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowforVisualStudio2015) since this is a prerequisite for the SpecByExample extension.

[SpecFlow extension image](https://github.com/triplebeta/SpecByExampleExtension/wiki/img/PrerequisiteSpecFlowExtension.png)

In case you want to change the generated code by updating the T4 templates, you may want to install the excellent [T4 Toolbox extension](https://marketplace.visualstudio.com/items?itemName=OlegVSych.T4ToolboxforVisualStudio2013)
of Oleg Sych as well. More information can be found on the [home of T4 Toolbox](http://olegsych.com/T4Toolbox/).

[T4 Toolbox extension image](https://github.com/triplebeta/SpecByExampleExtension/wiki/img/OptionalT4ToolboxExtension.png)


### What's in the extension?
After installing it you will find some extra templates:
- a Project Template to setup the test projects
- an Item Template that allows you to import the web page you want to test
[Item templates](https://github.com/triplebeta/SpecByExampleExtension/wiki/img/SpecByExampleItemTemplates.png)


### How does it work?
The Project Templates creates 3 projects to set the stage.
In the Pages project you can add a new item and choose the template named "SpecByExample Page Adapter". This will show a wizard where you can select the url for your page. In case you just want to test with an example site you can use:
[SpecByExample Sample Website](http://specbyexamplesamplewebsite.azurewebsites.net/)
]http://specbyexamplesamplewebsite.azurewebsites.net/
[Wizard](https://github.com/triplebeta/SpecByExampleExtension/wiki/img/AddPageAdapterWizard.png)

This wizard parses the HTML of the webpage and extracts the containers (divs, spans) and controls (input, button, ...). At completion it will create a .webmodel file in your project containing all of these.
For each control it registers how it can be found in the page, the name of the C# property to generate for it and more details.
Then it registers a custom tool (PageAdapterGenerator) for the webmodel file.

The custom tool uses T4 templates to generate C# code from the webmodel.
It will create a class representing the webpage (GoF Adapter pattern) in which each identified control will appear as a property. Each control propery is typed as one of the Control types such as Button, Link or Listbox.
These control types are adapters for the controls and allow you to easily interact with its underlying HTML element.

Optionally, the custom tool can generate a Steps file for this webmodel, containing Steps like "I click button Login".

### Extensibility
The page adapter and steps classes are defined as partial and can easily be extended.
All code generation can be customized by adding the underlying T4 templates to your solution. To do so, use the template "SpecByExample T4 Templates".

You can also create your own control adapters and automatically use them by adding them to the Control Adapter Mapping Configuration.
Add an item to your Pages project using the template "SpecByExample Control Adapter Mapping Configuration" and add your mapping.


