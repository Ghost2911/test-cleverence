# test-cleverence
//Использование представленной реализации

// Задача 1
var compressed = Compression.Compress("aaabbcccdde"); // "a3b2c3d2e"
var decompressed = Compression.Decompress("a3b2c3d2e"); // "aaabbcccdde"

// Задача 2
Server.AddToCount(5); // Потокобезопасное добавление
var count = Server.GetCount(); // Потокобезопасное чтение

// Задача 3
LogStandard.ProcessLogs("input.log", "output.log", "problems.txt");
