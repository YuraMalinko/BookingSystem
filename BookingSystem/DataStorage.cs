using System.Text.Json;

namespace BookingSystem
{
    public class DataStorage
    {
        public string Path { get; set; }

        public List<Table> Tables { get; set; }

        public List<Reservation> Reservations { get; set; }

        public DataStorage()
        {
            {
                Tables = new List<Table>();
                Reservations = new List<Reservation>();
                Path = @".\DataStorage.txt";
            }
        }

        public void RewriteFile()
        {
            using (StreamWriter file = new StreamWriter(Path))
            {
                string serializedFile;
                serializedFile = JsonSerializer.Serialize(Tables);
                file.WriteLine(serializedFile);
                serializedFile = JsonSerializer.Serialize(Reservations);
                file.Write(serializedFile);
            }
        }

        public void ReturnFromFile()
        {
            if (File.Exists(Path))
            {
                using (StreamReader file = new StreamReader(Path))
                {
                    string jsn = file.ReadLine()!;
                    Tables = JsonSerializer.Deserialize<List<Table>>(jsn)!;
                    jsn = file.ReadLine()!;
                    Reservations = JsonSerializer.Deserialize<List<Reservation>>(jsn)!;
                }
            }
        }
    }
}
