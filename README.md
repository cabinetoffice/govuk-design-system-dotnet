# Gov.UK Design System in C#/ASP.Net Core

This is a collection of [Gov.UK Design System](https://design-system.service.gov.uk) components build in C# / ASP.Net Core.

It's the C# equivalent of the [Gov.UK Prototyping Kit](https://govuk-prototype-kit.herokuapp.com/docs) Nunjucks templates.


#### Warning: work in progress

Warning: This is very much a work in progress!  
Only a subset of the components have been built and there is the possibility of breaking changes as we make bug fixes / add extra features.

Please feel free to use this in your own project.  You can see our [contributing guide here](CONTRIBUTING.md).

If you do, please let us know, so we can avoid making changes that will cause problems for you.  
Email: James Griffiths [james.griffiths@softwire.com](mailto:james.griffiths@softwire.com)


## How to use

This library can be used in two ways:
* View components only
* View components + validation / error message generation

These features are interoperable and you can use as much or as little of them as you like in your project - it's not necessary to migrate totally to using this library.


### View components

e.g. for a Gov.UK Button

On the Design System website:  
https://design-system.service.gov.uk/components/button  
the Nunjucks code would look like this:
```javascript
{% from "govuk/components/button/macro.njk" import govukButton %}

{{ govukButton({
    text: "Save and continue"
}) }}
```

The C# code would look like this:
```csharp
@using GovUkDesignSystem
@using GovUkDesignSystem.GovUkDesignSystemComponents

@(Html.GovUkButton(new ButtonViewModel
{
    Text = "Save and continue"
}))
```

e.g. for a Text Input  
https://design-system.service.gov.uk/components/text-input/  
the C# code would be:

```csharp
@(Html.GovUkTextInput(new TextInputViewModel
{
    Label = new LabelViewModel
    {
        Text = "Your email address"
    },
    Name = "EmailAddress",
    InputMode = "email"
}))
```


### View components + validation / error message generation

Here's an example of how to get automatic error message generation for an integer field.

On your view-model:
* Inherit from `GovUkViewModel`
* Use a nullable integer (`int?`) property
* Add the `GovUkValidateRequired` attribute if you want to validate that the field is required (and to specify the error message if it's missing)
* Add the `GovUkDisplayNameForErrors` attribute for all other error messages of the form `Enter a [Field Name]` and `[Field Name] must be a whole number`

```csharp
public class MyViewModel : GovUkViewModel
{
    [GovUkDisplayNameForErrors(
        NameAtStartOfSentence = "Number of children",
        NameWithinSentence = "number of children"
    )]
    [GovUkValidateRequired(
        ErrorMessageIfMissing = "Enter the number of children you have"
    )]
    public int? NumberOfChildren
}
```

On the view:
```csharp
@using GovUkDesignSystem
@using GovUkDesignSystem.GovUkDesignSystemComponents

@model MyViewModel

@(Html.GovUkErrorSummary())

@(Html.GovUkTextInputFor(
    m => m.NumberOfChildren,
    labelOptions: new LabelViewModel
    {
        Text = "How many children do you have?"
    }
))

```

On the controller:
* Take the view-model as a parameter (optional)
* Call `ParseAndValidateParameters`
* Call `HasAnyErrors`
* Add your own errors with `AddErrorFor`

```csharp
[HttpPost("url-to-action")]
public IActionResult ActionName(MyViewModel viewModel)
{
    // Call ParseAndValidateParameters on each field you need
    viewModel.ParseAndValidateParameters(Request, m => m.NumberOfChildren);

    // Use HasAnyErrors to check if anything failed validation
    if (viewModel.HasAnyErrors())
    {
        return View("ViewName", viewModel);
    }

    //To do mvc data annotation validation
    
    TryValidateModel(viewModel);

    if (!ModelState.IsValid)
    {
        foreach (var modelStateKey in ViewData.ModelState.Keys.Reverse())
        {
            AddressViewModel vm = new AddressViewModel();
            var value = ViewData.ModelState[modelStateKey];

            PropertyInfo property = ParserHelpers.GetPropertyInfoFromPropertyName(viewModel, modelStateKey.Split('.').Last()); 

            foreach (var error in value.Errors)
            { 
                //TODO: Check that error is not already added for the property before adding error 
                ParserHelpers.AddErrorInModel(viewModel, property, error.ErrorMessage); 
                //TODO: Check if the property belongs to a nested class only then execute below line
                ParserHelpers.AddErrorInNested(viewModel, property, error.ErrorMessage);                        
            }
        }
    }

    // You can do your own custom validation...
    if (viewModel.NumberOfChildren > 100)
    {
        //...and add your own error messages like this
        viewModel.AddErrorFor<MyViewModel, int?>(
            m => m.NumberOfChildren,
            "The number of children you say you have is implausible");
    }

    // Then return the user back to the page if there's an error
    if (viewModel.HasAnyErrors())
    {
        return View("ViewName", viewModel);
    }
}
```

C