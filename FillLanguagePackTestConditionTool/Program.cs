using Microsoft.VisualBasic.CompilerServices;


string fileToReadFrom =
    @"C:\Users\Public\Documents\smartPerformEducationApp\EducationAppData_2022.1.3\Data\resources\LanguagePackTemplate\smartperformLanguagePack.Template.resx";
string fileToWriteTo =
    @"C:\Users\Public\Documents\smartPerformEducationApp\EducationAppData_2022.1.3\Data\resources\LanguagePacks\TestLanguage\smartPerformLanguagePack.Test.resx";
List<string> resultLines = new List<string>(File.ReadAllLines(fileToReadFrom));

string dataName = "";
string value = "";
List<string> linesToAppend = new List<string>();
List<string> headerLines = resultLines.GetRange(0, 119);

resultLines.RemoveRange(0,119);

File.WriteAllLines(fileToWriteTo, headerLines);

foreach (string line in resultLines)
{
    linesToAppend.Clear();
    if (line.Contains("<data name=\""))
    {
        dataName = line.Substring(14);
        dataName = dataName.Substring(0, dataName.IndexOf('"'));
        value = $"<value>Test_{dataName}_Test</value>";
        linesToAppend.Add(line);
        linesToAppend.Add(value);
        linesToAppend.Add("</data>");
        File.AppendAllLines(fileToWriteTo,linesToAppend);
    }
}

File.AppendAllText(fileToWriteTo,"</root>");