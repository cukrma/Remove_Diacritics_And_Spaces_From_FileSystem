using System.Text;
using System.Text.RegularExpressions;


Console.WriteLine("Zadejte vychozi adresar napr. C:\\my_files\\Skola");
string? path;

while (true)
{
    path = Console.ReadLine();

    if (path != null) { break; }
}

DirectoryInfo d = new DirectoryInfo(@path);


bool notBroke = true;

while (true)
{
    DirectoryInfo[] Directories = d.GetDirectories("*", SearchOption.AllDirectories);

    foreach (DirectoryInfo dir in Directories)
    {
        string oldName = dir.FullName;

        string newName = myReplace(oldName, false);

        if (newName != oldName)
        {
            try
            {
                Directory.Move(oldName, newName);
            }
            catch
            {
                notBroke = true;
                break;
            }
        }
    }

    if (notBroke)
    {
        break;
    }

}


while (true)
{
    FileInfo[] Files = d.GetFiles("*.*", SearchOption.AllDirectories);

    foreach (FileInfo file in Files)
    {
        string oldName = file.FullName;

        string newName = myReplace(oldName, true);

        if (newName != oldName)
        {
            try
            {
                File.Move(oldName, newName);
            }
            catch
            {
                notBroke = true;
                break;
            }
        }
    }

    if (notBroke)
    {
        break;
    }
}




string myReplace(string oldName, bool hasExtension)
{
    StringBuilder sb = new StringBuilder(oldName);

    sb = new StringBuilder(Regex.Replace(sb.ToString(), @"[.][ ]+", "-"));

    if (hasExtension)
    {
        while (CountChars(sb.ToString(), '.') > 1)
        {
            var regex = new Regex(Regex.Escape("."));
            var newText = regex.Replace(sb.ToString(), "-", 1);
            sb = new StringBuilder(newText);
        }
    }
    else
    {
        sb.Replace('.', '-');
    }
    
    sb.Replace(' ', '_');
    sb.Replace(',', '-');
    sb.Replace('ě', 'e');
    sb.Replace('é', 'e');
    sb.Replace('Ě', 'E');
    sb.Replace('É', 'E');
    sb.Replace('š', 's');
    sb.Replace('Š', 'S');
    sb.Replace('č', 'c');
    sb.Replace('Č', 'C');
    sb.Replace('ř', 'r');
    sb.Replace('Ř', 'R');
    sb.Replace('ž', 'z');
    sb.Replace('Ž', 'Z');
    sb.Replace('ý', 'y');
    sb.Replace('Ý', 'Y');
    sb.Replace('á', 'a');
    sb.Replace('Á', 'A');
    sb.Replace('í', 'i');
    sb.Replace('Í', 'I');
    sb.Replace('ó', 'o');
    sb.Replace('Ó', 'O');
    sb.Replace('ť', 't');
    sb.Replace('Ť', 'T');
    sb.Replace('ň', 'n');
    sb.Replace('Ň', 'N');
    sb.Replace('ď', 'd');
    sb.Replace('Ď', 'D');
    sb.Replace('ů', 'u');
    sb.Replace('Ů', 'U');
    sb.Replace('ú', 'u');
    sb.Replace('Ú', 'U');

    return sb.ToString();
}

int CountChars(string s, char t)
{
    int count = 0;
    foreach (char c in s)
        if (c.Equals(t)) count++;
    return count;
}
