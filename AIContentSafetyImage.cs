using System;
using Azure;
using Azure.AI.ContentSafety;

string endpoint = "https://contentsafetyzavi2.cognitiveservices.azure.com/";
string key = "6KHQnMoyqmCU7lIsY1P0gQh2wV5LjP0c4e8MizNkRKNZ4EC6s2uZJQQJ99BBACYeBjFXJ3w3AAAHACOGfQ0p";

ContentSafetyClient client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(key));

string imagePath = @"C:\Users\MSI\source\repos\AiContentSafetyImage\Vietnam.jpg";

ContentSafetyImageData image = new ContentSafetyImageData(BinaryData.FromBytes(File.ReadAllBytes(imagePath)));
var request = new AnalyzeImageOptions(image);
Response<AnalyzeImageResult> response;

try
{
    response = client.AnalyzeImage(request);
}
catch (RequestFailedException ex)
{
    Console.WriteLine("error ", ex);
    throw;
}

Console.WriteLine("\nAnalyze text succeeded:");
Console.WriteLine("Hate severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.Hate)?.Severity ?? 0);
Console.WriteLine("Self Harm severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.SelfHarm)?.Severity ?? 0);
Console.WriteLine("Sexual severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.Sexual)?.Severity ?? 0);
Console.WriteLine("Violence severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.Violence)?.Severity ?? 0);