using System;
using System.Globalization;
using System.IO;
using System.Text;

public class LogStandard
{
    public static void ProcessLogs(string inputPath, string outputPath, string problemsPath)
    {
        using var reader = new StreamReader(inputPath);
        using var writer = new StreamWriter(outputPath);
        using var problemWriter = new StreamWriter(problemsPath);

        string line;
        while ((line = reader.ReadLine()) != null)
        {
            if (TryParseFormat1(line, out var logEntry) || TryParseFormat2(line, out logEntry))
            {
                writer.WriteLine($"{logEntry.Date}\t{logEntry.Time}\t{logEntry.Level}\t{logEntry.Method}\t{logEntry.Message}");
            }
            else
            {
                problemWriter.WriteLine(line);
            }
        }
    }

    private static bool TryParseFormat1(string line, out LogEntry entry)
    {
        entry = null;
        var parts = line.Split(' ', 4);
        if (parts.Length < 4) return false;

        if (!DateTime.TryParseExact(parts[0], "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            return false;

        entry = new LogEntry
        {
            Date = date.ToString("dd-MM-yyyy"),
            Time = parts[1],
            Level = ConvertLevel(parts[2]),
            Method = "DEFAULT",
            Message = parts[3]
        };
        return true;
    }

    private static bool TryParseFormat2(string line, out LogEntry entry)
    {
        entry = null;
        var parts = line.Split('|');
        if (parts.Length != 5) 
            return false;

        var datetime = parts[0].Split(' ');
        if (datetime.Length != 2) 
            return false;

        if (!DateTime.TryParseExact(datetime[0], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            return false;

        entry = new LogEntry
        {
            Date = date.ToString("dd-MM-yyyy"),
            Time = datetime[1],
            Level = ConvertLevel(parts[1]),
            Method = parts[3],
            Message = parts[4]
        };
        return true;
    }

    private static string ConvertLevel(string level)
    {
        string upperLevel = level.ToUpper();
        switch (upperLevel)
        {
            case "INFORMATION":
                return "INFO";
            case "WARNING":
                return "WARN";
            default:
                return level;
        }
    }

    private class LogEntry
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string Level { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
    }
}