# test-cleverence
//Использование представленной реализации

// Задача 1 (Compression.cs)

var compressed = Compression.Compress("aaabbcccdde"); // "a3b2c3d2e"

var decompressed = Compression.Decompress("a3b2c3d2e"); // "aaabbcccdde"



// Задача 2 (Server.cs)

var count = Server.GetCount(); // Потокобезопасное чтение

Server.AddToCount(5); // Потокобезопасное добавление



// Задача 3 (LogStandard.cs)

LogStandard.ProcessLogs("input.log", "output.log", "problems.txt");
