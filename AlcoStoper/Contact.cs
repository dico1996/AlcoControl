using SQLite;

namespace AlcoStoper
{
    class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public byte[] Image { get; set; }

        public override string ToString()
        {
            return string.Format("[Contact: Id={0}, Name={1}, Number={2}, Image={3}]", Id, Name, Number, Image);
        }
    }
}