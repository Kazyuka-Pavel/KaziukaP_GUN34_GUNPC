// See https://aka.ms/new-console-template for more information

using System.Xml;
using System.Xml.Serialization;
using ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        var dungeon = new Dungeon();
        dungeon.ShowRooms();
    }

}