using SQLite;

namespace AlcoStoper
{
    class Alcohole
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Percent { get; set; }
        public byte[] Image { get; set; }

        public override string ToString()
        {
            return string.Format("[Alcohole: Id={0}, Name={1}, Percent={2}, Image={3}]", Id, Name, Percent, Image);
        }
    }
}