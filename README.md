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

This library includes a number of validation attributes that can be used alongside the built in MVC validation attributes.
The `GovUkErrorSummary` will display any errors in the model state.

For property types where a badly formed value may make it impossible to bind the submitted value to the model, this library
provides custom model binders that will generate binding failure messages that match the GovUK design system suggested error
messages.

Here's an example of how to get automatic error message generation for a mandatory integer field.

In your application's Startup class add the following to the ConfigureServices method:

```csharp
    services.AddControllersWithViews(options =>
        options.ModelMetadataDetailsProviders.Add(new GovUkDataBindingErrorTextProvider()));
```

On your view-model:
* Use a nullable integer (`int?`) property
* Add the `ModelBinder` attribute with `typeof(GovUkMandatoryIntBinder)`
* Add the `GovUkDataBindingIntErrorText` attribute to specify the text to use within the error messages.

```csharp
public class MyViewModel : GovUkViewModel
{
    [ModelBinder(typeof(GovUkMandatoryIntBinder))]
    [GovUkDataBindingIntErrorText(
        ErrorMessageIfMissing = "Enter the number of children you have",
        NameAtStartOfSentence = "Number of children"
    )]
    public int? NumberOfChildren
}
```

On the view:
```csharp
@using GovUkDesignSystem
@using GovUkDesignSystem.GovUkDesignSystemComponents

@model MyViewModel

@(Html.GovUkErrorSummary(ViewData.ModelState))

@(Html.GovUkTextInputFor(
    m => m.NumberOfChildren,
    labelOptions: new LabelViewModel
    {
        Text = "How many children do you have?"
    }
))

```

On the controller:
* Check `ModelState.IsValid` as normal

```csharp
[HttpPost("url-to-action")]
public IActionResult ActionName(MyViewModel viewModel)
{
    // Return the user back to the page if there's an error
    if (!ModelState.IsValid)
    {
        return View("ViewName", viewModel);
    }
}
```

C