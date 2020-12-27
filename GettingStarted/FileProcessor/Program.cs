using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace FileProcessor
{
	class Program
	{
		static IFeatureManager FeatureManager;
		static async Task Main(string[] args)
		{
			InitializeFeature();
			WriteLine("File Processor");
			WriteLine("--------------");                      
			
			while (true)
			{
				WriteLine();
				WriteLine("(V)erify only");
				WriteLine("(I)mport into datbase");
				WriteLine("(P)rint");
				if (await FeatureManager.IsEnabledAsync("Convert"))
				{
					WriteLine("(C)onvert");
				}
				WriteLine("(C)onveret");
				WriteLine("(E)xit");

				var input = GetUserInput("Please choose an option and press enter");

				switch (input)
				{
					case "V":
						Verify();
						break;
					case "I":
						Import();
						break;
					case "P":
						Print();
						break;
					case "C":
						if (await FeatureManager.IsEnabledAsync("Convert"))
						{
							Convert();
						}
						break;
					case "E":
						Environment.Exit(0);
						break;
					default:
						WriteLine("Invalid option.");
						break;
				}
			}
		}

		private static void InitializeFeature()
		{
		
			IConfigurationBuilder builder = new ConfigurationBuilder();
			//replace in-memory flag with json file settings

			//builder.AddInMemoryCollection(flags);
			builder.AddJsonFile("appsettings.json");
			IConfigurationRoot configuration = builder.Build();

			//Setup servies (including Feature Management)
			IServiceCollection services = new ServiceCollection();
			services.AddFeatureManagement(configuration);
			IServiceProvider serviceProvider = services.BuildServiceProvider();
			FeatureManager = serviceProvider.GetRequiredService<IFeatureManager>();
		}

		private static void Convert()
		{
			WriteLine("Converting...");
		}

		private static void Verify()
		{
			WriteLine("Verifying...");
		}
		
		private static void Import()
		{
			WriteLine("Importing...");
		}

		private static void Print()
		{
			WriteLine("Printing...");
		}

		private static string GetUserInput(string prompt)
		{
			WriteLine(prompt);
			return ReadLine();
		}        
	}
}
