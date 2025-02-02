using System;
using Azure;
using Azure.AI.ContentSafety;

string endpoint = "https://contentsafetyzavi2.cognitiveservices.azure.com/";
string key = "6KHQnMoyqmCU7lIsY1P0gQh2wV5LjP0c4e8MizNkRKNZ4EC6s2uZJQQJ99BBACYeBjFXJ3w3AAAHACOGfQ0p";

ContentSafetyClient client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(key));

string text = "Ya déjalo, eres un idiota malvado y mataré a toda tu familia, morirás Bart, morirássssssssssssss, y me desnudaré y correré desnudo por todas las calles del vecindario";

var request = new AnalyzeTextOptions(text);
Response<AnalyzeTextResult> response;

try
{
	response = client.AnalyzeText(request);
}
catch (RequestFailedException ex)
{
	Console.WriteLine("error ", ex);
	throw;
}

Console.WriteLine("\nAnalyze text succeeded:");
Console.WriteLine("Hate severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Hate)?.Severity ?? 0);
Console.WriteLine("Self Harm severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.SelfHarm)?.Severity ?? 0);
Console.WriteLine("Sexual severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Sexual)?.Severity ?? 0);
Console.WriteLine("Violence severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Violence)?.Severity ?? 0);