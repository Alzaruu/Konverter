using конвертер;

while (Processing.key.Key != ConsoleKey.Escape)
{
    Console.Clear();
    Console.WriteLine("Введите путь к файлу: ");
    Console.WriteLine("-----------------------");
    Console.SetCursorPosition(0, 2);
    Processing.put = Console.ReadLine();
    if (Processing.put.EndsWith("txt"))
    {
        Processing.Deserialtxt();
    }
    if (Processing.put.EndsWith("json"))
    {
        Processing.Deserialjson();
    }
    if (Processing.put.EndsWith("xml"))
    {
        Processing.Deserialxml();
    }
}
