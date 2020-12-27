# MicrosoftFeatureTagging
Microsoft Feature Tagging

Microsoft feature tagging eliminates need for multiple branches and complicated merges. 

### Starter
For an inital setup project please checkout the getstarted branch

In this branch, we have a simple cmd and we added `Microsoft.Featuremanagement` NuGet package

Also, add the Microsoft.Extension.DependencyInjection NuGet package to add dependency injection to your program. 


Inside the `Program` file:
1. add `static IFeatureManager FeatureManager;`
2. add `InitializeFeature();`
```C#
private static void InitializeFeature()
		{
		
			IConfigurationBuilder builder = new ConfigurationBuilder();
			//builder.AddInMemoryCollection(flags);
			builder.AddJsonFile("appsettings.json");
			IConfigurationRoot configuration = builder.Build();

			//Setup servies (including Feature Management)
			IServiceCollection services = new ServiceCollection();
			services.AddFeatureManagement(configuration);
			IServiceProvider serviceProvider = services.BuildServiceProvider();
			FeatureManager = serviceProvider.GetRequiredService<IFeatureManager>();
		}
```


### flaginsettings

Add appsettings.json with following structure:
```json

{
	"FeatureManagement": {
		"Convert": true
	}
}

```

### flagsenum

Add an enum class that would list all the flags. We do this te eliminate "magic strings" that usually cause an error. 

So I take the "Convert" flag and move it as part of the enum

Then I'l go back to my Program class and reference the enum instead of the string. 


